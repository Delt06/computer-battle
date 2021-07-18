using _Shared.UI;
using UnityEngine;

namespace Battle.UI
{
    public class BattleView : View<IBattlePresenter>
    {
        [SerializeField] private bool _showOnAwake;
        [SerializeField] private GameObject _contentRoot = default;
        [SerializeField] private BattleView_HealthBar _playerHealthBar;
        [SerializeField] private BattleView_HealthBar _opponentHealthBar;

        public BattleView_HealthBar PlayerHealthBar => _playerHealthBar;

        public BattleView_HealthBar OpponentHealthBar => _opponentHealthBar;

        public void Show() => _contentRoot.SetActive(true);

        public void Hide() => _contentRoot.SetActive(false);

        private void Awake()
        {
            if (_showOnAwake)
                Show();
            else
                Hide();
        }
    }
}