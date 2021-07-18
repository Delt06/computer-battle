using UnityEngine;

namespace _Shared.UI
{
    public abstract class View<TPresenter> : MonoBehaviour, IView<TPresenter>
    {
        protected TPresenter Presenter { get; private set; }

        public void Initialize(TPresenter presenter) => Presenter = presenter;
    }
}