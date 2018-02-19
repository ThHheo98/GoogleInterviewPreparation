using System.Collections.Generic;
using CommonAlgo.ADT.Graphs.Base;

namespace CommonAlgo.ADT.Graphs.Graph
{
    public class DirectedCycle
    {
        private readonly int[] _edgeTo;
        private readonly bool[] _marked;
        private readonly bool[] _onStack;
        private Stack<int> _cycle;

        public DirectedCycle(IDigraph g)
        {
            _onStack = new bool[g.V];
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];

            for (int v = 0; v < g.V; v++)
            {
                if (_marked[v]) continue;
                dfs(g, v);
            }
        }

        public bool HasCycle
        {
            get { return _cycle != null; }
        }

        public IEnumerable<int> Cycle
        {
            get { return _cycle; }
        }

        private void dfs(IDigraph graph, int v)
        {
            _onStack[v] = true;
            _marked[v] = true;
            foreach (int w in graph.Adj(v))
            {
                if (HasCycle) return;
                if (!_marked[w]) dfs(graph, w);
                else if (_onStack[w])
                {
                    _cycle = new Stack<int>();
                    for (int x = v; x != w; x = _edgeTo[x])
                    {
                        _cycle.Push(x);
                    }
                    _cycle.Push(w);
                    _cycle.Push(v);
                }
            }
            _onStack[v] = false;
        }
    }
}