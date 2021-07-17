namespace Shared.UI
{
    public abstract class Presenter<TModel, TView> where TView : class
    {
        private readonly IViewCollection _viewCollection;

        protected Presenter(TModel model, IViewCollection viewCollection)
        {
            Model = model;
            _viewCollection = viewCollection;

            // ReSharper disable once VirtualMemberCallInConstructor
            // Reason: expected implementation is considered safe.
            InitializeView(View);
        }

        /// <summary>
        /// Should be implemented as View.Initialize(this).
        /// </summary>
        /// <param name="view">Initialized view.</param>
        /// <see cref="Shared.UI.View&lt;TPresenter&gt;.Initialize(TPresenter)"/>
        protected abstract void InitializeView(TView view);

        protected TModel Model { get; }

        protected TView View => _viewCollection.Get<TView>();
    }
}