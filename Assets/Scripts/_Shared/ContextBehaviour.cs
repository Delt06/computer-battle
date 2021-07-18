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
        private TModel _model;
        private IViewCollection _viewCollection;
        private TPresenter _presenter;
        private bool _isInitialized;

        public void Construct(IViewCollection viewCollection)
        {
            _viewCollection = viewCollection;
        }

        public TModel Model
        {
            get
            {
                EnsureInitialized();
                return _model;
            }
        }

        protected void Awake()
        {
            EnsureInitialized();
        }

        private void EnsureInitialized()
        {
            if (_isInitialized) return;
            _isInitialized = true;
            _model = CreateModel();
            var view = _viewCollection.Get<TView>();
            _presenter = CreatePresenter(_model, view);
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