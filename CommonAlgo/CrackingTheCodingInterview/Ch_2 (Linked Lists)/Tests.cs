using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /**
 * Definition for singly-linked list.

 */

    public class ListNode
    {
        public ListNode next;
        public int val;

        public ListNode(int x)
        {
            val = x;
        }
    }

    /**
  * Definition for singly-linked list.
  * public class ListNode {
  *     public int val;
  *     public ListNode next;
  *     public ListNode(int x) { val = x; }
  * }
  */

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return GetSum(l1, l2, 0);
        }

        private static ListNode GetSum(ListNode l1, ListNode l2, int add)
        {
            if (l1 == null && l2 == null && add == 0) return null;

            var value = add;
            if (l1 != null) value += l1.val;
            if (l2 != null) value += l2.val;

            var r = new ListNode(value%10);
            if (l1 != null || l2 != null || value >= 10)
            {
                r.next = GetSum(l1 == null ? null : l1.next, l2 == null ? null : l2.next, value/10);
            }
            return r;
        }


        [TestCase]
        public void Test()
        {
            Console.WriteLine("Test 1");
            var l1 = new ListNode(0);
            var l2 = new ListNode(0);
            AddTwoNumbers(l1, l2);
            Console.WriteLine("Test 2");
            l1 = new ListNode(5);
            l2 = new ListNode(5);
            AddTwoNumbers(l1, l2);
            Console.WriteLine("Test 3");
            l1 = new ListNode(5);
            l1.next = new ListNode(3);
            l2 = new ListNode(0);
            AddTwoNumbers(l1, l2);
        }
    }

    public class Tests1
    {
        [TestCase("FOLLOW UP", TestName = "Test1")]
        [TestCase("OLL", TestName = "Test2")]
        [TestCase("AAAA", TestName = "Test3")]
        public void Test21(string text)
        {
            {
                var list = new InnerListTest2<char>();
                for (var i = 0; i < text.Length; i++)
                {
                    list.Add(text[i]);
                }
                list.Print();
                list.RemoveDuplicatesHashTable();
                list.Print();
            }

            {
                var list = new InnerListTest2<char>();
                for (var i = 0; i < text.Length; i++)
                {
                    list.Add(text[i]);
                }
                list.Print();
                list.RemoveDuplicates();
                list.Print();
            }
        }

        [TestCase("ABACABA", 4, Result = 'C', TestName = "Test1")]
        [TestCase("OLL", 2, Result = 'L', TestName = "Test2")]
        public char Test22(string text, int k)
        {
            var list = new InnerListTest2<char>();
            foreach (var t in text)
            {
                list.Add(t);
            }
            return list.FindkthToLast(k);
        }

        [TestCase("FOLLOW UP", 'U', Result = true, TestName = "Test1")]
        [TestCase("FOLLOW UP", 'F', Result = false, TestName = "Test2")]
        [TestCase("ENISEY", 'E', Result = true, TestName = "Test3")]
        [TestCase("OLB", 'L', Result = true, TestName = "Test4")]
        public bool Test23(string text, char k)
        {
            var list = new InnerListTest2<char>();
            foreach (var t in text)
            {
                list.Add(t);
            }
            Console.WriteLine("Removed char is {0}", k);
            Console.WriteLine("List before remove");
            list.Print();
            var b = list.RemoveItemFromListWithoutUsingHead(k);
            Console.WriteLine("List after remove");
            list.Print();
            return b;
        }

        [TestCase("123456789", '5', TestName = "test1")]
        [TestCase("888854444", '5', TestName = "test2")]
        public void Test24(string text, char ch)
        {
            var list = new InnerListTest2<char>();
            foreach (var value in text)
            {
                list.Add(value);
            }
            list.Print();
            list.PartitionByItem(ch);
            list.Print();

            var s = list.ToString();

            for (var i = 0; i < s.Length/2; i++)
            {
                Assert.IsTrue(s[i] <= ch);
            }

            for (var i = s.Length - 1; i >= s.Length/2; i--)
            {
                Assert.IsTrue(s[i] >= ch);
            }
        }

        [TestCase("432151234", Result = true)]
        [TestCase("4454444", Result = false)]
        public bool Test27(string text)
        {
            var list = new InnerListTest2<char>();
            foreach (var value in text)
            {
                list.Add(value);
            }
            list.Print();
            return list.IsPolindrom();
        }

        [TestCase(617, 295, Result = "219", TestName = "test3")]
        [TestCase(7, 73, Result = "08", TestName = "test4")]
        [TestCase(72, 7, Result = "97", TestName = "test2")]
        public string Test25(int f, int s)
        {
            var first = new OwnBigInteger();
            foreach (var value in f.ToString())
            {
                first.Add(int.Parse(value.ToString()), true);
            }
            first.Print(true);

            var second = new OwnBigInteger();
            foreach (var value in s.ToString())
            {
                second.Add(int.Parse(value.ToString()), true);
            }
            second.Print(true);

            var result = OwnBigInteger.AddInReverseOrder(first, second);
            Console.WriteLine("Result is");
            result.Print(true);
            var test25 = result.ToString();
            return test25;
        }

        // Сложение для прямого порядка
//        [TestCase(617, 295, Result = "219", TestName = "test1")]
//        public string Test25_1(int f, int s)
//        {
//            var first = new OwnBigInteger();

//            foreach (char value in f.ToString())
//            {
//                first.Add(int.Parse(value.ToString()), false);
//            }
//            first.Print(true);
//
//            var second = new OwnBigInteger();
//            foreach (char value in s.ToString())
//            {
//                second.Add(int.Parse(value.ToString()), false);
//            }
//            second.Print(true);
//
//            OwnBigInteger result = OwnBigInteger.AddInReverseOrder(first, second);
//            Console.WriteLine("Result is");
//            result.Print(true);
//            string test25 = result.ToString();
//            return test25;
//        }
    }
}