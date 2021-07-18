using System.Reflection;
using DELTation.UI.Attributes;
using UnityEditor;
using UnityEngine;

namespace DELTation.UI.Editor
{
    public abstract class ConditionalShowPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var value = GetValueOrDefault(position, property);
            var show = true;

            if (value != null)
            {
                show = ShouldShow(value.Value);

                if (show)
                    EditorGUI.PropertyField(position, property);
            }

            _height = show ? EditorGUI.GetPropertyHeight(property, label) : 0f;
        }

        private bool? GetValueOrDefault(Rect position, SerializedProperty property)
        {
            var att = (IConditionShowAttribute) attribute;
            var serializedObject = property.serializedObject;
            var targetObject = EditorExt.GetTargetObjectOfProperty(property, 1);
            var fieldProperty = serializedObject.FindProperty(att.MemberName);
            if (fieldProperty != null)
            {
                if (fieldProperty.propertyType == SerializedPropertyType.Boolean)
                    return fieldProperty.boolValue;

                ShowError(position, $"Field {att.MemberName} is not boolean.");
                return null;
            }

            var type = targetObject.GetType();
            var propertyMember = type.GetProperty(att.MemberName, BindingFlags);
            if (propertyMember != null)
            {
                if (propertyMember.PropertyType == typeof(bool) && propertyMember.CanRead)
                    return (bool) propertyMember.GetValue(targetObject);

                ShowError(position, $"Property {att.MemberName} is not boolean or not readable.");
                return null;
            }

            var methodMember = type.GetMethod(att.MemberName, BindingFlags);
            if (methodMember != null)
            {
                if (methodMember.ReturnType == typeof(bool) && methodMember.GetParameters().Length == 0)
                    return (bool) methodMember.Invoke(targetObject, new object[0]);

                ShowError(position, $"Method {att.MemberName}'s return type is not boolean or it has parameters.");
                return null;
            }

            ShowError(position, $"Property {att.MemberName} was not found.");
            return null;
        }

        private static BindingFlags BindingFlags =>
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        private static void ShowError(Rect position, string message) =>
            EditorGUI.LabelField(position, "Error: " + message);

        protected abstract bool ShouldShow(bool propertyValue);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => _height;

        private float _height;
    }
}