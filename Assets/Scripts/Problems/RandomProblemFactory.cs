using System;

namespace Problems
{
	public class RandomProblemFactory : IProblemFactory
	{
		private readonly Random _random;

		public RandomProblemFactory(Random random) => _random = random;

		public Problem Create()
		{
			var leftNumber = GenerateNumber();
			var rightNumber = GenerateNumber();
			var operation = GenerateOperation();
			EnsureAnswerIsNonNegative(ref leftNumber, ref rightNumber, operation);

			return new Problem(leftNumber, rightNumber, operation);
		}

		private static void EnsureAnswerIsNonNegative(ref int leftNumber, ref int rightNumber, Operation operation)
		{
			if (operation == Operation.Subtraction && leftNumber < rightNumber)
				Swap(ref leftNumber, ref rightNumber);
		}

		private int GenerateNumber() => _random.Next(1, 10);

		private Operation GenerateOperation() =>
			_random.NextDouble() > 0.5f ? Operation.Addition : Operation.Subtraction;

		private static void Swap(ref int number1, ref int number2)
		{
			(number1, number2) = (number2, number1);
		}
	}
}