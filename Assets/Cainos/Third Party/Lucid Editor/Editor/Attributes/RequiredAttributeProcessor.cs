using UnityEditor;

namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(RequiredAttribute))]
    public class RequiredAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var required = (RequiredAttribute)attribute;

            if (property.serializedProperty.propertyType == SerializedPropertyType.ObjectReference &&
                property.serializedProperty.objectReferenceValue == null)
                EditorGUILayout.HelpBox(
                    required.message == null ? $"{property.displayName} is required." : required.message,
                    MessageType.Error);
        }
    }
}