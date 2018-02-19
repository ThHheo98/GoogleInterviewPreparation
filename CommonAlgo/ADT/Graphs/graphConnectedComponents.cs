using CommonAlgo.ADT.Graphs.Base;
using CommonAlgo.ADT.Graphs.Digraph;

namespace CommonAlgo.ADT.Graphs
{
    public class GraphConnectedComponents
    {
        private readonly int _count;
        private readonly int[] _id;
        private readonly bool[] _marked;

        public GraphConnectedComponents(IGraph g)
        {
            _marked = new bool[g.V];
            _id = new int[g.V];

            for (int i = 0; i < g.V; i++)
            {
                if (_marked[i]) continue;

                dfs(g, i); //помечаем все вершины, которые достижимы из данной
                _count++; // увеличиваем номер компонента
            }
        }

        public int Count
        {
            get { return _count; }
        }

        private void dfs(IGraph graph, int v)
        {
            _marked[v] = true; // отмечаем вершину
            _id[v] = _count; // поставляем номер компонента
            foreach (int i in graph.Adj(v))
            {
                if (_marked[i]) continue;
                dfs(graph, i);
            }
        }

        public bool IsConnected(int v, int w)
        {
            return _id[v] == _id[w];
        }

        public int Id(int v)
        {
            return _id[v];
        }
    }

    public class KosarajuDigraphStronglyConnectedComponents
    {
        private readonly int _count;
        private readonly int[] _id;
        private readonly bool[] _marked;

        public KosarajuDigraphStronglyConnectedComponents(IDigraph g)
        {
            _marked = new bool[g.V];
            _id = new int[g.V];
            var dfo = new DepthFirstOrder(g.Reverse());

            foreach (int w in dfo.ReversePost)
            {
                if (!_marked[w])
                {
                    dfs(g, w); //помечаем все вершины, которые достижимы из данной
                    _count++; // увеличиваем номер компонента
                }
            }
        }

        public int Count
        {
            get { return _count; }
        }

        private void dfs(IDigraph graph, int v)
        {
            _marked[v] = true; // отмечаем вершину
            _id[v] = _count; // поставляем номер компонента
            foreach (int i in graph.Adj(v))
            {
                if (_marked[i]) continue;
                dfs(graph, i);
            }
        }

        public bool IsStronglyConnected(int v, int w)
        {
            return _id[v] == _id[w];
        }

        public int Id(int v)
        {
            return _id[v];
        }
    }
}