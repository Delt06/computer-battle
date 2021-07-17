using JetBrains.Annotations;

namespace Shared.UI
{
    public interface IView<in TPresenter>
    {
        void Initialize([NotNull] TPresenter presenter);
    }
}