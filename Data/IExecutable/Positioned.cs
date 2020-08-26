using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public class Positioned : IExecutable
    {
        Coordinate pos;
        Selector targets;
        public Positioned(Coordinate pos) => this.pos = pos;
        public Positioned(Selector targets) => this.targets = targets;

        public string GetExecute(int type) => type == 0 ? $"positioned {pos.ToString()}" : $"positioned as {targets.ToString()}";
    }
}
