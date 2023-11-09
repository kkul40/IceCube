using UnityEditor;

namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(BlockquoteAttribute))]
    public class BlockquoteAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var blockquote = (BlockquoteAttribute)attribute;
            var style = EditorStyles.label;
            style.wordWrap = true;

            LucidEditorGUILayout.Blockquote(blockquote.text);
        }
    }
}