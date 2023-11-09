namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(HideIfAttribute))]
    public class HideIfAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var hideIf = (HideIfAttribute)attribute;
            property.isHidden |= ReflectionUtil.GetValueBool(property.parentObject, hideIf.condition);
        }
    }
}