using System.Collections.Generic;

namespace CommonAlgo.ADT.Graphs.Base
{
    public interface IDigraph
    {
        int V { get; }
        int E { get; }
        void AddEdge(int v, int w);
        IEnumerable<int> Adj(int v);
        IDigraph Reverse();
    }
}