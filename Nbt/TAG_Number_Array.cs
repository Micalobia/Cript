using System;

namespace Cript.Nbt
{
    public abstract class TAG_Number_Array<T> : TAG where T : struct, IConvertible
    {
        protected internal T[] value;
        public TAG_Number_Array(string name = null, T[] value = null) : base(name) => this.value = value ?? new T[0];
    }
}
