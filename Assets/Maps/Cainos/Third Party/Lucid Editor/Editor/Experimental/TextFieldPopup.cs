using System;
using UnityEditor;
using UnityEngine;

namespace Cainos.LucidEditor.Experimental
{
    public class TextFieldPopup : PopupWindowContent
    {
        private bool didFocus;
        private bool initialized;
        public Action onCancel;
        public Action onSubmit;

        public Action<string> onValueChanged;

        private Rect size;

        private bool submit;
        public string text;

        public void Show(Rect position)
        {
            size = position;
            size.height = EditorGUIUtility.singleLineHeight;
            PopupWindow.Show(position, this);
        }

        public override void OnGUI(Rect rect)
        {
            if (!initialized)
            {
                initialized = true;
                onValueChanged?.Invoke(text);
            }

            if (LucidGUIEvent.GetKeyDown(KeyCode.Return))
            {
                submit = true;
                editorWindow.Close();
            }

            var textFieldName = $"{GetType().Name}:{nameof(text)}";
            using (var scope = new EditorGUI.ChangeCheckScope())
            {
                GUI.SetNextControlName(textFieldName);
                var fieldRect = EditorGUILayout.GetControlRect();
                fieldRect.xMin -= 2.7f;
                fieldRect.xMax += 2.7f;
                fieldRect.yMin -= 2.7f;
                fieldRect.yMax += 2.7f;
                text = EditorGUI.TextField(fieldRect, text);
                if (scope.changed) onValueChanged?.Invoke(text);
            }

            if (!didFocus)
            {
                GUI.FocusControl(textFieldName);
                didFocus = true;
            }
        }

        public override Vector2 GetWindowSize()
        {
            return new Vector2(size.width, EditorGUIUtility.singleLineHeight);
        }

        public override void OnClose()
        {
            base.OnClose();
            if (submit) onSubmit?.Invoke();
            else onCancel?.Invoke();
        }
    }
}