using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Cainos.LucidEditor
{
    public class InspectorField : InspectorProperty
    {
        private readonly List<PropertyProcessor> processors = new();
        private InspectorProperty[] _childProperties;

        internal InspectorField(SerializedProperty property, Attribute[] attributes) : base(property.serializedObject,
            property, property.GetParentObject(), property.name, attributes)
        {
            displayName = property.displayName;
            InitializeChildProperties();
        }

        public IReadOnlyList<InspectorProperty> childProperties => Array.AsReadOnly(_childProperties);

        public bool hasChildren => _childProperties != null && _childProperties.Length > 0;

        public bool IsManagedReference => serializedProperty.propertyType == SerializedPropertyType.ManagedReference;

        public bool IsObjectReference => serializedProperty.propertyType == SerializedPropertyType.ObjectReference;

        internal void InitializeChildProperties()
        {
            _childProperties = InspectorPropertyUtil.GroupProperties(InspectorPropertyUtil.CreateChildProperties(this))
                .ToArray();
        }

        internal override void Initialize()
        {
            processors.Clear();
            foreach (var attribute in attributes)
            {
                var processor = ProcessorUtil.CreateAttributeProcessor(this, attribute);

                if (processor != null)
                {
                    processor.Initialize();
                    processors.Add(processor);
                }
            }

            foreach (var child in _childProperties) child.Initialize();
        }

        internal override void OnBeforeInspectorGUI()
        {
            foreach (var processor in processors) processor.OnBeforeInspectorGUI();
            foreach (var child in _childProperties) child.OnBeforeInspectorGUI();
        }

        internal override void OnAfterInspectorGUI()
        {
            foreach (var processor in processors) processor.OnAfterInspectorGUI();
            foreach (var child in _childProperties) child.OnAfterInspectorGUI();
        }

        internal override void Reset()
        {
            base.Reset();
            displayName = serializedProperty.displayName;
            foreach (var property in _childProperties) property.Reset();
        }

        internal override void Draw()
        {
            foreach (var processor in processors) processor.OnBeforeDrawProperty();

            if (isHidden) return;

            using (var changeScope = new EditorGUI.ChangeCheckScope())
            {
                if (!isEditable) EditorGUI.BeginDisabledGroup(true);
                {
                    LucidEditorUtility.PushIndentLevel(EditorGUI.indentLevel + indent);
                    var foldoutRect = Rect.zero;

                    if (IsManagedReference)
                    {
                        foldoutRect = EditorGUILayout.GetControlRect();
                        DrawSerializeReferenceField(foldoutRect, this);

                        if (!hasChildren)
                        {
                            serializedProperty.isExpanded = EditorGUI.Foldout(foldoutRect,
                                serializedProperty.isExpanded, displayName, true, EditorStyles.foldoutHeader);
                            if (serializedProperty.isExpanded)
                                using (new EditorGUI.IndentLevelScope())
                                {
                                    EditorGUILayout.HelpBox("No type assigned.", MessageType.Info);
                                }
                        }
                    }

                    if (hasChildren)
                    {
                        if (!IsManagedReference) foldoutRect = EditorGUILayout.GetControlRect();

                        if (_isInGroup)
                            using (new EditorGUI.IndentLevelScope())
                            {
                                foldoutRect.xMin -= 4f;
                                serializedProperty.isExpanded = EditorGUI.Foldout(foldoutRect,
                                    serializedProperty.isExpanded, displayName, true, EditorStyles.foldoutHeader);
                            }
                        else
                            serializedProperty.isExpanded = EditorGUI.Foldout(foldoutRect,
                                serializedProperty.isExpanded, displayName, true, EditorStyles.foldoutHeader);

                        if (serializedProperty.isExpanded)
                            using (new EditorGUI.IndentLevelScope())
                            {
                                foreach (var child in childProperties.OrderBy(x => x.order)) child.Draw();
                            }
                    }
                    else if (!IsManagedReference)
                    {
                        if (_isInGroup && serializedProperty.isArray &&
                            serializedProperty.propertyType != SerializedPropertyType.String) EditorGUI.indentLevel++;

                        GUIContent label;
                        if (hideLabel)
                            label = GUIContent.none;
                        else
                            label = new GUIContent(displayName);

                        if (LucidEditorUtility.horizontalGroupCount > 0 &&
                            serializedProperty.propertyType != SerializedPropertyType.Generic)
                            using (new EditorGUILayout.HorizontalScope())
                            {
                                GUILayout.Label(label, GUILayout.MinWidth(50f));
                                EditorGUILayout.PropertyField(serializedProperty, GUIContent.none, true,
                                    GUILayout.MinWidth(0));
                            }
                        else
                            EditorGUILayout.PropertyField(serializedProperty, label, true, GUILayout.MinWidth(0));
                    }

                    LucidEditorUtility.PopIndentLevel();
                }
                if (!isEditable) EditorGUI.EndDisabledGroup();

                _changed = changeScope.changed;
                if (_changed) serializedObject.ApplyModifiedProperties();
            }

            foreach (var processor in processors) processor.OnAfterDrawProperty();
        }

        private void DrawSerializeReferenceField(Rect position, InspectorField property)
        {
            var maxTypePopupLineCount = 13;

            position.height = EditorGUIUtility.singleLineHeight;
            position.xMin += EditorGUIUtility.labelWidth;

            var buttonLabel = EditorIcons.CsScriptIcon;
            buttonLabel.text = (property.serializedProperty.managedReferenceValue == null
                                   ? "Null"
                                   : property.serializedProperty.managedReferenceValue.GetType().Name) +
                               $" ({GetManagedReferenceFieldTypeName(property.serializedProperty)})";

            if (GUI.Button(position, buttonLabel, EditorStyles.objectField))
            {
                var baseType = GetManagedReferenceFieldType(property.serializedProperty);
                var dropdown = new SerializeReferenceDropdown(
                    TypeCache.GetTypesDerivedFrom(baseType).Append(baseType).Where(p =>
                        (p.IsPublic || p.IsNestedPublic) &&
                        !p.IsAbstract &&
                        !p.IsGenericType &&
                        !typeof(Object).IsAssignableFrom(p) &&
                        Attribute.IsDefined(p, typeof(SerializableAttribute))
                    ),
                    maxTypePopupLineCount,
                    new AdvancedDropdownState()
                );
                dropdown.onItemSelected += item =>
                {
                    var type = item.type;
                    var obj = property.serializedProperty.SetManagedReferenceType(type);
                    property.serializedProperty.isExpanded = true;
                    property.serializedProperty.serializedObject.ApplyModifiedProperties();
                    property.serializedProperty.serializedObject.Update();

                    property.InitializeChildProperties();
                };

                dropdown.Show(position);
            }
        }

        private string GetManagedReferenceFieldTypeName(SerializedProperty property)
        {
            var typeName = property.managedReferenceFieldTypename;
            var splitIndex = typeName.IndexOf(' ');
            return typeName.Substring(splitIndex + 1);
        }

        private Type GetManagedReferenceFieldType(SerializedProperty property)
        {
            var typeName = property.managedReferenceFieldTypename;
            var splitIndex = typeName.IndexOf(' ');
            var assembly = Assembly.Load(typeName.Substring(0, splitIndex));
            return assembly.GetType(typeName.Substring(splitIndex + 1));
        }
    }
}