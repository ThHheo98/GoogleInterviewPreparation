using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/sort-list/
    /// </summary>
    /*
        Can implement either merge sort or qsort.

        Lets look at merge sort. Traverse the linked list to find the mid point of the list. 
        Now sort the first half and second half separatly by calling the function on them. 
        Then merge the 2 lists ( Note that we already have solved a problem to merge 2 lists ).
    */
    public class SortLists
    {
        [Test]
        public void Test()
        {
            var list = new ListNode(1);
            list.next = new ListNode(5);
            list.next.next = new ListNode(4);
            list.next.next.next = new ListNode(3);
            list.next.next.next.next = new ListNode(2);

            var listNode = sortList(list);
            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(3));
            q.Enqueue(new ListNode(4));
            q.Enqueue(new ListNode(5));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, listNode.val);
                listNode = listNode.next;
            }
        }

        public ListNode sortList(ListNode a)
        {
            if (a == null || a.next == null) return a;

            // split on 2 parts
            var slow = a;
            var fast = a;
            ListNode prev = null;
            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null; // split lists

            var p1 = sortList(a);
            var p2 = sortList(slow);

            return merge(p1, p2);
        }

        private ListNode merge(ListNode h1, ListNode h2)
        {
            var dummy = new ListNode(int.MinValue);
            var p = dummy;
            while (h1 != null && h2 != null)
            {
                if (h1.val < h2.val)
                {
                    p.next = h1;
                    h1 = h1.next;
                }
                else
                {
                    p.next = h2;
                    h2 = h2.next;
                }
                p = p.next;
            }

            if (h1 != null) p.next = h1;
            if (h2 != null) p.next = h2;

            return dummy.next;
        }
    }
}
