using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Int : TAG_Number<int>
    {
        public override sbyte ID => 3;
        public override string ToString() => $"{Name}:{value}";
        public TAG_Int(string name = null, int? value = null) : base(name,value) { }
        protected internal override void WritePayload(BinaryDataWriter file) => file.Write(value);
        internal static int ReadPayload(BinaryDataReader file) => file.ReadInt32();
        internal static TAG_Int Read(BinaryDataReader file) => new TAG_Int(ReadName(file), ReadPayload(file));
    }
}
