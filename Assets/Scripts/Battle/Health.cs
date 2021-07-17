using System;
using UnityEngine;

namespace Battle
{
	public class Health
	{
		private float _value;

		public Health(float maxValue)
		{
			MaxValue = maxValue;
			_value = maxValue;
		}

		public float MaxValue { get; }

		public float Value
		{
			get => _value;
			set
			{
				if (IsDead) return;
				value = Mathf.Clamp(value, 0, MaxValue);
				if (Mathf.Approximately(_value, value)) return;

				_value = value;
				ValueChanged?.Invoke();

				if (Mathf.Approximately(_value, 0f))
				{
					IsDead = true;
					Died?.Invoke();
				}
			}
		}

		public bool IsDead { get; private set; }

		public event Action ValueChanged;
		public event Action Died;
	}
}