namespace Problems.UI
{
    public interface IProblemSolvingPresenter
    {
        void OnAnswerSelected(int selectedAnswerIndex);
        bool IsCorrect(int answerIndex);
        void Pause();
    }
}