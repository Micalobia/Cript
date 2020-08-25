using Syroot.BinaryData;
using System.Collections.Generic;
using System.Linq;

namespace Cript.Nbt
{
    public sealed class TAG_Long_Array : TAG_Number_Array<long>
    {
        public override sbyte ID => 12;
        public override string ToString() => $"{Name}:[L;{string.Join(",", values)}]";
        public TAG_Long_Array(string name = null, IEnumerable<long> value = null) : base(name, value.ToList()) { }
        protected internal override void WritePayload(BinaryDataWriter file)
        {
            file.Write(values.Count);
            foreach (long i in this) file.Write(i);
        }
        internal static long[] ReadPayload(BinaryDataReader file) => file.ReadInt64s(TAG_Int.ReadPayload(file));
        internal static TAG_Long_Array Read(BinaryDataReader file) => new TAG_Long_Array(ReadName(file), ReadPayload(file));
    }
}
