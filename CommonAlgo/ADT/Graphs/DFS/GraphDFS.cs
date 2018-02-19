using CommonAlgo.ADT.Graphs.Base;

namespace CommonAlgo.ADT.Graphs.DFS
{
    internal class DFS : IGraphSearch
    {
        private readonly bool[] _marked;
        private int _count;

        public DFS(IGraph g, int startVertex)
        {
            _marked = new bool[g.V];
            Dfs(g, startVertex);
        }

        public bool Marked(int v)
        {
            return _marked[v];
        }

        public int Count
        {
            get { return _count; }
        }

        private void Dfs(IGraph g, int v)
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