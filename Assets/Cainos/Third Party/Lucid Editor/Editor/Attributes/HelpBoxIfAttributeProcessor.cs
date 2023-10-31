using UnityEditor;

namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(HelpBoxIfAttribute))]
    public class HelpBoxIfAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var helpBoxIf = (HelpBoxIfAttribute)attribute;
            if (ReflectionUtil.GetValueBool(property.parentObject, helpBoxIf.condition))
                EditorGUILayout.HelpBox(helpBoxIf.message, (MessageType)helpBoxIf.type);
        }
    }
}