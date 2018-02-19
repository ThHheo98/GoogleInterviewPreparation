using System;

namespace CommonAlgo.ADT.Interfaces
{
    public interface IStack<T> where T : IComparable
    {
        int ItemCount { get; }
        T Pop();
        void Push(T item);
        T Peek();
        bool IsEmpty();
    }
}