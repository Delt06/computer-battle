using DELTation.UI.Screens;
using UnityEngine;

namespace _Shared.UI
{
    public abstract class SingleScreenView<TPresenter> : View<TPresenter>
    {
        [SerializeField] private GameScreen _screen = default;

        public virtual void Show() => _screen.Open();

        public virtual void Hide() => _screen.Close();

        protected virtual void Reset()
        {
            if (_screen == null)
                _screen = GetComponentInChildren<GameScreen>();
            if (_screen == null)
                _screen = GetComponentInChildren<GameScreen>(true);
        }
    }
}