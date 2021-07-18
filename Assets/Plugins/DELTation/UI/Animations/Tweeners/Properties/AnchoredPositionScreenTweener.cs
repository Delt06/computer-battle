using System;
using DELTation.UI.Animations.Tweeners.Types;
using UnityEngine;

namespace DELTation.UI.Animations.Tweeners.Properties
{
    public sealed class AnchoredPositionScreenTweener : Vector3ScreenTweener
    {
        public AnchoredPositionScreenTweener(RectTransform transform, Vector3? openState, Vector3 closedState) :
            base(openState ?? transform.anchoredPosition, closedState) =>
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));

        protected override Vector3 CurrentState
        {
            get => _transform.anchoredPosition;
            set => _transform.anchoredPosition = value;
        }

        private readonly RectTransform _transform;
    }
}