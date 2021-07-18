using UnityEngine;

namespace DELTation.UI.Animations.Tweeners.Types
{
    public abstract class Vector3ScreenTweener : ScreenTweener<Vector3>
    {
        protected Vector3ScreenTweener(Vector3 openState, Vector3 closedState) : base(openState, closedState) { }

        protected sealed override Vector3 InterpolateValuesUnclamped(Vector3 value1, Vector3 value2, float t) =>
            Vector3.LerpUnclamped(value1, value2, t);
    }
}