using Problems.UI;
using Shared.UI;
using UnityEngine;
using Random = System.Random;

namespace Problems
{
	public class ProblemSolvingContext : MonoBehaviour
	{
		[SerializeField, Min(1)] private int _answersNumber = 4;
		[SerializeField, Range(0f, 1f)] private float _maxDeviationFromRightAnswer = 0.25f;
		
		private ProblemSolvingPresenter _presenter;
		private IViewCollection _viewCollection;

		public void Construct(IViewCollection viewCollection)
		{
			_viewCollection = viewCollection;
		}

		public ProblemSolvingModel Model { get; private set; }

		private void Awake()
		{
			var problemFactory = new RandomProblemFactory(new Random());
			var answerFactory = new RandomAnswerFactory(new Random(), _maxDeviationFromRightAnswer);
			Model = new ProblemSolvingModel(problemFactory, answerFactory, _answersNumber);
			_presenter = new ProblemSolvingPresenter(Model, _viewCollection);
		}

		private void Start()
		{
			Model.Generate();
		}

		private void OnDestroy()
		{
			_presenter.Dispose();
		}
	}
}