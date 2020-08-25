using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Byte_Array : TAG_Number_Array<byte>
    {
        public override sbyte ID => 7;
        public override string ToString() => $"BYTE_ARRAY({name}): {value.Length} bytes";
        public TAG_Byte_Array(string name = null, byte[] value = null) : base(name, value) { }
        protected internal override void WritePayload(BinaryDataWriter file)
        {
            file.Write(value.Length);
            foreach (byte i in value) file.Write(i);
        }
        internal static byte[] ReadPayload(BinaryDataReader file) => file.ReadBytes(TAG_Int.ReadPayload(file));
        internal static TAG_Byte_Array Read(BinaryDataReader file) => new TAG_Byte_Array(ReadName(file), ReadPayload(file));
    }
}
