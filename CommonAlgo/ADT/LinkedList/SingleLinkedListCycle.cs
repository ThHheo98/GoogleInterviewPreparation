using System;
using CommonAlgo.ADT.Interfaces;

namespace CommonAlgo.ADT.LinkedList
{
    internal class SingleLinkedListCycle<T> : ISingleLinkeListCycle<T>, IPrintableList where T : IComparable
    {
        private Element _head;

        public SingleLinkedListCycle()
        {
            _head = null;
            Count = 0;
        }

        public void Print()
        {
            var t = _head;
            while (t != null)
            {
                Console.WriteLine(t.Item.ToString());
                t = t.Next;
            }
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

            Count++;
        }

        public void Remove(T item)
        {
            if (IsEmpty()) return;

            var currentElement = _head;
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
                    Count--;
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
            var cur = _head;

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

        public int Count { get; private set; }

        public void FindCycle()
        {
            var cycled = new SingleLinkedListCycle<int>();

            cycled.AddToFront(1);
            cycled.AddToFront(2);
            cycled.AddToFront(3);
            cycled._head.Next.Next.Next = cycled._head; // create a cycle

            var isCycled = IsListHasCycle(cycled);

            if (isCycled)
            {
                Console.WriteLine("isCycled");
            }
            else
            {
                Console.WriteLine("is not cycled");
            }

            cycled = new SingleLinkedListCycle<int>();

            cycled.AddToFront(1);
            cycled.AddToFront(2);
            cycled.AddToFront(3);

            isCycled = IsListHasCycle(cycled);

            if (isCycled)
            {
                Console.WriteLine("isCycled");
            }
            else
            {
                Console.WriteLine("is not cycled");
            }
        }

        public T FindMToLast(int m)
        {
            if (m > Count) return default(T);
            if (m < 0) return default(T);
            if (m == Count) return _head.Item;

            var c = 0;
            var ref1 = _head;
            while (c != m)
            {
                ref1 = ref1.Next;
                if (ref1 == null)
                    return default(T);
                c++;
            }

            var ref2 = _head;

            while (ref1 != null)
            {
                ref1 = ref1.Next;
                ref2 = ref2.Next;
            }
            return ref2.Item;
        }

        public void Update(T item)
        {
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        private static bool IsListHasCycle<T1>(SingleLinkedListCycle<T1> cycle) where T1 : IComparable
        {
            SingleLinkedListCycle<T1>.Element fast;
            var slow = fast = cycle._head;

            while (true)
            {
                if (fast == null || fast.Next == null) // list is null terminated
                {
                    return false;
                }

                if (fast.Next == slow)
                {
                    return true; // has a cicle
                }
                slow = slow.Next;
                fast = fast.Next.Next;
            }
        }

        private class Element
        {
            public T Item { get; set; }
            public Element Next { get; set; }
        }
    }
}