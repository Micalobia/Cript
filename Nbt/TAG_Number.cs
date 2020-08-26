using System;

namespace Cript.Nbt
{
    public abstract class TAG_Number<T> : TAG where T : struct, IConvertible
    {
        protected internal T value;
        protected internal TAG_Number(string name = null, T? value = null) : base(name) => this.value = value ?? default;
    }
}
