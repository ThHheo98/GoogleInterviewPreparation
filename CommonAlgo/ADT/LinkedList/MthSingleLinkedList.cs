using System;
using CommonAlgo.ADT.Interfaces;

namespace CommonAlgo.ADT.LinkedList
{
    internal class MthSingleLinkedList<T> : IMthSingleLinkeList<T>, IPrintableList where T : IComparable
    {
        private Element _head;
        private int _itemCount;

        public MthSingleLinkedList()
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

        public T FindMToLast(int m)
        {
            if (m > _itemCount) return default(T);
            if (m < 0) return default(T);
            if (m == _itemCount) return _head.Item;

            var first = _head;
            var second = _head;

            for (int i = 0; i < m; i++)
            {
                first = first.Next;
                if (first == null) return default(T);
            }

            while (first != null)
            {
                first = first.Next; second = second.Next;
            }
            return second.Item;
        }

        public void Print()
        {
            Element t = _head;
            while (t != null)
            {
                Console.WriteLine(t.Item.ToString());
                t = t.Next;
            }
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

        // Имеется указатель на голову односвязного списка. Требуется найти m-й с конца элемент.
        // Решение: отсчитать N элементов с начала списка, взять ещё один указатель на голову списка 
        // и двигать их одновременно, пока первый не достигнет конца. 
        // Тогда второй указатель будет стоять на m-ом с конца элементе.
    }
}