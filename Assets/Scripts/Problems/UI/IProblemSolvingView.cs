using System.Text;
using JetBrains.Annotations;
using Shared.UI;

namespace Problems.UI
{
    public interface IProblemSolvingView : IView<IProblemSolvingPresenter>
    {
        void SetAnswerText(int answerIndex, [NotNull] string format, int answerValue);
        void SetProblemText([NotNull] StringBuilder text);
        void OnGenerated();
        void Show();
        void Hide();
    }
}