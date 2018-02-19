using CommonAlgo.ADT.Graphs.Base;

namespace CommonAlgo.ADT.Graphs
{
    public static class GraphExtensions
    {
        public static int Degree(this IGraph graph, int edgeIndex)
        {
            int degree = 0;
            foreach (int i in graph.Adj(edgeIndex))
            {
                degree++;
            }
            return degree;
        }

        public static int MaxDegree(this IGraph graph)
        {
            int max = 0;
            for (int i = 0; i < graph.V; i++)
            {
                int degree = graph.Degree(i);
                if (degree > max)
                    max = degree;
            }
            return max;
        }

        public static int MinDegree(this IGraph graph)
        {
            int minDegree = int.MaxValue;
            for (int i = 0; i < graph.V; i++)
            {
                int degree = graph.Degree(i);
                if (degree < minDegree)
                    minDegree = degree;
            }
            return minDegree;
        }

        public static int NumberOfSelfLoops(this IGraph graph)
        {
            int count = 0;
            for (int i = 0; i < graph.V; i++)
            {
                foreach (int j in graph.Adj(i))
                {
                    if (j == i) count++;
                }
            }
            //In graph theory, the degree (or valency) of a vertex of a graph 
            // is the number of edges incident to the vertex,
            // WITH LOOPS COUNTED TWICE.
            return count/2;
        }

        public static int AverageDegree(this IGraph graph)
        {
            return 2*graph.E/graph.V;
        }
    }
}