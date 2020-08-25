using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Long : TAG_Number<long>
    {
        public override sbyte ID => 4;
        public override string ToString() => $"LONG({name}): {value}";
        public TAG_Long(string name = null, long? value = null) : base(name, value) { }
        protected internal override void WritePayload(BinaryDataWriter file) => file.Write(value);
        internal static long ReadPayload(BinaryDataReader file) => file.ReadInt64();
        internal static TAG_Long Read(BinaryDataReader file) => new TAG_Long(ReadName(file), ReadPayload(file));
    }
}
