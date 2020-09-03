using System;
using System.Collections.Generic;
using System.Linq;

namespace Cript.Data
{
    internal static class Utility
    {
        public static T Clamped<T>(this T value, T min, T max) where T : IComparable => value.CompareTo(min) < 0 ? min : value.CompareTo(max) > 0 ? max : value;
        public static void Clamp<T>(this T value, T min, T max) where T : IComparable => value = value.CompareTo(min) < 0 ? min : value.CompareTo(max) > 0 ? max : value;
        public static IDictionary<TKey, TValue> FilterNull<TKey, TValue>(this IDictionary<TKey, TValue> dict) => dict.Where(x => x.Value != null).ToDictionary(x => x.Key, x => x.Value);
        public static IEnumerable<T> FilterNull<T>(this IEnumerable<T> collection) => collection.Where(x => x != null);
    }
}