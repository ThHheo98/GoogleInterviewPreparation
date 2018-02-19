using System.Collections.Generic;
using CommonAlgo.ADT.Graphs.Base;
using CommonAlgo.ADT.Graphs.Graph;

namespace CommonAlgo.ADT.Graphs.Digraph
{
    public class TopologicalSort
    {
        private readonly IEnumerable<int> _order;

        public TopologicalSort(IDigraph g)
        {
            var cycleDirected = new DirectedCycle(g);
            if (!cycleDirected.HasCycle)
            {
                var dfs = new DepthFirstOrder(g);
                _order = dfs.ReversePost;
            }
        }

        public IEnumerable<int> Order
        {
            get { return _order; }
        }

        public bool IsDAG
        {
            get { return _order != null; }
        }
    }
}