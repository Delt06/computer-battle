using DELTation.UI.Animations.Tweeners;
using DELTation.UI.Animations.Tweeners.Properties;
using UnityEngine;

namespace DELTation.UI.Animations
{
    public sealed class ScreenLocalRotationAnimation : ScreenAnimation<Vector3, Quaternion>
    {
        protected override ScreenTweener<Quaternion> CreateTweener(Vector3? openState, Vector3 closedState) =>
            new LocalRotationScreenTweener(transform,
                openState.HasValue ? Quaternion.Euler(openState.Value) : (Quaternion?) null,
                Quaternion.Euler(closedState)
            );
    }
}