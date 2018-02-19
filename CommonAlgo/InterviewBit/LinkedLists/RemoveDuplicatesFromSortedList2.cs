using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    public class ListNode
    {
        public ListNode next;
        public int val;

        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    /// <summary>
    ///     https://www.interviewbit.com/problems/remove-duplicates-from-sorted-list-ii/
    ///     http://www.programcreek.com/2014/06/leetcode-remove-duplicates-from-sorted-list-ii-java/
    /// </summary>
    public class RemoveDuplicatesFromSortedList2
    {
        [Test]
        public void Test()
        {
            var l = new ListNode(1);
            l.next = new ListNode(2);
            l.next.next = new ListNode(2);
            l.next.next.next = new ListNode(3);
            var listNode = deleteDuplicates(l);
            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(3));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, listNode.val);
                listNode = listNode.next;
            }
        }

        public ListNode deleteDuplicates(ListNode a)
        {
            if (a == null || a.next == null)
                return a;

            var nh = new ListNode(-1);
            nh.next = a;

            var t = nh;
            while (t.next != null && t.next.next != null)
            {
                if (t.next.val == t.next.next.val)
                {
                    var dup = t.next.val;
                    while (t.next != null && t.next.val == dup)
                        t.next = t.next.next;
                }
                else
                {
                    t = t.next;
                }
            }
            return nh.next;
        }
    }
}
