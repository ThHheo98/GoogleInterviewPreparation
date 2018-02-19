using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.ADT.Graphs._2015Tasks
{
    /// <summary>
    /// http://e-maxx.ru/algo/mst_prim
    /// </summary>
    internal class GraphPrim
    {
        private class WeightedPath
        {
            public WeightedPath(int to, int w)
            {
                To = to;
                Weight = w;
            }

            public int To;
            public int Weight;
        }

        //[NotReady]!!!!!!!!!!!!!!!!!!!!
        [TestCase]
        public void Test()
        {
            int n = 5;
            var gr = new List<IList<WeightedPath>>();
            for (int i = 0; i < n; i++)
                gr.Add(new List<WeightedPath>());

            gr[0].Add(new WeightedPath(1, 5));
            gr[0].Add(new WeightedPath(2, 3));
            gr[0].Add(new WeightedPath(4, 6));
            
            gr[1].Add(new WeightedPath(0, 5));
            gr[1].Add(new WeightedPath(2, 4));

            gr[2].Add(new WeightedPath(1, 4));
            gr[2].Add(new WeightedPath(0, 3));
            gr[2].Add(new WeightedPath(4, 2));
            gr[2].Add(new WeightedPath(5, 1));

            gr[3].Add(new WeightedPath(2, 1));
            gr[3].Add(new WeightedPath(4, 7));

            gr[4].Add(new WeightedPath(2, 2));
            gr[4].Add(new WeightedPath(0, 6));

            int s = 0;
            var dist = new int[n];
            var pred = new int[n];
            var marked = new bool[n];
            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[s] = 0;
            for (int i = 0; i < n; i++)
            {
                int v = -1; // find v that has minimum distance among unmarked vertexes
                for (int j = 0; j < n; j++)
                {
                    if (!marked[j]) // if vertex not marked yet
                    {
                        if (v == -1 || dist[j] < dist[v])
                            v = j; // find vertex with min distance
                    }
                }
                if (dist[v] == int.MaxValue) break;
                marked[v] = true;// this vertex is marked now
                for (int k = 0; k < gr[v].Count; k++)
                {
                    int to = gr[v][k].To;
                    int w = gr[v][k].Weight;
                    if (dist[v] + w < dist[to])
                    {
                        dist[to] = dist[v] + w;
                        pred[to] = v;
                    }
                }
            }

            // distanse to all vertexes were found
            // now we can find shortest path from s to t

            // find sp from 0 to 3
            var path = new Stack<int>();
            int t = 3;
            int d = 0;
            for (int v = t; v != s; v = pred[v])
            {
                d += dist[v];
                path.Push(v);
            }
            path.Push(s);
            Console.Write("Shortest path from {0} to {1}: ", s, t);
            while (path.Count > 0)
            {
                Console.Write(path.Pop() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Distance from {0} to {1}: {2}", s, t, dist[t]);

            // find sp from 0 to 3
            path = new Stack<int>();
            t = 2;
            d = 0;
            for (int v = t; v != s; v = pred[v])
            {
                d += dist[v];
                path.Push(v);
            }
            path.Push(s);
            Console.Write("Shortest path from {0} to {1}: ", s, t);
            while (path.Count > 0)
            {
                Console.Write(path.Pop() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Distance from {0} to {1}: {2}", s, t, dist[t]);

        }
    }
}