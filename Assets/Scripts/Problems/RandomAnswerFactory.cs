using System;
using UnityEngine;
using Random = System.Random;

namespace Problems
{
    public class RandomAnswerFactory : IAnswerFactory
    {
        private readonly Random _random;
        private readonly float _maxDeviationRatio;
        private readonly int _maxForcedOffsetValue;
        private const int MaxIterations = 1000;

        public RandomAnswerFactory(Random random, float maxDeviationRatio, int maxForcedOffsetValue)
        {
            _random = random;
            _maxDeviationRatio = maxDeviationRatio;
            _maxForcedOffsetValue = maxForcedOffsetValue;
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
                    for (var _ = 0; _ < MaxIterations; _++)
                    {
                        var answer = GenerateWrongAnswer(rightAnswer);
                        if (Exists(answers, index, answer)) continue;

                        answers[index] = answer;
                        break;
                    }
            }
        }

        private static bool Exists(int[] answers, int numberOfReadyAnswers, int answer)
        {
            for (var index = 0; index < numberOfReadyAnswers; index++)
            {
                if (answers[index] == answer)
                    return true;
            }

            return false;
        }

        private int GenerateWrongAnswer(int rightAnswer)
        {
            var coefficient = Mathf.Lerp(1f - _maxDeviationRatio,
                1f + _maxDeviationRatio,
                (float) _random.NextDouble()
            );
            coefficient = Mathf.Max(0f, coefficient);
            var wrongAnswer = Mathf.RoundToInt(rightAnswer * coefficient);
            if (wrongAnswer == rightAnswer) wrongAnswer += _random.Next(1, _maxForcedOffsetValue);

            return wrongAnswer;
        }
    }
}