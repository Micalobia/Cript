using Syroot.BinaryData;
using System.Text;

namespace Cript.Nbt
{
    public sealed class TAG_String : TAG
    {
        private string value;
        public override sbyte ID => 8;
        public TAG_String(string name = null, string value = null) : base(name) => this.value = value ?? "";
        public override string ToString() => $"{Name}:\"{value}\"";
        protected internal override void WritePayload(BinaryDataWriter file)
        {
            file.Write((short)value.Length);
            if(value.Length > 0) foreach (char c in value) file.Write(c);
        }
        internal static string ReadPayload(BinaryDataReader file)
        {
            short length = file.ReadInt16();
            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++) builder.Append(file.ReadChar());
            return builder.ToString();
        }
        internal static TAG_String Read(BinaryDataReader file) => new TAG_String(ReadPayload(file), ReadPayload(file));
    }
}
