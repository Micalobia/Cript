using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    public class ExecuteStatement
    {
        List<ExecuteSegment<IExecutable>> conditions = new List<ExecuteSegment<IExecutable>>();
        public void Align(Align axes) => conditions.Add(new ExecuteSegment<Align>(axes, default));
        public void Anchored(Anchor anchor) => conditions.Add(new ExecuteSegment<Anchor>(anchor, default));
        public void As(Selector targets) => conditions.Add(new ExecuteSegment<Selector>(targets, 0));
        public void At(Selector targets) => conditions.Add(new ExecuteSegment<Selector>(targets, 1));
        public void Facing(Coordinate pos) => conditions.Add(new ExecuteSegment<Facing>(new Facing(pos), 0));
        public void Facing(Selector targets, Anchor anchor) => conditions.Add(new ExecuteSegment<Facing>(new Facing(targets, anchor), 1));
        public void In(Dimension dimension) => conditions.Add(new ExecuteSegment<Dimension>(dimension, 0));
        public void Positioned(Coordinate pos) => conditions.Add(new ExecuteSegment<Positioned>(new Positioned(pos), 0));
        public void Positioned(Selector targets) => conditions.Add(new ExecuteSegment<Positioned>(new Positioned(targets), 1));
        public void Rotated(Rotation rot) => conditions.Add(new ExecuteSegment<Rotated>(new Rotated(rot), 0));
        public void Rotated(Selector targets) => conditions.Add(new ExecuteSegment<Rotated>(new Rotated(targets), 1));
        public void IfBlock(Coordinate pos, Block block) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(pos, block, false), 0));
        public void IfBlocks(Coordinate start, Coordinate end, Coordinate destination, ScanMode scanMode) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(start, end, destination, scanMode, false), 0));
        public void IfData(Coordinate pos, string path) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(pos, path, false), 0));
        public void IfData(Selector target, string path) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(target, path, false), 0));
        public void IfData(string source, string path) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(source, path, false), 0));
        public void IfEntity(Selector targets) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(targets, false), 0));
        public void IfPredicate(Predicate predicate) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(predicate, false), 0));
        public void IfScore(Selector target, Scoreboard targetObjective, Comparison compare, Selector source, Scoreboard sourceObjective) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(target, targetObjective, compare, source, sourceObjective, false), 0));
        public void IfScore(Selector target, Scoreboard targetObjective, IntRange range) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(target, targetObjective, range, false), 0));
        public void UnlessBlock(Coordinate pos, Block block) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(pos, block, true), 0));
        public void UnlessBlocks(Coordinate start, Coordinate end, Coordinate destination, ScanMode scanMode) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(start, end, destination, scanMode, true), 0));
        public void UnlessData(Coordinate pos, string path) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(pos, path, true), 0));
        public void UnlessData(Selector target, string path) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(target, path, true), 0));
        public void UnlessData(string source, string path) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(source, path, true), 0));
        public void UnlessEntity(Selector targets) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(targets, true), 0));
        public void UnlessPredicate(Predicate predicate) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(predicate, true), 0));
        public void UnlessScore(Selector target, Scoreboard targetObjective, Comparison compare, Selector source, Scoreboard sourceObjective) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(target, targetObjective, compare, source, sourceObjective, true), 0));
        public void UnlessScore(Selector target, Scoreboard targetObjective, IntRange range) => conditions.Add(new ExecuteSegment<IfUnless>(new IfUnless(target, targetObjective, range, true), 0));
        public void StoreBlock(Coordinate targetPos, string path, DataLiteral type, double scale, bool success = false) => conditions.Add(new ExecuteSegment<Store>(new Store(targetPos, path, type, scale, success), 0));
        public void StoreBossbar(string id, BossbarValue value, bool success = false) => conditions.Add(new ExecuteSegment<Store>(new Store(id, value, success), 1));
        public void StoreEntity(Selector target, string path, DataLiteral type, double scale, bool success = false) => conditions.Add(new ExecuteSegment<Store>(new Store(target, path, type, scale, success), 2));
        public void StoreScore(Selector targets, Scoreboard objective, bool success = false) => conditions.Add(new ExecuteSegment<Store>(new Store(targets, objective, success), 3));
        public void StoreStorage(string target, string path, DataLiteral type, double scale, bool success = false) => conditions.Add(new ExecuteSegment<Store>(new Store(target, path, type, scale, success), 4));


        public override string ToString()
        {
            StringBuilder b = new StringBuilder(64);
            b.Append("execute ");
            foreach (var t in conditions)
            {
                b.Append(t.ToString());
                b.Append(' ');
            }
            b.Append("run say Hello World!");
            return b.ToString();
        }
    }
}
