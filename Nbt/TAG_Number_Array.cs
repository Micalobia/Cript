using System;
using System.Collections;
using System.Collections.Generic;

namespace Cript.Nbt
{
    public abstract class TAG_Number_Array<T> : TAG, IList<T> where T : struct, IConvertible
    {
        protected internal List<T> values;
        protected internal TAG_Number_Array(string name = null, List<T> raw = null, int capacity = 1) : base(name) => values = raw ?? new List<T>(capacity);

        public T this[int index] { get => values[index]; set => values[index] = value; }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="TAG_Number_Array{T}"/>
        /// </summary>
        public int Count => values.Count;

        /// <summary>
        /// Always returns false
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds a <typeparamref name="T"/> to the end of the <see cref="TAG_Number_Array{T}"/>
        /// </summary>
        /// <param name="item">The <typeparamref name="T"/> to add</param>
        public void Add(T item) => values.Add(item);
        public void Clear() => values.Clear();
        public bool Contains(T item) => values.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => values.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => values.GetEnumerator();
        public int IndexOf(T item) => values.IndexOf(item);
        public void Insert(int index, T item) => values.Insert(index, item);
        public bool Remove(T item) => values.Remove(item);
        public void RemoveAt(int index) => values.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
