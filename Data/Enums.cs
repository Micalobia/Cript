using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    [Flags()]
    public enum Align
    {
        None = 0,
        X = 1,
        Y = 2,
        XY = 3,
        YX = 3,
        Z = 4,
        ZX = 5,
        XZ = 5,
        ZY = 6,
        YZ = 6,
        XYZ = 7,
        XZY = 7,
        YXZ = 7,
        YZX = 7,
        ZXY = 7,
        ZYX = 7
    }

    public enum Anchor
    {
        Feet = 0,
        Eyes = 1
    }

    public enum SelectorType
    {
        None = 0,
        P = 1,
        A = 2,
        E = 3,
        S = 4,
    }

    public enum CoordinateType : byte
    {
        Absolute = 0,
        Relative = 1,
        Local = 2
    }

    public enum Axis
    {
        X = 0,
        Y = 1,
        Z = 2
    }

    public static class EnumExtensions
    {
        public static string Prefex(this CoordinateType type)
        {
            switch (type)
            {
                case CoordinateType.Relative: return "~";
                case CoordinateType.Local: return "^";
                default: return "";
            }
        }
    }
}
