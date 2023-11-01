using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Cainos.LucidEditor
{
    [CustomGroupProcessor(typeof(TabGroupAttribute))]
    public class TabGroupAttributeProcessor : PropertyGroupProcessor
    {
        private LocalPersistentData<int> selected;
        private string[] tabArray;

        public override void Initialize()
        {
            selected = GetLocalPersistentData<int>("selected");

            var tabList = new List<string>();
            foreach (var property in group.childProperties)
            {
                var att = property.GetAttribute<TabGroupAttribute>();
                if (!tabList.Contains(att.tabName)) tabList.Add(att.tabName);
            }

            tabArray = tabList.ToArray();
        }

        public override void BeginPropertyGroup()
        {
            LucidEditorGUILayout.BeginLayoutIndent(EditorGUI.indentLevel);
            selected.Value = LucidEditorGUILayout.BeginTabGroup(selected.Value, tabArray, GUILayout.MinWidth(0));

            foreach (var property in group.childProperties)
            {
                var att = property.GetAttribute<TabGroupAttribute>();
                if (att != null) property.isHidden |= att.tabName != tabArray[selected.Value];
            }
        }

        public override void EndPropertyGroup()
        {
            LucidEditorGUILayout.EndFoldoutGroup();
            LucidEditorGUILayout.EndLayoutIndent();

            EditorGUILayout.Space(2);
        }
    }
}