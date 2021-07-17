namespace Shared
{
    public interface IContext<out TModel> where TModel : class
    {
        TModel Model { get; }
    }
}