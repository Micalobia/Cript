using Cript.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Datapack
{
    public class Datapack
    {
        private string _iconPath;
        private MCMeta _mcmeta;
        private MinecraftVersion _version;
        //TODO: Add list of namespaces

        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public string Description { get => _mcmeta.Description; set => _mcmeta.Description = value; }
        public MinecraftVersion Version
        {
            get => _version;
            set
            {
                _version = value;
                _mcmeta.PackFormat = value.PackFormat();
            }
        }
    }
}
