using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommonAlgo.ADT.Graphs.Base
{
    public class Graph : IGraph
    {
        private readonly List<int>[] _adj; // adjacent list
        private readonly int _v;
        private int _e;

        public Graph(string fileName)
        {
            using (var stream = new StreamReader(fileName))
            {
                string readLine = stream.ReadLine();
                int i = int.Parse(readLine);
                _v = i;
                string line = stream.ReadLine();
                i = int.Parse(line);

                _e = i;
                _adj = new List<int>[_v];
                for (int j = 0; j < _v; j++)
                {
                    _adj[j] = new List<int>();
                }

                for (int j = 0; j < _e; j++)
                {
                    string s = stream.ReadLine();

                    int[] num = s.Split(new[] {' '}).Select(int.Parse).ToArray();

                    _adj[num[0]].Add(num[1]);
                }
            }
        }

        public Graph(int v)
        {
            _v = v;
            _e = 0;
            _adj = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                _adj[i] = new List<int>();
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

        public void AddEdge(int v, int w)
        {
            _adj[v].Add(w);
            _adj[w].Add(v);
            _e++;
        }

        public IEnumerable<int> Adj(int v)
        {
            return _adj[v];
        }

        public override string ToString()
        {
            string s = V + " вершин, " + E + " ребер" + Environment.NewLine;
            for (int v = 0; v < V; v++)
            {
                s += v + ": ";
                foreach (int w in Adj(v))
                {
                    s += w + " ";
                }
                s += Environment.NewLine;
            }
            return s;
        }
    }
}