using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public struct Coordinate
    {
        #region Variables
        private double _x;
        private double _y;
        private double _z;
        private CoordinateType _xType;
        private CoordinateType _yType;
        private CoordinateType _zType;
        #endregion

        #region Public Properties
        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public double Z { get => _z; set => _z = value; }
        public CoordinateType XType { get => _xType; set => _xType = (IsCompletelyLocal && value != CoordinateType.Local) || value == CoordinateType.Local ? throw new Exception("Can't mix local coordinates") : value; }
        public CoordinateType YType { get => _yType; set => _yType = (IsCompletelyLocal && value != CoordinateType.Local) || value == CoordinateType.Local ? throw new Exception("Can't mix local coordinates") : value; }
        public CoordinateType ZType { get => _zType; set => _zType = (IsCompletelyLocal && value != CoordinateType.Local) || value == CoordinateType.Local ? throw new Exception("Can't mix local coordinates") : value; }
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
        public bool IsCompletelyAbsolute => XType == CoordinateType.Absolute && YType == CoordinateType.Absolute && ZType == CoordinateType.Absolute;
        public bool IsCompletelyRelative => XType == CoordinateType.Relative && YType == CoordinateType.Relative && ZType == CoordinateType.Relative;
        public bool IsCompletelyLocal => XType == CoordinateType.Local && YType == CoordinateType.Local && ZType == CoordinateType.Local;
        #endregion

        #region Private Properties
        private bool HasAbsolute => XType == CoordinateType.Absolute || YType == CoordinateType.Absolute || ZType == CoordinateType.Absolute;
        #endregion

        #region Constants
        public static readonly Coordinate Zero = new Coordinate();
        public static readonly Coordinate RelativeZero = new Coordinate(0, 0, 0, CoordinateType.Relative);
        public static readonly Coordinate LocalZero = new Coordinate(0, 0, 0, CoordinateType.Local);
        public static readonly Coordinate RelativeUp = new Coordinate(0, 1, 0, CoordinateType.Relative);
        public static readonly Coordinate RelativeDown = new Coordinate(0, -1, 0, CoordinateType.Relative);
        public static readonly Coordinate LocalUp = new Coordinate(0, 1, 0, CoordinateType.Local);
        public static readonly Coordinate LocalDown = new Coordinate(0, -1, 0, CoordinateType.Local);
        public static readonly Coordinate Left = new Coordinate(1, 0, 0, CoordinateType.Local);
        public static readonly Coordinate Right = new Coordinate(-1, 0, 0, CoordinateType.Local);
        public static readonly Coordinate Forward = new Coordinate(0, 0, 1, CoordinateType.Local);
        public static readonly Coordinate Backward = new Coordinate(0, 0, -1, CoordinateType.Local);
        #endregion

        #region Constructors
        public Coordinate(double x, double y, double z) : this(x, y, z, CoordinateType.Absolute) { }
        public Coordinate(double x, double y, double z, CoordinateType type) : this(x, y, z, type, type, type) { }
        public Coordinate(double x, double y, double z, CoordinateType xType, CoordinateType yType, CoordinateType zType)
        {
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
                case Axis.X:
                    if (ZType == CoordinateType.Absolute || YType == CoordinateType.Absolute) throw new Exception("Cannot rotate absolute coordinates");
                    tu = Y;
                    tv = Z;
                    Y = tu * cos - tv * sin;
                    Z = tv * cos + tu * sin;
                    break;
                case Axis.Y:
                    if (XType == CoordinateType.Absolute || ZType == CoordinateType.Absolute) throw new Exception("Cannot rotate absolute coordinates");
                    tu = Z;
                    tv = X;
                    Z = tu * cos - tv * sin;
                    X = tv * cos + tu * sin;
                    break;

                case Axis.Z:
                default:
                    if (XType == CoordinateType.Absolute || YType == CoordinateType.Absolute) throw new Exception("Cannot rotate absolute coordinates");
                    tu = X;
                    tv = Y;
                    X = tu * cos - tv * sin;
                    Y = tv * cos + tu * sin;
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
        public override string ToString() => string.Format("{0}{1:0.0#} {2}{3:0.0#} {4}{5:0.0#}", XType.Prefex(), X, YType.Prefex(), Y, ZType.Prefex(), Z);
        public string ToString(int decimalPlaces) => string.Format(string.Format("{{0}}{{1:{0}}} {{2}}{{3:{0}}} {{4}}{{5:{0}}}", "0." + new string('0', decimalPlaces)), XType.Prefex(), X, YType.Prefex(), Y, ZType.Prefex(), Z);
        #endregion

        #region Operators
        public static Coordinate operator *(Coordinate a, double b) => a.HasAbsolute ? throw new ArgumentException("Cannot multiply absolute coordinates", "a") : new Coordinate(a.X * b, a.Y * b, a.Z * b, a.XType, a.YType, a.ZType);
        public static Coordinate operator /(Coordinate a, double b) => a.HasAbsolute ? throw new ArgumentException("Cannot divide absolute coordinates", "a") : new Coordinate(a.X / b, a.Y / b, a.Z / b, a.XType, a.YType, a.ZType);
        public static Coordinate operator +(Coordinate a, Coordinate b)
        {
            bool al = a.IsCompletelyLocal;
            bool bl = b.IsCompletelyLocal;
            if (al && bl) return new Coordinate(a.X + b.Y, a.Y + b.Y, a.Z + b.Z, CoordinateType.Local);
            if (al || bl) throw new ArgumentException("Can only add local coordinates to other local coordinates");
            bool br = b.IsCompletelyRelative;
            if(br) return new Coordinate(a.X + b.Y, a.Y + b.Y, a.Z + b.Z, a.XType, a.YType, a.ZType);
            throw new ArgumentException("Cannot add absolute coordinates onto another coordinate");
        }
        public static Coordinate operator -(Coordinate a, Coordinate b)
        {
            bool al = a.IsCompletelyLocal;
            bool bl = b.IsCompletelyLocal;
            if (al && bl) return new Coordinate(a.X - b.Y, a.Y - b.Y, a.Z - b.Z, CoordinateType.Local);
            if (al || bl) throw new ArgumentException("Can only subtract local coordinates from other local coordinates");
            bool br = b.IsCompletelyRelative;
            if (br) return new Coordinate(a.X - b.Y, a.Y - b.Y, a.Z - b.Z, a.XType, a.YType, a.ZType);
            throw new ArgumentException("Cannot subtract absolute coordinates from another coordinate");
        }
        public static explicit operator Rotation(Coordinate c)
        {
            if (!c.IsCompletelyLocal) throw new ArgumentException("Can only cast local coordinates to rotations");
            double yaw = Math.Atan2(c.X, c.Z);
            c.Rotate(-yaw,Axis.Y);
            double pitch = Math.Atan2(c.Z, c.Y);
            return new Rotation(yaw, pitch);
        }
        #endregion
    }
}
