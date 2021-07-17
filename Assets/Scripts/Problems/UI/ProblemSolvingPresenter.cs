using System;
using System.Text;
using Shared.UI;

namespace Problems.UI
{
    public class ProblemSolvingPresenter : Presenter<ProblemSolvingModel, ProblemSolvingView>, IDisposable,
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
        }

        public void Dispose()
        {
            Model.Generated -= Model_OnGenerated;
            Model.AnsweredCorrectly -= Model_OnAnswered;
            Model.AnsweredIncorrectly -= Model_OnAnswered;
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

        private void Model_OnGenerated()
        {
            View.Show();

            var problem = Model.Problem;
            _stringBuilder.Clear()
                .Append(problem.LeftNumber)
                .Append(OperationToString(problem.Operation))
                .Append(problem.RightNumber)
                .Append(ProblemPostfix);
            View.ProblemText.SetText(_stringBuilder);

            var answerButtons = View.AnswerButtons;

            for (var index = 0; index < answerButtons.Length; index++)
            {
                var answerButton = answerButtons[index];
                var answer = Model.Answers[index];
                answerButton.Text.SetText("{0:0}", answer);
            }

            View.OnGenerated();
        }

        private void Model_OnAnswered()
        {
            View.Hide();
        }

        private static string OperationToString(Operation operation) =>
            operation switch
            {
                Operation.Addition => "+",
                Operation.Subtraction => "-",
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null),
            };
    }
}