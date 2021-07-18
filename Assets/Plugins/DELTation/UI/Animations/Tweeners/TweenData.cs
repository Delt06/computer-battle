using System;
using DELTation.Easing;
using DELTation.UI.Attributes;
using UnityEngine;

namespace DELTation.UI.Animations.Tweeners
{
    [Serializable]
    public class TweenData
    {
        [Min(0f)] public float Delay = 0f;
        [Min(0f)] public float Duration = 0f;
        [HideIf(nameof(DurationIsZero))] public Ease Ease = Ease.Linear;

        [HideIf(nameof(DurationIsZero))] [Min(0f)]
        public float Overshoot = 1.7f;

        private bool DurationIsZero => Mathf.Approximately(Duration, 0f);

        public void Deconstruct(out float delay, out float duration, out Ease ease, out float overshoot)
        {
            delay = Delay;
            duration = Duration;
            ease = Ease;
            overshoot = Overshoot;
        }

        public void CopyTo(TweenData tweenData)
        {
            (tweenData.Delay, tweenData.Duration, tweenData.Ease, tweenData.Overshoot) = this;
        }
    }

    public sealed class TweenStateData<T> : TweenData
    {
        public readonly T State;

        public TweenStateData(T state) => State = state;

        public TweenStateData(TweenData baseData, T state)
        {
            baseData.CopyTo(this);
            State = state;
        }

        public void Deconstruct(out float delay, out float duration, out Ease ease, out float overshoot, out T state)
        {
            (delay, duration, ease, overshoot) = this;
            state = State;
        }
    }
}