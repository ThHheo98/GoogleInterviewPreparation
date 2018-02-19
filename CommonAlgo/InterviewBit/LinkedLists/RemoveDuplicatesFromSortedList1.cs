using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/remove-duplicates-from-sorted-list/
    /// </summary>
    public class RemoveDuplicatesFromSortedList1
    {
        [Test]
        public void Test()
        {
            var l = new ListNode(1) { next = new ListNode(1) { next = new ListNode(3) } };
            var res = deleteDuplicates(l);
            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(3));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, res.val);
                res = res.next;
            }
        }

        public ListNode deleteDuplicates(ListNode a)
        {
            if (a == null || a.next == null)
                return a;

            var p1 = a;
            var p2 = a.next;

            while (p1 != null && p2 != null)
            {
                if (p1.val != p2.val)
                {
                    p2 = p2.next;
                    p1 = p1.next;
                }
                else
                {
                    p1.next = p2.next;
                    p2 = p2.next;
                }
            }
            return a;
        }

        public class ListNode
        {
            public readonly int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
    }
}
