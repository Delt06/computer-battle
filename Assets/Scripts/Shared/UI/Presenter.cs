namespace Shared.UI
{
    public abstract class Presenter<TModel, TView> where TView : class
    {
        protected Presenter(TModel model, TView view)
        {
            Model = model;
            View = view;
        }

        protected TModel Model { get; }

        protected TView View { get; }
    }
}