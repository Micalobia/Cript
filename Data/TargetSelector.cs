using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cript.Nbt;

namespace Cript.Data
{
    class TargetSelector
    {
        public string name = null;
        public SelectorType Selector = SelectorType.None;
        public Align align = Align.None;
        public double x = double.NaN;
        public double y = double.NaN;
        public double z = double.NaN;
        public double distance = double.NaN;
        public double dx = double.NaN;
        public double dy = double.NaN;
        public double dz = double.NaN;
        public Dictionary<string, IntRange> scores = new Dictionary<string, IntRange>();
        public List<Tag> tags = new List<Tag>();
        public string team = null;
        public int limit = 1;
        public TargetSorting sort = TargetSorting.None;
        public IntRange level = new IntRange(0, 0, true, true);
        public Gamemode gamemode = Gamemode.None;
        public IntRange x_rotation = new IntRange(0, 0, true, true);
        public IntRange y_rotation = new IntRange(0, 0, true, true);
        public EntityType type = EntityType.None;
        public TAG_Compound nbt = new TAG_Compound();
        public List<Advancement> advancements = new List<Advancement>();
        public Predicate predicate = new Predicate();

        public TargetSelector(string name) => this.name = name;
    }
}
