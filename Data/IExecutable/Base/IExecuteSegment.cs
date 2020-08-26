namespace Cript.Data
{
    public interface IExecuteSegment<T>  where T : IExecutable
    {
        T Value { get; set; }
        int Type { get; set; }
    }
}
