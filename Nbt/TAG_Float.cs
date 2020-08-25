using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Float : TAG_Number<float>
    {
        public override sbyte ID => 5;
        public override string ToString() => $"{Name}:{value}f";
        public TAG_Float(string name = null, float? value = null) : base(name, value) { }
        protected internal override void WritePayload(BinaryDataWriter file) => file.Write(value);
        internal static float ReadPayload(BinaryDataReader file) => file.ReadSingle();
        internal static TAG_Float Read(BinaryDataReader file) => new TAG_Float(ReadName(file), ReadPayload(file));
    }
}
