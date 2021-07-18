using _Shared.UI;

namespace TapToPlay.UI
{
    public class TapToPlayPresenter : Presenter<TapToPlayModel, TapToPlayView>
    {
        public TapToPlayPresenter(TapToPlayModel model, TapToPlayView view) : base(model, view) { }

        public void OnTapped()
        {
            View.Hide();
            Model.OnTapped();
        }
    }
}