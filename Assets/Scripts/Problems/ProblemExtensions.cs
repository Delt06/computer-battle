using System;

namespace Problems
{
    public static class ProblemExtensions
    {
        public static int GetAnswer(this Problem problem) =>
            problem.Operation switch
            {
                Operation.Addition => problem.LeftNumber + problem.RightNumber,
                Operation.Subtraction => problem.LeftNumber - problem.RightNumber,
                _ => throw new ArgumentOutOfRangeException(),
            };
    }
}