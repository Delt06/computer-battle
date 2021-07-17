using JetBrains.Annotations;
using UnityEngine;

namespace Battle.Animations
{
	public class FighterAnimations : MonoBehaviour
	{
		private static readonly int BeganHittingId = Animator.StringToHash("BeganHitting");
		private static readonly int ReceivedDamageId = Animator.StringToHash("ReceivedDamage");
		private static readonly int DeadId = Animator.StringToHash("Dead");
		[SerializeField] private Fighter _fighter;
		[SerializeField] private Animator _animator;

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
		}

		private void OnDisable()
		{
			_fighter.BeganHittingOpponent -= Fighter_OnBeganHittingOpponent;
			_fighter.ReceivedDamage -= Fighter_OnReceivedDamage;
			_fighter.Died -= Fighter_OnDied;
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
	}
}