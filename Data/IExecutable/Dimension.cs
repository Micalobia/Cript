using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public class Dimension : IExecutable
    {
        public static readonly Dimension Overworld = new Dimension("minecraft:overworld");
        public static readonly Dimension TheNether = new Dimension("minecraft:the_nether");
        public static readonly Dimension TheEnd = new Dimension("minecraft:the_end");
        public string NamespacedID;
        public Dimension(string namespacedID) => NamespacedID = namespacedID;
        public override string ToString() => NamespacedID;
        public string GetExecute(int type) => $"in {NamespacedID}";
    }
}
