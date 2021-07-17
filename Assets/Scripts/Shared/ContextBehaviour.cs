using System;
using Shared.UI;
using UnityEngine;

namespace Shared
{
    public abstract class ContextBehaviour<TModel, TPresenter> : MonoBehaviour, IContext<TModel>
        where TModel : class where TPresenter : class
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
            _presenter = CreatePresenter(Model, _viewCollection);
            OnAwaken();
        }

        protected abstract TModel CreateModel();

        protected abstract TPresenter CreatePresenter(TModel model, IViewCollection viewCollection);

        protected virtual void OnAwaken() { }

        protected void OnDestroy()
        {
            if (Model is IDisposable disposableModel)
                disposableModel.Dispose();
            if (_presenter is IDisposable disposablePresenter)
                disposablePresenter.Dispose();
        }

        protected virtual void OnDestroyed() { }
    }
}