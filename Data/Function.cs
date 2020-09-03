using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    class Function : IList<string>
    {
        private List<string> _commands;

        public string this[int index] { get => _commands[index]; set => _commands[index] = value; }

        public int Count => _commands.Count;

        public bool IsReadOnly => ((IList<string>)_commands).IsReadOnly;

        public void Add(string item) => _commands.Add(item);
        public void Clear() => _commands.Clear();
        public bool Contains(string item) => _commands.Contains(item);
        public void CopyTo(string[] array, int arrayIndex) => _commands.CopyTo(array, arrayIndex);
        public IEnumerator<string> GetEnumerator() => _commands.GetEnumerator();
        public int IndexOf(string item) => _commands.IndexOf(item);
        public void Insert(int index, string item) => _commands.Insert(index, item);
        public bool Remove(string item) => _commands.Remove(item);
        public void RemoveAt(int index) => _commands.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => _commands.GetEnumerator();

        public string GetCommand() => string.Join("\n", _commands);

        public override bool Equals(object obj)
        {
            var builder = obj as Function;
            return builder != null &&
                   EqualityComparer<List<string>>.Default.Equals(_commands, builder._commands);
        }

        public override int GetHashCode() => -174928904 + EqualityComparer<List<string>>.Default.GetHashCode(_commands);
        public override string ToString() => GetCommand();

        public Function() => _commands = new List<string>();
        public Function(int capacity) => _commands = new List<string>(capacity);
        public Function(IEnumerable<string> collection) => _commands = new List<string>(collection);
    }
}
