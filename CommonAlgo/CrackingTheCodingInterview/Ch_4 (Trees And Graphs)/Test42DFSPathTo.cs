using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test42DFSPathTo
    {
        [TestCase]
        public void Test42()
        {
            IDigraph g = new Digraph(4);
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);
            g.AddEdge(3, 4);
            var digraphPath = new DigraphPath(g, 0);
            Assert.IsTrue(digraphPath.HasPathTo(4));
        }

        private class Digraph : IDigraph
        {
            private readonly List<int>[] _adj; // adjacent list
            private readonly int _v;
            private int _e;

            public Digraph(int v)
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
                _e++;
            }

            public IEnumerable<int> Adj(int v)
            {
                return _adj[v];
            }


            public override string ToString()
            {
                string s = V + " vertexes, " + E + " edges" + Environment.NewLine;
                for (int v = 0; v < V; v++)
                {
                    s += v + ": ";
// ReSharper disable once LoopCanBeConvertedToQuery
                    foreach (int w in Adj(v))
                    {
                        s += w + " ";
                    }
                    s += Environment.NewLine;
                }
                return s;
            }
        }

        private class DigraphPath : IGraphPath
        {
            private readonly int[] _edgeTo;
            private readonly bool[] _marked;
            private readonly int _startVertex;

            public DigraphPath(IDigraph g, int startVertex)
            {
                _marked = new bool[g.V];
                _edgeTo = new int[g.V];
                _startVertex = startVertex;
                Dfs(g, startVertex);
            }

            private void Dfs(IDigraph graph, int v)
            {
                _marked[v] = true;
                foreach (int w in graph.Adj(v))
                {
                    if (_marked[w]) continue;
                    _edgeTo[w] = v;
                    Dfs(graph, w);
                }
            }

            #region Implementation of IGraphPath

            public bool HasPathTo(int v)
            {
                return _marked[v];
            }

            public IEnumerable<int> PathTo(int v)
            {
                if (!HasPathTo(v)) return null;
                var path = new Stack<int>();
                for (int x = v; x != v; x = _edgeTo[x])
                {
                    path.Push(x);
                }
                path.Push(_startVertex);
                return path;
            }

            #endregion
        }

        private interface IDigraph
        {
            int V { get; }
            int E { get; }
            void AddEdge(int v, int w);
            IEnumerable<int> Adj(int v);
        }

        private interface IGraphPath
        {
            bool HasPathTo(int v);
            IEnumerable<int> PathTo(int v);
        }
    }
}