using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Cainos.LucidEditor
{
    public sealed class InspectorPropertyGroup : InspectorProperty
    {
        private readonly List<InspectorProperty> _childProperties = new();
        public readonly int groupDepth;

        public readonly string path;
        private readonly PropertyGroupProcessor processor;

        public bool isExpanded = true;

        internal InspectorPropertyGroup(string path, SerializedObject serializedObject,
            PropertyGroupAttribute attribute) : base(serializedObject, null, null, path.Split('/').Last(),
            new[] { attribute })
        {
            this.path = path;
            groupDepth = path.Split('/').Count();
            processor = ProcessorUtil.CreateGroupProcessor(this, serializedObject, attribute);
            displayName = name;
        }

        public IReadOnlyList<InspectorProperty> childProperties => _childProperties.AsReadOnly();

        internal void Add(InspectorProperty item)
        {
            item._isInGroup = true;
            if (!_childProperties.Contains(item)) _childProperties.Add(item);
        }

        internal override void Draw()
        {
            processor?.BeginPropertyGroup();

            if (isHidden) return;

            if (!isEditable) EditorGUI.BeginDisabledGroup(true);
            if (indent > 0) LucidEditorGUILayout.BeginLayoutIndent(indent);
            {
                if (isExpanded)
                    foreach (var property in childProperties.OrderBy(x => x.order))
                        property.Draw();
            }
            if (indent > 0) LucidEditorGUILayout.EndLayoutIndent();
            if (!isEditable) EditorGUI.EndDisabledGroup();

            processor?.EndPropertyGroup();
        }

        internal override void Initialize()
        {
            processor?.Initialize();
            foreach (var property in childProperties.OrderBy(x => x.order)) property.Initialize();
        }

        internal override void Reset()
        {
            base.Reset();
            foreach (var property in _childProperties) property.Reset();
        }

        internal override void OnBeforeInspectorGUI()
        {
            foreach (var property in childProperties) property.OnBeforeInspectorGUI();
        }

        internal override void OnAfterInspectorGUI()
        {
            foreach (var property in childProperties) property.OnAfterInspectorGUI();
        }
    }
}