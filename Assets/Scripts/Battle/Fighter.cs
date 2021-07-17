using System;
using UnityEngine;

namespace Battle
{
    public class Fighter : MonoBehaviour, IHittable
    {
        [SerializeField] [Min(0f)] private float _initialHealth = 100f;
        [SerializeField] [Min(0f)] private float _damage = 1f;

        private IHittable _opponent;

        public Health Health { get; private set; }
        private FighterState State { get; set; } = FighterState.Idle;

        private void OnDestroy()
        {
            if (Health != null)
                Health.Died -= Health_OnDied;
        }

        public event Action ReceivedDamage;

        public void ReceiveDamage(float damage)
        {
            Health.Value -= damage;
            ReceivedDamage?.Invoke();
        }

        public void Init(IHittable opponent)
        {
            _opponent = opponent;
            Health = new Health(_initialHealth);
            Health.Died += Health_OnDied;
        }

        private void Health_OnDied()
        {
            switch (State)
            {
                case FighterState.Idle:
                case FighterState.Attacking:
                    State = FighterState.Dead;
                    Died?.Invoke();
                    break;
            }
        }

        public event Action Died;

        public void StartCelebrating()
        {
            switch (State)
            {
                case FighterState.Idle:
                case FighterState.Attacking:
                    State = FighterState.Celebrating;
                    StartedCelebrating?.Invoke();
                    break;
            }
        }

        public event Action StartedCelebrating;

        public void HitOpponent()
        {
            if (State != FighterState.Idle) return;
            State = FighterState.Attacking;
            BeganHittingOpponent?.Invoke();
        }

        public event Action BeganHittingOpponent;

        public void DealDamageToOpponent()
        {
            if (State != FighterState.Attacking) return;
            _opponent.ReceiveDamage(_damage);
            State = FighterState.Idle;
            DealtDamageToOpponent?.Invoke();
        }

        public event Action DealtDamageToOpponent;
    }
}