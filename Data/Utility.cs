using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    internal static class Utility
    {
        public static T Clamped<T>(this T value, T min, T max) where T : IComparable => value.CompareTo(min) < 0 ? min : value.CompareTo(max) > 0 ? max : value;
        public static void Clamp<T>(this T value, T min, T max) where T : IComparable => value = value.CompareTo(min) < 0 ? min : value.CompareTo(max) > 0 ? max : value;
    }
}
