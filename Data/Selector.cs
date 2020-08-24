using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    class Selector
    {
        private string _name;
        private SelectorType _selector;

        public Selector(string name)
        {
            _selector = SelectorType.None;
            _name = name;
        }
    }
}
