namespace DELTation.UI.Screens
{
    public interface IScreenListener
    {
        bool ShouldBeAwaited { get; }
        void OnUpdate(IGameScreen gameScreen, float deltaTime);
        void OnOpened(IGameScreen gameScreen);
        void OnClosed(IGameScreen gameScreen);
        void OnClosedImmediately(IGameScreen gameScreen);
    }
}