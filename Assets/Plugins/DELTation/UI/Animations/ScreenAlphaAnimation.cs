using DELTation.UI.Animations.Tweeners;
using DELTation.UI.Animations.Tweeners.Properties;
using DELTation.UI.Animations.Tweeners.Properties.Elements;

namespace DELTation.UI.Animations
{
    public abstract class ScreenAlphaAnimation : ScreenAnimation<float, float>
    {
        protected override ScreenTweener<float> CreateTweener(float? openState, float closedState) =>
            new AlphaScreenTweener(TransparentElement, openState, closedState);

        private ITransparentElement TransparentElement =>
            _transparentElement ?? (_transparentElement = CreateTransparentElement());

        protected abstract ITransparentElement CreateTransparentElement();

        private ITransparentElement _transparentElement;
    }
}