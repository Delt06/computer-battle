using System;
using UnityEngine;
using Random = System.Random;

namespace Problems
{
	public class RandomAnswerFactory : IAnswerFactory
	{
		private readonly float _maxDeviationRatio;
		private readonly Random _random;

		public RandomAnswerFactory(Random random, float maxDeviationRatio)
		{
			_random = random;
			_maxDeviationRatio = maxDeviationRatio;
		}

		public void Create(in Problem problem, int[] answers)
		{
			if (answers == null) throw new ArgumentNullException(nameof(answers));

			var rightAnswerIndex = _random.Next(answers.Length);
			var rightAnswer = problem.GetAnswer();

			for (var index = 0; index < answers.Length; index++)
			{
				if (index == rightAnswerIndex)
					answers[index] = rightAnswer;
				else
					answers[index] = GenerateWrongAnswer(rightAnswer);
			}
		}

		private int GenerateWrongAnswer(int rightAnswer)
		{
			var coefficient = Mathf.Lerp(1f - _maxDeviationRatio,
				1f + _maxDeviationRatio,
				(float) _random.NextDouble()
			);
			coefficient = Mathf.Max(0f, coefficient);
			var wrongAnswer = Mathf.RoundToInt(rightAnswer * coefficient);
			if (wrongAnswer == rightAnswer) wrongAnswer++;

			return wrongAnswer;
		}
	}
}