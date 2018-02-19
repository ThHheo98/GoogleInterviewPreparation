using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/list-cycle/
    ///     https://allaboutalgorithms.wordpress.com/2011/10/20/find-the-starting-point-of-a-cycle-in-a-linked-list/
    ///     http://umairsaeed.com/blog/2011/06/23/finding-the-start-of-a-loop-in-a-circular-linked-list/
    ///     https://www.quora.com/How-can-you-detect-a-loop-in-singly-linked-list-fast-and-slow-pointer
    ///     http://www.ideserve.co.in/learn/detect-a-loop-in-a-linked-list
    ///     http://stackoverflow.com/questions/10275587/finding-loop-in-a-singly-linked-list
    ///     http://www.geeksforgeeks.org/write-a-c-function-to-detect-loop-in-a-linked-list/
    ///     https://en.wikipedia.org/wiki/Cycle_detection
    ///     Floyd's cycle-finding algorithm
    ///     https://tproger.ru/problems/given-a-circular-linked-list-implement-an-algorithm-which-returns/
    /// </summary>
    public class ListCycle
    {
        /*
         *
         *Lets first look at detection of a cycle in the list.

Following are different ways of doing this

1) Use Hashing:
What if you could maintain a list of nodes already visited. As soon as you visit a node already visited, you know that there is a cycle.

2) 2 pointer approach ( Floyd’s Cycle-Finding Algorithm ) : 
What if you have 2 pointers which are going at different speed. For arguments sake, lets just say one pointer is going at double the speed of the other. 
Would they meet if there is a cycle ? Are they guaranteed to meet if there is a cycle ? 
What happens if there is no cycle ?

Once you detect a cycle, think about finding the starting point.

         * Lets now look at the starting point. 
        If we were using hashing, the first repetition we get is the starting point. Simple!

        What happens with the 2 pointer approach ?

        Method 1 : 
        If you detect a cycle, the meeting point is definitely a point within the cycle. 
        * Can you determine the size of the cycle ? ( Easy ) Let the size be k.
        * Fix one pointer on the head, and another pointer to kth node from head. 
        * Now move them simulataneously one step at a time. They will meet at the starting point of the cycle.

        Method 2 : 
        This might be slightly more complicated. It involves a bit of maths and is not as intuitive as method 1. 
        Suppose the first meet at step k,the distance between the start node of list and the start node of cycle is s, and the distance between the start node of cycle and the first meeting node is m. 
        Then 
        2k = (s + m + n1r) 
        2(s + m + n2r) = (s + m + n1r) 
        s + m = nr where n is an integer.
        s = nr - m
        s = (r - m) + (n-1)r

        So, if we have one pointer on the head and another pointer at the meeting point. Note that since the distance between start node of cycle and the first meeting node is m, 
        therefore if the pointer moves (r - m) steps, it will reach the start of the cycle. When the pointer at the head moves s steps, the second pointer moves (r-m) + (n-1)r 
        steps which both points to the start of the cycle. In other words, both pointers meet first at the start of the cycle.
         Input : 

                  ______
                 |     |
                 \/    |
        1 -> 2 -> 3 -> 4

Return the node corresponding to node 3. 
             
             */

        [Test]
        public void Test()
        {
            var list = new ListNode(1);
            list.next = new ListNode(2);
            var nextNext = new ListNode(3);
            list.next.next = nextNext;
            list.next.next.next = new ListNode(4);
            list.next.next.next.next = nextNext;

            var detectCycle = DetectCycle(list);
            Assert.AreEqual(3, detectCycle.val);
        }

        public ListNode DetectCycle(ListNode a)
        {
            if (a == null || a.next == null) return null;

            var slow = a;
            var fast = a;

            var hasLoop = 0;

            // floyd's algo
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow)
                {
                    hasLoop = 1;
                    break;
                }
            }

            if (hasLoop == 1)
            {
                slow = a;
                while (slow != fast)
                {
                    fast = fast.next;
                    slow = slow.next;
                }
                return slow;
            }
            return null;
        }
    }
}
