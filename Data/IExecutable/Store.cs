using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    internal class Store : IExecutable
    {
        bool success;
        Coordinate targetPos;
        string path;
        DataLiteral type;
        BossbarValue value;
        Selector target;
        double scale;
        Scoreboard objective;
        string datatarget;
        private Store(bool success) => this.success = success;
        private Store(bool success, DataLiteral type) : this(success) => this.type = type;
        private Store(bool success, DataLiteral type, double scale) : this(success, type) => this.scale = scale;
        public Store(Coordinate targetPos, string path, DataLiteral type, double scale, bool success) : this(success, type, scale)
        {
            this.targetPos = targetPos;
            this.path = path;
        }
        public Store(string id, BossbarValue value, bool success) : this(success)
        {
            path = id;
            this.value = value;
        }
        public Store(Selector target, string path, DataLiteral type, double scale, bool success) : this(success, type, scale)
        {
            this.target = target;
            this.path = path;
        }
        public Store(Selector target, Scoreboard objective, bool success) : this(success)
        {
            this.target = target;
            this.objective = objective;
        }
        public Store(string target, string path, DataLiteral type, double scale, bool success) : this(success, type, scale)
        {
            datatarget = target;
            this.path = path;
        }

        public string GetExecute(int type)
        {
            string r = success ? "success" : "result";
            string Type = this.type.ToString().ToLower();
            switch (type)
            {
                case 0: return $"store {r} block {targetPos} {path} {this.type} {scale:0.0##}";
                case 1: return $"store {r} bossbar {path} {value.ToString().ToLower()}";
                case 2: return $"store {r} entity {target} {path} {Type} {scale:0.0##}";
                case 3: return $"store {r} score {target} {objective}";
                case 4: return $"store {r} storage {datatarget} {path} {Type} {scale:0.0##}";
                default: throw new ArgumentException("That's not a valid type", "type");
            }
        }
    }
}
