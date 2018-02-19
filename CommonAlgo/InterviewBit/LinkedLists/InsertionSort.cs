using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/insertion-sort-list/
    ///     https://discuss.leetcode.com/topic/8570/an-easy-and-clear-way-to-sort-o-1-space/3
    ///     http://www.programcreek.com/2012/11/leetcode-solution-sort-a-linked-list-using-insertion-sort-in-java/
    /// </summary>
    public class InsertionSort
    {
        /*
         * Sort a linked list using insertion sort.

We have explained Insertion Sort at Slide 7 of Arrays

Insertion Sort Wiki has some details on Insertion Sort as well.

Example :

Input : 1 -> 3 -> 2

Return 1 -> 2 -> 3

         This is very much a simulation problem.

The only trick is how do you move a node from ith position to jth position. 
How do you move the pointers to do so ? Would having a temporary node help ?
             */

        [Test]
        public void Test()
        {
            var list = new ListNode(1);
            list.next = new ListNode(3);
            list.next.next = new ListNode(2);

            var res = insertionSort(list);

            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(3));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, res.val);
                res = res.next;
            }
        }

        [Test]
        public void TestDesc()
        {
            var list = new ListNode(1);
            list.next = new ListNode(3);
            list.next.next = new ListNode(2);

            var res = insertionSortDesc(list);

            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(3));
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(1));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, res.val);
                res = res.next;
            }
        }

        private ListNode insertionSort(ListNode head)
        {
            if (head == null) return null;

            var dummy = new ListNode(int.MinValue);
            var curr = head;
            while (curr != null)
            {
                var iter = dummy;
                while (iter.next != null && iter.next.val < curr.val)
                    iter = iter.next;
                var t = curr.next;
                curr.next = iter.next;
                iter.next = curr;
                curr = t;
            }
            return dummy.next;
        }

        private ListNode insertionSortDesc(ListNode head)
        {
            if (head == null) return null;

            var dummy = new ListNode(int.MaxValue);
            var curr = head;
            while (curr != null)
            {
                var iter = dummy;
                while (iter.next != null && iter.next.val > curr.val)
                    iter = iter.next;
                var t = curr.next;
                curr.next = iter.next;
                iter.next = curr;
                curr = t;
            }
            return dummy.next;
        }
    }
}
