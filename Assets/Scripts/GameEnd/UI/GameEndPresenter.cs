using System;
using Shared.UI;

namespace GameEnd.UI
{
    public class GameEndPresenter : Presenter<GameEndModel, GameEndView>, IDisposable
    {
        public GameEndPresenter(GameEndModel model, GameEndView view) : base(model, view)
        {
            Model.Won += Model_OnWon;
            Model.Lost += Model_OnLost;
        }

        private void Model_OnWon() => View.ShowWinScreen();

        private void Model_OnLost() => View.ShowLoseScreen();

        public void Dispose()
        {
            Model.Won -= Model_OnWon;
            Model.Lost -= Model_OnLost;
        }

        public void OnNextButtonClicked()
        {
            Model.LoadNextLevel();
        }

        public void OnRetryButtonClicked()
        {
            Model.ReloadCurrentLevel();
        }
    }
}