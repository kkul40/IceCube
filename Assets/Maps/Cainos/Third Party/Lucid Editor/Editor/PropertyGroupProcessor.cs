using System;
using UnityEditor;

namespace Cainos.LucidEditor
{
    public abstract class PropertyGroupProcessor
    {
        internal PropertyGroupAttribute _attribute;
        internal InspectorPropertyGroup _group;

        internal SerializedObject serializedObject;
        public PropertyGroupAttribute attribute => _attribute;

        public InspectorPropertyGroup group => _group;

        public LocalPersistentData<T> GetLocalPersistentData<T>(string id)
        {
            return LucidEditorPrefs.CreateLocalPersistentData<T>
            (
                "LucidEditor_PropertyGroupProcessor_" +
                GlobalObjectId.GetGlobalObjectIdSlow(serializedObject.targetObject) + "_" +
                attribute.GetType().Name + "_" +
                attribute.path + "_" +
                id
            );
        }

        public virtual void Initialize()
        {
        }

        public virtual void BeginPropertyGroup()
        {
        }

        public virtual void EndPropertyGroup()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CustomGroupProcessorAttribute : Attribute
    {
        public readonly Type type;

        public CustomGroupProcessorAttribute(Type type)
        {
            this.type = type;
        }
    }
}