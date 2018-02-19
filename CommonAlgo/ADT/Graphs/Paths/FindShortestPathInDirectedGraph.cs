using System.Collections.Generic;
using CommonAlgo.ADT.Graphs.Base;

namespace CommonAlgo.ADT.Graphs.Paths
{
    internal class FindShortestPathInDirectedGraph : IGraphPath
    {
        private readonly int[] _edgeTo;
        private readonly bool[] _marked;
        private readonly int _startVertex;

        public FindShortestPathInDirectedGraph(IDigraph g, int startVertex)
        {
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _startVertex = startVertex;
            Bfs(g, startVertex);
        }

        private void Bfs(IDigraph g, int s)
        {
            var q = new Queue<int>();
            _marked[s] = true;
            q.Enqueue(s);
            while (q.Count > 0)
            {
                int v = q.Dequeue();
                foreach (int w in g.Adj(v))
                {
                    if (!_marked[w])
                    {
                        _edgeTo[w] = v;
                        _marked[w] = true;
                        q.Enqueue(w);
                    }
                }
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
            path.Push(_startVertex);
            return path;
        }

        #endregion
    }
}