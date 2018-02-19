using System;

namespace CommonAlgo.ADT.Interfaces
{
    internal interface ITailedSinglyLinkedList<T> : ISinglyLinkedList<T> where T : IComparable
    {
        T InsertAfter(int i, T item);
        new bool Remove(T item);
    }
}