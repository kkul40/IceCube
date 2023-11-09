using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Cainos.LucidEditor
{
    public static class LucidEditorUtility
    {
        private static readonly Stack<int> indentStack = new();
        private static readonly Stack<Color> guiColorStack = new();

        internal static int horizontalGroupCount;

        public static float singleIndentWidth { get; set; } = 15f;

        public static float currentIndentWidth => EditorGUI.indentLevel * singleIndentWidth;

        public static void PushIndentLevel(int indentLevel)
        {
            indentStack.Push(EditorGUI.indentLevel);
            EditorGUI.indentLevel = indentLevel;
        }

        public static void PopIndentLevel()
        {
            EditorGUI.indentLevel = indentStack.Pop();
        }

        public static void PushGUIColor(Color color)
        {
            guiColorStack.Push(GUI.color);
            GUI.color = color;
        }

        public static void PopGUIColor()
        {
            GUI.color = guiColorStack.Pop();
        }
    }
}