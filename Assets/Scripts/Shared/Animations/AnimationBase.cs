using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

namespace Shared.Animations
{
    public abstract class AnimationBase<TState> : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _delay;
        [SerializeField] [Min(0f)] private float _duration = 0.25f;
        [SerializeField] private Ease _ease = Ease.InOutQuad;
        [SerializeField] [Min(0f)] private float _overshoot = 2f;

        private TState _initialState;

        protected void OnEnable()
        {
            OnEnabled();
            this.DOKill();

            State = ZeroState;
            DOTween.Sequence()
                .SetRecyclable(true)
                .SetId(this)
                .AppendInterval(_delay)
                .Append(TweenTowards(_initialState, _duration).SetEase(_ease, _overshoot));
        }

        protected abstract TState State { get; set; }
        protected virtual TState ZeroState => default;

        protected abstract Tweener TweenTowards(TState targetState, float duration);

        protected virtual void OnEnabled() { }

        protected void OnDisable()
        {
            OnDisabled();
            this.DOKill();
        }

        protected virtual void OnDisabled() { }

        protected void Awake()
        {
            OnAwaken();
            _initialState = State;
        }


        protected virtual void OnAwaken() { }
    }
}