using System;
using DELTation.UI.Animations.Tweeners.Types;
using JetBrains.Annotations;
using UnityEngine;

namespace DELTation.UI.Animations.Tweeners.Properties
{
    public sealed class LocalRotationScreenTweener : QuaternionScreenTweener
    {
        public LocalRotationScreenTweener([NotNull] Transform transform, Quaternion? openState,
            Quaternion closedState) :
            base(openState ?? transform.localRotation, closedState) =>
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));

        protected override Quaternion CurrentState
        {
            get => _transform.localRotation;
            set => _transform.localRotation = value;
        }

        private readonly Transform _transform;
    }
}