using System;

namespace CommonAlgo.ADT.Interfaces
{
    internal interface ISingleLinkeListCycle<T> : ISinglyLinkedList<T> where T : IComparable
    {
        void FindCycle();
    }
}