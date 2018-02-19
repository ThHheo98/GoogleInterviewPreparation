namespace CommonAlgo.ADT.Graphs.Base
{
    public interface IGraphSearch
    {
        int Count { get; }
        bool Marked(int v);
    }
}