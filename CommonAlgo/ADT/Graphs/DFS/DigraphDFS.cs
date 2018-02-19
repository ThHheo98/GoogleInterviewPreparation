using System.Collections.Generic;
using CommonAlgo.ADT.Graphs.Base;

namespace CommonAlgo.ADT.Graphs.DFS
{
    internal class DirectedDFS : IGraphSearch
    {
        private readonly bool[] _marked;
        private int _count;

        public DirectedDFS(IDigraph g, int startVertex)
        {
            _marked = new bool[g.V];
            Dfs(g, startVertex);
        }

        public DirectedDFS(IDigraph g, IEnumerable<int> sources)
        {
            _marked = new bool[g.V];
            foreach (int w in sources)
            {
                if (!_marked[w]) Dfs(g, w);
            }
        }

        public bool Marked(int v)
        {
            return _marked[v];
        }

        public int Count
        {
            get { return _count; }
        }

        private void Dfs(IDigraph g, int v)
        {
            _marked[v] = true;
            _count++;
            foreach (int i in g.Adj(v))
            {
                if (!_marked[i]) Dfs(g, i);
            }
        }
    }
}