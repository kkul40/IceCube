using System;

namespace Cainos.LucidEditor
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class HideIfAttribute : Attribute
    {
        public readonly string condition;

        public HideIfAttribute(string condition)
        {
            this.condition = condition;
        }
    }
}