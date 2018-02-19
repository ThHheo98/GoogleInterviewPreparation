using System;

namespace CommonAlgo.ADT.Interfaces
{
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
            if (_head == null)
            {
                _head = element;
                _tail = _head;
            }
            else
            {
                _head = element;
            }
        }

        void ISinglyLinkedList<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {
            if (IsEmpty()) return false;

            Element currentElement = _head;
            Element prevElement = null;
            while (currentElement != null)
            {
                if (currentElement.Item.Equals(item))
                {
                    if (prevElement == null)
                    {
                        _head = currentElement.Next;
                        if (_head == null)
                        {
                            _tail = null;
                        }
                        else if (_head.Next == null)
                        {
                            _tail = _head;
                        }
                    }
                    else
                    {
                        prevElement.Next = currentElement.Next;
                    }
                    _count--;
                }
                else
                {
                    prevElement = currentElement;
                }
                currentElement = currentElement.Next;
            }
            return false;
        }

        public T Find(T item)
        {
            Element t = _head;
            while (t != null)
            {
                if (t.Item.Equals(item))
                    return t.Item;
                t = t.Next;
            }
            return default(T);
        }

        public T InsertAfter(int i, T item)
        {
            if (i < 0) throw new NotSupportedException("Index out of range");

            var element = new Element {Item = item};
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

            Element tmp = _head;
            int currIndex = 0;
            while (tmp != null)
            {
                if (currIndex == i)
                {
                    Element t1 = tmp.Next;
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

        private bool IsEmpty()
        {
            return _count == 0;
        }

        private class Element
        {
            public T Item { get; set; }
            public Element Next { get; set; }
        }
    }
}