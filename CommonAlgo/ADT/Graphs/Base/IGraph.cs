using System.Collections.Generic;

namespace CommonAlgo.ADT.Graphs.Base
{
    public interface IGraph
    {
        int V { get; }
        int E { get; }
        void AddEdge(int v, int w);
        IEnumerable<int> Adj(int v);
    }
}