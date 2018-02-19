using CommonAlgo.ADT.Graphs.Base;

namespace CommonAlgo.ADT.Graphs.Graph
{
    public class TwoColor
    {
        private readonly bool[] _color;
        private readonly bool[] _marked;
        private bool _isTwoColorable = true;

        public TwoColor(IGraph g)
        {
            _marked = new bool[g.V];
            _color = new bool[g.V];


            for (int i = 0; i < g.V; i++)
            {
                if (_marked[i]) continue;


                dfs(g, i);
            }
        }

        public bool IsBipartite
        {
            get { return _isTwoColorable; }
        }

        private void dfs(IGraph graph, int v)
        {
            _marked[v] = true;
            foreach (int w in graph.Adj(v))
            {
                if (!_marked[w])
                {
                    _color[w] = !_color[v];
                    dfs(graph, w);
                }
                else if (_color[w] == _color[v]) _isTwoColorable = false;
            }
        }
    }
}