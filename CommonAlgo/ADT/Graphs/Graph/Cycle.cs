using CommonAlgo.ADT.Graphs.Base;

namespace CommonAlgo.ADT.Graphs.Graph
{
    public class Cycle
    {
        private readonly bool[] _marked;
        private bool _hasCycle;

        public Cycle(IGraph g)
        {
            _marked = new bool[g.V];
            _hasCycle = false;

            for (int i = 0; i < g.V; i++)
            {
                if (_marked[i]) continue;


                dfs(g, i, i);
            }
        }

        public bool HasCycle
        {
            get { return _hasCycle; }
        }

        private void dfs(IGraph graph, int v, int u)
        {
            _marked[v] = true;
            foreach (int w in graph.Adj(v))
            {
                if (!_marked[w]) dfs(graph, w, v);
                else if (w != u) _hasCycle = true;
            }
        }
    }
}