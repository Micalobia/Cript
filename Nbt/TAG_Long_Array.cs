using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Long_Array : TAG_Number_Array<long>
    {
        public override sbyte ID => 12;
        public override string ToString() => $"LONG_ARRAY({name}): {value.Length} longs";
        public TAG_Long_Array(string name = null, long[] value = null) : base(name, value) { }
        protected internal override void WritePayload(BinaryDataWriter file)
        {
            file.Write(value.Length);
            foreach (long i in value) file.Write(i);
        }
        internal static long[] ReadPayload(BinaryDataReader file) => file.ReadInt64s(TAG_Int.ReadPayload(file));
        internal static TAG_Long_Array Read(BinaryDataReader file) => new TAG_Long_Array(ReadName(file), ReadPayload(file));
    }
}
