﻿using System;
using JetBrains.Annotations;
using Shared.UI;
using UnityEngine;

namespace Shared
{
    public abstract class ContextBehaviour<TModel, TPresenter, TView> : MonoBehaviour, IContext<TModel>
        where TModel : class
        where TView : class
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
            InitializeView(view, _presenter);
            OnAwaken();
        }

        [NotNull]
        protected abstract TModel CreateModel();

        [NotNull]
        protected abstract TPresenter CreatePresenter([NotNull] TModel model, [NotNull] TView view);

        /// <summary>
        /// Should be implemented as View.Initialize(presenter).
        /// </summary>
        /// <param name="view">Initialized view.</param>
        /// <param name="presenter">Presenter passed to the view initialization method.</param>
        /// <see cref="Shared.UI.View&lt;TPresenter&gt;.Initialize(TPresenter)"/>
        protected abstract void InitializeView([NotNull] TView view, [NotNull] TPresenter presenter);

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