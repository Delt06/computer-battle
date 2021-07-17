using Battle;
using GameEnd.UI;
using Shared;

namespace GameEnd
{
    public class GameEndContext : ContextBehaviour<GameEndModel, GameEndPresenter, GameEndView>
    {
        private IContext<BattleModel> _battleContext;

        public void Construct(IContext<BattleModel> battleContext)
        {
            _battleContext = battleContext;
        }

        private void Start()
        {
            BattleModel.PlayerWon += BattleModel_OnPlayerWon;
            BattleModel.PlayerLost += BattleModel_OnPlayerLost;
        }

        private BattleModel BattleModel => _battleContext.Model;

        private void BattleModel_OnPlayerWon() => Model.OnWon();
        private void BattleModel_OnPlayerLost() => Model.OnLost();


        protected override GameEndModel CreateModel() => new GameEndModel();

        protected override GameEndPresenter CreatePresenter(GameEndModel model, GameEndView view) =>
            new GameEndPresenter(model, view);

        protected override void InitializeView(GameEndView view, GameEndPresenter presenter)
        {
            view.Initialize(presenter);
        }

        protected override void OnDestroyed()
        {
            base.OnDestroyed();
            BattleModel.PlayerWon -= BattleModel_OnPlayerWon;
            BattleModel.PlayerLost -= BattleModel_OnPlayerLost;
        }
    }
}