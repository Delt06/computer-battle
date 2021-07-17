using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    public class BattleView_HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _fillSlider;

        public void SetFillAmount(float fillAmount) => _fillSlider.value = fillAmount;

        private void Reset()
        {
            _fillSlider = GetComponentInChildren<Slider>();
        }
    }
}