using System;

namespace Cainos.LucidEditor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RequiredAttribute : Attribute
    {
        public readonly string message;

        public RequiredAttribute()
        {
        }

        public RequiredAttribute(string message)
        {
            this.message = message;
        }
    }
}