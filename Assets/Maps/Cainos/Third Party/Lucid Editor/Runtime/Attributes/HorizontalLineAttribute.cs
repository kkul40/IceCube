using System;
using UnityEngine;

namespace Cainos.LucidEditor
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = true)]
    public class HorizontalLineAttribute : Attribute
    {
        public readonly InspectorColor color = InspectorColor.EditorLine;
        public readonly Color customColor;
        public readonly bool useCustomColor;

        public HorizontalLineAttribute()
        {
        }

        public HorizontalLineAttribute(InspectorColor color)
        {
            this.color = color;
        }

        public HorizontalLineAttribute(float r, float g, float b)
        {
            useCustomColor = true;
            customColor = new Color(r, g, b);
        }

        public HorizontalLineAttribute(float r, float g, float b, float a)
        {
            useCustomColor = true;
            customColor = new Color(r, g, b, a);
        }
    }
}