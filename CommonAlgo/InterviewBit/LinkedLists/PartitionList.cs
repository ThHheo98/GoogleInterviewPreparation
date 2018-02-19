using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    /// https://www.interviewbit.com/problems/partition-list/
    /// http://qa.geeksforgeeks.org/3823/partition-the-given-linkedlist
    /// </summary>
    public class PartitionList
    {
        /*
         Maintain 2 pointers - one which maintains all nodes less than x and another which maintains nodes greater than or equal to x. 
Keep going along our list. When we are at node that is greater than or equal to x, we remove this node from our list and move it to list of nodes greater than x.


             */
        [Test]
        public void Test()
        {
            //1->4->3->2->5->2
            var list = new ListNode(1);
            list.next = new ListNode(4);
            list.next.next = new ListNode(3);
            list.next.next.next = new ListNode(2);
            list.next.next.next.next = new ListNode(5);
            list.next.next.next.next.next = new ListNode(2);

            var ans = partition(list, 3);
            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(4));
            q.Enqueue(new ListNode(3));
            q.Enqueue(new ListNode(5));
            while (q.Count>0)
            {
                Assert.AreEqual(q.Dequeue().val, ans.val);
                ans = ans.next;
            }
        }

        public ListNode partition(ListNode head, int x)
        {
            if (head == null) return null;

            var iterator = head;

            var start = new ListNode(0);   // to store values equal or greater than x
            var tail = start;

            var newHead = new ListNode(0);
            newHead.next = head;
            var pre = newHead;

            while (iterator != null)
            {
                if (iterator.val < x)
                {
                    pre = iterator;
                    iterator = iterator.next;
                }
                else
                {
                    pre.next = iterator.next;// remove from our list
                    tail.next = iterator; // add to list of nodes greater than x
                    tail = tail.next;
                    iterator = iterator.next; // move iterator
                    tail.next = null; // tail has to stay tail :)
                }
            }
            // join lists
            pre.next = start.next;

            return newHead.next;
        }
    }
}