using System;
using System.Collections.Generic;
using UnityEngine;

namespace Problems
{
    public class ProblemSolvingModel
    {
        private readonly IAnswerFactory _answerFactory;
        private readonly int[] _answers;
        private readonly IProblemFactory _problemFactory;
        private float _remainingTime;
        private bool _paused;

        public ProblemSolvingModel(IProblemFactory problemFactory, IAnswerFactory answerFactory, int answersNumber,
            float timeLimit)
        {
            if (answersNumber <= 0) throw new ArgumentException();
            _problemFactory = problemFactory;
            _answerFactory = answerFactory;
            TimeLimit = timeLimit;
            _answers = new int[answersNumber];
        }

        public Problem Problem { get; private set; }
        public IReadOnlyList<int> Answers => _answers;

        public float RemainingTime => Mathf.Max(0, _remainingTime);

        public float TimeLimit { get; }

        public void Generate()
        {
            Problem = _problemFactory.Create();
            _answerFactory.Create(Problem, _answers);
            _remainingTime = TimeLimit;
            _paused = false;
            RemainingTimeChanged?.Invoke();
            Generated?.Invoke();
        }

        public event Action Generated;

        public void Pause() => _paused = true;

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

        public void UpdateTime(float deltaTime)
        {
            if (_paused) return;
            if (_remainingTime <= 0f) return;
            _remainingTime -= deltaTime;
            RemainingTimeChanged?.Invoke();
            if (_remainingTime > 0f) return;
            OnAnsweredIncorrectly();
        }

        public event Action RemainingTimeChanged;
    }
}