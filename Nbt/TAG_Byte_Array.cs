using Syroot.BinaryData;
using System.Collections.Generic;
using System.Linq;

namespace Cript.Nbt
{
    public sealed class TAG_Byte_Array : TAG_Number_Array<byte>
    {
        public override sbyte ID => 7;
        public override string ToString() => $"{Name}:[B;{string.Join(",",values)}]";
        public TAG_Byte_Array(string name = null, IEnumerable<byte> value = null) : base(name, value.ToList()) { }
        protected internal override void WritePayload(BinaryDataWriter file)
        {
            file.Write(Count);
            foreach (byte i in this) file.Write(i);
        }
        internal static byte[] ReadPayload(BinaryDataReader file) => file.ReadBytes(TAG_Int.ReadPayload(file));
        internal static TAG_Byte_Array Read(BinaryDataReader file) => new TAG_Byte_Array(ReadName(file), ReadPayload(file));
    }
}
