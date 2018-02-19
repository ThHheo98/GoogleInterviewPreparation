using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    public class AddToNumbersAsList
    {
        [Test]
        public void Test()
        {
            var fn = new ListNode(2);
            fn.next = new ListNode(4);
            fn.next.next = new ListNode(3);
            var sn = new ListNode(5);
            sn.next = new ListNode(6);
            sn.next.next = new ListNode(4);

            var numbers = AddTwoNumbers(fn, sn);

            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(7));
            q.Enqueue(new ListNode(0));
            q.Enqueue(new ListNode(8));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, numbers.val);
                numbers = numbers.next;
            }
        }

        public ListNode AddTwoNumbers(ListNode A, ListNode B)
        {
            if (A == null || B == null) return null;

            var dummy = new ListNode(0);
            var p1 = A;
            var p2 = B;
            var p3 = dummy;
            var carry = 0;
            while (p1 != null || p2 != null)
            {
                if (p1 != null)
                {
                    carry += p1.val;
                    p1 = p1.next;
                }
                if (p2 != null)
                {
                    carry += p2.val;
                    p2 = p2.next;
                }

                p3.next = new ListNode(carry % 10);
                p3 = p3.next;
                carry = carry / 10;
            }

            if (carry == 1)
                p3.next = new ListNode(1);
            return dummy.next;
        }
    }
}
