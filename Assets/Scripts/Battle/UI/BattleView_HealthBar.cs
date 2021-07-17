using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
	public class BattleView_HealthBar : MonoBehaviour
	{
		[SerializeField] private Slider _fillSlider;

		public Slider FillSlider => _fillSlider;

		private void Reset()
		{
			_fillSlider = GetComponentInChildren<Slider>();
		}
	}
}