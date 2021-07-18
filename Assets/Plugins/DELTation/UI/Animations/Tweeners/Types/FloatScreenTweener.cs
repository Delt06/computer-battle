using UnityEngine;

namespace DELTation.UI.Animations.Tweeners.Types
{
    public abstract class FloatScreenTweener : ScreenTweener<float>
    {
        protected FloatScreenTweener(float openState, float closedState) : base(openState, closedState) { }

        protected sealed override float InterpolateValuesUnclamped(float value1, float value2, float t) =>
            Mathf.LerpUnclamped(value1, value2, t);
    }
}