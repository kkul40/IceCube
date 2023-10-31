using UnityEditor;
using UnityEngine;

namespace Cainos.LucidEditor
{
    public static class EditorColors
    {
        public static Color background
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.219f, 0.219f, 0.219f);
                return new Color(0.784f, 0.784f, 0.784f);
            }
        }

        public static Color field
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.165f, 0.165f, 0.165f);
                return new Color(0.941f, 0.941f, 0.941f);
            }
        }

        public static Color tab
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.235f, 0.235f, 0.235f);
                return new Color(0.8f, 0.8f, 0.8f);
            }
        }

        public static Color text
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.725f, 0.725f, 0.725f);
                return new Color(0.141f, 0.141f, 0.141f);
            }
        }

        public static Color textSelected
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.486f, 0.675f, 0.945f);
                return new Color(0.05f, 0.275f, 0.552f);
            }
        }

        public static Color line
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.1f, 0.1f, 0.1f);
                return new Color(0.5f, 0.5f, 0.5f);
            }
        }

        public static Color thinLine
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.188f, 0.188f, 0.188f);
                return new Color(0.73f, 0.73f, 0.73f);
            }
        }

        public static Color button
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.345f, 0.345f, 0.345f);
                return new Color(0.894f, 0.894f, 0.894f);
            }
        }

        public static Color buttonSelected
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.27f, 0.376f, 0.49f);
                return new Color(0.549f, 0.725f, 0.752f);
            }
        }

        public static Color box
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.27f, 0.27f, 0.27f);
                return new Color(0.73f, 0.73f, 0.73f);
            }
        }

        public static Color helpBox
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.25f, 0.25f, 0.25f);
                return new Color(0.81f, 0.81f, 0.81f);
            }
        }

        public static Color warning
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(1f, 0.755f, 0.035f);
                return new Color(0.788f, 0.592f, 0f);
            }
        }

        public static Color error
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(1f, 0.431f, 0.247f);
                return new Color(0.695f, 0.040f, 0.053f);
            }
        }
    }
}