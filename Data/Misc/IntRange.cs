using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public struct IntRange
    {
        public const int Size = 10;
        
        private int _left;
        private int _right;
        private bool _leftOpen;
        private bool _rightOpen;

        [JsonProperty("min")] public int Left { get => _left; set => _left = value; }
        [JsonProperty("max")] public int Right { get => _right; set => _right = value; }
        public bool LeftOpen { get => _leftOpen; set => _leftOpen = value; }
        public bool RightOpen { get => _rightOpen; set => _rightOpen = value; }
        public bool Open => LeftOpen && RightOpen;
        public bool HasOpen => LeftOpen || RightOpen;
        public bool Skewed => LeftOpen ^ RightOpen;

        public IntRange(int left, int right) : this(left, right, false, false) { }
        public IntRange(int left, int right, bool leftOpen, bool rightOpen)
        {
            _left = left;
            _right = right;
            _leftOpen = leftOpen;
            _rightOpen = rightOpen;
        }

        public bool InRange(int value) => (LeftOpen || value >= Left) && (RightOpen || value <= Right);

        public bool ShouldSerializeLeft() => !LeftOpen;
        public bool ShouldSerializeRight() => !RightOpen;

        public override string ToString() => $"{(LeftOpen ? "" : Left.ToString())}{(HasOpen ? ".." : "")}{(RightOpen || !LeftOpen ? "" : Right.ToString())}";

        public override bool Equals(object obj)
        {
            if (!(obj is IntRange))
                return false;

            IntRange range = (IntRange)obj;
            return Left == range.Left &&
                   Right == range.Right &&
                   LeftOpen == range.LeftOpen &&
                   RightOpen == range.RightOpen;
        }

        public override int GetHashCode()
        {
            int hashCode = -1014783866;
            hashCode = hashCode * -1521134295 + Left.GetHashCode();
            hashCode = hashCode * -1521134295 + Right.GetHashCode();
            hashCode = hashCode * -1521134295 + LeftOpen.GetHashCode();
            hashCode = hashCode * -1521134295 + RightOpen.GetHashCode();
            return hashCode;
        }
    }
}
