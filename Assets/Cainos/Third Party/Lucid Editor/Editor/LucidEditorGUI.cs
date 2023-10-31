using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;

namespace Cainos.LucidEditor
{
    public static class LucidEditorGUI
    {
        public static T Field<T>(Rect position, T value)
        {
            return Field(position, GUIContent.none, value);
        }

        public static T Field<T>(Rect position, string label, T value)
        {
            return Field(position, new GUIContent(label), value);
        }

        public static T Field<T>(Rect position, GUIContent label, T value)
        {
            switch (value)
            {
                case int intValue:
                    return GenericTypeConverter<T>.Convert(IntField(position, label, intValue));
                case long longValue:
                    return GenericTypeConverter<T>.Convert(LongField(position, label, longValue));
                case float floatValue:
                    return GenericTypeConverter<T>.Convert(FloatField(position, label, floatValue));
                case double doubleValue:
                    return GenericTypeConverter<T>.Convert(DoubleField(position, label, doubleValue));
                case bool boolValue:
                    return GenericTypeConverter<T>.Convert(Toggle(position, label, boolValue));
                case string stringValue:
                    return GenericTypeConverter<T>.Convert(TextField(position, label, stringValue));
                case Vector2Int vector2IntValue:
                    return GenericTypeConverter<T>.Convert(Vector2IntField(position, label, vector2IntValue));
                case Vector2 vector2Value:
                    return GenericTypeConverter<T>.Convert(Vector2Field(position, label, vector2Value));
                case Vector3Int vector3IntValue:
                    return GenericTypeConverter<T>.Convert(Vector3IntField(position, label, vector3IntValue));
                case Vector3 vector3Value:
                    return GenericTypeConverter<T>.Convert(Vector3Field(position, label, vector3Value));
                case Vector4 vector4Value:
                    return GenericTypeConverter<T>.Convert<Vector3>(Vector4Field(position, label, vector4Value));
                case RectInt rectIntValue:
                    return GenericTypeConverter<T>.Convert(RectIntField(position, label, rectIntValue));
                case Rect rectValue:
                    return GenericTypeConverter<T>.Convert(RectField(position, label, rectValue));
                case BoundsInt boundsIntValue:
                    return GenericTypeConverter<T>.Convert(BoundsIntField(position, label, boundsIntValue));
                case Bounds boundsValue:
                    return GenericTypeConverter<T>.Convert(BoundsField(position, label, boundsValue));
                case Color colorValue:
                    return GenericTypeConverter<T>.Convert(ColorField(position, label, colorValue));
                case Gradient gradientValue:
                    return GenericTypeConverter<T>.Convert(GradientField(position, label, gradientValue));
                case Enum enumValue:
                    return GenericTypeConverter<T>.Convert(EnumPopup(position, label, enumValue));
                case AnimationCurve animationCurveValue:
                    return GenericTypeConverter<T>.Convert(CurveField(position, label, animationCurveValue));
                case Object objectValue:
                    return GenericTypeConverter<T>.Convert(ObjectField(position, label, objectValue,
                        objectValue.GetType(), true));
            }

            throw new ArgumentException($"Unsupported field type: {typeof(T).Name}");
        }

        public static void ReadOnlyField<T>(Rect position, T value)
        {
            EditorGUI.BeginDisabledGroup(true);
            Field(position, GUIContent.none, value);
            EditorGUI.BeginDisabledGroup(false);
        }

        public static void ReadOnlyField<T>(Rect position, string label, T value)
        {
            EditorGUI.BeginDisabledGroup(true);
            Field(position, new GUIContent(label), value);
            EditorGUI.BeginDisabledGroup(false);
        }

        public static void ReadOnlyField<T>(Rect position, GUIContent label, T value)
        {
            EditorGUI.BeginDisabledGroup(true);
            Field(position, label, value);
            EditorGUI.BeginDisabledGroup(false);
        }

        public static object Field(Rect position, object value, Type objType)
        {
            return Field(position, GUIContent.none, value, objType);
        }

        public static object Field(Rect position, string label, object value, Type objType)
        {
            return Field(position, new GUIContent(label), value, objType);
        }

        public static object Field(Rect position, GUIContent label, object value, Type objType)
        {
            switch (objType)
            {
                case Type t when t == typeof(int):
                    return IntField(position, label, (int)value);
                case Type t when t == typeof(long):
                    return LongField(position, label, (long)value);
                case Type t when t == typeof(float):
                    return FloatField(position, label, (float)value);
                case Type t when t == typeof(double):
                    return DoubleField(position, label, (double)value);
                case Type t when t == typeof(bool):
                    return Toggle(position, label, (bool)value);
                case Type t when t == typeof(string):
                    return TextField(position, label, (string)value);
                case Type t when t == typeof(Vector2Int):
                    return Vector2IntField(position, label, (Vector2Int)value);
                case Type t when t == typeof(Vector2):
                    return Vector2Field(position, label, (Vector2)value);
                case Type t when t == typeof(Vector3Int):
                    return Vector3IntField(position, label, (Vector3Int)value);
                case Type t when t == typeof(Vector3):
                    return Vector3Field(position, label, (Vector3)value);
                case Type t when t == typeof(Vector4):
                    return Vector4Field(position, label, (Vector4)value);
                case Type t when t == typeof(RectInt):
                    return RectIntField(position, label, (RectInt)value);
                case Type t when t == typeof(Rect):
                    return RectField(position, label, (Rect)value);
                case Type t when t == typeof(BoundsInt):
                    return BoundsIntField(position, label, (BoundsInt)value);
                case Type t when t == typeof(Bounds):
                    return BoundsField(position, label, (Bounds)value);
                case Type t when t == typeof(Color):
                    return ColorField(position, label, (Color)value);
                case Type t when t == typeof(Gradient):
                    return GradientField(position, label, (Gradient)value);
                case Type t when t == typeof(Enum):
                    return EnumPopup(position, label, (Enum)value);
                case Type t when t == typeof(AnimationCurve):
                    return CurveField(position, label, (AnimationCurve)value);
                case Type t when t == typeof(Object):
                    return ObjectField(position, label, (Object)value, objType, true);
            }

            throw new ArgumentException($"Unsupported field type: {objType.Name}");
        }

        public static void ReadOnlyField(Rect position, object value, Type objType)
        {
            ReadOnlyField(position, GUIContent.none, value, objType);
        }

        public static void ReadOnlyField(Rect position, string label, object value, Type objType)
        {
            ReadOnlyField(position, new GUIContent(label), value, objType);
        }

        public static void ReadOnlyField(Rect position, GUIContent label, object value, Type objType)
        {
            EditorGUI.BeginDisabledGroup(true);
            switch (objType)
            {
                case Type t when t == typeof(int):
                    IntField(position, label, (int)value);
                    break;
                case Type t when t == typeof(long):
                    LongField(position, label, (long)value);
                    break;
                case Type t when t == typeof(float):
                    FloatField(position, label, (float)value);
                    break;
                case Type t when t == typeof(double):
                    DoubleField(position, label, (double)value);
                    break;
                case Type t when t == typeof(bool):
                    Toggle(position, label, (bool)value);
                    break;
                case Type t when t == typeof(string):
                    TextField(position, label, (string)value);
                    break;
                case Type t when t == typeof(Vector2Int):
                    Vector2IntField(position, label, (Vector2Int)value);
                    break;
                case Type t when t == typeof(Vector2):
                    Vector2Field(position, label, (Vector2)value);
                    break;
                case Type t when t == typeof(Vector3Int):
                    Vector3IntField(position, label, (Vector3Int)value);
                    break;
                case Type t when t == typeof(Vector3):
                    Vector3Field(position, label, (Vector3)value);
                    break;
                case Type t when t == typeof(Vector4):
                    Vector4Field(position, label, (Vector4)value);
                    break;
                case Type t when t == typeof(RectInt):
                    RectIntField(position, label, (RectInt)value);
                    break;
                case Type t when t == typeof(Rect):
                    RectField(position, label, (Rect)value);
                    break;
                case Type t when t == typeof(BoundsInt):
                    BoundsIntField(position, label, (BoundsInt)value);
                    break;
                case Type t when t == typeof(Bounds):
                    BoundsField(position, label, (Bounds)value);
                    break;
                case Type t when t == typeof(Color):
                    ColorField(position, label, (Color)value);
                    break;
                case Type t when t == typeof(Gradient):
                    GradientField(position, label, (Gradient)value);
                    break;
                case Type t when t == typeof(Enum):
                    EnumPopup(position, label, (Enum)value);
                    break;
                case Type t when t == typeof(AnimationCurve):
                    CurveField(position, label, (AnimationCurve)value);
                    break;
                case Type t when t == typeof(Object):
                    ObjectField(position, label, (Object)value, objType, true);
                    break;
                default:
                    EditorGUI.BeginDisabledGroup(false);
                    throw new ArgumentException($"Unsupported field type: {objType.Name}");
            }

            EditorGUI.BeginDisabledGroup(false);
        }

        public static bool PropertyField(Rect position, SerializedProperty property)
        {
            return EditorGUI.PropertyField(position, property);
        }

        public static bool PropertyField(Rect position, SerializedProperty property, bool includeChildren)
        {
            return EditorGUI.PropertyField(position, property, includeChildren);
        }

        public static bool PropertyField(Rect position, SerializedProperty property, GUIContent label)
        {
            return EditorGUI.PropertyField(position, property, label);
        }

        public static bool PropertyField(Rect position, SerializedProperty property, GUIContent label,
            bool includeChildren)
        {
            return EditorGUI.PropertyField(position, property, label, includeChildren);
        }

        public static void MultiPropertyField(Rect position, GUIContent[] subLabels, SerializedProperty valuesIterator,
            GUIContent label)
        {
            EditorGUI.MultiPropertyField(position, subLabels, valuesIterator, label);
        }

        public static void MultiPropertyField(Rect position, GUIContent[] subLabels, SerializedProperty valuesIterator)
        {
            EditorGUI.MultiPropertyField(position, subLabels, valuesIterator);
        }

        public static string TextField(Rect position, string value)
        {
            return EditorGUI.TextField(position, value);
        }

        public static string TextField(Rect position, string value, GUIStyle style)
        {
            return EditorGUI.TextField(position, value, style);
        }

        public static string TextField(Rect position, string label, string value)
        {
            return EditorGUI.TextField(position, label, value);
        }

        public static string TextField(Rect position, string label, string value, GUIStyle style)
        {
            return EditorGUI.TextField(position, label, value, style);
        }

        public static string TextField(Rect position, GUIContent label, string value)
        {
            return EditorGUI.TextField(position, label, value);
        }

        public static string TextField(Rect position, GUIContent label, string value, GUIStyle style)
        {
            return EditorGUI.TextField(position, label, value, style);
        }

        public static string DelayedTextField(Rect position, string value)
        {
            return EditorGUI.DelayedTextField(position, value);
        }

        public static string DelayedTextField(Rect position, string value, GUIStyle style)
        {
            return EditorGUI.DelayedTextField(position, value, style);
        }

        public static string DelayedTextField(Rect position, string label, string value)
        {
            return EditorGUI.DelayedTextField(position, label, value);
        }

        public static string DelayedTextField(Rect position, string label, string value, GUIStyle style)
        {
            return EditorGUI.DelayedTextField(position, label, value, style);
        }

        public static string DelayedTextField(Rect position, GUIContent label, string value)
        {
            return EditorGUI.DelayedTextField(position, label, value);
        }

        public static string DelayedTextField(Rect position, GUIContent label, string value, GUIStyle style)
        {
            return EditorGUI.DelayedTextField(position, label, value, style);
        }

        public static string TextArea(Rect position, string text)
        {
            return EditorGUI.TextArea(position, text);
        }

        public static string TextArea(Rect position, string text, GUIStyle style)
        {
            return EditorGUI.TextArea(position, text, style);
        }

        public static string PasswordField(Rect position, string password)
        {
            return EditorGUI.PasswordField(position, password);
        }

        public static string PasswordField(Rect position, string password, GUIStyle style)
        {
            return EditorGUI.PasswordField(position, password, style);
        }

        public static string PasswordField(Rect position, string label, string password)
        {
            return EditorGUI.PasswordField(position, label, password);
        }

        public static string PasswordField(Rect position, string label, string password, GUIStyle style)
        {
            return EditorGUI.PasswordField(position, label, password, style);
        }

        public static string PasswordField(Rect position, GUIContent label, string password)
        {
            return EditorGUI.PasswordField(position, label, password);
        }

        public static string PasswordField(Rect position, GUIContent label, string password, GUIStyle style)
        {
            return EditorGUI.PasswordField(position, label, password, style);
        }

        public static int IntField(Rect position, int value)
        {
            return EditorGUI.IntField(position, value);
        }

        public static int IntField(Rect position, int value, GUIStyle style)
        {
            return EditorGUI.IntField(position, value, style);
        }

        public static int IntField(Rect position, string label, int value)
        {
            return EditorGUI.IntField(position, label, value);
        }

        public static int IntField(Rect position, string label, int value, GUIStyle style)
        {
            return EditorGUI.IntField(position, label, value, style);
        }

        public static int IntField(Rect position, GUIContent label, int value)
        {
            return EditorGUI.IntField(position, label, value);
        }

        public static int IntField(Rect position, GUIContent label, int value, GUIStyle style)
        {
            return EditorGUI.IntField(position, label, value, style);
        }

        public static int DelayedIntField(Rect position, int value)
        {
            return EditorGUI.DelayedIntField(position, value);
        }

        public static int DelayedIntField(Rect position, int value, GUIStyle style)
        {
            return EditorGUI.DelayedIntField(position, value, style);
        }

        public static int DelayedIntField(Rect position, string label, int value)
        {
            return EditorGUI.DelayedIntField(position, label, value);
        }

        public static int DelayedIntField(Rect position, string label, int value, GUIStyle style)
        {
            return EditorGUI.DelayedIntField(position, label, value, style);
        }

        public static int DelayedIntField(Rect position, GUIContent label, int value)
        {
            return EditorGUI.DelayedIntField(position, label, value);
        }

        public static int DelayedIntField(Rect position, GUIContent label, int value, GUIStyle style)
        {
            return EditorGUI.DelayedIntField(position, label, value, style);
        }

        public static int IntPopup(Rect position, int selectedValue, string[] displayedOptions, int[] optionValues)
        {
            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues);
        }

        public static int IntPopup(Rect position, int selectedValue, string[] displayedOptions, int[] optionValues,
            GUIStyle style)
        {
            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues, style);
        }

        public static int IntPopup(Rect position, int selectedValue, GUIContent[] displayedOptions, int[] optionValues)
        {
            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues);
        }

        public static int IntPopup(Rect position, int selectedValue, GUIContent[] displayedOptions, int[] optionValues,
            GUIStyle style)
        {
            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues, style);
        }

        public static int IntPopup(Rect position, string label, int selectedValue, string[] displayedOptions,
            int[] optionValues)
        {
            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues);
        }

        public static int IntPopup(Rect position, string label, int selectedValue, string[] displayedOptions,
            int[] optionValues, GUIStyle style)
        {
            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues, style);
        }

        public static int IntPopup(Rect position, GUIContent label, int selectedValue, GUIContent[] displayedOptions,
            int[] optionValues)
        {
            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues);
        }

        public static int IntPopup(Rect position, GUIContent label, int selectedValue, GUIContent[] displayedOptions,
            int[] optionValues, GUIStyle style)
        {
            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues, style);
        }

        public static void IntPopup(Rect position, SerializedProperty property, GUIContent[] displayedOptions,
            int[] optionValues)
        {
            EditorGUI.IntPopup(position, property, displayedOptions, optionValues);
        }

        public static void IntPopup(Rect position, SerializedProperty property, GUIContent[] displayedOptions,
            int[] optionValues, GUIContent label)
        {
            EditorGUI.IntPopup(position, property, displayedOptions, optionValues, label);
        }

        public static int IntSlider(Rect position, int value, int leftValue, int rightValue)
        {
            return EditorGUI.IntSlider(position, value, leftValue, rightValue);
        }

        public static int IntSlider(Rect position, string label, int value, int leftValue, int rightValue)
        {
            return EditorGUI.IntSlider(position, label, value, leftValue, rightValue);
        }

        public static int IntSlider(Rect position, GUIContent label, int value, int leftValue, int rightValue)
        {
            return EditorGUI.IntSlider(position, label, value, leftValue, rightValue);
        }

        public static void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue)
        {
            EditorGUI.IntSlider(position, property, leftValue, rightValue);
        }

        public static void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue,
            string label)
        {
            EditorGUI.IntSlider(position, property, leftValue, rightValue, label);
        }

        public static void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue,
            GUIContent label)
        {
            EditorGUI.IntSlider(position, property, leftValue, rightValue, label);
        }

        public static void MultiIntField(Rect position, GUIContent[] subLabels, int[] values)
        {
            EditorGUI.MultiIntField(position, subLabels, values);
        }

        public static float FloatField(Rect position, float value)
        {
            return EditorGUI.FloatField(position, value);
        }

        public static float FloatField(Rect position, float value, GUIStyle style)
        {
            return EditorGUI.FloatField(position, value, style);
        }

        public static float FloatField(Rect position, string label, float value)
        {
            return EditorGUI.FloatField(position, label, value);
        }

        public static float FloatField(Rect position, string label, float value, GUIStyle style)
        {
            return EditorGUI.FloatField(position, label, value, style);
        }

        public static float FloatField(Rect position, GUIContent label, float value)
        {
            return EditorGUI.FloatField(position, label, value);
        }

        public static float FloatField(Rect position, GUIContent label, float value, GUIStyle style)
        {
            return EditorGUI.FloatField(position, label, value, style);
        }

        public static float FloatSlider(Rect position, float value, float leftValue, float rightValue)
        {
            return EditorGUI.Slider(position, value, leftValue, rightValue);
        }

        public static float FloatSlider(Rect position, string label, float value, float leftValue, float rightValue)
        {
            return EditorGUI.Slider(position, label, value, leftValue, rightValue);
        }

        public static float FloatSlider(Rect position, GUIContent label, float value, float leftValue, float rightValue)
        {
            return EditorGUI.Slider(position, label, value, leftValue, rightValue);
        }

        public static void FloatSlider(Rect position, SerializedProperty property, float leftValue, float rightValue)
        {
            EditorGUI.Slider(position, property, leftValue, rightValue);
        }

        public static void FloatSlider(Rect position, SerializedProperty property, float leftValue, float rightValue,
            string label)
        {
            EditorGUI.Slider(position, property, leftValue, rightValue, label);
        }

        public static void FloatSlider(Rect position, SerializedProperty property, float leftValue, float rightValue,
            GUIContent label)
        {
            EditorGUI.Slider(position, property, leftValue, rightValue, label);
        }

        public static float DelayedFloatField(Rect position, float value)
        {
            return EditorGUI.DelayedFloatField(position, value);
        }

        public static float DelayedFloatField(Rect position, float value, GUIStyle style)
        {
            return EditorGUI.DelayedFloatField(position, value, style);
        }

        public static float DelayedFloatField(Rect position, string label, float value)
        {
            return EditorGUI.DelayedFloatField(position, label, value);
        }

        public static float DelayedFloatField(Rect position, string label, float value, GUIStyle style)
        {
            return EditorGUI.DelayedFloatField(position, label, value, style);
        }

        public static float DelayedFloatField(Rect position, GUIContent label, float value)
        {
            return EditorGUI.DelayedFloatField(position, label, value);
        }

        public static float DelayedFloatField(Rect position, GUIContent label, float value, GUIStyle style)
        {
            return EditorGUI.DelayedFloatField(position, label, value, style);
        }

        public static void MultiFloatField(Rect position, GUIContent[] subLabels, float[] values)
        {
            EditorGUI.MultiFloatField(position, subLabels, values);
        }

        public static void MultiFloatField(Rect position, GUIContent label, GUIContent[] subLabels, float[] values)
        {
            EditorGUI.MultiFloatField(position, label, subLabels, values);
        }

        public static double DoubleField(Rect position, double value)
        {
            return EditorGUI.DoubleField(position, value);
        }

        public static double DoubleField(Rect position, double value, GUIStyle style)
        {
            return EditorGUI.DoubleField(position, value, style);
        }

        public static double DoubleField(Rect position, string label, double value)
        {
            return EditorGUI.DoubleField(position, label, value);
        }

        public static double DoubleField(Rect position, string label, double value, GUIStyle style)
        {
            return EditorGUI.DoubleField(position, label, value, style);
        }

        public static double DoubleField(Rect position, GUIContent label, double value)
        {
            return EditorGUI.DoubleField(position, label, value);
        }

        public static double DoubleField(Rect position, GUIContent label, double value, GUIStyle style)
        {
            return EditorGUI.DoubleField(position, label, value, style);
        }

        public static double DelayedDoubleField(Rect position, double value)
        {
            return EditorGUI.DelayedDoubleField(position, value);
        }

        public static double DelayedDoubleField(Rect position, double value, GUIStyle style)
        {
            return EditorGUI.DelayedDoubleField(position, value, style);
        }

        public static double DelayedDoubleField(Rect position, string label, double value)
        {
            return EditorGUI.DelayedDoubleField(position, label, value);
        }

        public static double DelayedDoubleField(Rect position, string label, double value, GUIStyle style)
        {
            return EditorGUI.DelayedDoubleField(position, label, value, style);
        }

        public static double DelayedDoubleField(Rect position, GUIContent label, double value)
        {
            return EditorGUI.DelayedDoubleField(position, label, value);
        }

        public static double DelayedDoubleField(Rect position, GUIContent label, double value, GUIStyle style)
        {
            return EditorGUI.DelayedDoubleField(position, label, value, style);
        }

        public static long LongField(Rect position, long value)
        {
            return EditorGUI.LongField(position, value);
        }

        public static long LongField(Rect position, long value, GUIStyle style)
        {
            return EditorGUI.LongField(position, value, style);
        }

        public static long LongField(Rect position, string label, long value)
        {
            return EditorGUI.LongField(position, label, value);
        }

        public static long LongField(Rect position, string label, long value, GUIStyle style)
        {
            return EditorGUI.LongField(position, label, value, style);
        }

        public static long LongField(Rect position, GUIContent label, long value)
        {
            return EditorGUI.LongField(position, label, value);
        }

        public static long LongField(Rect position, GUIContent label, long value, GUIStyle style)
        {
            return EditorGUI.LongField(position, label, value, style);
        }

        public static bool Toggle(Rect position, bool value)
        {
            return EditorGUI.Toggle(position, value);
        }

        public static bool Toggle(Rect position, bool value, GUIStyle style)
        {
            return EditorGUI.Toggle(position, value, style);
        }

        public static bool Toggle(Rect position, string label, bool value)
        {
            return EditorGUI.Toggle(position, label, value);
        }

        public static bool Toggle(Rect position, string label, bool value, GUIStyle style)
        {
            return EditorGUI.Toggle(position, label, value, style);
        }

        public static bool Toggle(Rect position, GUIContent label, bool value)
        {
            return EditorGUI.Toggle(position, label, value);
        }

        public static bool Toggle(Rect position, GUIContent label, bool value, GUIStyle style)
        {
            return EditorGUI.Toggle(position, label, value, style);
        }

        public static bool ToggleLeft(Rect position, string label, bool value)
        {
            return EditorGUI.ToggleLeft(position, label, value);
        }

        public static bool ToggleLeft(Rect position, string label, bool value, GUIStyle style)
        {
            return EditorGUI.ToggleLeft(position, label, value, style);
        }

        public static bool ToggleLeft(Rect position, GUIContent label, bool value)
        {
            return EditorGUI.ToggleLeft(position, label, value);
        }

        public static bool ToggleLeft(Rect position, GUIContent label, bool value, GUIStyle style)
        {
            return EditorGUI.ToggleLeft(position, label, value, style);
        }

        public static Vector2 Vector2Field(Rect position, string label, Vector2 value)
        {
            return EditorGUI.Vector2Field(position, label, value);
        }

        public static Vector2 Vector2Field(Rect position, GUIContent label, Vector2 value)
        {
            return EditorGUI.Vector2Field(position, label, value);
        }

        public static Vector2Int Vector2IntField(Rect position, string label, Vector2Int value)
        {
            return EditorGUI.Vector2IntField(position, label, value);
        }

        public static Vector2Int Vector2IntField(Rect position, GUIContent label, Vector2Int value)
        {
            return EditorGUI.Vector2IntField(position, label, value);
        }

        public static Vector3 Vector3Field(Rect position, string label, Vector3 value)
        {
            return EditorGUI.Vector3Field(position, label, value);
        }

        public static Vector3 Vector3Field(Rect position, GUIContent label, Vector3 value)
        {
            return EditorGUI.Vector3Field(position, label, value);
        }

        public static Vector3Int Vector3IntField(Rect position, string label, Vector3Int value)
        {
            return EditorGUI.Vector3IntField(position, label, value);
        }

        public static Vector3Int Vector3IntField(Rect position, GUIContent label, Vector3Int value)
        {
            return EditorGUI.Vector3IntField(position, label, value);
        }

        public static Vector4 Vector4Field(Rect position, string label, Vector4 value)
        {
            return EditorGUI.Vector4Field(position, label, value);
        }

        public static Vector4 Vector4Field(Rect position, GUIContent label, Vector4 value)
        {
            return EditorGUI.Vector4Field(position, label, value);
        }

        public static Color ColorField(Rect position, Color value)
        {
            return EditorGUI.ColorField(position, value);
        }

        public static Color ColorField(Rect position, string label, Color value)
        {
            return EditorGUI.ColorField(position, label, value);
        }

        public static Color ColorField(Rect position, GUIContent label, Color value)
        {
            return EditorGUI.ColorField(position, label, value);
        }

        public static Color ColorField(Rect position, GUIContent label, Color value, bool showEyedropper,
            bool showAlpha, bool hdr)
        {
            return EditorGUI.ColorField(position, label, value, showEyedropper, showAlpha, hdr);
        }

        public static Gradient GradientField(Rect position, Gradient gradient)
        {
            return EditorGUI.GradientField(position, gradient);
        }

        public static Gradient GradientField(Rect position, string label, Gradient gradient)
        {
            return EditorGUI.GradientField(position, label, gradient);
        }

        public static Gradient GradientField(Rect position, GUIContent label, Gradient gradient)
        {
            return EditorGUI.GradientField(position, label, gradient);
        }

        public static Gradient GradientField(Rect position, GUIContent label, Gradient gradient, bool hdr)
        {
            return EditorGUI.GradientField(position, label, gradient, hdr);
        }

        public static AnimationCurve CurveField(Rect position, AnimationCurve value)
        {
            return EditorGUI.CurveField(position, value);
        }

        public static AnimationCurve CurveField(Rect position, string label, AnimationCurve value)
        {
            return EditorGUI.CurveField(position, label, value);
        }

        public static AnimationCurve CurveField(Rect position, GUIContent label, AnimationCurve value)
        {
            return EditorGUI.CurveField(position, label, value);
        }

        public static AnimationCurve CurveField(Rect position, AnimationCurve value, Color color, Rect ranges)
        {
            return EditorGUI.CurveField(position, value, color, ranges);
        }

        public static AnimationCurve CurveField(Rect position, string label, AnimationCurve value, Color color,
            Rect ranges)
        {
            return EditorGUI.CurveField(position, label, value, color, ranges);
        }

        public static AnimationCurve CurveField(Rect position, GUIContent label, AnimationCurve value, Color color,
            Rect ranges)
        {
            return EditorGUI.CurveField(position, label, value, color, ranges);
        }

        public static void CurveField(Rect position, SerializedProperty property, Color color, Rect ranges)
        {
            EditorGUI.CurveField(position, property, color, ranges);
        }

        public static void CurveField(Rect position, SerializedProperty property, Color color, Rect ranges,
            GUIContent label)
        {
            EditorGUI.CurveField(position, property, color, ranges, label);
        }

        public static Bounds BoundsField(Rect position, Bounds value)
        {
            return EditorGUI.BoundsField(position, value);
        }

        public static Bounds BoundsField(Rect position, string label, Bounds value)
        {
            return EditorGUI.BoundsField(position, label, value);
        }

        public static Bounds BoundsField(Rect position, GUIContent label, Bounds value)
        {
            return EditorGUI.BoundsField(position, label, value);
        }

        public static BoundsInt BoundsIntField(Rect position, BoundsInt value)
        {
            return EditorGUI.BoundsIntField(position, value);
        }

        public static BoundsInt BoundsIntField(Rect position, string label, BoundsInt value)
        {
            return EditorGUI.BoundsIntField(position, label, value);
        }

        public static BoundsInt BoundsIntField(Rect position, GUIContent label, BoundsInt value)
        {
            return EditorGUI.BoundsIntField(position, label, value);
        }

        public static Rect RectField(Rect position, Rect value)
        {
            return EditorGUI.RectField(position, value);
        }

        public static Rect RectField(Rect position, string label, Rect value)
        {
            return EditorGUI.RectField(position, label, value);
        }

        public static Rect RectField(Rect position, GUIContent label, Rect value)
        {
            return EditorGUI.RectField(position, label, value);
        }

        public static RectInt RectIntField(Rect position, RectInt value)
        {
            return EditorGUI.RectIntField(position, value);
        }

        public static RectInt RectIntField(Rect position, string label, RectInt value)
        {
            return EditorGUI.RectIntField(position, label, value);
        }

        public static RectInt RectIntField(Rect position, GUIContent label, RectInt value)
        {
            return EditorGUI.RectIntField(position, label, value);
        }

        public static Enum EnumFlagsField(Rect position, Enum enumValue)
        {
            return EditorGUI.EnumFlagsField(position, enumValue);
        }

        public static Enum EnumFlagsField(Rect position, Enum enumValue, GUIStyle style)
        {
            return EditorGUI.EnumFlagsField(position, enumValue, style);
        }

        public static Enum EnumFlagsField(Rect position, string label, Enum enumValue)
        {
            return EditorGUI.EnumFlagsField(position, label, enumValue);
        }

        public static Enum EnumFlagsField(Rect position, string label, Enum enumValue, GUIStyle style)
        {
            return EditorGUI.EnumFlagsField(position, label, enumValue, style);
        }

        public static Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue)
        {
            return EditorGUI.EnumFlagsField(position, label, enumValue);
        }

        public static Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue, GUIStyle style)
        {
            return EditorGUI.EnumFlagsField(position, label, enumValue, style);
        }

        public static Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue, bool includeObsolete)
        {
            return EditorGUI.EnumFlagsField(position, label, enumValue, includeObsolete);
        }

        public static Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue, bool includeObsolete,
            GUIStyle style)
        {
            return EditorGUI.EnumFlagsField(position, label, enumValue, includeObsolete, style);
        }

        public static TEnum EnumFlagsField<TEnum>(Rect position, TEnum enumValue) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumFlagsField(position, enumValue);
        }

        public static TEnum EnumFlagsField<TEnum>(Rect position, TEnum enumValue, GUIStyle style) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumFlagsField(position, enumValue, style);
        }

        public static TEnum EnumFlagsField<TEnum>(Rect position, string label, TEnum enumValue) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumFlagsField(position, label, enumValue);
        }

        public static TEnum EnumFlagsField<TEnum>(Rect position, string label, TEnum enumValue, GUIStyle style)
            where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumFlagsField(position, label, enumValue, style);
        }

        public static TEnum EnumFlagsField<TEnum>(Rect position, GUIContent label, TEnum enumValue) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumFlagsField(position, label, enumValue);
        }

        public static TEnum EnumFlagsField<TEnum>(Rect position, GUIContent label, TEnum enumValue, GUIStyle style)
            where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumFlagsField(position, label, enumValue, style);
        }

        public static TEnum EnumFlagsField<TEnum>(Rect position, GUIContent label, TEnum enumValue,
            bool includeObsolete) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumFlagsField(position, label, enumValue, includeObsolete);
        }

        public static TEnum EnumFlagsField<TEnum>(Rect position, GUIContent label, TEnum enumValue,
            bool includeObsolete, GUIStyle style) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumFlagsField(position, label, enumValue, includeObsolete, style);
        }

        public static Enum EnumPopup(Rect position, Enum selected)
        {
            return EditorGUI.EnumPopup(position, selected);
        }

        public static Enum EnumPopup(Rect position, Enum selected, GUIStyle style)
        {
            return EditorGUI.EnumPopup(position, selected, style);
        }

        public static Enum EnumPopup(Rect position, string label, Enum selected)
        {
            return EditorGUI.EnumPopup(position, label, selected);
        }

        public static Enum EnumPopup(Rect position, string label, Enum selected, GUIStyle style)
        {
            return EditorGUI.EnumPopup(position, label, selected, style);
        }

        public static Enum EnumPopup(Rect position, GUIContent label, Enum selected)
        {
            return EditorGUI.EnumPopup(position, label, selected);
        }

        public static Enum EnumPopup(Rect position, GUIContent label, Enum selected, GUIStyle style)
        {
            return EditorGUI.EnumPopup(position, label, selected, style);
        }

        public static Enum EnumPopup(Rect position, GUIContent label, Enum selected, Func<Enum, bool> checkEnabled,
            bool includeObsolete)
        {
            return EditorGUI.EnumPopup(position, label, selected, checkEnabled, includeObsolete);
        }

        public static Enum EnumPopup(Rect position, GUIContent label, Enum selected, Func<Enum, bool> checkEnabled,
            bool includeObsolete, GUIStyle style)
        {
            return EditorGUI.EnumPopup(position, label, selected, checkEnabled, includeObsolete, style);
        }

        public static TEnum EnumPopup<TEnum>(Rect position, TEnum selected) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumPopup(position, selected);
        }

        public static TEnum EnumPopup<TEnum>(Rect position, TEnum selected, GUIStyle style) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumPopup(position, selected, style);
        }

        public static TEnum EnumPopup<TEnum>(Rect position, string label, TEnum selected) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumPopup(position, label, selected);
        }

        public static TEnum EnumPopup<TEnum>(Rect position, string label, TEnum selected, GUIStyle style)
            where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumPopup(position, label, selected, style);
        }

        public static TEnum EnumPopup<TEnum>(Rect position, GUIContent label, TEnum selected) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumPopup(position, label, selected);
        }

        public static TEnum EnumPopup<TEnum>(Rect position, GUIContent label, TEnum selected, GUIStyle style)
            where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumPopup(position, label, selected, style);
        }

        public static TEnum EnumPopup<TEnum>(Rect position, GUIContent label, TEnum selected,
            Func<Enum, bool> checkEnabled, bool includeObsolete) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumPopup(position, label, selected, checkEnabled, includeObsolete);
        }

        public static TEnum EnumPopup<TEnum>(Rect position, GUIContent label, TEnum selected,
            Func<Enum, bool> checkEnabled, bool includeObsolete, GUIStyle style) where TEnum : Enum
        {
            return (TEnum)EditorGUI.EnumPopup(position, label, selected, checkEnabled, includeObsolete, style);
        }

        public static Object ObjectField(Rect position, Object obj, Type objType, bool allowSceneObjects)
        {
            return EditorGUI.ObjectField(position, obj, objType, allowSceneObjects);
        }

        public static Object ObjectField(Rect position, string label, Object obj, Type objType, bool allowSceneObjects)
        {
            return EditorGUI.ObjectField(position, label, obj, objType, allowSceneObjects);
        }

        public static Object ObjectField(Rect position, GUIContent label, Object obj, Type objType,
            bool allowSceneObjects)
        {
            return EditorGUI.ObjectField(position, label, obj, objType, allowSceneObjects);
        }

        public static T ObjectField<T>(Rect position, T obj, bool allowSceneObjects) where T : Object
        {
            return (T)EditorGUI.ObjectField(position, obj, typeof(T), allowSceneObjects);
        }

        public static T ObjectField<T>(Rect position, string label, T obj, bool allowSceneObjects) where T : Object
        {
            return (T)EditorGUI.ObjectField(position, label, obj, typeof(T), allowSceneObjects);
        }

        public static T ObjectField<T>(Rect position, GUIContent label, T obj, bool allowSceneObjects) where T : Object
        {
            return (T)EditorGUI.ObjectField(position, label, obj, typeof(T), allowSceneObjects);
        }

        public static void ObjectField(Rect position, SerializedProperty property)
        {
            EditorGUI.ObjectField(position, property);
        }

        public static void ObjectField(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.ObjectField(position, property, label);
        }

        public static void ObjectField(Rect position, SerializedProperty property, Type objType)
        {
            EditorGUI.ObjectField(position, property, objType);
        }

        public static void ObjectField(Rect position, SerializedProperty property, Type objType, GUIContent label)
        {
            EditorGUI.ObjectField(position, property, objType, label);
        }

        public static void ObjectField<T>(Rect position, SerializedProperty property)
        {
            EditorGUI.ObjectField(position, property, typeof(T));
        }

        public static void ObjectField<T>(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.ObjectField(position, property, typeof(T), label);
        }

        public static string TagField(Rect position, string tag)
        {
            return EditorGUI.TagField(position, tag);
        }

        public static string TagField(Rect position, string tag, GUIStyle style)
        {
            return EditorGUI.TagField(position, tag, style);
        }

        public static string TagField(Rect position, string label, string tag)
        {
            return EditorGUI.TagField(position, label, tag);
        }

        public static string TagField(Rect position, string label, string tag, GUIStyle style)
        {
            return EditorGUI.TagField(position, label, tag, style);
        }

        public static string TagField(Rect position, GUIContent label, string tag)
        {
            return EditorGUI.TagField(position, label, tag);
        }

        public static string TagField(Rect position, GUIContent label, string tag, GUIStyle style)
        {
            return EditorGUI.TagField(position, label, tag, style);
        }

        public static int LayerField(Rect position, int layer)
        {
            return EditorGUI.LayerField(position, layer);
        }

        public static int LayerField(Rect position, int layer, GUIStyle style)
        {
            return EditorGUI.LayerField(position, layer, style);
        }

        public static int LayerField(Rect position, string label, int layer)
        {
            return EditorGUI.LayerField(position, label, layer);
        }

        public static int LayerField(Rect position, string label, int layer, GUIStyle style)
        {
            return EditorGUI.LayerField(position, label, layer, style);
        }

        public static int LayerField(Rect position, GUIContent label, int layer)
        {
            return EditorGUI.LayerField(position, label, layer);
        }

        public static int LayerField(Rect position, GUIContent label, int layer, GUIStyle style)
        {
            return EditorGUI.LayerField(position, label, layer, style);
        }

        public static int MaskField(Rect position, GUIContent label, int mask, string[] displayedOptions)
        {
            return EditorGUI.MaskField(position, label, mask, displayedOptions);
        }

        public static int MaskField(Rect position, GUIContent label, int mask, string[] displayedOptions,
            GUIStyle style)
        {
            return EditorGUI.MaskField(position, label, mask, displayedOptions, style);
        }

        public static int MaskField(Rect position, string label, int mask, string[] displayedOptions)
        {
            return EditorGUI.MaskField(position, label, mask, displayedOptions);
        }

        public static int MaskField(Rect position, string label, int mask, string[] displayedOptions, GUIStyle style)
        {
            return EditorGUI.MaskField(position, label, mask, displayedOptions, style);
        }

        public static int MaskField(Rect position, int mask, string[] displayedOptions)
        {
            return EditorGUI.MaskField(position, mask, displayedOptions);
        }

        public static int MaskField(Rect position, int mask, string[] displayedOptions, GUIStyle style)
        {
            return EditorGUI.MaskField(position, mask, displayedOptions, style);
        }

        public static int Popup(Rect position, int selectedIndex, string[] displayedOptions)
        {
            return EditorGUI.Popup(position, selectedIndex, displayedOptions);
        }

        public static int Popup(Rect position, int selectedIndex, string[] displayedOptions, GUIStyle style)
        {
            return EditorGUI.Popup(position, selectedIndex, displayedOptions, style);
        }

        public static int Popup(Rect position, int selectedIndex, GUIContent[] displayedOptions)
        {
            return EditorGUI.Popup(position, selectedIndex, displayedOptions);
        }

        public static int Popup(Rect position, int selectedIndex, GUIContent[] displayedOptions, GUIStyle style)
        {
            return EditorGUI.Popup(position, selectedIndex, displayedOptions, style);
        }

        public static int Popup(Rect position, string label, int selectedIndex, string[] displayedOptions)
        {
            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions);
        }

        public static int Popup(Rect position, string label, int selectedIndex, string[] displayedOptions,
            GUIStyle style)
        {
            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions, style);
        }

        public static int Popup(Rect position, GUIContent label, int selectedIndex, GUIContent[] displayedOptions)
        {
            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions);
        }

        public static int Popup(Rect position, GUIContent label, int selectedIndex, GUIContent[] displayedOptions,
            GUIStyle style)
        {
            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions, style);
        }

        public static void LabelField(Rect position, string label)
        {
            EditorGUI.LabelField(position, label);
        }

        public static void LabelField(Rect position, string label, GUIStyle style)
        {
            EditorGUI.LabelField(position, label, style);
        }

        public static void LabelField(Rect position, GUIContent label)
        {
            EditorGUI.LabelField(position, label);
        }

        public static void LabelField(Rect position, GUIContent label, GUIStyle style)
        {
            EditorGUI.LabelField(position, label, style);
        }

        public static void LabelField(Rect position, string label, string label2)
        {
            EditorGUI.LabelField(position, label, label2);
        }

        public static void LabelField(Rect position, string label, string label2, GUIStyle style)
        {
            EditorGUI.LabelField(position, label, label2, style);
        }

        public static void LabelField(Rect position, GUIContent label, GUIContent label2)
        {
            EditorGUI.LabelField(position, label, label2);
        }

        public static void LabelField(Rect position, GUIContent label, GUIContent label2, GUIStyle style)
        {
            EditorGUI.LabelField(position, label, label2, style);
        }

        public static Rect PrefixLabel(Rect totalPosition, GUIContent label)
        {
            return EditorGUI.PrefixLabel(totalPosition, label);
        }

        public static Rect PrefixLabel(Rect totalPosition, GUIContent label, GUIStyle style)
        {
            return EditorGUI.PrefixLabel(totalPosition, label, style);
        }

        public static Rect PrefixLabel(Rect totalPosition, int id, GUIContent label)
        {
            return EditorGUI.PrefixLabel(totalPosition, id, label);
        }

        public static Rect PrefixLabel(Rect totalPosition, int id, GUIContent label, GUIStyle style)
        {
            return EditorGUI.PrefixLabel(totalPosition, id, label, style);
        }

        public static void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label)
        {
            EditorGUI.HandlePrefixLabel(totalPosition, labelPosition, label);
        }

        public static void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label, int id)
        {
            EditorGUI.HandlePrefixLabel(totalPosition, labelPosition, label, id);
        }

        public static void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label, int id,
            GUIStyle style)
        {
            EditorGUI.HandlePrefixLabel(totalPosition, labelPosition, label, id, style);
        }

        public static void SelectableLabel(Rect position, string text)
        {
            EditorGUI.SelectableLabel(position, text);
        }

        public static void SelectableLabel(Rect position, string text, GUIStyle style)
        {
            EditorGUI.SelectableLabel(position, text, style);
        }

        public static void DrawRect(Rect rect, Color color)
        {
            EditorGUI.DrawRect(rect, color);
        }

        public static void DrawPreviewTexture(Rect position, Texture image, Material mat = null,
            ScaleMode scaleMode = ScaleMode.StretchToFill, float imageAspect = 0, float mipLevel = -1,
            ColorWriteMask colorWriteMask = ColorWriteMask.All)
        {
            EditorGUI.DrawPreviewTexture(position, image, mat, scaleMode, imageAspect, mipLevel, colorWriteMask);
        }

        public static void DrawTextureAlpha(Rect position, Texture image, ScaleMode scaleMode = ScaleMode.StretchToFill,
            float imageAspect = 0, float mipLevel = -1)
        {
            EditorGUI.DrawTextureAlpha(position, image, scaleMode, imageAspect, mipLevel);
        }

        public static void DrawTextureTransparent(Rect position, Texture image,
            ScaleMode scaleMode = ScaleMode.StretchToFill, float imageAspect = 0, float mipLevel = -1,
            ColorWriteMask colorWriteMask = ColorWriteMask.All, float explosure = 0)
        {
            EditorGUI.DrawTextureTransparent(position, image, scaleMode, imageAspect, mipLevel, colorWriteMask,
                explosure);
        }

        public static bool InspectorTitlebar(Rect position, bool foldout, Object targetObj, bool expandable)
        {
            return EditorGUI.InspectorTitlebar(position, foldout, targetObj, expandable);
        }

        public static bool InspectorTitlebar(Rect position, bool foldout, Object[] targetObjs, bool expandable)
        {
            return EditorGUI.InspectorTitlebar(position, foldout, targetObjs, expandable);
        }

        public static void MinMaxSlider(Rect position, ref float minValue, ref float maxValue, float minLimit,
            float maxLimit)
        {
            EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public static void MinMaxSlider(Rect position, string label, ref float minValue, ref float maxValue,
            float minLimit, float maxLimit)
        {
            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public static void MinMaxSlider(Rect position, GUIContent label, ref float minValue, ref float maxValue,
            float minLimit, float maxLimit)
        {
            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public static void ProgressBar(Rect position, float value, string text)
        {
            EditorGUI.ProgressBar(position, value, text);
        }

        public static void HelpBox(Rect position, string message, MessageType type)
        {
            EditorGUI.HelpBox(position, message, type);
        }

        public static bool Foldout(Rect position, bool foldout, string content)
        {
            return EditorGUI.Foldout(position, foldout, content);
        }

        public static bool Foldout(Rect position, bool foldout, string content, GUIStyle style)
        {
            return EditorGUI.Foldout(position, foldout, content, style);
        }

        public static bool Foldout(Rect position, bool foldout, string content, bool toggleOnLabelClick)
        {
            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick);
        }

        public static bool Foldout(Rect position, bool foldout, string content, bool toggleOnLabelClick, GUIStyle style)
        {
            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick, style);
        }

        public static bool Foldout(Rect position, bool foldout, GUIContent content)
        {
            return EditorGUI.Foldout(position, foldout, content);
        }

        public static bool Foldout(Rect position, bool foldout, GUIContent content, GUIStyle style)
        {
            return EditorGUI.Foldout(position, foldout, content, style);
        }

        public static bool Foldout(Rect position, bool foldout, GUIContent content, bool toggleOnLabelClick)
        {
            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick);
        }

        public static bool Foldout(Rect position, bool foldout, GUIContent content, bool toggleOnLabelClick,
            GUIStyle style)
        {
            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick, style);
        }

        public static bool FolderFoldout(Rect position, bool foldout, string text, bool toggleOnLabelClick = true)
        {
            var folderContent = foldout ? EditorIcons.FolderOpenedIcon : EditorIcons.FolderIcon;
            folderContent.text = text;
            return EditorGUI.Foldout(position, foldout, folderContent, toggleOnLabelClick);
        }

        public static bool ToggleFoldout(Rect position, bool foldout, ref bool toggle, string text,
            bool toggleOnLabelClick = true)
        {
            var toggleRect = position;
            toggleRect.x += 2f;
            toggleRect.y += position.height * 0.25f;
            toggleRect.width = 13f;
            toggleRect.height = 13f;

            var labelRect = position;
            labelRect.xMin += 18f;

            EditorGUI.LabelField(labelRect, text, EditorStyles.label);
            var value = FoldoutToggle(position, foldout);
            toggle = GUI.Toggle(toggleRect, toggle, GUIContent.none, EditorStyles.toggle);

            LucidGUIEvent.MouseDownEvent(labelRect, () => value = !value);
            return value;
        }

        internal static bool FoldoutToggle(Rect position, bool foldout)
        {
            var foldoutRect = position;
            foldoutRect.x -= 13.5f;
            foldoutRect.y += position.height * 0.23f;
            foldoutRect.width = 13f;
            foldoutRect.height = 13f;
            return GUI.Toggle(foldoutRect, foldout, GUIContent.none, EditorStyles.foldout);
        }

        public static bool FoldoutHeader(Rect position, bool foldout, string content)
        {
            return EditorGUI.Foldout(position, foldout, content, EditorStyles.foldoutHeader);
        }

        public static bool FoldoutHeader(Rect position, bool foldout, string content, bool toggleOnLabelClick)
        {
            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick, EditorStyles.foldoutHeader);
        }

        public static bool FoldoutHeader(Rect position, bool foldout, GUIContent content)
        {
            return EditorGUI.Foldout(position, foldout, content, EditorStyles.foldoutHeader);
        }

        public static bool FoldoutHeader(Rect position, bool foldout, GUIContent content, bool toggleOnLabelClick)
        {
            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick, EditorStyles.foldoutHeader);
        }

        public static bool Button(Rect position, string content)
        {
            return GUI.Button(position, content);
        }

        public static bool Button(Rect position, string content, Action action)
        {
            var value = GUI.Button(position, content);
            if (value) action?.Invoke();
            return value;
        }

        public static bool Button(Rect position, string content, GUIStyle style)
        {
            return GUI.Button(position, content, style);
        }

        public static bool Button(Rect position, string content, GUIStyle style, Action action)
        {
            var value = GUI.Button(position, content, style);
            if (value) action?.Invoke();
            return value;
        }

        public static bool Button(Rect position, Texture image)
        {
            return GUI.Button(position, image);
        }

        public static bool Button(Rect position, Texture image, Action action)
        {
            var value = GUI.Button(position, image);
            if (value) action?.Invoke();
            return value;
        }

        public static bool Button(Rect position, Texture image, GUIStyle style)
        {
            return GUI.Button(position, image, style);
        }

        public static bool Button(Rect position, Texture image, GUIStyle style, Action action)
        {
            var value = GUI.Button(position, image, style);
            if (value) action?.Invoke();
            return value;
        }

        public static bool Button(Rect position, GUIContent content)
        {
            return GUI.Button(position, content);
        }

        public static bool Button(Rect position, GUIContent content, Action action)
        {
            var value = GUI.Button(position, content);
            if (value) action?.Invoke();
            return value;
        }

        public static bool Button(Rect position, GUIContent content, GUIStyle style)
        {
            return GUI.Button(position, content, style);
        }

        public static bool Button(Rect position, GUIContent content, GUIStyle style, Action action)
        {
            var value = GUI.Button(position, content, style);
            if (value) action?.Invoke();
            return value;
        }

        public static bool RepeatButton(Rect position, string content)
        {
            return GUI.RepeatButton(position, content);
        }

        public static bool RepeatButton(Rect position, string content, Action action)
        {
            var value = GUI.RepeatButton(position, content);
            if (value) action?.Invoke();
            return value;
        }

        public static bool RepeatButton(Rect position, string content, GUIStyle style)
        {
            return GUI.RepeatButton(position, content, style);
        }

        public static bool RepeatButton(Rect position, string content, GUIStyle style, Action action)
        {
            var value = GUI.RepeatButton(position, content, style);
            if (value) action?.Invoke();
            return value;
        }

        public static bool RepeatButton(Rect position, Texture image)
        {
            return GUI.RepeatButton(position, image);
        }

        public static bool RepeatButton(Rect position, Texture image, Action action)
        {
            var value = GUI.RepeatButton(position, image);
            if (value) action?.Invoke();
            return value;
        }

        public static bool RepeatButton(Rect position, Texture image, GUIStyle style)
        {
            return GUI.RepeatButton(position, image, style);
        }

        public static bool RepeatButton(Rect position, Texture image, GUIStyle style, Action action)
        {
            var value = GUI.RepeatButton(position, image, style);
            if (value) action?.Invoke();
            return value;
        }

        public static bool RepeatButton(Rect position, GUIContent content)
        {
            return GUI.RepeatButton(position, content);
        }

        public static bool RepeatButton(Rect position, GUIContent content, Action action)
        {
            var value = GUI.RepeatButton(position, content);
            if (value) action?.Invoke();
            return value;
        }

        public static bool RepeatButton(Rect position, GUIContent content, GUIStyle style)
        {
            return GUI.RepeatButton(position, content, style);
        }

        public static bool RepeatButton(Rect position, GUIContent content, GUIStyle style, Action action)
        {
            var value = GUI.RepeatButton(position, content, style);
            if (value) action?.Invoke();
            return value;
        }

        public static bool LinkButton(Rect position, string text)
        {
            Line(new Rect(position.x, position.y + position.height, position.width, position.height),
                EditorStyles.linkLabel.normal.textColor);
            return Button(position, text, EditorStyles.linkLabel);
        }

        public static bool LinkButton(Rect position, string text, Action action)
        {
            Line(new Rect(position.x, position.y + position.height, position.width, position.height),
                EditorStyles.linkLabel.normal.textColor);
            var value = Button(position, text, EditorStyles.linkLabel);
            if (value) action?.Invoke();
            return value;
        }

        public static void Line(Rect position)
        {
            Line(position, 1f, EditorColors.line);
        }

        public static void Line(Rect position, Color color)
        {
            Line(position, 1f, color);
        }

        public static void Line(Rect position, float height, Color color)
        {
            var rect = position;
            rect.height = height;
            DrawRect(rect, color);
        }

        public static void Header(Rect position, string label)
        {
            EditorGUI.LabelField(position, label, EditorStyles.boldLabel);
        }

        public static void Header(Rect position, GUIContent label)
        {
            EditorGUI.LabelField(position, label, EditorStyles.boldLabel);
        }

        public static void BoxHeader(Rect position, GUIContent label)
        {
            BoxHeader(position, label, EditorColors.box);
        }

        public static void BoxHeader(Rect position, string label)
        {
            BoxHeader(position, label, EditorColors.box);
        }

        public static void BoxHeader(Rect position, GUIContent label, Color color)
        {
            DrawBoxHeaderArea(position, color);
            Header(position, label);
        }

        public static void BoxHeader(Rect position, string label, Color color)
        {
            DrawBoxHeaderArea(position, color);
            Header(position, label);
        }

        private static void DrawBoxHeaderArea(Rect position, Color color)
        {
            var rect = position;
            rect.xMin -= 2f;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            EditorGUI.DrawRect(rect, color);
        }

        public static void TitleHeader(Rect position, string label)
        {
            TitleHeader(position, label, EditorColors.thinLine);
        }

        public static void TitleHeader(Rect position, GUIContent label)
        {
            TitleHeader(position, label, EditorColors.thinLine);
        }

        public static void TitleHeader(Rect position, string label, Color lineColor)
        {
            DrawTitleHeaderArea(position, lineColor);
            EditorGUI.LabelField(position, label, EditorStyles.boldLabel);
        }

        public static void TitleHeader(Rect position, GUIContent label, Color lineColor)
        {
            DrawTitleHeaderArea(position, lineColor);
            EditorGUI.LabelField(position, label, EditorStyles.boldLabel);
        }

        private static void DrawTitleHeaderArea(Rect position, Color lineColor)
        {
            var lineRect = position;
            lineRect.y = position.yMax - 1f;
            Line(lineRect, lineColor);
        }

        public static void SectionHeader(Rect position, GUIContent label)
        {
            SectionHeader(position, label, EditorColors.tab, EditorColors.thinLine);
        }

        public static void SectionHeader(Rect position, string label)
        {
            SectionHeader(position, label, EditorColors.tab, EditorColors.thinLine);
        }

        public static void SectionHeader(Rect position, GUIContent label, Color backgroundColor)
        {
            SectionHeader(position, label, backgroundColor, EditorColors.thinLine);
        }

        public static void SectionHeader(Rect position, string label, Color backgroundColor)
        {
            SectionHeader(position, label, backgroundColor, EditorColors.thinLine);
        }

        public static void SectionHeader(Rect position, GUIContent label, Color backgroundColor, Color lineColor)
        {
            DrawSectionHeaderArea(position, backgroundColor, lineColor);
            Header(position, label);
        }

        public static void SectionHeader(Rect position, string label, Color backgroundColor, Color lineColor)
        {
            DrawSectionHeaderArea(position, backgroundColor, lineColor);
            Header(position, label);
        }

        public static bool SectionFoldout(Rect position, bool foldout, string label)
        {
            return SectionFoldout(position, foldout, label, EditorColors.helpBox, EditorColors.thinLine, true);
        }

        public static bool SectionFoldout(Rect position, bool foldout, GUIContent label)
        {
            return SectionFoldout(position, foldout, label, EditorColors.helpBox, EditorColors.thinLine, true);
        }

        public static bool SectionFoldout(Rect position, bool foldout, string label, bool toggleOnLabelClick)
        {
            return SectionFoldout(position, foldout, label, EditorColors.helpBox, EditorColors.thinLine,
                toggleOnLabelClick);
        }

        public static bool SectionFoldout(Rect position, bool foldout, GUIContent label, bool toggleOnLabelClick)
        {
            return SectionFoldout(position, foldout, label, EditorColors.helpBox, EditorColors.thinLine,
                toggleOnLabelClick);
        }

        public static bool SectionFoldout(Rect position, bool foldout, string label, Color backgroundColor,
            Color lineColor, bool toggleOnLabelClick)
        {
            SectionHeader(position, label, backgroundColor, lineColor);

            var value = FoldoutToggle(position, foldout);
            LucidGUIEvent.MouseDownEvent(position, () => value = !value);
            return value;
        }

        public static bool SectionFoldout(Rect position, bool foldout, GUIContent label, Color backgroundColor,
            Color lineColor, bool toggleOnLabelClick)
        {
            SectionHeader(position, label, backgroundColor, lineColor);

            var value = FoldoutToggle(position, foldout);
            LucidGUIEvent.MouseDownEvent(position, () => value = !value);
            return value;
        }

        private static void DrawSectionHeaderArea(Rect position, Color backgroundColor, Color lineColor)
        {
            var rect = position;
            rect.xMin -= 16f;
            rect.xMax += 16f;
            EditorGUI.DrawRect(rect, backgroundColor);
            Line(rect, lineColor);
            rect.y += rect.height;
            Line(rect, lineColor);
        }

        public static void Blockquote(Rect position, string label)
        {
            Blockquote(position, label, EditorStyles.label);
        }

        public static void Blockquote(Rect position, GUIContent label)
        {
            Blockquote(position, label, EditorStyles.label);
        }

        public static void Blockquote(Rect position, string label, GUIStyle style)
        {
            DrawQuoteLine(position, style);

            var labelPosition = position;
            labelPosition.xMin += 7f;
            EditorGUI.LabelField(labelPosition, label, style);
        }

        public static void Blockquote(Rect position, GUIContent label, GUIStyle style)
        {
            DrawQuoteLine(position, style);

            var labelPosition = position;
            labelPosition.xMin += 7f;
            EditorGUI.LabelField(labelPosition, label, style);
        }

        internal static void DrawQuoteLine(Rect position, GUIStyle style)
        {
            var blockRect = position;
            var backgroundColor = EditorColors.text;
            backgroundColor.a = 0.06f;
            EditorGUI.DrawRect(blockRect, backgroundColor);
            blockRect.x = position.xMin;
            blockRect.width = 3;
            EditorGUI.DrawRect(blockRect, EditorColors.text);
        }

        public static void ScriptField(Rect position, Object target)
        {
            EditorGUI.BeginDisabledGroup(true);
            if (target is MonoBehaviour)
                EditorGUI.ObjectField(position, "Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target),
                    typeof(MonoScript), false);
            else if (target is ScriptableObject)
                EditorGUI.ObjectField(position, "Script", MonoScript.FromScriptableObject((ScriptableObject)target),
                    typeof(MonoScript), false);
            EditorGUI.EndDisabledGroup();
        }

        public static void DrawBox(Rect rect)
        {
            DrawBox(rect, GUI.skin.box);
        }

        public static void DrawBox(Rect rect, GUIStyle style)
        {
            EditorGUI.LabelField(rect, GUIContent.none, style);
        }

        public static int Toolbar(Rect position, int selectedIndex, string[] displayedOptions)
        {
            return Toolbar(position, selectedIndex, displayedOptions, GUI.ToolbarButtonSize.Fixed);
        }

        public static int Toolbar(Rect position, int selectedIndex, string[] displayedOptions,
            GUI.ToolbarButtonSize toolbarButtonSize)
        {
            return GUI.Toolbar(position, selectedIndex, displayedOptions.Select(x => new GUIContent(x)).ToArray(),
                "LargeButton", toolbarButtonSize);
        }

        public static void BeginDisabledGroup(bool disabled)
        {
            EditorGUI.BeginDisabledGroup(disabled);
        }

        public static void EndDisabledGroup()
        {
            EditorGUI.EndDisabledGroup();
        }

        public static void BeginChangeCheck()
        {
            EditorGUI.BeginChangeCheck();
        }

        public static void EndChangeCheck()
        {
            EditorGUI.EndChangeCheck();
        }

        public static GUIContent BeginProperty(Rect totalPosition, GUIContent label, SerializedProperty property)
        {
            return EditorGUI.BeginProperty(totalPosition, label, property);
        }

        public static void EndProperty()
        {
            EditorGUI.EndProperty();
        }
    }
}