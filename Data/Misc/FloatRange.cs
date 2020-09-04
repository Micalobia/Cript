using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data.Misc
{
    [JsonObject(MemberSerialization.OptIn)]
    public struct FloatRange
    {
        private float _left;
        private float _right;
        private bool _leftOpen;
        private bool _rightOpen;

        [JsonProperty("min")] public float Left { get => _left; set => _left = value; }
        [JsonProperty("max")] public float Right { get => _right; set => _right = value; }
        public bool LeftOpen { get => _leftOpen; set => _leftOpen = value; }
        public bool RightOpen { get => _rightOpen; set => _rightOpen = value; }
        public bool Open => LeftOpen && RightOpen;
        public bool HasOpen => LeftOpen || RightOpen;
        public bool Skewed => LeftOpen ^ RightOpen;

        public FloatRange(float left, float right) : this(left, right, false, false) { }
        public FloatRange(float left, float right, bool leftOpen, bool rightOpen)
        {
            _left = left;
            _right = right;
            _leftOpen = leftOpen;
            _rightOpen = rightOpen;
        }

        public bool InRange(float value) => (LeftOpen || value >= Left) && (RightOpen || value <= Right);

        public bool ShouldSerializeLeft() => !LeftOpen;
        public bool ShouldSerializeRight() => !RightOpen;

        public override string ToString() => $"{(LeftOpen ? "" : Left.ToString())}{(HasOpen ? ".." : "")}{(RightOpen || !LeftOpen ? "" : Right.ToString())}";

        public override bool Equals(object obj)
        {
            if (!(obj is FloatRange))
                return false;

            FloatRange range = (FloatRange)obj;
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
