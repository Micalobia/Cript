using Syroot.BinaryData;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Nbt
{
    public abstract class TAG
    {
        public const sbyte TAG_END = 0;
        public const sbyte TAG_BYTE = 1;
        public const sbyte TAG_SHORT = 2;
        public const sbyte TAG_INT = 3;
        public const sbyte TAG_LONG = 4;
        public const sbyte TAG_FLOAT = 5;
        public const sbyte TAG_DOUBLE = 6;
        public const sbyte TAG_BYTE_ARRAY = 7;
        public const sbyte TAG_STRING = 8;
        public const sbyte TAG_LIST = 9;
        public const sbyte TAG_COMPOUND = 10;
        public const sbyte TAG_INT_ARRAY = 11;
        public const sbyte TAG_LONG_ARRAY = 12;
        public abstract sbyte ID { get; }
        public string name;
        public TAG(string name = null) => this.name = name ?? "";
        public override string ToString() => $"{name}: TAG";
        protected internal abstract void WritePayload(BinaryDataWriter file);
        protected internal virtual void Write(BinaryDataWriter file)
        {
            file.Write(ID);
            file.Write((short)name.Length);
            if (name.Length > 0) foreach (char c in name) file.Write(c);
            WritePayload(file);
        }
        protected internal static string ReadName(BinaryDataReader file) => TAG_String.ReadPayload(file);
    }
}
