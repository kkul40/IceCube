namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(IndentAttribute))]
    public class IndentAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var indent = (IndentAttribute)attribute;
            property.indent = indent.indent;
        }
    }
}