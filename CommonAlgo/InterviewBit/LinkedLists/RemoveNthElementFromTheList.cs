using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/remove-nth-node-from-list-end/
    /// </summary>
    public class RemoveNthElementFromTheList
    {
        [Test]
        public void Test()
        {
            var a = new ListNode(1);
            a.next = new ListNode(2);
            a.next.next = new ListNode(3);
            a.next.next.next = new ListNode(4);
            a.next.next.next.next = new ListNode(5);

            var nthFromEnd = removeNthFromEnd(a, 2);
            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(3));
            q.Enqueue(new ListNode(5));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, nthFromEnd.val);
                nthFromEnd = nthFromEnd.next;
            }
        }

        public ListNode removeNthFromEnd(ListNode a, int b)
        {
            if (b <= 0) return a;

            if (a == null) return a;

            var fast = a;
            var len = 0;
            while (fast.next != null && len < b)
            {
                fast = fast.next;
                len++;
            }

            // when b > len(a)?
            // when we reach the end ie fast==null and i>b 
            // b = 60 but len(a) = 10 => if len < b

            if (b > len)
                return a.next;

            // after that fast never can be null

            var slow = a;
            ListNode prev = null;
            while (fast != null)
            {
                fast = fast.next;
                prev = slow;
                slow = slow.next;
            }

            // now slow at position to delete
            // so just reassign prev next pointer
            // is possible that prev == null?? obviously no, a != null so at least one step have to happen

            prev.next = slow.next;

            return a;
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
