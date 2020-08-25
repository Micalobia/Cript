using Syroot.BinaryData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Nbt
{
    public class TAG_Compound : TAG//, IList<TAG>, ICollection<TAG>, IEnumerable<TAG>, IEnumerable, IList, ICollection, IReadOnlyList<TAG>, IReadOnlyCollection<TAG>
    {
        private List<TAG> tags;
        public override sbyte ID => 10;

        public int Count => tags.Count;

        public override string ToString() => $"COMPOUND({name}): {tags.Count} tags";
        public TAG_Compound(string name = null, int capacity = 1) : this(name, null, capacity) { }
        internal TAG_Compound(string name, List<TAG> tags, int capacity = 1) : base(name) => this.tags = tags ?? new List<TAG>(capacity);
        public void Add(TAG tag) => tags.Add(tag);
        internal NBTFile ToFile()
        {
            NBTFile ret = new NBTFile();
            foreach (var t in tags) ret.Add(t);
            return ret;
        }
        protected internal override void WritePayload(BinaryDataWriter file)
        {
            foreach (TAG t in tags) t.Write(file);
            TAG_End.WriteEnd(file);
        }
        internal static TAG_Compound Read(BinaryDataReader file) => new TAG_Compound(ReadName(file), ReadPayload(file));
        internal static List<TAG> ReadPayload(BinaryDataReader file)
        {
            List<TAG> ret = new List<TAG>();
            while (true)
            {
                sbyte id = TAG_Byte.ReadPayload(file);
                switch (id)
                {
                    case TAG_END: return ret;
                    case TAG_BYTE: ret.Add(TAG_Byte.Read(file)); break;
                    case TAG_SHORT: ret.Add(TAG_Short.Read(file)); break;
                    case TAG_INT: ret.Add(TAG_Int.Read(file)); break;
                    case TAG_LONG: ret.Add(TAG_Long.Read(file)); break;
                    case TAG_FLOAT: ret.Add(TAG_Float.Read(file)); break;
                    case TAG_DOUBLE: ret.Add(TAG_Double.Read(file)); break;
                    case TAG_BYTE_ARRAY: ret.Add(TAG_Byte_Array.Read(file)); break;
                    case TAG_STRING: ret.Add(TAG_String.Read(file)); break;
                    case TAG_LIST: ret.Add(TAG_List.Read(file)); break;
                    case TAG_COMPOUND: ret.Add(Read(file)); break;
                    case TAG_INT_ARRAY: ret.Add(TAG_Int_Array.Read(file)); break;
                    case TAG_LONG_ARRAY: ret.Add(TAG_Long_Array.Read(file)); break;
                    default: throw new Exception("Something went wrong here");
                }
            }
        }

        #region Collection Stuffs
        #endregion
    }
}
