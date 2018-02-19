using System;
using System.Collections.Generic;
using C5;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TreeMapsAndHeaps
{
    public class ListNode : IComparable<ListNode>
    {
        public readonly int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
            next = null;
        }

        #region Implementation of IComparable<in ListNode>

        public int CompareTo(ListNode other)
        {
            return val.CompareTo(other.val);
        }

        #endregion
    }

    /// <summary>
    ///     https://www.interviewbit.com/problems/merge-k-sorted-lists/
    ///     http://www.geeksforgeeks.org/merge-k-sorted-linked-lists/
    ///     http://www.programcreek.com/2013/02/leetcode-merge-k-sorted-lists-java/
    /// </summary>
    public class MergeKSortedLists
    {
        [Test]
        public void Test()
        {
            var l = new List<ListNode>();
            var n1 = new ListNode(1) { next = new ListNode(3) { next = new ListNode(5) } };
            var n2 = new ListNode(1) { next = new ListNode(6) { next = new ListNode(8) } };
            l.Add(n1);
            l.Add(n2);

            var listNode = mergeKLists(l);
            var t = listNode;

            var q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(1);
            q.Enqueue(3);
            q.Enqueue(5);
            q.Enqueue(6);
            q.Enqueue(8);
            while (t != null)
            {
                var deq = q.Dequeue();
                Assert.AreEqual(deq, t.val);
                t = t.next;
            }
        }

        public ListNode mergeKLists(List<ListNode> a)
        {
            if (a == null || a.Count == 0)
                return null;

            var pq = new IntervalHeap<ListNode>();

            foreach (var ln in a)
            {
                if (ln != null)
                    pq.Add(ln);
            }

            var head = new ListNode(0);
            var p = head;
            while (pq.Count > 0)
            {
                var t = pq.DeleteMin();
                p.next = t;
                p = p.next;

                if (t.next != null)
                    pq.Add(t.next);
            }
            return head.next;
        }
    }
}
