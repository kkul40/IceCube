namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(ShowIfAttribute))]
    public class ShowIfAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var showIf = (ShowIfAttribute)attribute;
            property.isHidden |= !ReflectionUtil.GetValueBool(property.parentObject, showIf.condition);
        }
    }
}