using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    internal class IfUnless : IExecutable
    {
        bool unless = false;
        Coordinate position0;
        Coordinate position1;
        Coordinate position2;
        Block block;
        ScanMode scanMode;
        string path;
        Selector selector0;
        Selector selector1;
        string source;
        Predicate predicate;
        Scoreboard score0;
        Scoreboard score1;
        Comparison comparison;
        IntRange range;
        private IfUnless(bool unless) => this.unless = unless;
        public IfUnless(Coordinate position0, Block block, bool unless) : this(unless)
        {
            this.position0 = position0;
            this.block = block;
        }
        public IfUnless(Coordinate position0, Coordinate position1, Coordinate position2, ScanMode scanMode, bool unless) : this(unless)
        {
            this.position0 = position0;
            this.position1 = position1;
            this.position2 = position2;
            this.scanMode = scanMode;
        }
        public IfUnless(Coordinate position0, string path, bool unless) : this(unless)
        {
            this.position0 = position0;
            this.path = path;
        }
        public IfUnless(Selector selector0, string path, bool unless) : this(unless)
        {
            this.selector0 = selector0;
            this.path = path;
        }
        public IfUnless(string source, string path, bool unless) : this(unless)
        {
            this.source = source;
            this.path = path;
        }
        public IfUnless(Selector selector0, bool unless) : this(unless) => this.selector0 = selector0;
        public IfUnless(Predicate predicate, bool unless) : this(unless) => this.predicate = predicate;
        public IfUnless(Selector selector0, Scoreboard score0, Comparison comparison, Selector selector1, Scoreboard score1, bool unless) : this(unless)
        {
            this.selector0 = selector0;
            this.score0 = score0;
            this.comparison = comparison;
            this.selector1 = selector1;
            this.score1 = score1;
        }
        public IfUnless(Selector selector0, Scoreboard score0, IntRange range, bool unless)
        {
            this.selector0 = selector0;
            this.score0 = score0;
            this.range = range;
        }

        public string GetExecute(int type)
        {
            string i = unless ? "unless" : "if";
            switch (type)
            {
                case 0: return $"{i} block {position0} {block}";
                case 1: return $"{i} blocks {position0} {position1} {position2} {scanMode.ToString().ToLower()}";
                case 2: return $"{i} data block {position0} {path}";
                case 3: return $"{i} data entity {selector0} {path}";
                case 4: return $"{i} data storage {source} {path}";
                case 5: return $"{i} entity {selector0}";
                case 6: return $"{i} predicate {predicate}";
                case 7: return $"{i} score {selector0} {score0} {comparison.Symbol()} {selector1} {score1}";
                case 8: return $"{i} score {selector0} {score0} matches {range}";
                default: throw new ArgumentException("That isn't a valid type", "type");
            }
        }
    }
}
