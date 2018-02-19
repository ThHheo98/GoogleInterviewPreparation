using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.ADT.Graphs._2015Tasks
{
    /// <summary>
    ///     O(V+E)
    ///     http://www.geeksforgeeks.org/detect-cycle-undirected-graph/
    /// </summary>
    public class DetectCycleInUndircetedGraphsDFS
    {
        [TestCase]
        public void Test()
        {
            var g = new UndirectedGraph(4);
            g.AddVertex(0, 1);
            g.AddVertex(1, 2);
            g.AddVertex(1, 3);
            g.AddVertex(3, 1);
            Console.WriteLine(g.IsCyclic());
            Assert.IsTrue(g.IsCyclic());
            g = new UndirectedGraph(4);
            g.AddVertex(0, 1);
            g.AddVertex(1, 2);
            g.AddVertex(2, 3);
            Console.WriteLine(g.IsCyclic());
            Assert.IsFalse(g.IsCyclic());
        }

        /// <summary>
        ///     We do a DFS traversal of the given graph. For every visited vertex ‘v’,
        ///     if there is an adjacent ‘u’ such that u is already visited and u
        ///     is not parent of v, then there is a cycle in graph.
        ///     If we don’t find such an adjacent for any vertex,
        ///     we say that there is no cycle.
        ///     The assumption of this approach is that there are no parallel edges
        ///     between any two vertices.
        /// </summary>
        private class UndirectedGraph
        {
            private readonly IList<IList<int>> _adj;


            public UndirectedGraph(int v)
            {
                VertexCount = v;
                _adj = new List<IList<int>>();
                for (var i = 0; i < v; i++)
                {
                    _adj.Add(new List<int>());
                }
            }

            public int VertexCount { get; private set; }

            public void AddVertex(int from, int to)
            {
                _adj[from].Add(to);
                _adj[to].Add(from);
            }

            // A recursive function that uses visited[] and parent to detect
            // cycle in subgraph reachable from vertex v.
            private bool IsCyclicInternal(bool[] visited, int s, int parentVertex)
            {
                visited[s] = true;
                for (var i = 0; i < _adj[s].Count; i++)
                {
                    // If an adjacent is not visited, then recur for that
                    // adjacent
                    var to = _adj[s][i];
                    if (!visited[to])
                    {
                        if (IsCyclicInternal(visited, to, s))
                            return true;
                    }
                    // If an adjacent is visited and not parent of current
                    // vertex, then there is a cycle.
                    else if (to != parentVertex)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool IsCyclic()
            {
                var visited = new bool[VertexCount];
                for (var i = 0; i < VertexCount; i++)
                {
                    if (!visited[i])
                    {
                        if (IsCyclicInternal(visited, i, -1))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }

    /// <summary>
    ///     O(V+E)
    ///     http://www.geeksforgeeks.org/detect-cycle-in-a-graph/
    /// </summary>
    public class DetectCycleInDirectedGraphsDFS
    {
        [TestCase]
        public void Test()
        {
            var g = new DirectedGraph(4);
            g.AddVertex(0, 1);
            g.AddVertex(1, 2);
            g.AddVertex(1, 3);
            g.AddVertex(3, 1);
            Console.WriteLine(g.IsCyclic());
            Assert.IsTrue(g.IsCyclic());
            g = new DirectedGraph(4);
            g.AddVertex(0, 1);
            g.AddVertex(1, 2);
            g.AddVertex(2, 3);
            Console.WriteLine(g.IsCyclic());
            Assert.IsFalse(g.IsCyclic());
        }

        /// <summary>
        /// </summary>
        private class DirectedGraph
        {
            private readonly IList<IList<int>> _adj;

            public DirectedGraph(int v)
            {
                VertexCount = v;
                _adj = new List<IList<int>>();
                for (var i = 0; i < v; i++)
                {
                    _adj.Add(new List<int>());
                }
            }

            public int VertexCount { get; private set; }

            public void AddVertex(int from, int to)
            {
                _adj[from].Add(to);
            }

            // This function is a variation of DFSUtil() in http://www.geeksforgeeks.org/archives/18212
            private bool IsCyclicInternal(bool[] visited, bool[] recStack, int s)
            {
                if (!visited[s])
                {
                    visited[s] = true;
                    recStack[s] = true;

                    for (var i = 0; i < _adj[s].Count; i++)
                    {
                        var to = _adj[s][i];
                        if (!visited[to] && IsCyclicInternal(visited, recStack, to))
                            return true;
                        if (recStack[to])
                            return true;
                    }
                }
                recStack[s] = false;
                return false;
            }

            public bool IsCyclic()
            {
                var visited = new bool[VertexCount];
                var recStack = new bool[VertexCount];
                for (var i = 0; i < VertexCount; i++)
                {
                    if (!visited[i])
                        if (IsCyclicInternal(visited, recStack, i))
                            return true;
                }
                return false;
            }
        }
    }
}