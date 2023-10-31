using System.Collections.Generic;
using UnityEditor;

namespace Cainos.LucidEditor
{
    public static class LucidEditorPrefs
    {
        public static bool HasKey<T>(string key)
        {
            return EditorPrefs.HasKey(key);
        }

        public static void DeleteKey(string key)
        {
            EditorPrefs.DeleteKey(key);
        }

        public static T Get<T>(string key)
        {
            var defaultValue = default(T);
            var data = EditorPrefs.GetString(key);
            if (string.IsNullOrEmpty(data)) return defaultValue;

            switch (defaultValue)
            {
                case long longValue:
                    return GenericTypeConverter<T>.Convert(long.Parse(data));
                case int intValue:
                    return GenericTypeConverter<T>.Convert(int.Parse(data));
                case float floatValue:
                    return GenericTypeConverter<T>.Convert(float.Parse(data));
                case double doubleValue:
                    return GenericTypeConverter<T>.Convert(double.Parse(data));
                case bool boolValue:
                    return GenericTypeConverter<T>.Convert(bool.Parse(data));
                case string stringValue:
                    return GenericTypeConverter<T>.Convert(data);
                default:
                    object obj = defaultValue;
                    EditorJsonUtility.FromJsonOverwrite(data, obj);
                    return (T)obj;
            }
        }

        public static void Set<T>(string key, T value)
        {
            string data = null;
            switch (value)
            {
                case long longValue:
                case int intValue:
                case double doubleValue:
                case float floatValue:
                case bool boolValue:
                case string stringValue:
                    data = value.ToString();
                    break;
                default:
                    data = EditorJsonUtility.ToJson(value);
                    break;
            }

            EditorPrefs.SetString(key, data);
        }

        public static bool HasConfigValueKey(string key)
        {
            return EditorUserSettings.GetConfigValue(key) != null;
        }

        public static T GetConfigValue<T>(string key)
        {
            var defaultValue = default(T);
            var data = EditorUserSettings.GetConfigValue(key);
            if (string.IsNullOrEmpty(data)) return defaultValue;

            switch (defaultValue)
            {
                case long longValue:
                    return GenericTypeConverter<T>.Convert(long.Parse(data));
                case int intValue:
                    return GenericTypeConverter<T>.Convert(int.Parse(data));
                case float floatValue:
                    return GenericTypeConverter<T>.Convert(float.Parse(data));
                case double doubleValue:
                    return GenericTypeConverter<T>.Convert(double.Parse(data));
                case bool boolValue:
                    return GenericTypeConverter<T>.Convert(bool.Parse(data));
                case string stringValue:
                    return GenericTypeConverter<T>.Convert(data);
                default:
                    object obj = defaultValue;
                    EditorJsonUtility.FromJsonOverwrite(data, obj);
                    return (T)obj;
            }
        }

        public static void SetConfigValue<T>(string key, T value)
        {
            string data = null;
            switch (value)
            {
                case long longValue:
                case int intValue:
                case double doubleValue:
                case float floatValue:
                case bool boolValue:
                case string stringValue:
                    data = value.ToString();
                    break;
                default:
                    data = EditorJsonUtility.ToJson(value);
                    break;
            }

            EditorUserSettings.SetConfigValue(key, data);
        }

        public static LocalPersistentData<T> CreateLocalPersistentData<T>(string key)
        {
            return new LocalPersistentData<T>(key);
        }

        public static GlobalPersistentData<T> CreateGlobalPersistentData<T>(string key)
        {
            return new GlobalPersistentData<T>(key);
        }
    }

    public sealed class GlobalPersistentData<T>
    {
        private readonly EqualityComparer<T> comparer = EqualityComparer<T>.Default;

        private readonly string key;
        private T value;

        internal GlobalPersistentData(string key)
        {
            this.key = key;
            value = LucidEditorPrefs.Get<T>(key);
        }

        public T Value
        {
            get => value;
            set
            {
                if (!comparer.Equals(this.value, value)) LucidEditorPrefs.Set(key, value);
                this.value = value;
            }
        }
    }

    public sealed class LocalPersistentData<T>
    {
        private readonly EqualityComparer<T> comparer = EqualityComparer<T>.Default;

        private readonly string key;
        private T value;

        internal LocalPersistentData(string key)
        {
            this.key = key;
            value = LucidEditorPrefs.Get<T>(key);
        }

        public T Value
        {
            get => value;
            set
            {
                if (!comparer.Equals(this.value, value)) LucidEditorPrefs.Set(key, value);
                this.value = value;
            }
        }
    }
}