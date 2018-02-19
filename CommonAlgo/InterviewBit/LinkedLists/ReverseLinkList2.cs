using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/reverse-link-list-ii/
    /// </summary>
    public class ReverseLinkList2
    {
        /*
         * Lets first look at the problem of reversing the linked list.

a -> b -> c should become
a <- b <- c

Obviously at every instant, you need to know about the previous of the node, so that you can link it to the next of the node. 
Can you think along the lines of maintaining a previousNode, curNode and nextNode ?

Now once you know how to reverse a linked List, how can you apply it to the current problem ?

         * 
         If you are still stuck at reversing the full linked list problem, 
then would maintaining curNode, nextNode and a tmpNode help ?

Maybe at every step, you do something like this :

    tmp = nextNode->next;
            nextNode->next = cur;
            cur = nextNode;
            nextNode = tmp;
Now, lets say you did solve the problem of reversing the linked list and are stuck at applying it to current problem. 
What if your function reverses the linked list and returns the endNode of the list. 
You can simply do 
prevNodeOfFirstNode->next = everseLinkedList(curNode, n - m + 1);
             */
        [Test]
        public void Test()
        {
            var list = new ListNode(1);
            list.next = new ListNode(2);
            list.next.next = new ListNode(3);
            list.next.next.next = new ListNode(4);
            list.next.next.next.next = new ListNode(5);

            var rev = ReverseBetween(list, 2, 4);

            var q = new Queue<ListNode>();
            q.Enqueue(new ListNode(1));
            q.Enqueue(new ListNode(4));
            q.Enqueue(new ListNode(3));
            q.Enqueue(new ListNode(2));
            q.Enqueue(new ListNode(5));
            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue().val, rev.val);
                rev = rev.next;
            }
        }

        public ListNode ReverseBetween(ListNode a, int m, int n)
        {
            if (n == m) return a;
            var dummy = new ListNode(0);
            dummy.next = a;

            // find pre node
            var pre = dummy;
            for (var i = 0; i < m - 1; ++i)
                pre = pre.next;

            var start = pre.next;
            var then = start.next;
            for (var i = 0; i < n - m; i++)
            {
                start.next = then.next;
                then.next = pre.next;
                pre.next = then;
                then = start.next;
            }

            return dummy.next;
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
