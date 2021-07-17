using Shared.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Problems.UI
{
	public class ProblemSolvingView : View<IProblemSolvingPresenter>
	{
		[SerializeField] private TMP_Text _problemText;

		private UnityAction[] _onClickListeners;

		public TMP_Text ProblemText => _problemText;
		public ProblemSolvingView_AnswerButton[] AnswerButtons { get; private set; }

		private void Awake()
		{
			AnswerButtons = GetComponentsInChildren<ProblemSolvingView_AnswerButton>();
			_onClickListeners = new UnityAction[AnswerButtons.Length];

			for (var index = 0; index < AnswerButtons.Length; index++)
			{
				var capturedIndex = index;
				_onClickListeners[index] = () => Presenter.OnAnswerSelected(capturedIndex);
			}
		}

		private void OnEnable()
		{
			for (var i = 0; i < AnswerButtons.Length; i++)
			{
				var buttonClickedEvent = AnswerButtons[i].Button.onClick;
				buttonClickedEvent.AddListener(_onClickListeners[i]);
			}
		}

		private void OnDisable()
		{
			for (var i = 0; i < AnswerButtons.Length; i++)
			{
				var buttonClickedEvent = AnswerButtons[i].Button.onClick;
				buttonClickedEvent.RemoveListener(_onClickListeners[i]);
			}
		}

		public void Show() => Toggle(true);

		public void Hide() => Toggle(false);

		private void Toggle(bool active)
		{
			_problemText.gameObject.SetActive(active);

			foreach (var answerButton in AnswerButtons)
			{
				answerButton.gameObject.SetActive(active);
			}
		}
	}
}