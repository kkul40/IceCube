using UnityEngine;

namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(DisableInEditModeAttribute))]
    public class DisableInEditModeAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            var disableInEditMode = (DisableInEditModeAttribute)attribute;
            property.isEditable = Application.isPlaying;
        }
    }
}