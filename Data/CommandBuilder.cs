using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public class CommandBuilder : IList<object>
    {
        private List<object> _chunks;

        public object this[int index] { get => ((IList<object>)_chunks)[index]; set => ((IList<object>)_chunks)[index] = value; }

        public int Count => ((IList<object>)_chunks).Count;

        public bool IsReadOnly => ((IList<object>)_chunks).IsReadOnly;

        public void Add(object item) => _chunks.Add(item);
        public void Clear() => _chunks.Clear();
        public bool Contains(object item) => _chunks.Contains(item);
        public void CopyTo(object[] array, int arrayIndex) => _chunks.CopyTo(array, arrayIndex);
        public IEnumerator<object> GetEnumerator() => _chunks.GetEnumerator();
        public int IndexOf(object item) => _chunks.IndexOf(item);
        public void Insert(int index, object item) => _chunks.Insert(index, item);
        public bool Remove(object item) => _chunks.Remove(item);
        public void RemoveAt(int index) => _chunks.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => _chunks.GetEnumerator();

        public string GetCommand() => string.Join(" ", _chunks);

        public override bool Equals(object obj)
        {
            var builder = obj as CommandBuilder;
            return builder != null &&
                   EqualityComparer<List<object>>.Default.Equals(_chunks, builder._chunks);
        }

        public override int GetHashCode() => -174928904 + EqualityComparer<List<object>>.Default.GetHashCode(_chunks);
        public override string ToString() => GetCommand();

        public CommandBuilder() => _chunks = new List<object>();
        public CommandBuilder(int capacity) => _chunks = new List<object>(capacity);
        public CommandBuilder(IEnumerable<object> collection) => _chunks = new List<object>(collection);
    }
}
