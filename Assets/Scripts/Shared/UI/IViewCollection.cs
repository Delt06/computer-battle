namespace Shared.UI
{
    public interface IViewCollection
    {
        TView Get<TView>() where TView : class;
    }
}