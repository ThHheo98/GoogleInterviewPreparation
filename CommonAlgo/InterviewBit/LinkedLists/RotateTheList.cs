using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/rotate-list/
    /// </summary>
    public class RotateTheList
    {
        [Test]
        public void Test()
        {
            var list = new ListNode(1);
            var listNode = rotateRight(list, 100);
            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(1));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, listNode.val);
                listNode = listNode.next;
            }

            list = new ListNode(1);
            list.next = new ListNode(2);
            list.next.next = new ListNode(3);
            list.next.next.next = new ListNode(4);
            list.next.next.next.next = new ListNode(5);

            listNode = rotateRight(list, 2);
            q = new Queue<ListNode>();
            q.Enqueue(new ListNode(4));
            q.Enqueue(new ListNode(5));
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(3));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, listNode.val);
                listNode = listNode.next;
            }

            list = new ListNode(68);
            list.next = new ListNode(86);
            list.next.next = new ListNode(36);
            list.next.next.next = new ListNode(16);
            list.next.next.next.next = new ListNode(5);
            list.next.next.next.next.next = new ListNode(75);

            listNode = rotateRight(list, 90);
            q = new Queue<ListNode>();
            q.Enqueue(new ListNode(68));
            q.Enqueue(new ListNode(86));
            q.Enqueue(new ListNode(36));
            q.Enqueue(new ListNode(16));
            q.Enqueue(new ListNode(5));
            q.Enqueue(new ListNode(75));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, listNode.val);
                listNode = listNode.next;
            }
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine((10 - 12) % 10);
            Console.WriteLine(mod(10 - 12, 10));
        }

        private static int GetCnt(ListNode a)
        {
            if (a == null) return 0;
            var t = a;
            var c = 0;
            while (t != null)
            {
                t = t.next;
                c++;
            }
            return c;
        }

        private int mod(int x, int m)
        {
            var r = x % m;
            return r < 0 ? r + m : r;
        }

        public ListNode rotateRight(ListNode head, int b)
        {
            if (head == null) return null;
            if (head.next == null && b < 2) return head;

            var len = GetCnt(head);

            if (mod(len - b, len) == 0) return head; // no rotation needed

            var i = 1;
            var fast = head;
            while (i < mod(len - b, len))
            {
                fast = fast.next;
                i++;
            }

            var head2 = fast.next;
            fast.next = null;

            // lets reverse list from fast to head
            var p1 = head;
            var p2 = head.next;
            while (p2 != null)
            {
                var t = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = t;
            }
            head.next = null;

            var newHead1 = p2 == null ? p1 : p2;
            var newEnd1 = head;

            // reverse second part
            ListNode newHead2;

            if (head2 != null && head2.next != null)
            {
                var q1 = head2;
                var q2 = head2.next;
                while (q2 != null)
                {
                    var t = q2.next;
                    q2.next = q1;
                    q1 = q2;
                    q2 = t;
                }
                head2.next = null;

                newHead2 = q2 == null ? q1 : q2;
            }
            else
            {
                newHead2 = head2;
            }

            // join lists
            newEnd1.next = newHead2;

            // reverse whole list
            var r1 = newHead1;
            var r2 = newHead1.next;
            while (r2 != null)
            {
                var t = r2.next;
                r2.next = r1;
                r1 = r2;
                r2 = t;
            }
            newHead1.next = null;

            return r2 == null ? r1 : r2;
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
