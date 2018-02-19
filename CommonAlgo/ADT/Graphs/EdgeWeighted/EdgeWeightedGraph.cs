using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CommonAlgo.ADT.Graphs.EdgeWeighted
{
    public class EdgeWeightedGraph
    {
        private readonly List<Edge>[] _adj;
        private readonly int _v;
        private bool _b;
        private int _e;

        public EdgeWeightedGraph(string fileName)
        {
            using (var stream = new StreamReader(fileName))
            {
                string readLine = stream.ReadLine();
                int i = int.Parse(readLine);
                _v = i;
                string line = stream.ReadLine();
                i = int.Parse(line);

                _e = i;
                _adj = new List<Edge>[_v];
                for (int j = 0; j < _v; j++)
                {
                    _adj[j] = new List<Edge>();
                }

                for (int j = 0; j < _e; j++)
                {
                    string s = stream.ReadLine();

                    string[] array = s.Split(new[] {' '}).ToArray();
                    int v = int.Parse(array[0]);
                    int w = int.Parse(array[1]);
                    double weight = double.Parse(array[2], CultureInfo.InvariantCulture);

                    _adj[v].Add(new Edge(v, w, weight));
                }
            }
        }

        public EdgeWeightedGraph(int v, int e)
        {
            _v = v;
            _e = e;
            _adj = new List<Edge>[v];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new List<Edge>();
            }
        }

        public int V
        {
            get { return _v; }
        }

        public int E
        {
            get { return _e; }
        }

        public void AddEdge(Edge e)
        {
            int v = e.Either;
            int w = e.Other(v);
            _adj[v].Add(e);
            _adj[w].Add(e);
            _e++;
        }

        public IEnumerable<Edge> Adj(int v)
        {
            return _adj[v];
        }

        public IEnumerable<Edge> Edges()
        {
            var res = new List<Edge>();
            for (int v = 0; v < V; v++)
            {
                foreach (Edge edge in Adj(v))
                {
                    _b = edge.Other(v) > v;
                    if (_b) res.Add(edge);
                }
            }
            return res;
        }


        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < V; i++)
            {
                s += string.Format("Vertex {0}", i) + Environment.NewLine;
                foreach (Edge edge in _adj[i])
                {
                    s += edge + Environment.NewLine;
                }
            }

            return s;
        }
    }
}