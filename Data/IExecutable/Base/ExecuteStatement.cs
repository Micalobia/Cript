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
        
    }
}
