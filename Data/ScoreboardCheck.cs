using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    struct ScoreboardCheck
    {
        public IntRange Range;
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value == null ? throw new ArgumentNullException("Name cannot be null") : value.Length > 0 && value.Length <= 16 ? _name = value : throw new ArgumentException("Has to be 1-16 characters");
        }
    }
}
