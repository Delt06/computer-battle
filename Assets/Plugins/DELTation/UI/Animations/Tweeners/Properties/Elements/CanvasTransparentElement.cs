using System;
using JetBrains.Annotations;
using UnityEngine;

namespace DELTation.UI.Animations.Tweeners.Properties.Elements
{
    public sealed class CanvasGroupTransparentElement : ITransparentElement
    {
        public CanvasGroupTransparentElement([NotNull] CanvasGroup canvasGroup) => _canvasGroup =
            canvasGroup ? canvasGroup : throw new ArgumentNullException(nameof(canvasGroup));

        public float Alpha
        {
            get => _canvasGroup.alpha;
            set => _canvasGroup.alpha = value;
        }

        private readonly CanvasGroup _canvasGroup;
    }
}