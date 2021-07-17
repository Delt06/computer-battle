namespace Shared.UI
{
    public abstract class Presenter<TModel, TView> where TView : class
    {
        private readonly IViewCollection _viewCollection;

        protected Presenter(TModel model, IViewCollection viewCollection)
        {
            Model = model;
            _viewCollection = viewCollection;
        }

        protected TModel Model { get; }

        protected TView View => _viewCollection.Get<TView>();
    }
}