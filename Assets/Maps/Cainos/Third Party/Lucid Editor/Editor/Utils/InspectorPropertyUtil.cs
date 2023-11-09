using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Cainos.LucidEditor
{
    internal static class InspectorPropertyUtil
    {
        public static IEnumerable<InspectorProperty> CreateProperties(SerializedObject serializedObject)
        {
            var list = new List<InspectorProperty>();
            var iterator = serializedObject.GetIterator();

            iterator.NextVisible(true);
            while (iterator.NextVisible(false))
            {
                var ip = new InspectorField(iterator.Copy(), iterator.GetAttributes<Attribute>(true));
                list.Add(ip);
            }

            list.AddRange(CreateEditableProperties(serializedObject, serializedObject.targetObject));
            list.AddRange(CreateButtonsAndNonSerializedProperties(serializedObject, serializedObject.targetObject));

            return list;
        }

        public static IEnumerable<InspectorProperty> CreateChildProperties(InspectorField property)
        {
            var list = new List<InspectorProperty>();

            if (property.serializedProperty.hasVisibleChildren &&
                (property.serializedProperty.propertyType == SerializedPropertyType.Generic ||
                 property.serializedProperty.propertyType == SerializedPropertyType.ManagedReference) &&
                !property.serializedProperty.isArray &&
                !TypeUtil.HasCustomDrawerType(TypeUtil.GetType(property.serializedProperty.type)))
            {
                var iterator = property.serializedProperty.Copy();

                iterator.NextVisible(true);
                var depth = iterator.depth;
                list.Add(new InspectorField(iterator.Copy(), iterator.GetAttributes<Attribute>(true)));

                while (iterator.NextVisible(false))
                {
                    if (iterator.depth != depth) break;
                    list.Add(new InspectorField(iterator.Copy(), iterator.GetAttributes<Attribute>(true)));
                }

                var obj = property.serializedProperty.GetValue<object>();
                list.AddRange(
                    CreateButtonsAndNonSerializedProperties(property.serializedProperty.serializedObject, obj));
            }

            return list;
        }

        public static IEnumerable<InspectorProperty> CreateButtonsAndNonSerializedProperties(
            SerializedObject serializedObject, object targetObject)
        {
            var list = new List<InspectorProperty>();

            foreach (var memberInfo in ReflectionUtil.GetAllMembers(targetObject.GetType(), (BindingFlags)(-1), true))
                //field
                if (memberInfo is FieldInfo fieldInfo)
                {
                    if (fieldInfo.IsPublic || fieldInfo.GetCustomAttribute<SerializeField>() == null)
                    {
                        var showInInspector = fieldInfo.GetCustomAttribute<ShowInInspectorAttribute>();
                        if (showInInspector != null)
                            list.Add(new NonSerializedInspectorProperty(serializedObject, targetObject, fieldInfo.Name,
                                fieldInfo.GetCustomAttributes().ToArray()));
                    }
                }

                //property
                //modified: property is now handled in CreateEditableProperties to support editing
                //else if (memberInfo is PropertyInfo propertyInfo)
                //{
                //    MethodInfo getterInfo = propertyInfo.GetGetMethod();
                //    if (getterInfo != null)
                //    {
                //        if (getterInfo.IsPublic || propertyInfo.GetCustomAttribute<SerializeField>() == null)
                //        {
                //            ShowInInspectorAttribute showInInspector = propertyInfo.GetCustomAttribute<ShowInInspectorAttribute>();
                //            if (showInInspector != null)
                //            {
                //                list.Add(new NonSerializedInspectorProperty(serializedObject, targetObject, propertyInfo.Name, propertyInfo.GetCustomAttributes().ToArray()));
                //            }
                //        }
                //    }
                //}
                //method
                else if (memberInfo is MethodInfo methodInfo)
                {
                    var showInInspector = methodInfo.GetCustomAttribute<ShowInInspectorAttribute>();
                    if (showInInspector != null)
                        list.Add(new NonSerializedInspectorProperty(serializedObject, targetObject, methodInfo.Name,
                            methodInfo.GetCustomAttributes().ToArray()));

                    var buttonAttribute = methodInfo.GetCustomAttribute<ButtonAttribute>();
                    if (buttonAttribute != null)
                    {
                        InspectorButton ib;
                        if (string.IsNullOrEmpty(buttonAttribute.label))
                            ib = new InspectorButton(serializedObject, serializedObject.targetObject, methodInfo,
                                buttonAttribute.size);
                        else
                            ib = new InspectorButton(serializedObject, serializedObject.targetObject, methodInfo,
                                buttonAttribute.label, buttonAttribute.size);
                        list.Add(ib);
                    }
                }

            return list;
        }

        //draw editable property
        public static IEnumerable<InspectorProperty> CreateEditableProperties(SerializedObject serializedObject,
            object targetObject)
        {
            var list = new List<InspectorProperty>();

            foreach (var memberInfo in ReflectionUtil.GetAllMembers(targetObject.GetType(), (BindingFlags)(-1), true))
                if (memberInfo is PropertyInfo propertyInfo)
                {
                    var getterInfo = propertyInfo.GetGetMethod();
                    if (getterInfo != null)
                    {
                        var showInInspector = propertyInfo.GetCustomAttribute<ShowInInspectorAttribute>();
                        if (showInInspector != null)
                            list.Add(new EditableInspectorProperty(serializedObject, targetObject, propertyInfo.Name,
                                propertyInfo.GetCustomAttributes().ToArray()));
                    }
                }

            return list;
        }

        public static IEnumerable<InspectorProperty> GroupProperties(IEnumerable<InspectorProperty> properties)
        {
            var groupList = new List<List<InspectorProperty>>();

            var propertyList = new List<InspectorProperty>(properties);
            var usedProperties = new List<InspectorProperty>();

            var paDictionary = new Dictionary<InspectorProperty, List<PropertyGroupAttribute>>();
            foreach (var property in propertyList)
            {
                paDictionary.Add(property, new List<PropertyGroupAttribute>());
                paDictionary[property].AddRange(
                    property.attributes
                        .Where(x => x is PropertyGroupAttribute)
                        .Select(x => (PropertyGroupAttribute)x)
                );
            }

            var depth = 0;
            while (propertyList.Count > 0)
            {
                groupList.Add(new List<InspectorProperty>());

                foreach (var property in propertyList)
                {
                    var attribute = paDictionary[property].FirstOrDefault(x => x.groupDepth == depth);

                    if (attribute != null)
                    {
                        var hierarchy = attribute.path.Split('/');
                        var currentPath = string.Empty;
                        InspectorPropertyGroup group = null;

                        for (var i = 0; i < hierarchy.Length; i++)
                        {
                            currentPath += hierarchy[i];

                            var newGroup = groupList[i]
                                .Where(x => x is InspectorPropertyGroup)
                                .Select(x => (InspectorPropertyGroup)x)
                                .FirstOrDefault(x => x.path.Split('/')[i] == hierarchy[i]);

                            if (newGroup == null)
                            {
                                newGroup = new InspectorPropertyGroup(currentPath, property.serializedObject,
                                    attribute);
                                groupList[i].Add(newGroup);
                                group?.Add(newGroup);
                            }

                            group = newGroup;
                            currentPath += '/';
                        }

                        paDictionary[property].RemoveAll(x => x.groupDepth == depth);
                        if (paDictionary[property].Count == 0)
                        {
                            group.Add(property);
                            usedProperties.Add(property);
                        }
                    }
                    else if (paDictionary[property].Count == 0)
                    {
                        groupList[0].Add(property);
                        usedProperties.Add(property);
                    }
                }

                foreach (var property in usedProperties) propertyList.Remove(property);
                usedProperties.Clear();
                depth++;
            }

            return groupList.Count > 0 ? groupList[0] : new List<InspectorProperty>();
        }
    }
}