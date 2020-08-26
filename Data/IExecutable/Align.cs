using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public sealed class Align : IExecutable
    {
        public const int None = 0;
        public const int X = 1;
        public const int Y = 2;
        public const int XY = 3;
        public const int YX = 3;
        public const int Z = 4;
        public const int ZX = 5;
        public const int XZ = 5;
        public const int ZY = 6;
        public const int YZ = 6;
        public const int XYZ = 7;
        public const int XZY = 7;
        public const int YXZ = 7;
        public const int YZX = 7;
        public const int ZXY = 7;
        public const int ZYX = 7;
        public int Value { get; private set; }
        public Align() => Value = None;
        public Align(int type) => Value = type & XYZ;
        private bool HasFlag(int type) => (Value & type) > 0;
        public override string ToString() => string.Format("{0}{1}{2}", HasFlag(X) ? "x" : "", HasFlag(Y) ? "y" : "", HasFlag(Z) ? "z" : "");
        public string GetExecute(int type) => Value == None ? null : $"align {ToString()}";
    }
}
