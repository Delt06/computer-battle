using System;
using System.Collections;
using System.Reflection;
using UnityEditor;
using static System.Convert;

namespace DELTation.UI.Editor
{
    public static class EditorExt
    {
        public static object GetTargetObjectOfProperty(SerializedProperty property, int remainingDepth = 0)
        {
            if (property == null) return null;

            var path = property.propertyPath.Replace(".Array.data[", "[");
            object obj = property.serializedObject.targetObject;
            var elements = path.Split('.');
            for (var i = 0; i < elements.Length - remainingDepth; i++)
            {
                var element = elements[i];
                if (element.Contains("["))
                {
                    var indexOfBracket = element.IndexOf("[", StringComparison.InvariantCulture);
                    var elementName = element.Substring(0, indexOfBracket);
                    var index = ToInt32(element.Substring(indexOfBracket).Replace("[", "")
                        .Replace("]", "")
                    );
                    obj = GetValue(obj, elementName, index);
                }
                else
                {
                    obj = GetValue(obj, element);
                }
            }

            return obj;
        }

        private static object GetValue(object source, string name)
        {
            if (source == null)
                return null;
            var type = source.GetType();

            while (type != null)
            {
                var field = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                if (field != null) return field.GetValue(source);

                var property = type.GetProperty(name,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
                );
                if (property != null) return property.GetValue(source, null);

                type = type.BaseType;
            }

            return null;
        }

        private static object GetValue(object source, string name, int index)
        {
            if (!(GetValue(source, name) is IEnumerable enumerable)) return null;

            var enumerator = enumerable.GetEnumerator();

            for (var i = 0; i <= index; i++)
            {
                if (!enumerator.MoveNext()) return null;
            }

            return enumerator.Current;
        }
    }
}