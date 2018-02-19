using System;

namespace CommonAlgo.ADT.Interfaces
{
    public interface IQueue<T> where T : IComparable
    {
        int Count { get; }
        T Dequeue();
        void Enqueue(T item);
        bool IsEmpty();
    }
}