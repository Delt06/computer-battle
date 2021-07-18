using Battle;
using Problems;

namespace TapToPlay
{
    public class TapToPlayModel
    {
        private readonly ProblemSolvingModel _problemSolvingModel;
        private readonly BattleModel _battleModel;
        private bool _tapped;

        public TapToPlayModel(ProblemSolvingModel problemSolvingModel, BattleModel battleModel)
        {
            _battleModel = battleModel;
            _problemSolvingModel = problemSolvingModel;
        }

        public void OnTapped()
        {
            if (_tapped) return;
            _tapped = true;
            _problemSolvingModel.Generate();
            _battleModel.Start();
        }
    }
}