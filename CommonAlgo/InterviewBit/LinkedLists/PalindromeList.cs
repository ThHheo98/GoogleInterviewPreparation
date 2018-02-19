using NUnit.Framework;

namespace CommonAlgo.InterviewBit.LinkedLists
{
    public class PalindromeList
    {
        private class ListNode
        {
            public readonly int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        public class Tests
        {
            [Test]
            public void Test()
            {
                var s = new Solution();
                var listNode = new ListNode(1);
                listNode.next = new ListNode(2);
                listNode.next.next = new ListNode(3);
                listNode.next.next.next = new ListNode(2);
                listNode.next.next.next.next = new ListNode(1);
                var lPalin = s.lPalin(listNode);
                Assert.AreEqual(1, lPalin);
            }
        }

        private class Solution
        {
            public int lPalin(ListNode head)
            {
                if (head == null || head.next == null)
                    return 1;

                // find the middle of list
                var slow = head;
                var fast = head;
                while (fast.next != null && fast.next.next != null)
                {
                    fast = fast.next.next;
                    slow = slow.next;
                }

                var secondHead = slow.next;
                slow.next = null;

                // reverse second part of list
                var p1 = secondHead;
                var p2 = secondHead.next;
                while (p1 != null && p2 != null)
                {
                    var t = p2.next;
                    p2.next = p1;
                    p1 = p2;
                    p2 = t;
                }

                secondHead.next = null;

                var pp = p2 == null ? p1 : p2;
                var qq = head;

                while (pp != null)
                {
                    if (pp.val != qq.val)
                        return 0;

                    pp = pp.next;
                    qq = qq.next;
                }

                return 1;
            }
        }
    }
}
