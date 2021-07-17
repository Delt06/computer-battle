using System;
using DG.Tweening;
using UnityEngine;

namespace Shared.UI
{
	public class ScaleUpAnimation : MonoBehaviour
	{
		[SerializeField, Min(0f)] private float _delay;
		[SerializeField, Min(0f)] private float _duration = 0.25f;
		[SerializeField] private Ease _ease = Ease.InOutQuad;
		[SerializeField, Min(0f)] private float _overshoot = 2f;

		private Vector3 _initialScale;

		private void Awake()
		{
			_initialScale = transform.localScale;
		}

		private void OnEnable()
		{
			this.DOKill();

			transform.localScale = Vector3.zero;
			DOTween.Sequence()
				.SetId(this)
				.AppendInterval(_delay)
				.Append(transform.DOScale(_initialScale, _duration).SetEase(_ease, _overshoot));
		}

		private void OnDisable()
		{
			this.DOKill();
		}
	}
}