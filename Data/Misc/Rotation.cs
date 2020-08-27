using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public struct Rotation
    {
        #region Variables
        private double _yaw;
        private double _pitch;
        private RotationType _yawType;
        private RotationType _pitchType;
        #endregion

        #region Public Properties
        public double Yaw { get => _yaw; set => _yaw = (value + 180d) % 360d - 180d; }
        public double Pitch { get => _pitch; set => _pitch = _yawType == RotationType.Absolute ? value.Clamped(-90d, 90d) : value.Clamped(-180d, 180d); }
        public RotationType YawType { get => _yawType; set => _yawType = value; }
        public RotationType PitchType { get => _pitchType; set => _pitchType = value; }
        public bool IsCompletelyAbsolute => YawType == RotationType.Absolute && PitchType == RotationType.Absolute;
        public bool IsCompletelyRelative => YawType == RotationType.Relative && PitchType == RotationType.Relative;
        #endregion

        #region Private Properties
        private bool HasRelative => YawType == RotationType.Relative || PitchType == RotationType.Relative;
        #endregion

        #region Constants
        public static readonly Rotation Zero = new Rotation();
        public static readonly Rotation South = Zero;
        public static readonly Rotation West = new Rotation(90d, 0d);
        public static readonly Rotation East = new Rotation(-90d, 0);
        public static readonly Rotation North = new Rotation(-180, 0);
        #endregion

        #region Constructors
        public Rotation(double yaw, double pitch) : this(yaw, pitch, RotationType.Absolute) { }
        public Rotation(double yaw, double pitch, RotationType type) : this(yaw, pitch, type, type) { }
        public Rotation(double yaw, double pitch, RotationType yawType, RotationType pitchType) : this()
        {
            _yawType = yawType;
            _pitchType = pitchType;
            Yaw = yaw;
            Pitch = pitch;
        }
        #endregion

        #region Overrides
        public override string ToString() => string.Format("{0}{1:0.0#} {2}{3:0.0#}", YawType.Prefex(), Yaw, PitchType.Prefex(), Pitch);
        #endregion

        public static implicit operator Coordinate(Rotation r) => r.HasRelative ? throw new ArgumentException("Cannot cast relative rotation to coordinate") : Coordinate.Backward.Rotated(r.Pitch, Axis.X).Rotated(r.Yaw, Axis.Y);
    }
}
