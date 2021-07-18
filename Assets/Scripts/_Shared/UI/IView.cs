using JetBrains.Annotations;

namespace _Shared.UI
{
    public interface IView<in TPresenter>
    {
        void Initialize([NotNull] TPresenter presenter);
    }
}