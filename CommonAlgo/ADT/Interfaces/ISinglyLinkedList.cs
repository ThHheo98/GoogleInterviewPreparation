using System;

namespace CommonAlgo.ADT.Interfaces
{
    public interface ISinglyLinkedList<T> where T : IComparable
    {
        int Count { get; }
        void AddToFront(T item);
        void Remove(T item);
        T Find(T item);
    }
}