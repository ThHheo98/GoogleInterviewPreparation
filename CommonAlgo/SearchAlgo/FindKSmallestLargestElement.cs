using System;
using CommonAlgo.SortingAlgo;
using NUnit.Framework;

namespace CommonAlgo.SearchAlgo
{
    public class FindKSmallestLargestElement
    {
        private static readonly Random Rnd = new Random();

        [TestCase(new[] {12, 10, 15, 7, 11, 13, 16, 14, 17}, 3, Result = 15)]
        public int LargestTest(int[] a, int k)
        {
            return HeapSort.TakeKMax(a, k);
        }

        [TestCase(new[] {12, 10, 15, 7, 11, 13, 16, 14, 17}, 3, Result = 11, TestName = "test1")]
        [TestCase(new[] {12, 10, 15, 7, 11, 13, 16, 14, 17}, 4, Result = 12, TestName = "test2")]
        public int SmallestTest(int[] a, int k)
        {
            return HeapSort.TakeKMin(a, k);
        }

        private static int nth_element(int[] a, int low, int high, int k)
        {
            int i1 = low + Rnd.Next(high - low);
            Swap(a, i1, high - 1);

            int i = Partition(a, low, high);

            if (k < i) return nth_element(a, low, i, k);
            if (k > i) return nth_element(a, i + 1, high, k);
            return i;
        }

        private static int Partition(int[] a, int low, int high)
        {
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (a[j] <= a[high - 1])
                {
                    i++;
                    Swap(a, i, j);
                }
            }
            return i;
        }

        private static void Swap(int[] a, int i, int j)
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        // O(n) in average (probability)
        [TestCase(new[] {12, 10, 15, 7, 11, 13, 16, 14, 17}, 3, Result = 12, TestName = "test1")]
        [TestCase(new[] {12, 10, 15, 7, 11, 13, 16, 14, 17}, 4, Result = 13, TestName = "test2")]
        [TestCase(new[] {12, 10, 15, 7, 11, 13, 16, 14, 17}, 0, Result = 7, TestName = "test3")]
        [TestCase(new[] {12, 10, 15, 7, 11, 13, 16, 14, 17}, 8, Result = 17, TestName = "test4")]
        public int KthOrderStat(int[] a, int k)
        {
            // See: http://www.cplusplus.com/reference/algorithm/nth_element
            int r = nth_element(a, 0, a.Length, k);
            return a[r];
        }
    }
}