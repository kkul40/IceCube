using System;
using UnityEditor;

namespace Cainos.LucidEditor
{
    public abstract class InspectorProperty
    {
        public readonly Attribute[] attributes;
        public readonly string name;
        public readonly object parentObject;
        public readonly SerializedObject serializedObject;
        public readonly SerializedProperty serializedProperty;
        public readonly Type type;

        internal bool _changed;
        internal bool _isInGroup;
        public bool allowSceneObject = true;
        public string displayName;
        public bool hideLabel;
        public int indent;
        public bool isEditable = true;
        public bool isHidden;

        public int order;

        internal InspectorProperty(SerializedObject serializedObject, SerializedProperty serializedProperty,
            object parentObject, string name, Attribute[] attributes)
        {
            this.serializedObject = serializedObject;
            if (serializedProperty != null)
            {
                this.serializedProperty = serializedProperty.Copy();
                type = serializedProperty.GetUnderlyingType();
            }

            this.parentObject = parentObject;
            displayName = name;
            this.name = name;
            this.attributes = attributes;
        }

        public bool isInGroup => _isInGroup;
        public bool changed => _changed;

        public TAttribute GetAttribute<TAttribute>() where TAttribute : Attribute
        {
            foreach (var att in attributes)
                if (att is TAttribute)
                    return (TAttribute)att;
            return null;
        }

        public bool TryGetAttribute<TAttribute>(out TAttribute result) where TAttribute : Attribute
        {
            foreach (var att in attributes)
                if (att is TAttribute)
                {
                    result = (TAttribute)att;
                    return true;
                }

            result = null;
            return false;
        }

        internal abstract void Initialize();
        internal abstract void OnBeforeInspectorGUI();
        internal abstract void OnAfterInspectorGUI();
        internal abstract void Draw();

        internal virtual void Reset()
        {
            order = 0;
            isHidden = false;
            isEditable = true;
            hideLabel = false;
            indent = 0;
            displayName = string.Empty;
            allowSceneObject = true;
            _changed = false;
        }
    }
}