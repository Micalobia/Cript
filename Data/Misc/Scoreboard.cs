using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public struct Scoreboard
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value == null ? throw new ArgumentNullException("Name cannot be null") : value.Length > 0 && value.Length <= 16 ? _name = value : throw new ArgumentException("Has to be 1-16 characters");
        }
        public Scoreboard(string name) : this() => Name = name;

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if (!(obj is Scoreboard))
                return false;

            var scoreboard = (Scoreboard)obj;
            return Name == scoreboard.Name;
        }

        public override int GetHashCode() => 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
    }
}
