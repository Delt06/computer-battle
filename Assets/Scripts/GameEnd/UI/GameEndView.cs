using _Shared.UI;
using DELTation.UI.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace GameEnd.UI
{
    public class GameEndView : View<GameEndPresenter>
    {
        [SerializeField] private GameScreen _winScreen;
        [SerializeField] private GameScreen _loseScreen;
        [SerializeField] private Button _nextButton = default;
        [SerializeField] private Button _retryButton = default;

        public void ShowWinScreen()
        {
            _winScreen.Open();
        }

        public void ShowLoseScreen()
        {
            _loseScreen.Open();
        }

        private void OnEnable()
        {
            _nextButton.onClick.AddListener(NextButton_OnClick);
            _retryButton.onClick.AddListener(RetryButton_OnClick);
        }

        private void OnDisable()
        {
            _nextButton.onClick.RemoveListener(NextButton_OnClick);
            _retryButton.onClick.RemoveListener(RetryButton_OnClick);
        }

        private void NextButton_OnClick()
        {
            Presenter.OnNextButtonClicked();
        }

        private void RetryButton_OnClick()
        {
            Presenter.OnRetryButtonClicked();
        }
    }
}