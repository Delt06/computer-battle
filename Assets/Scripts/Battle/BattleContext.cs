using Battle.UI;
using Problems;
using Shared.UI;
using UnityEngine;

namespace Battle
{
    public class BattleContext : MonoBehaviour
    {
        [SerializeField] private ProblemSolvingContext _problemSolvingContext;
        [SerializeField] private Fighter _player;
        [SerializeField] private Fighter _opponent;

        private BattleModel _model;
        private IBattlePresenter _presenter;
        private IViewCollection _viewCollection;

        public void Construct(IViewCollection viewCollection)
        {
            _viewCollection = viewCollection;
        }

        private ProblemSolvingModel ProblemSolvingModel => _problemSolvingContext.Model;

        private void Awake()
        {
            _player.Init(_opponent);
            _opponent.Init(_player);

            _model = new BattleModel(_player, _opponent);
            _presenter = new BattlePresenter(_model, _viewCollection);
        }

        private void Start()
        {
            ProblemSolvingModel.AnsweredCorrectly += Model_OnAnsweredCorrectly;
            ProblemSolvingModel.AnsweredIncorrectly += Model_OnAnsweredIncorrectly;
            _player.DealtDamageToOpponent += Fighter_OnDealtDamageToOpponent;
            _opponent.DealtDamageToOpponent += Fighter_OnDealtDamageToOpponent;
        }

        private void OnDestroy()
        {
            ProblemSolvingModel.AnsweredCorrectly -= Model_OnAnsweredCorrectly;
            ProblemSolvingModel.AnsweredIncorrectly -= Model_OnAnsweredIncorrectly;
            _player.DealtDamageToOpponent -= Fighter_OnDealtDamageToOpponent;
            _opponent.DealtDamageToOpponent -= Fighter_OnDealtDamageToOpponent;
        }

        private void Model_OnAnsweredCorrectly() => _player.HitOpponent();

        private void Model_OnAnsweredIncorrectly() => _opponent.HitOpponent();

        private void Fighter_OnDealtDamageToOpponent()
        {
            if (_model.Player.Health.IsDead || _model.Opponent.Health.IsDead) return;
            ProblemSolvingModel.Generate();
        }
    }
}