using System.Collections.Generic;

namespace CommonAlgo.ADT.Graphs.Base
{
    public interface IGraphPath
    {
        bool HasPathTo(int v);
        IEnumerable<int> PathTo(int v);
    }
}