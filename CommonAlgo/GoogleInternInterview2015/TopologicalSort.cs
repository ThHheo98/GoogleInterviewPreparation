using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.GoogleInternInterview2015
{
    public class TopologicalSort
    {
        [TestCase]
        public void Test()
        {
            var graph = new List<List<int>>();
            var vertexCnt = 6;
            for (var i = 0; i < vertexCnt; i++)
            {
                graph.Add(new List<int>());
            }

            graph[5].Add(2);
            graph[5].Add(0);
            graph[4].Add(0);
            graph[4].Add(1);
            graph[2].Add(3);
            graph[3].Add(1);

            var used = new bool[graph.Count];
            var ans = new Stack<int>(graph.Count);
            for (var i = 0; i < graph.Count; i++)
                if (!used[i]) DFS(ans, used, graph, i);
            Utils.PrintCollection(ans);
        }

        [TestCase]
        public void Test1()
        {
            var graph = new List<List<int>>();
            var vertexCnt = 5;
            for (var i = 0; i < vertexCnt; i++)
            {
                graph.Add(new List<int>());
            }

            graph[0].Add(1);
            graph[0].Add(2);
            graph[0].Add(3);
            graph[1].Add(4);
            graph[2].Add(4);
            graph[3].Add(4);
            var used = new bool[graph.Count];
            var ans = new Stack<int>(graph.Count);
            for (var i = 0; i < graph.Count; i++)
                if (!used[i]) DFS(ans, used, graph, i);
            Utils.PrintCollection(ans);
        }

        private static void DFS(Stack<int> ans, IList<bool> used, IReadOnlyList<List<int>> graph, int v)
        {
            used[v] = true;
            for (var i = 0; i < graph[v].Count; i++)
            {
                var to = graph[v][i];
                if (!used[to])
                    DFS(ans, used, graph, to);
            }
            ans.Push(v);
        }
    }
}