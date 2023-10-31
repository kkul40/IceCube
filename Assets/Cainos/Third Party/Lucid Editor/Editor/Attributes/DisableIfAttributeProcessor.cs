namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(DisableIfAttribute))]
    public class DisableIfAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var disableIf = (DisableIfAttribute)attribute;
            property.isEditable = !ReflectionUtil.GetValueBool(property.parentObject, disableIf.condition);
        }
    }
}