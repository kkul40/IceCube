using System;

namespace Cainos.LucidEditor
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class LabelTextAttribute : Attribute
    {
        public readonly string label;

        public LabelTextAttribute(string label)
        {
            this.label = label;
        }
    }
}