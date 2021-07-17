using Battle.UI;
using Problems;
using Shared;
using Shared.UI;
using UnityEngine;

namespace Battle
{
    public class BattleContext : ContextBehaviour<BattleModel, BattlePresenter>
    {
        [SerializeField] private Fighter _player;
        [SerializeField] private Fighter _opponent;

        private IContext<ProblemSolvingModel> _problemSolvingContext;

        public void Construct(IContext<ProblemSolvingModel> problemSolvingContext)
        {
            _problemSolvingContext = problemSolvingContext;
        }

        protected override BattleModel CreateModel()
        {
            _player.Init(_opponent);
            _opponent.Init(_player);
            return new BattleModel(_player, _opponent);
        }

        protected override BattlePresenter CreatePresenter(BattleModel model, IViewCollection viewCollection) =>
            new BattlePresenter(model, viewCollection);

        private void Start()
        {
            ProblemSolvingModel.AnsweredCorrectly += ProblemSolvingModel_OnAnsweredCorrectly;
            ProblemSolvingModel.AnsweredIncorrectly += ProblemSolvingModel_OnAnsweredIncorrectly;
            _player.DealtDamageToOpponent += Fighter_OnDealtDamageToOpponent;
            _opponent.DealtDamageToOpponent += Fighter_OnDealtDamageToOpponent;
            Model.PlayerLost += Model_OnPlayerLost;
            Model.PlayerWon += Model_OnPlayerWon;
        }

        protected override void OnDestroyed()
        {
            base.OnDestroyed();
            ProblemSolvingModel.AnsweredCorrectly -= ProblemSolvingModel_OnAnsweredCorrectly;
            ProblemSolvingModel.AnsweredIncorrectly -= ProblemSolvingModel_OnAnsweredIncorrectly;
            _player.DealtDamageToOpponent -= Fighter_OnDealtDamageToOpponent;
            _opponent.DealtDamageToOpponent -= Fighter_OnDealtDamageToOpponent;
            Model.PlayerLost -= Model_OnPlayerLost;
            Model.PlayerWon -= Model_OnPlayerWon;
        }

        private ProblemSolvingModel ProblemSolvingModel => _problemSolvingContext.Model;

        private void ProblemSolvingModel_OnAnsweredCorrectly() => _player.HitOpponent();

        private void ProblemSolvingModel_OnAnsweredIncorrectly() => _opponent.HitOpponent();

        private void Fighter_OnDealtDamageToOpponent()
        {
            if (Model.Player.Health.IsDead || Model.Opponent.Health.IsDead) return;
            ProblemSolvingModel.Generate();
        }

        private void Model_OnPlayerLost() => ProblemSolvingModel.EndGame();

        private void Model_OnPlayerWon() => ProblemSolvingModel.EndGame();
    }
}