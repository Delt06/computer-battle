using UnityEngine;

namespace DELTation.UI.Screens
{
    public abstract class OpenScreenBehaviour : MonoBehaviour, IScreenListener
    {
        bool IScreenListener.ShouldBeAwaited => false;

        void IScreenListener.OnUpdate(IGameScreen gameScreen, float deltaTime)
        {
            if (!gameScreen.IsOpened) return;
            OnUpdate(deltaTime);
        }

        protected abstract void OnUpdate(float deltaTime);

        void IScreenListener.OnOpened(IGameScreen gameScreen) { }

        void IScreenListener.OnClosed(IGameScreen gameScreen) { }
        void IScreenListener.OnClosedImmediately(IGameScreen gameScreen) { }
    }
}