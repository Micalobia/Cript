using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Int_Array : TAG_Number_Array<int>
    {
        public override sbyte ID => 11;
        public override string ToString() => $"INT_ARRAY({name}): {value.Length} ints";
        public TAG_Int_Array(string name = null, int[] value = null) : base(name, value) { }
        protected internal override void WritePayload(BinaryDataWriter file)
        {
            file.Write(value.Length);
            foreach (int i in value) file.Write(i);
        }
        internal static int[] ReadPayload(BinaryDataReader file) => file.ReadInt32s(TAG_Int.ReadPayload(file));
        internal static TAG_Int_Array Read(BinaryDataReader file) => new TAG_Int_Array(ReadName(file), ReadPayload(file));
    }
}
