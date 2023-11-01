using System;
using System.Linq;

namespace Cainos.LucidEditor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PropertyGroupAttribute : Attribute
    {
        public readonly int groupDepth;
        public readonly string name;
        public readonly string path;

        public PropertyGroupAttribute(string groupPath)
        {
            path = groupPath;
            name = path.Split('/').Last();
            groupDepth = path.Count(x => x == '/');
        }
    }
}