using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/swap-list-nodes-in-pairs/
    ///     http://www.programcreek.com/2014/04/leetcode-swap-nodes-in-pairs-java/
    /// </summary>
    public class SwapListNodesInPair
    {
        [Test]
        public void Test()
        {
            var ln = new ListNode(1);
            ln.next = new ListNode(2);
            ln.next.next = new ListNode(3);

            var listNode = swapPairs(ln);
            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(3));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, listNode.val);
                listNode = listNode.next;
            }

            ln = new ListNode(1);
            ln.next = new ListNode(2);
            ln.next.next = new ListNode(3);
            var listNode2 = swapPairsRecusively(ln);
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(3));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, listNode2.val);
                listNode2 = listNode2.next;
            }
        }

        /// <summary>
        ///     Медленное и не маштабируемое решение
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode swapPairsRecusively(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            // swap the two
            var newHead = head.next;
            head.next = swapPairs(head.next.next);
            newHead.next = head;
            return newHead;
        }

        public ListNode swapPairs(ListNode a)
        {
            if (a == null || a.next == null) return a;

            var dummy = new ListNode(0);
            dummy.next = a;
            var p = dummy;

            while (p.next != null && p.next.next != null)
            {
                var t1 = p;
                p = p.next;
                t1.next = p.next;

                var t2 = p.next.next;
                p.next.next = p;
                p.next = t2;
            }
            return dummy.next;
        }
    }
}
