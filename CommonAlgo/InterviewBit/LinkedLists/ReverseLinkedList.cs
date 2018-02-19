using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/reverse-linked-list/
    ///     https://www.youtube.com/watch?v=sYcOK51hl-A&feature=player_embedded
    /// </summary>
    public class ReverseLinkedList
    {
        [Test]
        public void Test()
        {
            var node = new ListNode(1);
            node.next = new ListNode(2);
            node.next.next = new ListNode(3);

            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(3));
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(1));
            var rev = reverseList(node);
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, rev.val);
                rev = rev.next;
            }
        }

        public ListNode reverseList(ListNode a)
        {
            if (a == null || a.next == null)
                return a;
            var p1 = a;
            var p2 = a.next;
            while (p1 != null && p2 != null)
            {
                var t = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = t;
            }
            a.next = null;
            return p2 == null ? p1 : p2;
        }

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
    }
}
