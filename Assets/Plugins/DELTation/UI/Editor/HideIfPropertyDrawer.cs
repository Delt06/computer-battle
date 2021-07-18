using DELTation.UI.Attributes;
using UnityEditor;

namespace DELTation.UI.Editor
{
    [CustomPropertyDrawer(typeof(HideIfAttribute))]
    public sealed class HideIfPropertyDrawer : ConditionalShowPropertyDrawer
    {
        protected override bool ShouldShow(bool propertyValue) => !propertyValue;
    }
}