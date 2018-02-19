using System.Collections.Generic;
using CommonAlgo.ADT.Queue;

namespace CommonAlgo.ADT.Graphs.EdgeWeighted
{
    // memory O(E), time O(ElogE)
    public class LazyPrimeMST
    {
        private readonly bool[] _marked;
        private readonly Queue<Edge> _mst;
        private readonly PriorityQueue<Edge> _pq;

        public LazyPrimeMST(EdgeWeightedGraph graph)
        {
            _pq = new PriorityQueue<Edge>();
            _marked = new bool[graph.V];
            _mst = new Queue<Edge>();

            Visit(graph, 0);

            while (_pq.Count() > 0)
            {
                Edge e = _pq.Dequeue();
                int v = e.Either;
                int w = e.Other(v);

                if (_marked[v] && _marked[w]) continue;
                _mst.Enqueue(e);
                if (!_marked[v]) Visit(graph, v);
                if (!_marked[w]) Visit(graph, w);
            }
        }

        private void Visit(EdgeWeightedGraph graph, int v)
        {
            _marked[v] = true;
            foreach (Edge edge in graph.Adj(v))
            {
                if (!_marked[edge.Other(v)]) _pq.Enqueue(edge);
            }
        }

        public IEnumerable<Edge> Edges()
        {
            return _mst;
        }

        public double Weight()
        {
            return 10;
        }
    }
}