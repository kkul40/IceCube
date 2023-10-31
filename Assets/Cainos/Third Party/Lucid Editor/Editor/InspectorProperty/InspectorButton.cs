using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Cainos.LucidEditor
{
    public sealed class InspectorButton : InspectorProperty
    {
        private readonly Action action;
        private readonly string label;
        public readonly MethodInfo methodInfo;
        private readonly List<PropertyProcessor> processors = new();
        public readonly InspectorButtonSize size;

        internal InspectorButton(SerializedObject serializedObject, object parentObject, MethodInfo methodInfo,
            InspectorButtonSize size) : base(serializedObject, null, parentObject, methodInfo.Name,
            methodInfo.GetCustomAttributes().ToArray())
        {
            this.methodInfo = methodInfo;
            this.size = size;
            label = methodInfo.Name;

            action = Expression.Lambda<Action>(
                Expression.Call(
                    methodInfo.IsStatic ? null : Expression.Constant(methodInfo.IsStatic ? null : parentObject),
                    methodInfo)
            ).Compile();
        }

        internal InspectorButton(SerializedObject serializedObject, object parentObject, MethodInfo methodInfo,
            string label, InspectorButtonSize size) : base(serializedObject, null, parentObject, methodInfo.Name,
            methodInfo.GetCustomAttributes().ToArray())
        {
            this.methodInfo = methodInfo;
            this.size = size;
            this.label = label;

            action = Expression.Lambda<Action>(
                Expression.Call(methodInfo.IsStatic ? null : Expression.Constant(parentObject), methodInfo)
            ).Compile();
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
        }

        internal override void Reset()
        {
            base.Reset();
            displayName = label;
        }

        internal override void Draw()
        {
            foreach (var processor in processors) processor.OnBeforeDrawProperty();

            if (isHidden) return;

            LucidEditorGUILayout.BeginLayoutIndent(EditorGUI.indentLevel + indent);
            if (!isEditable) EditorGUI.BeginDisabledGroup(true);
            {
                if (GUILayout.Button(hideLabel ? string.Empty : displayName, GUILayout.Height(size.GetHeight())))
                    action.Invoke();
            }
            if (!isEditable) EditorGUI.EndDisabledGroup();
            LucidEditorGUILayout.EndLayoutIndent();

            foreach (var processor in processors) processor.OnAfterDrawProperty();
        }

        internal override void OnBeforeInspectorGUI()
        {
            foreach (var processor in processors) processor.OnBeforeInspectorGUI();
        }

        internal override void OnAfterInspectorGUI()
        {
            foreach (var processor in processors) processor.OnAfterInspectorGUI();
        }
    }
}