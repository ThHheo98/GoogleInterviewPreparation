using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/copy-list/
    /// http://www.geeksforgeeks.org/clone-linked-list-next-arbit-pointer-set-2/
    /// </summary>
    /*
     A linked list is given such that each node contains an additional random pointer which could point to any node in the list or NULL.

Return a deep copy of the list.

Example

Given list

   1 -> 2 -> 3
with random pointers going from

  1 -> 3
  2 -> 1
  3 -> 1
You should return a deep copy of the list. The returned answer 
should not contain the same node as the original list, but a copy of them. The pointers in the returned list should not link to any node in the original input list.

        There are 2 approaches to solving this problem.

Approach 1 : Using hashmap.
Use a hashmap to store the mapping from oldListNode to the newListNode. 
Whenever you encounter a new node in the oldListNode (either via random pointer or through the next pointer ), 
create the newListNode, store the mapping. and update the next and random pointers of the newListNode using the mapping from the hashmap.

Approach 2 : Using 2 traversals of the list. 
Step 1: create a new node for each existing node and join them together eg: A->B->C will be A->A’->B->B’->C->C’

Step2: copy the random links: for each new node n’, n’.random = n.random.next

Step3: detach the list: basically n.next = n.next.next; n’.next = n’.next.next

         */
    public class CopyList
    {
        [Test]
        public void Test()
        {
            var one = new RandomListNode(1);
            var two = new RandomListNode(2);
            var tree = new RandomListNode(3);

            var list = one;
            list.next = two;
            list.next.next = tree;

            list.random = tree;
            list.next.random = one;
            list.next.next.random = one;

            var copy = copyRandomList(list);

            Assert.AreNotSame(copy, list);
            Assert.AreNotSame(copy.next, list.next);
            Assert.AreNotSame(copy.next.next, list.next.next);
            Assert.AreNotSame(copy.random, list.random);
            Assert.AreNotSame(copy.next.random, list.next.random);
            Assert.AreNotSame(copy.next.next.random, list.next.next.random);
        }

        public RandomListNode copyRandomList(RandomListNode head)
        {
            if (head == null) return null;

            var map = new Dictionary<RandomListNode, RandomListNode>();

            RandomListNode orig = head;
            while (orig != null)
            {
                var cpy = new RandomListNode(orig.label);
                map.Add(orig, cpy);
                orig = orig.next;
            }

            orig = head;
            while (orig != null)
            {
                var cpy = map[orig];
                cpy.next = orig.next == null ? null : map[orig.next];
                cpy.random = orig.random == null ? null : map[orig.random];
                orig = orig.next;
            }

            return map[head];
        }

        public class RandomListNode
        {
            public readonly int label;
            public RandomListNode next;
            public RandomListNode random;

            public RandomListNode(int x)
            {
                label = x;
            }
        }
    }
}
