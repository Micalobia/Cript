namespace Cript.Data
{
    public sealed class ExecuteSegment<T> : IExecuteSegment<T> where T : IExecutable
    {
        public T Value { get; set; }
        public int Type { get; set; }
        internal ExecuteSegment(T value, int type)
        {
            Value = value;
            Type = type;
        }
        public static implicit operator ExecuteSegment<IExecutable>(ExecuteSegment<T> value) => new ExecuteSegment<IExecutable>(value.Value, value.Type);
        public sealed override string ToString() => Value.GetExecute(Type);
    }
}
