using System;
using System.Collections.Generic;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class InnerListTest2<T> where T : IComparable
    {
        private Node _head;

        public InnerListTest2()
        {
            _head = null;
        }

        public void Add(T value, bool toBegin = false)
        {
            _head = toBegin ? AddToBegin(_head, value) : AddToEnd(_head, value);
        }

        private Node AddToEnd(Node head, T value)
        {
            var node = new Node {item = value};
            if (head == null)
            {
                head = node;
                return head;
            }
            Node t = head;
            while (t.next != null)
            {
                t = t.next;
            }

            t.next = node;
            return head;
        }

        private Node AddToBegin(Node head, T item)
        {
            var newBee = new Node {item = item, next = null};

            newBee.next = head;
            head = newBee;
            return head;
        }

        public void Print()
        {
            Node t = _head;
            while (t != null)
            {
                Console.Write(t.item);
                t = t.next;
            }
            Console.WriteLine();
        }

        // TODO: Cracking the coding interview task 2.5
        private Node FindCycleStartNode(Node head)
        {
            Node slow = head;
            Node fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    break;
                }
            }

            if (fast == null && fast.next == null)
            {
                return null;
            }

            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return fast;
        }

        public void RemoveDuplicatesHashTable()
        {
            if (_head == null || _head.next == null) return;

            var ht = new HashSet<T>();

            Node curr = _head;
            Node prev = _head;

            while (curr != null)
            {
                if (!ht.Contains(curr.item))
                {
                    ht.Add(curr.item);
                    prev = curr;
                }
                else
                {
                    prev.next = curr.next;
                }

                curr = curr.next;
            }
        }

        public void RemoveDuplicates()
        {
            if (_head == null || _head.next == null) return;

            Node start = _head;
            while (start != null)
            {
                Node curr = start;
                Node prev = start;

                while (curr != null)
                {
                    if (curr.item.CompareTo(prev.item) != 0)
                    {
                        prev = curr;
                    }
                    else
                    {
                        prev.next = curr.next;
                    }

                    curr = curr.next;
                }
                start = start.next;
            }
        }

        public T FindkthToLast(int k)
        {
            if (k <= 0) throw new ArgumentException("k");

            // suppose that list has k element at least

            Node f = _head;

            for (int i = 0; i < k; i++)
            {
                if (f == null) throw new InvalidOperationException("Length < k");
                f = f.next;
            }
            if (f == null) throw new InvalidOperationException("Length < k");

            Node s = _head;
            while (f != null)
            {
                s = s.next;
                f = f.next;
            }
            return s.item;
        }

        public bool RemoveItemFromListWithoutUsingHead(T item)
        {
            Node t = _head;
            while (t != null && t.item.CompareTo(item) != 0)
            {
                t = t.next;
            }

            if (t != null)
            {
                bool b = RemoveItemFromListWithoutUsingHead(t);
                if (b)
                {
                    Console.WriteLine("Node was removed successfully!");
                    return true;
                }
                Console.WriteLine("Node was not removed!");
                return false;
            }
            Console.WriteLine("Cannot find item equals the arg!");
            return false;
        }


        private bool RemoveItemFromListWithoutUsingHead(Node deleted)
        {
            if (deleted == null || deleted.next == null) return false;
            // cannot be done if input node is last node in list
            // we can mark it as deleted (node.IsDeleted = true)

            Node next = deleted.next;
            deleted.item = next.item;
            deleted.next = next.next;
            return true;
        }

        public void PartitionByItem(T item)
        {
            if (_head == null || _head.next == null) return;

            _head = PartitionByItemInternal(_head, item);
        }

        private Node PartitionByItemInternal(Node head, T item)
        {
            if (head == null || head.next == null) return head;

            Node after = null;
            Node before = null;
            Node equals = null;

            Node runner = _head;
            while (runner != null)
            {
                if (runner.item.CompareTo(item) < 0)
                {
                    before = AddToBegin(before, runner.item);
                }
                else if (runner.item.CompareTo(item) > 0)
                {
                    after = AddToBegin(after, runner.item);
                }
                else
                {
                    equals = AddToBegin(equals, runner.item);
                }

                runner = runner.next;
            }
            equals = MergeLists(before, equals);
            equals = MergeLists(after, equals);
            return equals;
        }

        private static Node MergeLists(Node first, Node second)
        {
            if (first == null) return second;
            if (second == null) return first;

            if (first.item.CompareTo(second.item) < 0)
            {
                first.next = MergeLists(first.next, second);
                return first;
            }
            second.next = MergeLists(second.next, first);
            return second;
        }

        public bool IsPolindrom()
        {
            var stack = new Stack<T>();
            Node slow = _head;
            Node fast = _head;

            // find middle of list

            while (fast != null && fast.next != null)
            {
                stack.Push(slow.item);
                slow = slow.next;
                fast = fast.next.next;
            }

            // if length is odd
            if (fast != null)
            {
                slow = slow.next;
            }

            // now slow in the middle
            while (slow != null) // from middle to the end
            {
                T v = stack.Pop();
                if (v.CompareTo(slow.item) != 0)
                    return false;
                slow = slow.next;
            }
            return true;
        }

        #region Overrides of Object

        public override string ToString()
        {
            string str = string.Empty;
            Node t = _head;
            while (t != null)
            {
                str += t.item.ToString();
                t = t.next;
            }
            return str;
        }

        #endregion

        private class Node
        {
            public T item;
            public Node next;
        }
    }
}