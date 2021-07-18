namespace DELTation.UI.Animations.Tweeners
{
    public interface IScreenTweener
    {
        void Open();
        void Close();
        void CloseImmediately();

        void Update(float deltaTime);
    }
}