using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/max-continuous-series-of-1s/
    ///     http://www.geeksforgeeks.org/find-index-0-replaced-1-get-longest-continuous-sequence-1s-binary-array/
    /// </summary>
    public class MaxContinousSeriesOfOnes
    {
        [Test]
        public void Test()
        {
            var ints = maxone(new List<int> { 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1 }, 2);
            Assert.AreEqual(2, ints.Count);
            Assert.AreEqual(5, ints[0]);
            Assert.AreEqual(7, ints[1]);
        }

        public List<int> maxone(List<int> a, int m)
        {
            var left = 0;
            var right = 0;
            var zeroCount = 0;

            var bestLeft = 0;
            var bestLength = 0;

            while (right < a.Count)
            {
                if (zeroCount <= m)
                {
                    if (a[right] == 0)
                        zeroCount++;
                    right++;
                }

                if (zeroCount > m)
                {
                    if (a[left] == 0)
                        zeroCount--;
                    left++;
                }

                if (right - left > bestLength)
                {
                    bestLength = right - left;
                    bestLeft = left;
                }
            }

            var res = new List<int>();

            for (var i = 0;
                i < bestLength;
                i++)
            {
                if (a[bestLeft + i] == 0)
                    res.Add(bestLeft + i);
            }

            return res;
        }
    }
}
