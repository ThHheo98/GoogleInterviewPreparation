using System;
using System.Collections.Generic;
using CommonAlgo.ADT.Interfaces;

namespace CommonAlgo.ADT.LinkedList
{
    public class DoublyLinkedList<T> : IPrintableList, IDoublyLinkedList<T> where T : IComparable
    {
        private int _count;
        private Element _head;
        private Element _tail;

        public void Add(T item)
        {
            var n = new Element {Item = item};
            if (_head == null)
            {
                _head = n;
                _tail = _head;
            }
            else
            {
                n.Prev = _tail;
                _tail.Next = n;
                _tail = _tail.Next;
            }
            _count++;
        }

        public void Remove(T item)
        {
            if (IsEmpty()) throw new InvalidOperationException("List is empty!");
            Element node = Find(item);
            if (node != null)
            {
                InternalRemoveNode(node);
            }
        }

        public void Clear()
        {
            while (!IsEmpty())
            {
                Remove(_head);
            }
        }

        public void Flat()
        {
            Element t = _head;
            while (t != null)
            {
                if (t.Child != null)
                {
                    WorkWithChild(t.Child);
                }
                t = t.Next;
            }
        }

        public void Unflat()
        {
            Element curNode;
            ExploreAndSeparate(_head);

            /* Update the tail pointer */
            for (curNode = _head;
                curNode.Next != null;
                curNode = curNode.Next) ;

            _tail = curNode;
        }

        public DoublyLinkedList<int> CreateFlattenList()
        {
            var list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list._head.Child = new DoublyLinkedList<int>.Element {Item = 3};
            list._head.Next.Child = new DoublyLinkedList<int>.Element {Item = 4};
            return list;
        }

        public int Count
        {
            get { return _count; }
        }

        public void Print()
        {
            Element t = _head;
            while (t != null)
            {
                Console.WriteLine(t.ToString());
                t = t.Next;
            }
        }

        private void Remove(Element item)
        {
            if (item != null)
            {
                InternalRemoveNode(item);
            }
        }

        private void WorkWithChild(Element child)
        {
            _tail.Next = child;
            child.Prev = _tail;
            Element curr = child;
            _count++;
            while (curr.Next != null)
            {
                curr = curr.Next;
                _count++;
            }

            _tail = curr;
        }

        /* This is the function that actually does the recursion and
        * the separation
        */

        private void ExploreAndSeparate(Element childListStart)
        {
            Element curNode = childListStart;
            while (curNode != null)
            {
                if (curNode.Child != null)
                {
                    /* terminates the child list before the child */
                    curNode.Child.Prev.Next = null;
                    /* starts the child list beginning with the child */
                    curNode.Child.Prev = null;
                    ExploreAndSeparate(curNode.Child);
                    _count--;
                }
                curNode = curNode.Next;
            }
        }

        private Element Find(T item)
        {
            Element t = _head;
            while (t != null)
            {
                if (t.Item.CompareTo(item) == 0)
                {
                    return t;
                }
                t = t.Next;
            }
            return null;
        }

        private void InternalRemoveNode(Element node)
        {
            if (_count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                if (node.Equals(_tail))
                {
                    node.Prev.Next = node.Next;
                    _tail = node.Prev;
                    node.Prev = null;
                }
                else if (node.Equals(_head))
                {
                    node.Next.Prev = node.Prev;
                    _head = node.Next;
                    node.Next = null;
                }
                else
                {
                    node.Next.Prev = node.Prev;
                    node.Prev.Next = node.Next;
                    node.Prev = null;
                    node.Next = null;
                }
            }
            _count--;
        }

        private bool IsEmpty()
        {
            return _count == 0;
        }

        public override string ToString()
        {
            return string.Format("Count: {0}", _count);
        }

        private class Element
        {
            public T Item { get; set; }
            public Element Prev { get; set; }
            public Element Next { get; set; }
            public Element Child { get; set; }

            protected bool Equals(Element other)
            {
                return EqualityComparer<T>.Default.Equals(Item, other.Item);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Element) obj);
            }

            public override int GetHashCode()
            {
                return EqualityComparer<T>.Default.GetHashCode(Item);
            }

            public override string ToString()
            {
                return string.Format("Item: {0}", Item);
            }
        }
    }
}