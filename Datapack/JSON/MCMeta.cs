using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Datapack
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MCMeta
    {
        [JsonProperty] private Pack pack { get; set; }
        public string Description { get => pack.Description; set => pack.Description = value; }
        public int PackFormat { get => pack.PackFormat; set => pack.PackFormat = value; }
        [JsonObject(MemberSerialization.OptIn)]
        private class Pack
        {
            [JsonProperty("pack_format")] public int PackFormat { get; set; }
            [JsonProperty("description")] public string Description { get; set; }
        }
        public MCMeta() => pack = new Pack();
    }
}
