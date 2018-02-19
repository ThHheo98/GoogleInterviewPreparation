using System;
using CommonAlgo.ADT.LinkedList;

namespace CommonAlgo.ADT.Interfaces
{
    public interface IDoublyLinkedList<T> where T : IComparable
    {
        int Count { get; }
        void Add(T item);
        void Remove(T item);
        void Clear();
        void Flat();
        void Unflat();
        DoublyLinkedList<int> CreateFlattenList();
    }
}