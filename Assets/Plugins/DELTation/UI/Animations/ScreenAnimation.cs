using DELTation.UI.Animations.Tweeners;
using DELTation.UI.Attributes;
using DELTation.UI.Screens;
using UnityEngine;

namespace DELTation.UI.Animations
{
    public abstract class ScreenAnimation<TInspectorValue, TValue> : MonoBehaviour, IScreenListener
        where TInspectorValue : struct
        where TValue : struct
    {
        [SerializeField] private TweenData _openData = default;
        [SerializeField] private bool _openToInitialState = true;

        [SerializeField] [HideIf(nameof(_openToInitialState))]
        private TInspectorValue _openState = default;

        [SerializeField] private TweenData _closeData = default;
        [SerializeField] private TInspectorValue _closedState = default;

        public bool ShouldBeAwaited => _tweener.IsActive;
        public void OnUpdate(IGameScreen gameScreen, float deltaTime) => Tweener.Update(deltaTime);

        public void OnOpened(IGameScreen gameScreen)
        {
            Tweener.Open();
        }

        public void OnClosed(IGameScreen gameScreen)
        {
            Tweener.Close();
        }

        public void OnClosedImmediately(IGameScreen gameScreen) => Tweener.CloseImmediately();

        private ScreenTweener<TValue> Tweener => _tweener ?? (_tweener = ConstructTweener());

        private ScreenTweener<TValue> ConstructTweener()
        {
            var tweener = CreateTweener(OpenState, ClosedState);
            _openData.CopyTo(tweener.OpenData);
            _closeData.CopyTo(tweener.CloseData);
            return tweener;
        }

        protected abstract ScreenTweener<TValue> CreateTweener(TInspectorValue? openState, TInspectorValue closedState);

        private TInspectorValue? OpenState => _openToInitialState ? (TInspectorValue?) null : _openState;
        private TInspectorValue ClosedState => _closedState;

        private ScreenTweener<TValue> _tweener;
    }
}