using System.Linq;
using UnityEditor;

namespace Cainos.LucidEditor
{
    public class LucidEditor : Editor
    {
        internal bool hideMonoScript;

        private InspectorProperty[] properties;
        //internal bool disableEditor;

        protected virtual void OnEnable()
        {
            hideMonoScript = target.GetType().IsDefined(typeof(HideMonoScriptAttribute), true);
            //disableEditor = target.GetType().IsDefined(typeof(DisableLucidEditorAttribute), true);
        }

        public override void OnInspectorGUI()
        {
            //if (disableEditor)
            //{
            //    base.OnInspectorGUI();
            //    return;
            //}

            serializedObject.Update();
            if (properties == null) InitializeProperties();
            ResetProperties();

            OnBeforeInspectorGUI();

            if (!hideMonoScript) LucidEditorGUILayout.ScriptField(target);
            DrawAllProperties();

            OnAfterInspectorGUI();

            serializedObject.ApplyModifiedProperties();
        }

        private void InitializeProperties()
        {
            properties = InspectorPropertyUtil.GroupProperties(InspectorPropertyUtil.CreateProperties(serializedObject))
                .ToArray();
            foreach (var property in properties) property.Initialize();
        }

        private void ResetProperties()
        {
            foreach (var property in properties) property.Reset();
        }

        private void DrawAllProperties()
        {
            foreach (var property in properties.OrderBy(x => x.order)) property.Draw();
        }

        private void OnBeforeInspectorGUI()
        {
            foreach (var property in properties.OrderBy(x => x.order)) property.OnBeforeInspectorGUI();
        }

        private void OnAfterInspectorGUI()
        {
            foreach (var property in properties.OrderBy(x => x.order)) property.OnAfterInspectorGUI();
        }
    }

    //[CanEditMultipleObjects]
    //[CustomEditor(typeof(MonoBehaviour), true)]
    //internal class MonoBehaviourEditor : LucidEditor { }

    //[CanEditMultipleObjects]
    //[CustomEditor(typeof(ScriptableObject), true)]
    //internal class ScriptableObjectEditor : LucidEditor { }
}