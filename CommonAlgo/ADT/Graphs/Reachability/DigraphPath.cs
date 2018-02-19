using System.Collections.Generic;
using CommonAlgo.ADT.Graphs.Base;

namespace CommonAlgo.ADT.Graphs.Reachability
{
    public class DigraphPath : IGraphPath
    {
        private readonly int[] _edgeTo;
        private readonly bool[] _marked;
        private readonly int _s;

        public DigraphPath(IDigraph g, int s)
        {
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _s = s;
            dfs(g, s);
        }

        private void dfs(IDigraph graph, int v)
        {
            _marked[v] = true;
            foreach (int w in graph.Adj(v))
            {
                if (_marked[w]) continue;
                _edgeTo[w] = v;
                dfs(graph, w);
            }
        }

        #region Implementation of IGraphPath

        public bool HasPathTo(int v)
        {
            return _marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            var path = new Stack<int>();
            for (int x = v; x != v; x = _edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(_s);
            return path;
        }

        #endregion
    }
}