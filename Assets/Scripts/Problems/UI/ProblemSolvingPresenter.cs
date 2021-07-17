using System;
using System.Text;
using Shared.UI;

namespace Problems.UI
{
    public class ProblemSolvingPresenter : Presenter<ProblemSolvingModel, IProblemSolvingView>, IDisposable,
        IProblemSolvingPresenter
    {
        private const string ProblemPostfix = "=?";
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public ProblemSolvingPresenter(ProblemSolvingModel model, IViewCollection viewCollection) : base(model,
            viewCollection
        )
        {
            View.Initialize(this);
            Model.Generated += Model_OnGenerated;
            Model.AnsweredCorrectly += Model_OnAnswered;
            Model.AnsweredIncorrectly += Model_OnAnswered;
            Model.RemainingTimeChanged += Model_OnRemainingTimeChanged;
            Model.GameEnded += Model_OnGameEnded;
        }

        public void Dispose()
        {
            Model.Generated -= Model_OnGenerated;
            Model.AnsweredCorrectly -= Model_OnAnswered;
            Model.AnsweredIncorrectly -= Model_OnAnswered;
            Model.RemainingTimeChanged -= Model_OnRemainingTimeChanged;
            Model.GameEnded -= Model_OnGameEnded;
        }

        public void OnAnswerSelected(int selectedAnswerIndex)
        {
            if (IsCorrect(selectedAnswerIndex))
                Model.OnAnsweredCorrectly();
            else
                Model.OnAnsweredIncorrectly();
        }

        public bool IsCorrect(int answerIndex)
        {
            var selectedAnswer = Model.Answers[answerIndex];
            var answerIsCorrect = selectedAnswer == Model.Problem.GetAnswer();
            return answerIsCorrect;
        }

        public void Pause() => Model.Pause();

        private void Model_OnGenerated()
        {
            View.Show();

            var problem = Model.Problem;
            _stringBuilder.Clear()
                .Append(problem.LeftNumber)
                .Append(OperationToString(problem.Operation))
                .Append(problem.RightNumber)
                .Append(ProblemPostfix);
            View.SetProblemText(_stringBuilder);

            for (var answerIndex = 0; answerIndex < Model.Answers.Count; answerIndex++)
            {
                var answer = Model.Answers[answerIndex];
                View.SetAnswerText(answerIndex, "{0:0}", answer);
            }

            View.OnGenerated();
        }

        private static string OperationToString(Operation operation) =>
            operation switch
            {
                Operation.Addition => "+",
                Operation.Subtraction => "-",
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null),
            };

        private void Model_OnAnswered()
        {
            View.Hide();
        }

        private void Model_OnRemainingTimeChanged()
        {
            var ratio = Model.RemainingTime / Model.TimeLimit;
            View.SetRemainingTimeRatio(ratio);
        }

        private void Model_OnGameEnded()
        {
            View.Hide();
        }
    }
}