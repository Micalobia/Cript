using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Short : TAG_Number<short>
    {
        public override sbyte ID => 2;
        public override string ToString() => $"{Name}:{value}s";
        public TAG_Short(string name = null, short? value = null) : base(name, value) { }
        protected internal override void WritePayload(BinaryDataWriter file) => file.Write(value);
        internal static short ReadPayload(BinaryDataReader file) => file.ReadInt16();
        internal static TAG_Short Read(BinaryDataReader file) => new TAG_Short(ReadName(file), ReadPayload(file));
    }
}
