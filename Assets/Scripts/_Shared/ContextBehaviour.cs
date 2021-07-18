using System;
using _Shared.UI;
using JetBrains.Annotations;
using UnityEngine;

namespace _Shared
{
    public abstract class ContextBehaviour<TModel, TView, TPresenter> : MonoBehaviour, IContext<TModel>
        where TModel : class
        where TView : class, IView<TPresenter>
    {
        private IViewCollection _viewCollection;
        private TPresenter _presenter;

        public void Construct(IViewCollection viewCollection)
        {
            _viewCollection = viewCollection;
        }

        public TModel Model { get; private set; }

        protected void Awake()
        {
            Model = CreateModel();
            var view = _viewCollection.Get<TView>();
            _presenter = CreatePresenter(Model, view);
            view.Initialize(_presenter);
            OnAwaken();
        }

        [NotNull]
        protected abstract TModel CreateModel();

        [NotNull]
        protected abstract TPresenter CreatePresenter([NotNull] TModel model, [NotNull] TView view);

        protected virtual void OnAwaken() { }

        protected void OnDestroy()
        {
            if (Model is IDisposable disposableModel)
                disposableModel.Dispose();
            if (_presenter is IDisposable disposablePresenter)
                disposablePresenter.Dispose();
            OnDestroyed();
        }

        protected virtual void OnDestroyed() { }
    }
}