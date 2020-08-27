using Cript.Nbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public class Selector : IExecutable
    {
        public string name = null;
        public SelectorType selector = SelectorType.None;
        public double x = double.NaN;
        public double y = double.NaN;
        public double z = double.NaN;
        public IntRange distance = new IntRange(0, 0, true, true);
        public double dx = double.NaN;
        public double dy = double.NaN;
        public double dz = double.NaN;
        public Dictionary<Scoreboard, IntRange> scores = new Dictionary<Scoreboard, IntRange>();
        public List<Tag> tags = new List<Tag>();
        public string team = null;
        public int limit = -1;
        public TargetSorting sort = TargetSorting.None;
        public IntRange level = new IntRange(0, 0, true, true);
        public Gamemode gamemode = Gamemode.None;
        public IntRange x_rotation = new IntRange(0, 0, true, true);
        public IntRange y_rotation = new IntRange(0, 0, true, true);
        public EntityType type = EntityType.None;
        public TAG_Compound nbt = new TAG_Compound();
        public List<Advancement> advancements = new List<Advancement>();
        public Predicate predicate = new Predicate();
        public string GetExecute(int type)
        {
            switch (type)
            {
                case 0: return $"as {ToString()}";
                case 1: return $"at {ToString()}";
                default: throw new ArgumentOutOfRangeException("Not a valid selector executable");
            }
        }
        public Selector(string name = null) => this.name = name;
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(32);
            switch (selector)
            {
                case SelectorType.S: builder.Append("@s"); break;
                case SelectorType.A: builder.Append("@a"); break;
                case SelectorType.P: builder.Append("@p"); break;
                case SelectorType.E: builder.Append("@e"); break;
                case SelectorType.R: builder.Append("@r"); break;
                case SelectorType.None:
                    if (name == null) builder.Append("@s");
                    else return name;
                    break;
                default: throw new ArgumentException("Invalid selector");
            }
            List<string> things = new List<string>(5);
            if (name != null) things.Add($"name={name}");
            if (!double.IsNaN(x)) things.Add($"x={x}");
            if (!double.IsNaN(y)) things.Add($"y={y}");
            if (!double.IsNaN(z)) things.Add($"z={z}");
            if (!(distance.LeftOpen && distance.RightOpen)) things.Add($"distance={distance.ToString()}");
            if (!double.IsNaN(dx)) things.Add($"dx={dx}");
            if (!double.IsNaN(dy)) things.Add($"dy={dy}");
            if (!double.IsNaN(dz)) things.Add($"dz={dz}");
            if (scores.Count != 0)
            {
                List<string> _ = new List<string>();
                foreach (var t in scores) if (!t.Value.Open) _.Add($"{t.Key}={t.Value}");
                things.Add($"scores={{{string.Join(",", _)}}}");
            }
            if (tags.Count != 0)
            {
                List<string> _ = new List<string>();
                foreach (var t in tags) _.Add($"tag={(t.Negate ? "!" : "")}{t.Name}");
                things.Add(string.Join(",", _));
            }
            if (team != null) things.Add(team);
            if (limit > 0) things.Add($"limit={limit.ToString()}");
            if (gamemode != Gamemode.None) things.Add($"gamemode={gamemode.ToString().ToLower()}");
            if (!x_rotation.Open) things.Add(x_rotation.ToString());
            if (!y_rotation.Open) things.Add(y_rotation.ToString());
            if (type != EntityType.None) things.Add($"type={type.Namespaced()}");
            if (nbt.Count > 0) things.Add($"nbt={nbt.ToString()}");
            if (advancements.Count > 0) things.Add($"advancements={{{string.Join(",", advancements)}}}");
            if (predicate.NamespacedID != null) things.Add($"predicate={(predicate.Negate ? "!" : "")}{predicate.NamespacedID}");
            if (things.Count > 0)
            {
                builder.Append("[");
                builder.Append(string.Join(",", things));
                builder.Append("]");
            }
            return builder.ToString();
        }
    }
}
