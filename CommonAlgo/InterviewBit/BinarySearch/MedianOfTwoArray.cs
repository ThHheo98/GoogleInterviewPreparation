using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/median-of-array/
    /// </summary>
    /*
     * 
     Given a sorted array A of length m, we can split it into two parts:

     { A[0], A[1], … , A[i - 1] }	{ A[i], A[i + 1], … , A[m - 1] }
     All the elements in right part are greater than the elements in left part.
     
     The left part has “i” elements, and right part has “m - i” elements.
     
     There are “m + 1” kinds of splits. (i = 0 ~ m)
     
     When i = 0, the left part has “0” elements, right part has “m” elements.
     
     When i = m, the left part has “m” elements, right part has “0” elements.
     
     For array B, we can split it with the same way:
     
     { B[0], B[1], … , B[j - 1] }	{ B[j], B[j + 1], … , B[n - 1] }
     The left part has “j” elements, and right part has “n - j” elements.
     
     Put A’s left part and B’s left part into one set. (Let us name this set “LeftPart”)
     
     Put A’s right part and B’s right part into one set. (Let us name this set”RightPart”)
     
             LeftPart           |            RightPart 
     { A[0], A[1], … , A[i - 1] }	{ A[i], A[i + 1], … , A[m - 1] }
     { B[0], B[1], … , B[j - 1] }	{ B[j], B[j + 1], … , B[n - 1] }

     If we can ensure the following:
     
     1) LeftPart’s length == RightPart’s length (or RightPart’s length + 1)
     
     2) All elements in RightPart is greater than elements in LeftPart,
     
     then we split all elements in {A, B} into two parts with equal length, and one part is
     
     always greater than the other part.
     
     Then the median can be easily found.
       
     
     To ensure these two condition, we just need to ensure:
     
     Condition 1 : 
      i + j == (m - i) + (n - j) OR i + j == (m - i) + (n - j) + 1 
     
     Which means if n >= m, then     
     i = 0 to m
     j = (m + n + 1) / 2 - i
     Condition 2
      B[j - 1] <= A[i] and A[i - 1] <= B[j]
     Considering edge values, we need to ensure:
     
        (j == 0 or i == m or B[j - 1] <= A[i]) and 
     
        (i == 0 or j == n or A[i - 1] <= B[j])
     So, all we need to do is:
     
     Search i from 0 to m, to find an object i to meet condition (1) and (2) above.
     And we can do this search by binary search.
     
     How?
     
     If B[j0 - 1] > A[i0], than the object ix can’t be in [0, i0].
     
     Why?
     
     Because if
     
       ix < i0, 
       => jx = (m + n + 1) / 2 - ix > j0 
       => B[jx - 1] >= B[j0 - 1] > A[i0] >= A[ix]. 
     This violates the condition (2). So ix can’t be less than i0.
     
     And if A[i0 - 1] > B[j0], than the object ix can’t be in [i0, m].
     So we can do the binary search following the steps described below:
     
     set imin, imax = 0, m, then start searching in [imin, imax]
     Search in [imin, imax]:

    i = (imin + imax) / 2
    j = ((m + n + 1) / 2) - i
    if B[j - 1] > A[i]: 
        search in [i + 1, imax]
    else if A[i - 1] > B[j]: 
        search in [imin, i - 1]
    else:
        if m + n is odd:
            answer is max(A[i - 1], B[j - 1])
        else:
            answer is (max(A[i - 1], B[j - 1]) + min(A[i], B[j])) / 2
         */
    public class MedianOfTwoArray
    {
        [Test]
        public void Test()
        {
            var a = new List<int> { 1, 2, 3, 4 };
            var b = new List<int> { 5, 6, 7, 8, 9 };
            var d = FindMedianSortedArrays(a, b);

            Assert.AreEqual(5, d);
        }

        public static double FindMedianSortedArrays(List<int> a, List<int> b)
        {
            var len = a.Count + b.Count;
            var lenHalf = len / 2;

            if (len % 2 == 1)
                return FindKth(a, 0, b, 0, lenHalf + 1);
            return (FindKth(a, 0, b, 0, lenHalf) + FindKth(a, 0, b, 0, lenHalf + 1)) / 2.0;
        }

        private static int FindKth(IReadOnlyList<int> a, int aStart, IReadOnlyList<int> b, int bStart, int k)
        {
            while (true)
            {
                if (aStart >= a.Count)
                    return b[bStart + k - 1];

                if (bStart >= b.Count)
                    return a[aStart + k - 1];

                if (k == 1)
                    return Math.Min(a[aStart], b[bStart]);

                var aKey = aStart + k / 2 - 1 < a.Count ? a[aStart + k / 2 - 1] : int.MaxValue;
                var bKey = bStart + k / 2 - 1 < b.Count ? b[bStart + k / 2 - 1] : int.MinValue;

                if (aKey < bKey)
                    aStart += k / 2;
                else
                    bStart += k / 2;

                k -= k / 2;
            }
        }
    }

    public class MedianTwo
    {
        [Test]
        public void Test()
        {
            var a = new[] { 1, 2, 3, 4 };
            var b = new[] { 5, 6, 7, 8, 9 };
            var d = GetMedian(a, b, 0, a.Length - 1, a.Length);

            Assert.AreEqual(5, d);
        }

        private static int GetMedian(int[] a1, int[] a2, int left, int right, int n)
        {
            if (left > right)
                return GetMedian(a2, a1, 0, n - 1, n);

            var i = (left + right) / 2;
            var j = n - i - 1;

            if (a1[i] > a2[j] && (j == n - 1 || a1[i] <= a2[j + 1]))
            {
                if (i == 0 || a2[j] > a1[i - 1])
                    return (a1[i] + a2[j]) / 2;
                return (a1[i] + a1[i - 1]) / 2;
            }

            if (a1[i] > a2[j] && j != n - 1 && a1[i] > a2[j + 1])
                return GetMedian(a1, a2, left, i - 1, n);

            return GetMedian(a1, a2, i + 1, right, n);
        }
    }
}
