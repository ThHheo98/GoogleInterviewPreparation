using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/intersection-of-linked-lists/
    ///     https://www.youtube.com/watch?v=gE0GopCq378&feature=player_embedded
    /// </summary>
    public class IntersectionOfLinkedLists
    {
        [Test]
        public void Test()
        {
            var listNode = new ListNode(2);

            var l1 = new ListNode(1) { next = listNode };
            l1.next.next = new ListNode(3);

            var l2 = listNode;
            l2.next = new ListNode(4);

            var intersectionNode = GetIntersectionNode(l1, l2);
            Assert.AreEqual(listNode, intersectionNode);
        }

        public int GetCount(ListNode a)
        {
            if (a == null)
                return 0;
            var c = 0;
            var t = a;
            while (t != null)
            {
                c++;
                t = t.next;
            }
            return c;
        }

        public ListNode GetIntersectionNode(ListNode a, ListNode b)
        {
            if (a == null || b == null)
                return null;
            var ac = GetCount(a);
            var bc = GetCount(b);

            var d = bc - ac;

            if (ac > bc)
            {
                var t = b;
                b = a;
                a = t;
                d = ac - bc;
            }

            // b list is longest always
            for (var i = 0;
                i < d;
                i++)
                b = b.next;

            while (a != null && b != null)
            {
                if (a == b)
                    return a;
                b = b.next;
                a = a.next;
            }

            return null;
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
