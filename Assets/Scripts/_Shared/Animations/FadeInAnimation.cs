using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Shared.Animations
{
    [RequireComponent(typeof(Graphic))]
    public sealed class FadeInAnimation : AnimationBase<float>
    {
        private Graphic _graphic;

        protected override void OnAwaken()
        {
            base.OnAwaken();
            _graphic = GetComponent<Graphic>();
        }

        protected override float State
        {
            get => _graphic.color.a;
            set
            {
                var color = _graphic.color;
                color.a = value;
                _graphic.color = color;
            }
        }

        protected override Tweener TweenTowards(float targetState, float duration) =>
            _graphic.DOFade(targetState, duration);
    }
}