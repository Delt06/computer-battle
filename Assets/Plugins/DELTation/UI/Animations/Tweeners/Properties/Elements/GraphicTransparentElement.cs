using System;
using UnityEngine.UI;

namespace DELTation.UI.Animations.Tweeners.Properties.Elements
{
    public sealed class GraphicTransparentElement : ITransparentElement
    {
        public GraphicTransparentElement(Graphic graphic) =>
            _graphic = graphic ? graphic : throw new ArgumentNullException(nameof(graphic));

        public float Alpha
        {
            get => _graphic.color.a;
            set
            {
                var color = _graphic.color;
                color.a = value;
                _graphic.color = color;
            }
        }

        private readonly Graphic _graphic;
    }
}