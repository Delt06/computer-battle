using _Shared;
using Battle;
using Problems;
using TapToPlay.UI;

namespace TapToPlay
{
    public class TapToPlayContext : ContextBehaviour<TapToPlayModel, TapToPlayView, TapToPlayPresenter>
    {
        private ProblemSolvingContext _problemSolvingContext;
        private BattleContext _battleContext;

        public void Construct(ProblemSolvingContext problemSolvingContext, BattleContext battleContext)
        {
            _problemSolvingContext = problemSolvingContext;
            _battleContext = battleContext;
        }

        protected override TapToPlayModel CreateModel() =>
            new TapToPlayModel(_problemSolvingContext.Model, _battleContext.Model);

        protected override TapToPlayPresenter CreatePresenter(TapToPlayModel model, TapToPlayView view) =>
            new TapToPlayPresenter(model, view);
    }
}