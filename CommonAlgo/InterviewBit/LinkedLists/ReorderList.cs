using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    /// https://www.interviewbit.com/problems/reorder-list/
    /// http://www.programcreek.com/2013/12/in-place-reorder-a-singly-linked-list-in-java/
    /// </summary>
    public class ReorderList
    {
        [Test]
        public void Test()
        {
            var l = new ListNode(99);
            l.next = new ListNode(83);
            var r = reorderList(l);
            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(83));
            q.Enqueue(new ListNode(99));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, r.val);
                r = r.next;
            }
        }

        private ListNode reverse(ListNode head)
        {
            if (head == null || head.next == null) return head;
            var pre = head;
            var curr = head.next;
            while (curr != null)
            {
                var t = curr.next;
                curr.next = pre;
                pre = curr;
                curr = t;
            }
            head.next = null;
            return pre;
        }

        public ListNode reorderList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            // split
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var secondHead = slow.next;
            slow.next = null;

            // reverse second list
            secondHead = reverse(secondHead);

            // merge two lists
            var p1 = head;
            var p2 = secondHead;
            while (p2 != null)
            {
                var t1 = p1.next;
                var t2 = p2.next;

                p1.next = p2;
                p2.next = t1;

                p1 = t1;
                p2 = t2;
            }
            return head;
        }
    }
}
