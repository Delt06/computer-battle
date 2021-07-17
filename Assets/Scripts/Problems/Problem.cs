namespace Problems
{
	public readonly struct Problem
	{
		public readonly int LeftNumber;
		public readonly int RightNumber;
		public readonly Operation Operation;

		public Problem(int leftNumber, int rightNumber, Operation operation)
		{
			LeftNumber = leftNumber;
			RightNumber = rightNumber;
			Operation = operation;
		}
	}
}