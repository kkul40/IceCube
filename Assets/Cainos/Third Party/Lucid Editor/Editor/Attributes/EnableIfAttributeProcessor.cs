namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(EnableIfAttribute))]
    public class EnableIfAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var enableIf = (EnableIfAttribute)attribute;
            property.isEditable = ReflectionUtil.GetValueBool(property.parentObject, enableIf.condition);
        }
    }
}