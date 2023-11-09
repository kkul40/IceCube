using System;

namespace Cainos.LucidEditor
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AssetsOnlyAttribute : Attribute
    {
    }
}