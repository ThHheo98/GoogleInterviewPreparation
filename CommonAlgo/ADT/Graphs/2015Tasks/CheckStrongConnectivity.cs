using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.ADT.Graphs._2015Tasks
{
    /// <summary>
    ///     http://www.geeksforgeeks.org/connectivity-in-a-directed-graph/
    ///     http://e-maxx.ru/algo/strong_connected_components
    ///     Find SCC. If SCC == 1 then digraph is strong connected
    ///     Examples:
    ///     SC:
    ///     0 -> 1 -> 2 ->"--" 4
    ///     *\   _/
    ///     3
    ///     NotSC:
    ///     0 -> 1 -> 2 -> 3
    /// </summary>
    internal class CheckStrongConnectivity
    {
        [TestCase]
        public void TestIsSc()
        {
            const int v = 5;
            var g = new List<IList<int>>();
            for (var i = 0; i < v; i++)
                g.Add(new List<int>());
            
            g[0].Add(1);
            g[1].Add(2);
            g[2].Add(3);
            g[2].Add(4);
            g[3].Add(0);
            g[4].Add(2);
            Console.WriteLine("Graph");
            Utils.PrintAdjacencyList(g);
            var gr = TransposeGraph(g, v);
            Console.WriteLine("Transposed graph");
            Utils.PrintAdjacencyList(gr);

            var visited = new bool[v];

            DFS(g, 0, visited);
            foreach (var b in visited)
                Assert.IsTrue(b);

            for (var i = 0; i < visited.Length; i++)
                visited[i] = false;

            var component = new List<int>();
            DFSC(gr, 0, visited, component);
            Console.WriteLine("Length of component = {0}", component.Count);
            Assert.IsTrue(component.Count == v);
        }

        [TestCase]
        public void TestIsNotSc()
        {
            const int v = 4;
            var g = new List<IList<int>>();
            for (var i = 0; i < v; i++)
                g.Add(new List<int>());

            g[0].Add(1);
            g[1].Add(2);
            g[2].Add(3);

            Console.WriteLine("Graph");
            Utils.PrintAdjacencyList(g);
            var gr = TransposeGraph(g, v);
            Console.WriteLine("Transposed graph");
            Utils.PrintAdjacencyList(gr);

            var visited = new bool[v];
            DFS(g, 0, visited);
            foreach (var b in visited)
                Assert.IsTrue(b);

            for (var i = 0; i < visited.Length; i++)
                visited[i] = false;

            var component = new List<int>();
            DFSC(gr, 0, visited, component);
            Console.WriteLine("Length of component = {0}", component.Count);
            Assert.IsTrue(component.Count != v);
        }

        private static void DFSC(IList<IList<int>> graph, int s, bool[] visited, IList<int> component)
        {
            visited[s] = true;
            component.Add(s);
            for (var i = 0; i < graph[s].Count; i++)
            {
                var to = graph[s][i];
                if (!visited[to])
                    DFSC(graph, to, visited, component);
            }
        }

        private static void DFS(IList<IList<int>> graph, int s, bool[] vis)
        {
            vis[s] = true;
            for (var i = 0; i < graph[s].Count; i++)
            {
                var to = graph[s][i];
                if (!vis[to])
                    DFS(graph, to, vis);
            }
        }

        private static IList<IList<int>> TransposeGraph(IList<IList<int>> list, int v)
        {
            var r = new List<IList<int>>();
            for (var i = 0; i < v; i++)
                r.Add(new List<int>());
            for (var i = 0; i < v; i++)
                for (var j = 0; j < list[i].Count; j++)
                    r[list[i][j]].Add(i);
            return r;
        }
    }
}