using DELTation.UI.Animations.Tweeners.Properties.Elements;
using UnityEngine;

namespace DELTation.UI.Animations
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class ScreenCanvasGroupAlphaAnimation : ScreenAlphaAnimation
    {
        protected override ITransparentElement CreateTransparentElement() =>
            new CanvasGroupTransparentElement(GetComponent<CanvasGroup>());
    }
}