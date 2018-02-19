using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    public class RotatedArray
    {
        [Test]
        public void Test()
        {
            var findMin = FindMin(new List<int> { 4, 5, 6, 1, 2, 3 });

            Assert.AreEqual(1, findMin);
        }

        public int FindMin(List<int> a)
        {
            var n = a.Count;

            return fm(a, 0, n - 1, n);
        }

        private int fm(List<int> a, int start, int end, int n)
        {
            while (start <= end)
            {
                if (a[start] <= a[end])
                    return a[start];

                var mid = start + (end - start) / 2;

                var nxt = (mid + 1) % n;
                var prev = (mid + n - 1) % n;
                if (a[mid] <= a[prev] && a[mid] <= a[nxt])
                    return a[mid];

                if (a[mid] <= a[end])
                    end = mid - 1;
                else if (a[mid] >= a[start])
                    start = mid + 1;
            }
            return -1;
        }
    }
}
