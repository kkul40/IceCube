namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(PropertyOrderAttribute))]
    public class PropertyOrderAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeInspectorGUI()
        {
            var propertyOrder = (PropertyOrderAttribute)attribute;
            property.order = propertyOrder.propertyOrder;
        }
    }
}