namespace CommonAlgo.ADT.Graphs.EdgeWeighted
{
    public class JavaKruskal
    {
//        public class KruskalMST
//        {
//            private readonly Queue<Edge> mst = new Queue<Edge>(); // edges in MST
//            private double weight; // weight of MST

//            public KruskalMST(EdgeWeightedGraph G)
//            {
//                // more efficient to build heap by passing array of edges
//                var pq = new MinPQ<Edge>();
//                for (Edge e : G.edges())
//                {
//                    pq.insert(e);
//                }
//
//                // run greedy algorithm
//                var uf = new UF(G.V());
//                while (!pq.isEmpty() && mst.size() < G.V() - 1)
//                {
//                    Edge e = pq.delMin();
//                    int v = e.either();
//                    int w = e.other(v);
//                    if (!uf.connected(v, w))
//                    {
//                        // v-w does not create a cycle
//                        uf.union(v, w); // merge v and w components
//                        mst.enqueue(e); // add edge e to mst
//                        weight += e.weight();
//                    }
//                }
        // }

////
//            public Iterable<Edge> edges()
//            {
//                return mst;
//            }

//            public double weight()
//            {
//                return weight;
//            }
//
//            public static void main(String[] args)
//            {
//                In in =    new In(args[0]);
//                var G = new EdgeWeightedGraph(in)    ;
//                var mst = new KruskalMST(G);
//                for (Edge e : mst.edges())
//                {
//                    StdOut.println(e);
//                }
//                StdOut.printf("%.5f\n", mst.weight());
//            }
//        }
    }
}