using System.Collections.Generic;
using CommonAlgo.ADT.Queue;

namespace CommonAlgo.ADT.Graphs.EdgeWeighted
{
    public class PrimeMST
    {
        private readonly double[] _distTo;
        private readonly Edge[] _edgeTo;
        private readonly bool[] _marked;
        private readonly IndexMinPQ<double> _pq;

        public PrimeMST(EdgeWeightedGraph graph)
        {
            _edgeTo = new Edge[graph.V];
            _distTo = new double[graph.V];
            _marked = new bool[graph.V];

            for (int i = 0; i < graph.V; i++)
            {
                _distTo[i] = double.PositiveInfinity;
            }
            _pq = new IndexMinPQ<double>(graph.V);

            _distTo[0] = 0.0;
            _pq.insert(0, 0.0);
            while (!_pq.isEmpty())
                Visit(graph, _pq.delMin());
        }

        private void Visit(EdgeWeightedGraph graph, int v)
        {
            _marked[v] = true;
            foreach (Edge edge in graph.Adj(v))
            {
                int w = edge.Other(v);
                if (_marked[w]) continue;
                if (edge.Weight < _distTo[w])
                {
                    _edgeTo[w] = edge;
                    _distTo[w] = edge.Weight;
                    if (_pq.contains(w)) _pq.change(w, _distTo[w]);
                    else _pq.insert(w, _distTo[w]);
                }
            }
        }

        public IEnumerable<Edge> Edges()
        {
            return _edgeTo;
        }

        public double Weight()
        {
            return 10;
        }
    }
}