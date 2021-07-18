using DELTation.UI.Attributes;
using UnityEditor;

namespace DELTation.UI.Editor
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public sealed class ShowIfPropertyDrawer : ConditionalShowPropertyDrawer
    {
        protected override bool ShouldShow(bool propertyValue) => propertyValue;
    }
}