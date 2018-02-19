using System;
using CommonAlgo.Misc;

namespace CommonAlgo.ADT.LinkedList
{
    public interface ISinglyLinkedList<T> where T : IComparable
    {
        int Count { get; }
        void AddToFront(T item);
        void Remove(T item);
        T Find(T item);
    }

    internal interface ITailedSinglyLinkedList<T> : ISinglyLinkedList<T> where T : IComparable
    {
        T InsertAfter(int i, T item);
        new bool Remove(T item);
    }

    internal class TailedSinglyLinkedList<T> : ITailedSinglyLinkedList<T> where T : IComparable 
    {
        private int _count;
        private Element _head;
        private Element _tail;

        public int Count
        {
            get { return _count; }
        }

        public void AddToFront(T item)
        {
            var element = new Element {Item = item, Next = _head};
            _head = element;
        }

        void ISinglyLinkedList<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {

            if (IsEmpty()) return;

            Element currentElement = _head;
            Element prevElement = null;
            while (currentElement != null)
            {
                if (currentElement.Item.Equals(item))
                {
                    if (prevElement == null)
                    {
                        _head = currentElement.Next;
                    }
                    else
                    {
                        prevElement.Next = currentElement.Next;
                    }
                    _itemCount--;
                }
                else
                {
                    prevElement = currentElement;
                }
                currentElement = currentElement.Next;
            }
        }

        private bool IsEmpty()
        {
            return _count == 0;
        }

        public T Find(T item)
        {
            var t = _head;
            while (t!= null)
            {
                if (t.Item.Equals(item))
                    return t.Item;
                t = t.Next;
            }
            return default(T);
        }

        public T InsertAfter(int i, T item)
        {
            if (i<0) throw new NotSupportedException("Index out of range");

            var element = new Element { Item = item };
            if (_count == 0)
            {
                _head = element;
                _tail = _head;
                _count++;
                return element.Item;
            }

            if (_count == 1)
            {
                _head.Next = element;
                _tail = _head.Next;
                _count++;
                return element.Item;
            }

            var tmp = _head;
            int currIndex =  0;
            while (tmp != null)
            {
                if (currIndex == i)
                {
                    var t1 = tmp.Next;
                    tmp.Next = element;
                    element = t1;
                    _count++;
                    return element.Item;
                }
                currIndex++;
                tmp = tmp.Next;
            }
            return default(T);
        }

        private class Element
        {
            public T Item { get; set; }
            public Element Next { get; set; }
        }
    }
}