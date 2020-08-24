using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    [StructLayout(LayoutKind.Explicit, Size = Size, Pack = Pack)]
    struct Coordinate
    {
        #region Constants
        public const int Size = 27;
        public const int Pack = 32;
        #endregion

        #region Variables
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Size)] [FieldOffset(0)] private byte[] _bytes;
        [FieldOffset(0)] private double _x;
        [FieldOffset(8)] private double _y;
        [FieldOffset(16)] private double _z;
        [FieldOffset(24)] private CoordinateType _xType;
        [FieldOffset(25)] private CoordinateType _yType;
        [FieldOffset(26)] private CoordinateType _zType;
        #endregion

        #region Public Properties
        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public double Z { get => _z; set => _z = value; }
        public CoordinateType XType { get => _xType; set => _xType = (IsLocal && value != CoordinateType.Local) || value == CoordinateType.Local ? throw new Exception("Can't mix local coordinates") : value; }
        public CoordinateType YType { get => _yType; set => _yType = (IsLocal && value != CoordinateType.Local) || value == CoordinateType.Local ? throw new Exception("Can't mix local coordinates") : value; }
        public CoordinateType ZType { get => _zType; set => _zType = (IsLocal && value != CoordinateType.Local) || value == CoordinateType.Local ? throw new Exception("Can't mix local coordinates") : value; }
        public CoordinateType Type
        {
            set
            {
                _xType = value;
                _yType = value;
                _zType = value;
            }
        }
        public Coordinate Normalized
        {
            get
            {
                Coordinate ret = this;
                ret.Normalize();
                return ret;
            }
        }
        public byte[] Bytes
        {
            get
            {
                if (_bytes == null)
                {
                    using (MemoryStream m = new MemoryStream(new byte[Size]))
                    using (BinaryWriter b = new BinaryWriter(m))
                    {
                        b.Write(X);
                        b.Write(Y);
                        b.Write(Z);
                        b.Write((byte)XType);
                        b.Write((byte)YType);
                        b.Write((byte)ZType);
                        m.Seek(0, SeekOrigin.Begin);
                        _bytes = m.ToArray();
                    }
                }
                return _bytes;
            }
        }
        public bool IsLocal => XType == CoordinateType.Local && YType == CoordinateType.Local && ZType == CoordinateType.Local;
        #endregion

        #region Private Properties
        private bool HasAbsolute => XType == CoordinateType.Absolute || YType == CoordinateType.Absolute || ZType == CoordinateType.Absolute;
        #endregion

        #region Constructors
        public Coordinate(byte[] bytes) : this() => _bytes = bytes;
        public Coordinate(double x, double y, double z) : this(x, y, z, CoordinateType.Absolute) { }
        public Coordinate(double x, double y, double z, CoordinateType type) : this(x, y, z, type, type, type) { }
        public Coordinate(double x, double y, double z, CoordinateType xType, CoordinateType yType, CoordinateType zType)
        {
            _bytes = new byte[Size];
            _x = x;
            _y = y;
            _z = z;
            _xType = xType;
            _yType = yType;
            _zType = zType;
        }
        #endregion

        #region Transformations
        public void Translate(double x, double y, double z)
        {
            X += x;
            Y += y;
            Z += z;
        }
        public Coordinate Translated(double x, double y, double z)
        {
            Coordinate ret = this;
            ret.Translate(x, y, z);
            return ret;
        }
        public void Rotate(double angle, Axis axis)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            double tu, tv;
            switch (axis)
            {
                case Axis.Z:
                default:
                    if (XType == CoordinateType.Absolute || YType == CoordinateType.Absolute) throw new Exception("Cannot rotate absolute coordinates");
                    tu = X;
                    tv = Y;
                    X = tu * cos - tv * sin;
                    Y = tv * cos + tu * sin;
                    break;
                case Axis.Y:
                    if (XType == CoordinateType.Absolute || ZType == CoordinateType.Absolute) throw new Exception("Cannot rotate absolute coordinates");
                    tu = Z;
                    tv = X;
                    Z = tu * cos - tv * sin;
                    X = tv * cos + tu * sin;
                    break;
                case Axis.X:
                    if (ZType == CoordinateType.Absolute || YType == CoordinateType.Absolute) throw new Exception("Cannot rotate absolute coordinates");
                    tu = Y;
                    tv = Z;
                    Y = tu * cos - tv * sin;
                    Z = tv * cos + tu * sin;
                    break;
            }
        }
        public Coordinate Rotated(double angle, Axis axis)
        {
            Coordinate ret = this;
            ret.Rotate(angle, axis);
            return ret;
        }
        public void Reflect(double x, double y, double z)
        {
            if (HasAbsolute) throw new Exception("Cannot reflect absolute coordinates");
            double mag = Math.Sqrt(x * x + y * y + z * z);
            x /= mag;
            y /= mag;
            z /= mag;
            double dot = x * X + y * Y + z * Z;
            X = X - 2 * dot * x;
            Y = Y - 2 * dot * y;
            Z = Z - 2 * dot * z;
        }
        public Coordinate Reflected(double x, double y, double z)
        {
            Coordinate ret = this;
            ret.Reflect(x, y, z);
            return ret;
        }
        public void Normalize()
        {
            if (HasAbsolute) throw new Exception("Cannot normalize absolute coordinates");
            double mag = Math.Sqrt(X * X + Y * Y + Z * Z);
            X /= mag;
            Y /= mag;
            Z /= mag;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is Coordinate)) return false;
            Coordinate coordinate = (Coordinate)obj;
            return X == coordinate.X &&
                   Y == coordinate.Y &&
                   Z == coordinate.Z &&
                   XType == coordinate.XType &&
                   YType == coordinate.YType &&
                   ZType == coordinate.ZType;
        }
        public override int GetHashCode()
        {
            int hashCode = 2124988552;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            hashCode = hashCode * -1521134295 + XType.GetHashCode();
            hashCode = hashCode * -1521134295 + YType.GetHashCode();
            hashCode = hashCode * -1521134295 + ZType.GetHashCode();
            return hashCode;
        }
        public override string ToString() => string.Format("{0}{1:0.00} {2}{3:0.00} {4}{5:0.00}", XType.Prefex(), X, YType.Prefex(), Y, ZType.Prefex(), Z);
        public string ToString(int decimalPlaces) => string.Format(string.Format("{{0}}{{1:{0}}} {{2}}{{3:{0}}} {{4}}{{5:{0}}}", "0." + new string('0', decimalPlaces)), XType.Prefex(), X, YType.Prefex(), Y, ZType.Prefex(), Z);
        #endregion
    }
}
