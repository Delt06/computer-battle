using _Shared.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TapToPlay.UI
{
    public class TapToPlayView : View<TapToPlayPresenter>
    {
        [SerializeField] private Button _tapArea = default;

        public void Hide() => _tapArea.gameObject.SetActive(false);

        private void OnEnable()
        {
            _tapArea.onClick.AddListener(TapArea_OnClick);
        }

        private void OnDisable()
        {
            _tapArea.onClick.RemoveListener(TapArea_OnClick);
        }

        private void TapArea_OnClick() => Presenter.OnTapped();
    }
}