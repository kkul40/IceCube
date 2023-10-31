using System;
using UnityEngine;

namespace Cainos.LucidEditor
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = true)]
    public class GUIColorAttribute : Attribute
    {
        public readonly InspectorColor color = InspectorColor.EditorText;
        public readonly Color customColor;
        public readonly bool useCustomColor;

        public GUIColorAttribute()
        {
        }

        public GUIColorAttribute(InspectorColor color)
        {
            this.color = color;
        }

        public GUIColorAttribute(float r, float g, float b)
        {
            useCustomColor = true;
            customColor = new Color(r, g, b);
        }

        public GUIColorAttribute(float r, float g, float b, float a)
        {
            useCustomColor = true;
            customColor = new Color(r, g, b, a);
        }
    }
}