using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    [StructLayout(LayoutKind.Explicit,Size=Size)]
    struct IntRange
    {
        public const int Size = 10;

        [FieldOffset(0)] private byte[] _bytes;
        [FieldOffset(0)] private int _left;
        [FieldOffset(4)] private int _right;
        [FieldOffset(8)] private bool _leftOpen;
        [FieldOffset(9)] private bool _rightOpen;

        public int Left { get => _left; set => _left = value; }
        public int Right { get => _right; set => _right = value; }
        public bool LeftOpen { get => _leftOpen; set => _leftOpen = value; }
        public bool RightOpen { get => _rightOpen; set => _rightOpen = value; }
        public bool Open => LeftOpen && RightOpen;
        public byte[] Bytes
        {
            get
            {
                if (_bytes == null)
                {
                    using (MemoryStream m = new MemoryStream(new byte[Size]))
                    using (BinaryWriter b = new BinaryWriter(m))
                    {
                        b.Write(Left);
                        b.Write(Right);
                        b.Write(LeftOpen);
                        b.Write(RightOpen);
                        m.Seek(0, SeekOrigin.Begin);
                        _bytes = m.ToArray();
                    }
                }
                return _bytes;
            }
        }

        public IntRange(int left, int right) : this(left, right, false, false) { }
        public IntRange(int left, int right, bool leftOpen, bool rightOpen)
        {
            _bytes = new byte[Size];
            _left = left;
            _right = right;
            _leftOpen = leftOpen;
            _rightOpen = rightOpen;
        }

        public bool InRange(int value) => (LeftOpen || value >= Left) && (RightOpen || value <= Right);

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
