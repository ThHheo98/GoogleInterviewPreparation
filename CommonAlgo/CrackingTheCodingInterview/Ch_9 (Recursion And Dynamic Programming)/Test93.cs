using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test93
    {
        [TestCase(new[] {-40, -20, -1, 3, 4, 6, 7, 8, 9, 12, 13}, Result = 3, TestName = "test1")]
        public int TestNoRepeat(int[] a)
        {
            return BinSearchNoRepeat(a, 0, a.Length - 1);
        }

        private int BinSearchNoRepeat(int[] a, int l, int r)
        {
            if (r < l || l < 0 || r >= a.Length) return int.MinValue;

            int mid = l + (r - l)/2;
            if (a[mid] == mid) return mid;
            return a[mid] > mid ? BinSearchNoRepeat(a, l, mid - 1) : BinSearchNoRepeat(a, mid + 1, r);
        }

        [TestCase(new[] {-40, -20, -1, 3, 4, 4, 4, 4, 4, 6, 7, 8, 9, 12, 13}, Result = 3, TestName = "test1")]
        public int TestRepeat(int[] a)
        {
            return BinSearchRepeat(a, 0, a.Length - 1);
        }

        private int BinSearchRepeat(int[] a, int start, int end)
        {
            if (end < start || start < 0 || end >= a.Length) return int.MinValue;

            int midIndex = start + (end - start)/2;
            int midValue = a[midIndex];

            if (midValue == midIndex) return midIndex;

            int leftIndex = Math.Min(midIndex - 1, midValue);
            int left = BinSearchRepeat(a, start, leftIndex);
            if (left >= 0) return left;

            int rightIndex = Math.Max(midIndex + 1, midValue);
            return BinSearchRepeat(a, rightIndex, end);
        }
    }
}