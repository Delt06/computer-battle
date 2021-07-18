using System;
using DELTation.UI.Animations.Tweeners.Types;
using UnityEngine;

namespace DELTation.UI.Animations.Tweeners.Properties
{
    public sealed class ScaleScreenTweener : Vector3ScreenTweener
    {
        public ScaleScreenTweener(Transform transform, Vector3? openState, Vector3 closedState) :
            base(openState ?? transform.localScale, closedState) =>
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));

        protected override Vector3 CurrentState
        {
            get => _transform.localScale;
            set => _transform.localScale = value;
        }

        private readonly Transform _transform;
    }
}