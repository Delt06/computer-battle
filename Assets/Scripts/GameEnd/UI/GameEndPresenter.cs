using System;
using Shared.UI;

namespace GameEnd.UI
{
    public class GameEndPresenter : Presenter<GameEndModel, GameEndView>, IDisposable
    {
        public GameEndPresenter(GameEndModel model, IViewCollection viewCollection) : base(model, viewCollection)
        {
            Model.Won += Model_OnWon;
            Model.Lost += Model_OnLost;
        }

        protected override void InitializeView(GameEndView view)
        {
            View.Initialize(this);
        }

        private void Model_OnWon() => View.ShowWinScreen();

        private void Model_OnLost() => View.ShowLoseScreen();

        public void Dispose()
        {
            Model.Won -= Model_OnWon;
            Model.Lost -= Model_OnLost;
        }
    }
}