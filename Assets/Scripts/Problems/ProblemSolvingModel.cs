using System;
using System.Collections.Generic;

namespace Problems
{
	public class ProblemSolvingModel
	{
		private readonly IAnswerFactory _answerFactory;
		private readonly int[] _answers;
		private readonly IProblemFactory _problemFactory;

		public ProblemSolvingModel(IProblemFactory problemFactory, IAnswerFactory answerFactory, int answersNumber)
		{
			if (answersNumber <= 0) throw new ArgumentException();
			_problemFactory = problemFactory;
			_answerFactory = answerFactory;
			_answers = new int[answersNumber];
		}

		public Problem Problem { get; private set; }
		public IReadOnlyList<int> Answers => _answers;

		public void Generate()
		{
			Problem = _problemFactory.Create();
			_answerFactory.Create(Problem, _answers);
			Generated?.Invoke();
		}

		public event Action Generated;

		public void OnAnsweredCorrectly()
		{
			AnsweredCorrectly?.Invoke();
		}

		public event Action AnsweredCorrectly;

		public void OnAnsweredIncorrectly()
		{
			AnsweredIncorrectly?.Invoke();
		}

		public event Action AnsweredIncorrectly;
	}
}