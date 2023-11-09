using System.Collections.Generic;
using UnityEngine;

namespace Cainos.LucidEditor.Experimental
{
    public sealed class Toolbar
    {
        private readonly List<GUIContent> _items = new();

        public int selected;
        public GUI.ToolbarButtonSize size = GUI.ToolbarButtonSize.FitToContents;
        public GUIStyle style = null;
        public IReadOnlyList<GUIContent> items => _items;

        public void AddItem(string item)
        {
            _items.Add(new GUIContent(item));
        }

        public void AddItem(GUIContent item)
        {
            _items.Add(item);
        }

        public bool RemoveItem(string item)
        {
            return _items.RemoveAll(x => x.text == item) > 0;
        }

        public bool RemoveItem(GUIContent item)
        {
            return _items.Remove(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public int Show(Rect rect)
        {
            return Show(rect, selected);
        }

        private int Show(Rect rect, int selected)
        {
            this.selected = GUI.Toolbar(rect, selected, _items.ToArray(), style == null ? GUI.skin.button : style,
                size);
            return this.selected;
        }

        public int ShowLayout(params GUILayoutOption[] options)
        {
            return ShowLayout(selected, options);
        }

        private int ShowLayout(int selected, params GUILayoutOption[] options)
        {
            this.selected = GUILayout.Toolbar(selected, _items.ToArray(), style == null ? GUI.skin.button : style, size,
                options);
            return this.selected;
        }
    }
}