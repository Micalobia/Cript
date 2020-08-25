using Syroot.BinaryData;
using System.Collections.Generic;
using System.Linq;

namespace Cript.Nbt
{
    public sealed class TAG_Int_Array : TAG_Number_Array<int>
    {
        public override sbyte ID => 11;
        public override string ToString() => $"{Name}:[I;{string.Join(",", values)}]";
        public TAG_Int_Array(string name = null, IEnumerable<int> value = null) : base(name, value.ToList()) { }
        protected internal override void WritePayload(BinaryDataWriter file)
        {
            file.Write(values.Count);
            foreach (int i in this) file.Write(i);
        }
        internal static int[] ReadPayload(BinaryDataReader file) => file.ReadInt32s(TAG_Int.ReadPayload(file));
        internal static TAG_Int_Array Read(BinaryDataReader file) => new TAG_Int_Array(ReadName(file), ReadPayload(file));
    }
}
