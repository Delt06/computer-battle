using DG.Tweening;
using UnityEngine;

namespace TapToPlay.UI
{
    public sealed class TapToPlayTextAnimation : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _delay;
        [SerializeField] [Min(0f)] private float _period = 0.25f;
        [SerializeField] private Ease _upEase = Ease.InOutQuad;
        [SerializeField] private Ease _downEase = Ease.InOutQuad;
        [SerializeField] [Min(0f)] private float _smallScale = 0.75f;
        [SerializeField] [Min(0f)] private float _overshoot = 2f;

        private Vector3 _initialScale;

        private void OnEnable()
        {
            this.DOKill();
            transform.localScale = Vector3.zero;
            var halfPeriod = _period * 0.5f;
            DOTween.Sequence()
                .SetId(this)
                .SetRecyclable(true)
                .AppendInterval(_delay)
                .Append(transform.DOScale(_initialScale, halfPeriod).SetEase(_upEase, _overshoot))
                .Append(transform.DOScale(SmallScale, halfPeriod).SetEase(_downEase, _overshoot)
                    .SetLoops(int.MaxValue, LoopType.Yoyo)
                );
        }

        private Vector3 SmallScale => _initialScale * _smallScale;

        private void OnDisable()
        {
            this.DOKill();
        }

        private void Awake()
        {
            _initialScale = transform.localScale;
        }
    }
}