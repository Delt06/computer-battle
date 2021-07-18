using DELTation.UI.Animations.Tweeners.Properties.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace DELTation.UI.Animations
{
    [RequireComponent(typeof(Graphic))]
    public sealed class ScreenGraphicAlphaAnimation : ScreenAlphaAnimation
    {
        protected override ITransparentElement CreateTransparentElement() =>
            new GraphicTransparentElement(GetComponent<Graphic>());
    }
}