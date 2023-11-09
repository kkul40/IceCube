using UnityEditor;

namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(HelpBoxAttribute))]
    public class HelpBoxAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var helpBox = (HelpBoxAttribute)attribute;
            EditorGUILayout.HelpBox(helpBox.message, (MessageType)helpBox.type);
        }
    }
}