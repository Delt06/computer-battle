namespace Shared.UI
{
    public interface IView<in TPresenter>
    {
        void Initialize(TPresenter presenter);
    }
}