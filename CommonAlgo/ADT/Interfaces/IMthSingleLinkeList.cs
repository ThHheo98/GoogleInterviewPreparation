using System;

namespace CommonAlgo.ADT.Interfaces
{
    internal interface IMthSingleLinkeList<T> : ISinglyLinkedList<T> where T : IComparable
    {
        T FindMToLast(int m);
    }
}