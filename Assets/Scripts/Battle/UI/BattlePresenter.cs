using System;
using Shared.UI;

namespace Battle.UI
{
    public class BattlePresenter : Presenter<BattleModel, BattleView>, IBattlePresenter, IDisposable
    {
        private readonly HealthBarBinding _opponentHealthBarBinding;
        private readonly HealthBarBinding _playerHealthBarBinding;

        public BattlePresenter(BattleModel model, BattleView view) : base(model, view)
        {
            _playerHealthBarBinding = new HealthBarBinding(View.PlayerHealthBar, model.Player);
            _opponentHealthBarBinding = new HealthBarBinding(View.OpponentHealthBar, model.Opponent);
            Model.PlayerWon += Model_OnPlayerWon;
            Model.PlayerLost += Model_OnPlayerLost;
        }

        private void Model_OnPlayerWon()
        {
            View.Hide();
        }

        private void Model_OnPlayerLost()
        {
            View.Hide();
        }

        public void Dispose()
        {
            _playerHealthBarBinding.Dispose();
            _opponentHealthBarBinding.Dispose();
            Model.PlayerWon -= Model_OnPlayerWon;
            Model.PlayerLost -= Model_OnPlayerLost;
        }
    }

    public class HealthBarBinding : IDisposable
    {
        private readonly Fighter _fighter;
        private readonly BattleView_HealthBar _healthBar;

        public HealthBarBinding(BattleView_HealthBar healthBar, Fighter fighter)
        {
            _healthBar = healthBar;
            _fighter = fighter;
            UpdateFill();
            Health.ValueChanged += UpdateFill;
        }

        private Health Health => _fighter.Health;

        public void Dispose()
        {
            Health.ValueChanged -= UpdateFill;
        }

        private void UpdateFill()
        {
            var fillAmount = Health.Value / Health.MaxValue;
            _healthBar.SetFillAmount(fillAmount);
        }
    }
}