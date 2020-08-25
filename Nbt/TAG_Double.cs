using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Double : TAG_Number<double>
    {
        public override sbyte ID => 6;
        public override string ToString() => $"DOUBLE({name}): {value}";
        public TAG_Double(string name = null, double? value = null) : base(name, value) { }
        protected internal override void WritePayload(BinaryDataWriter file) => file.Write(value);
        internal static double ReadPayload(BinaryDataReader file) => file.ReadDouble();
        internal static TAG_Double Read(BinaryDataReader file) => new TAG_Double(ReadName(file), ReadPayload(file));
    }
}
