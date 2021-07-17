using Problems.UI;
using Shared;
using Shared.UI;
using UnityEngine;
using Random = System.Random;

namespace Problems
{
    public class ProblemSolvingContext : ContextBehaviour<ProblemSolvingModel, IProblemSolvingPresenter>
    {
        [SerializeField] [Min(1)] private int _answersNumber = 4;
        [SerializeField] [Range(0f, 1f)] private float _maxDeviationFromRightAnswer = 0.25f;
        [SerializeField] [Min(0f)] private float _timeLimit = 1.0f;

        private void Update()
        {
            Model.UpdateTime(Time.deltaTime);
        }

        private void Start()
        {
            Model.Generate();
        }

        protected override ProblemSolvingModel CreateModel()
        {
            var problemFactory = new RandomProblemFactory(new Random());
            var answerFactory = new RandomAnswerFactory(new Random(), _maxDeviationFromRightAnswer);
            return new ProblemSolvingModel(problemFactory, answerFactory, _answersNumber, _timeLimit);
        }

        protected override IProblemSolvingPresenter CreatePresenter(ProblemSolvingModel model,
            IViewCollection viewCollection) => new ProblemSolvingPresenter(model, viewCollection);
    }
}