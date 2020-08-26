using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public class Facing : IExecutable
    {
        public Coordinate pos;
        public Selector targets;
        public Anchor anchor;
        public Facing(Coordinate pos) => this.pos = pos;
        public Facing(Selector targets, Anchor anchor)
        {
            this.targets = targets;
            this.anchor = anchor;
        }
        public string GetExecute(int type) => type == 0 ? $"facing {pos.ToString()}" : $"facing entity {targets.ToString()} {anchor.ToString()}";
    }
}
