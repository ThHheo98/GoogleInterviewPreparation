using System;
using System.Collections.Generic;
using CommonAlgo.ADT.Graphs.EdgeWeighted;
using NUnit.Framework;

namespace CommonAlgo.ADT.Graphs
{
    public class Tests
    {
        [TestCase]
        public void ConnectedComponents()
        {
            var g = new Base.Graph("GraphSmall.txt");
            var c = new GraphConnectedComponents(g);

            Console.WriteLine(c.Count + " компонентов");

            var components = new List<int>[c.Count];


            for (int i = 0; i < components.Length; i++)
            {
                components[i] = new List<int>();
            }

            for (int i = 0; i < g.V; i++)
            {
                components[c.Id(i)].Add(i);
            }

            for (int i = 0; i < components.Length; i++)
            {
                foreach (int item in components[i])
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        [TestCase("TinyEWG.txt")]
        public void PrimsMSTTest(string filename)
        {
            var g = new EdgeWeightedGraph(filename);
//            var mst = new PrimMST(g);
//            foreach (var edge in mst.Edges())
//            {
//                Console.WriteLine(edge.ToString());
//            }

            Console.WriteLine();

            var mst1 = new LazyPrimeMST(g);
            foreach (Edge edge in mst1.Edges())
            {
                Console.WriteLine(edge.ToString());
            }
        }
    }
}