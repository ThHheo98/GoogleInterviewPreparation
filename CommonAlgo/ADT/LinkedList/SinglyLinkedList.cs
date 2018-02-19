using System;
using CommonAlgo.ADT.Interfaces;

namespace CommonAlgo.ADT.LinkedList
{
    public class SinglyLinkedList<T> : ISinglyLinkedList<T> where T : IComparable
    {
        private Element _head;
        private int _itemCount;

        public SinglyLinkedList()
        {
            _head = null;
            _itemCount = 0;
        }

        public void AddToFront(T item)
        {
            var newNode = new Element {Item = item, Next = null};

            if (IsEmpty())
            {
                _head = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }

            _itemCount++;
        }

        public void Remove(T item)
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

        public T Find(T item)
        {
            if (IsEmpty()) return default(T);
            Element cur = _head;

            while (cur != null)
            {
                if (cur.Item.Equals(item))
                {
                    return cur.Item;
                }
                cur = cur.Next;
            }

            return default(T);
        }

        public int Count
        {
            get { return _itemCount; }
        }

        public void Update(T item)
        {
        }

        public bool IsEmpty()
        {
            return _itemCount == 0;
        }

        private class Element
        {
            public T Item { get; set; }
            public Element Next { get; set; }
        }
    }
}