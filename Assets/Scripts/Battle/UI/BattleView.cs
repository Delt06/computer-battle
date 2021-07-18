using _Shared.UI;
using UnityEngine;

namespace Battle.UI
{
    public class BattleView : SingleScreenView<IBattlePresenter>
    {
        [SerializeField] private BattleView_HealthBar _playerHealthBar;
        [SerializeField] private BattleView_HealthBar _opponentHealthBar;

        public BattleView_HealthBar PlayerHealthBar => _playerHealthBar;

        public BattleView_HealthBar OpponentHealthBar => _opponentHealthBar;
    }
}