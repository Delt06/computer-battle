using JetBrains.Annotations;

namespace Problems
{
    public interface IAnswerFactory
    {
        void Create(in Problem problem, [NotNull] int[] answers);
    }
}