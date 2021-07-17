using System;
using System.Text;
using DG.Tweening;
using Shared.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Problems.UI
{
    public class ProblemSolvingView : View<IProblemSolvingPresenter>, IProblemSolvingView
    {
        [SerializeField] private TMP_Text _problemText;
        [SerializeField] [Min(0f)] private float _selectionDuration = 0.5f;
        [SerializeField] [Min(0f)] private float _answerDisplayDuration = 1f;
        [SerializeField] private Slider _timerSlider = default;

        private UnityAction[] _onClickListeners;
        private ProblemSolvingView_AnswerButton[] _answerButtons;

        public void SetAnswerText(int answerIndex, string format, int answerValue)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            _answerButtons[answerIndex].Text.SetText(format, answerValue);
        }

        public void SetProblemText(StringBuilder text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            _problemText.SetText(text);
        }

        public void SetRemainingTimeRatio(float ratio)
        {
            _timerSlider.value = ratio;
        }

        private void Awake()
        {
            _answerButtons = GetComponentsInChildren<ProblemSolvingView_AnswerButton>();
            _onClickListeners = new UnityAction[_answerButtons.Length];

            for (var index = 0; index < _answerButtons.Length; index++)
            {
                var capturedIndex = index;
                _onClickListeners[index] = () => OnSelected(capturedIndex);
            }
        }

        public void OnGenerated()
        {
            foreach (var answerButton in _answerButtons)
            {
                answerButton.Button.interactable = true;
                answerButton.MakeNormal();
            }
        }

        public void Show() => Toggle(true);

        public void Hide() => Toggle(false);

        private void OnSelected(int selectedAnswerIndex)
        {
            foreach (var answerButton in _answerButtons)
            {
                answerButton.Button.interactable = false;
            }

            _answerButtons[selectedAnswerIndex].MakeSelected();
            Presenter.Pause();

            DOTween.Sequence()
                .AppendInterval(_selectionDuration)
                .AppendCallback(() =>
                    {
                        if (!Presenter.IsCorrect(selectedAnswerIndex))
                            _answerButtons[selectedAnswerIndex].MakeIncorrect();

                        for (var answerIndex = 0; answerIndex < _answerButtons.Length; answerIndex++)
                        {
                            if (Presenter.IsCorrect(answerIndex))
                                _answerButtons[answerIndex].MakeCorrect();
                        }
                    }
                )
                .AppendInterval(_answerDisplayDuration)
                .AppendCallback(() => Presenter.OnAnswerSelected(selectedAnswerIndex));
        }

        private void OnEnable()
        {
            for (var i = 0; i < _answerButtons.Length; i++)
            {
                var buttonClickedEvent = _answerButtons[i].Button.onClick;
                buttonClickedEvent.AddListener(_onClickListeners[i]);
            }
        }

        private void OnDisable()
        {
            for (var i = 0; i < _answerButtons.Length; i++)
            {
                var buttonClickedEvent = _answerButtons[i].Button.onClick;
                buttonClickedEvent.RemoveListener(_onClickListeners[i]);
            }
        }

        private void Toggle(bool active)
        {
            _problemText.gameObject.SetActive(active);

            foreach (var answerButton in _answerButtons)
            {
                answerButton.gameObject.SetActive(active);
            }
        }
    }
}