using System;

namespace CommonAlgo.ADT.Graphs.EdgeWeighted
{
    public class Edge : IComparable<Edge>
    {
        private readonly int _v;
        private readonly int _w;
        private readonly double _weight;

        public Edge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;
        }

        public double Weight
        {
            get { return _weight; }
        }

        public int Either
        {
            get { return _v; }
        }

        public int Other(int vertex)
        {
            if (vertex == _v) return _w;
            if (vertex == _w) return _w;
            throw new InvalidOperationException("Invalid edge");
        }

        #region Implementation of IComparable<in Edge>

        public int CompareTo(Edge other)
        {
            if (Weight < other.Weight) return -1;
            if (Weight > other.Weight) return 1;
            return 0;
        }

        #region Overrides of Object

        public override string ToString()
        {
            return string.Format("{0}-{1} {2}", _v, _w, _weight);
        }

        #endregion

        #endregion
    }
}