using DELTation.UI.Animations.Tweeners;
using DELTation.UI.Animations.Tweeners.Properties;
using UnityEngine;

namespace DELTation.UI.Animations
{
    public sealed class ScreenScaleAnimation : ScreenAnimation<Vector3, Vector3>
    {
        protected override ScreenTweener<Vector3> CreateTweener(Vector3? openState, Vector3 closedState) =>
            new ScaleScreenTweener(transform, openState, closedState);
    }
}