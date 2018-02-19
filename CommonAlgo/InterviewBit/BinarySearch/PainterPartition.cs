using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/painters-partition-problem/
    ///     http://articles.leetcode.com/the-painters-partition-problem-part-i
    ///     http://articles.leetcode.com/the-painters-partition-problem-part-ii
    ///     https://www.topcoder.com/community/data-science/data-science-tutorials/binary-search/
    /// </summary>
    /*
     You have to paint N boards of length {A0, A1, A2, A3 … AN-1}. 
     There are K painters available and you are also given how much time a painter takes to paint 1 unit of board. 
     You have to get this job done as soon as possible under the constraints that any painter will only paint contiguous sections of board.

     2 painters cannot share a board to paint. That is to say, a board
     cannot be painted partially by one painter, and partially by another.
     A painter will only paint contiguous boards. Which means a
     configuration where painter 1 paints board 1 and 3 but not 2 is
     invalid.
     Return the ans % 10000003
     
     Input :
     K : Number of painters
     T : Time taken by painter to paint 1 unit of board
     L : A List which will represent length of each board
     
     Output:
          return minimum time to paint all boards % 10000003
     Example
     
     Input : 
       K : 2
       T : 5
       L : [1, 10]
     Output : 50
         */
    public class PainterPartition
    {
        [Test]
        public void Test()
        {
            var k = 2;
            var t = 5;
            var l = new List<int> { 1, 10 };
            var paint = Paint(k, t, l);
            Assert.AreEqual(50, paint);
        }

        private static long Max1(IEnumerable<int> arr)
        {
            var m = long.MinValue;
            foreach (var i in arr)
                m = Math.Max(i, m);
            return m;
        }

        private static long Sum(IEnumerable<int> arr)
        {
            long s = 0;
            foreach (var i in arr)
                s += i;
            return s;
        }

        private static long GetPaintersRequired(List<int> arr, long maxLengthPerPainter)
        {
            long ans = 1;
            long sum = 0;
            foreach (var i in arr)
            {
                sum += i;
                if (sum > maxLengthPerPainter)
                {
                    sum = i;
                    ans++;
                }
            }
            return ans;
        }

        private static int Paint(int k, int t, List<int> list)
        {
            /*
             Assume that you are assigning continuous section of board to each painter such that its total length must not exceed a predefined maximum, costmax. 
             Then, you are able to find the number of painters that is required, x. Following are some key observations:

             1 The lowest possible value for costmax must be the maximum element in A (name this as lo).
             2 The highest possible value for costmax must be the entire sum of A, (name this as hi).
             3 As costmax increases, x decreases. The opposite also holds true.

             */
            var lo = Max1(list); // The lowest possible value for costmax must be the maximum element in A (name this as lo).
            var hi = Sum(list); // The highest possible value for costmax must be the entire sum of A, (name this as hi).

            while (lo < hi)
            {
                var m = lo + (hi - lo) / 2;
                var paintersRequired = GetPaintersRequired(list, m);

                /*
                    
                 */
                if (paintersRequired <= k)
                    hi = m;
                else
                    lo = m + 1;
            }
            return (int)(lo * t % 10000003);
        }
    }
}
