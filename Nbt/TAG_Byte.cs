using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Byte : TAG_Number<sbyte>
    {
        public override sbyte ID => TAG_BYTE;
        public override string ToString() => $"BYTE({name}): {value}";
        public TAG_Byte(string name = null, sbyte? value = null) : base(name, value) { }
        protected internal override void WritePayload(BinaryDataWriter file) => file.Write(value);
        internal static sbyte ReadPayload(BinaryDataReader file) => file.ReadSByte();
        internal static TAG_Byte Read(BinaryDataReader file) => new TAG_Byte(ReadName(file), ReadPayload(file));
    }
}
