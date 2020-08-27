using Cript.Nbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    class BlockPredicate
    {
        public string BlockID;
        public Dictionary<string, object> BlockStates;
        public TAG_Compound BlockTag;
        public BlockPredicate(string blockID) : this(blockID, new TAG_Compound()) { }
        public BlockPredicate(string blockID, TAG_Compound blockTag)
        {
            BlockID = blockID;
            BlockTag = blockTag;
            BlockStates = new Dictionary<string, object>();
        }
        public object this[string state]
        {
            get => BlockStates[state];
            set => BlockStates[state] = value;
        }
        public override string ToString()
        {
            StringBuilder b = new StringBuilder(32);
            b.Append(BlockID);
            if(BlockStates.Count > 0)
            {
                b.Append("[");
                List<string> l = new List<string>(BlockStates.Count);
                foreach (var pair in BlockStates) l.Add(string.Format("{0}={1}", pair.Key, pair.Value));
                b.Append(string.Join(",", l));
                b.Append("]");
            }
            if (BlockTag.Count > 0) b.Append(BlockTag.ToString());
            return b.ToString();
        }
    }
}
