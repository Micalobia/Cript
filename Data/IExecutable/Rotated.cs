using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    internal class Rotated : IExecutable
    {
        Selector targets;
        Rotation rot;
        public Rotated(Rotation rot) => this.rot = rot;
        public Rotated(Selector targets) => this.targets = targets;

        public string GetExecute(int type) => type == 0 ? $"rotated {rot.ToString()}" : $"rotated as {targets.ToString()}";
    }
}
