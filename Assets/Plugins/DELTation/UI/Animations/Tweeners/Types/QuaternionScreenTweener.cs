using UnityEngine;

namespace DELTation.UI.Animations.Tweeners.Types
{
    public abstract class QuaternionScreenTweener : ScreenTweener<Quaternion>
    {
        protected QuaternionScreenTweener(Quaternion openState, Quaternion closedState) :
            base(openState, closedState) { }

        protected override Quaternion InterpolateValuesUnclamped(Quaternion value1, Quaternion value2, float t) =>
            Quaternion.Slerp(value1, value2, t);
    }
}