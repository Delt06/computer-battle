using DG.Tweening;
using UnityEngine;

namespace _Shared.Animations
{
    public sealed class ScaleUpAnimation : AnimationBase<Vector3>
    {
        protected override Vector3 State
        {
            get => transform.localScale;
            set => transform.localScale = value;
        }

        protected override Tweener TweenTowards(Vector3 targetState, float duration) =>
            transform.DOScale(targetState, duration);
    }
}