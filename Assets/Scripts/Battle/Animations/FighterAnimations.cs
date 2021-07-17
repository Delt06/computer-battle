using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

namespace Battle.Animations
{
    public class FighterAnimations : MonoBehaviour
    {
        [SerializeField] private Fighter _fighter;
        [SerializeField] private Animator _animator;
        [SerializeField] [Min(0f)] private float _celebratingDelay = 1f;

        private static readonly int BeganHittingId = Animator.StringToHash("BeganHitting");
        private static readonly int ReceivedDamageId = Animator.StringToHash("ReceivedDamage");
        private static readonly int DeadId = Animator.StringToHash("Dead");
        private static readonly int CelebratingId = Animator.StringToHash("Celebrating");

        private void Reset()
        {
            _fighter = GetComponentInParent<Fighter>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _fighter.BeganHittingOpponent += Fighter_OnBeganHittingOpponent;
            _fighter.ReceivedDamage += Fighter_OnReceivedDamage;
            _fighter.Died += Fighter_OnDied;
            _fighter.StartedCelebrating += Fighter_OnStartedCelebrating;
        }

        private void OnDisable()
        {
            _fighter.BeganHittingOpponent -= Fighter_OnBeganHittingOpponent;
            _fighter.ReceivedDamage -= Fighter_OnReceivedDamage;
            _fighter.Died -= Fighter_OnDied;
            _fighter.StartedCelebrating -= Fighter_OnStartedCelebrating;
        }

        [UsedImplicitly]
        public void OnHitOpponent()
        {
            _fighter.DealDamageToOpponent();
        }

        private void Fighter_OnBeganHittingOpponent()
        {
            _animator.SetTrigger(BeganHittingId);
        }

        private void Fighter_OnReceivedDamage()
        {
            _animator.SetTrigger(ReceivedDamageId);
        }

        private void Fighter_OnDied()
        {
            _animator.SetBool(DeadId, true);
        }

        private void Fighter_OnStartedCelebrating()
        {
            DOTween.Sequence()
                .AppendInterval(_celebratingDelay)
                .AppendCallback(() => _animator.SetBool(CelebratingId, true));
        }
    }
}