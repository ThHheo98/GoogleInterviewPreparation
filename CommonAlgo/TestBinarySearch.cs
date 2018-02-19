using System;
using NUnit.Framework;

namespace CommonAlgo
{
    public class TestFib
    {
        [TestCase]
        public void FibTest()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Fib(i));
            }
        }

        private static int Fib(int n)
        {
            return n <= 1 ? 1 : Fib(n - 1) + Fib(n - 2);
        }
    }

    public class TestFact
    {
        private static readonly int[] Fibc = new int[100];

        [TestCase]
        public void FactTest()
        {
            for (int i = 0; i < 6; i++)
                Console.WriteLine(Fact(i));
        }

        private static int Fact(int n)
        {
            return n <= 1 ? 1 : n*Fact(n - 1);
        }

        [TestCase]
        public void FactTest1()
        {
            for (int i = 0; i < 6; i++)
                Console.WriteLine(FactTail(i, 1));
        }

        private static int FactTail(int n, int accumulator)
        {
            return n <= 1 ? accumulator : FactTail(n - 1, n*accumulator);
        }

        [TestCase]
        public void FactTest2()
        {
            for (int i = 0; i < 6; i++)
                Console.WriteLine(FibCache(i));
        }

        private static int FibCache(int n)
        {
            if (n == 0 || n == 1) return n;
            if (Fibc[n] != 0) return Fibc[n];
            Fibc[n] = FibCache(n - 1) + FibCache(n - 2);
            return Fibc[n];
        }

    }

    public class TestBinarySearch
    {
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 5, Result = 5, TestName = "test1")]
        public int TestBinarySearchRec(int[] a, int e)
        {
            int rec = BinarySearchRec(a, 0, a.Length, e);
            if (rec == -1)
                return -1;
            return a[rec];
        }

        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 5, Result = 5, TestName = "test1")]
        public int TestBinarySearchIter(int[] a, int e)
        {
            int iter = BinarySearchIter(a, 0, a.Length, e);
            if (iter == -1)
                return -1;
            return a[iter];
        }

        private static int BinarySearchRec(int[] a, int l, int h, int e)
        {
            while (true)
            {
                int m = l + (h - l)/2;
                if (e < a[m])
                    return BinarySearchRec(a, l, m - 1, e);
                if (e > a[m])
                    return BinarySearchRec(a, m + 1, h, e);
                if (e == a[m]) return m;
                return -1;
            }
        }

        private static int BinarySearchIter(int[] a, int l, int h, int e)
        {
            while (l <= h)
            {
                int m = l + (h - l)/2;
                if (e < a[m])
                    h = m - 1;
                else if (e > a[m]) l = m + 1;
                else if (e == a[m]) return m;
            }
            return -1;
        }
    }
}