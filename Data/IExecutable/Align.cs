using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public sealed class Align : IExecutable
    {
        public static readonly Align None = new Align(_none);
        public static readonly Align X = new Align(_x);
        public static readonly Align Y = new Align(_y);
        public static readonly Align Z = new Align(_z);
        public static readonly Align XY = new Align(_x | _y);
        public static readonly Align XZ = new Align(_x | _z);
        public static readonly Align YX = XY;
        public static readonly Align YZ = new Align(_y | _z);
        public static readonly Align ZX = XZ;
        public static readonly Align ZY = YZ;
        public static readonly Align XYZ = new Align(_xyz);
        public static readonly Align XZY = XYZ;
        public static readonly Align YXZ = XYZ;
        public static readonly Align YZX = XYZ;
        public static readonly Align ZXY = XYZ;
        public static readonly Align ZYX = XYZ;
        private const int _none = 0;
        private const int _x = 1;
        private const int _y = 2;
        private const int _z = 4;
        private const int _xyz = _x | _y | _z;
        private readonly int _value;
        private Align(int type) => _value = type & _xyz;
        private bool HasFlag(int type) => (_value & type) > 0;
        public override string ToString() => string.Format("{0}{1}{2}", HasFlag(_x) ? "x" : "", HasFlag(_y) ? "y" : "", HasFlag(_z) ? "z" : "");
        public string GetExecute(int type) => _value == _none ? null : $"align {ToString()}";
    }
}
