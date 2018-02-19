using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/container-with-most-water/
    ///     http://www.programcreek.com/2014/03/leetcode-container-with-most-water-java/
    /// </summary>
    public class ContainerWithMostWater
    {
        [Test]
        public void Test()
        {
            var area = MaxArea(new List<int> { 1, 5, 4, 3 });
            Assert.AreEqual(6, area);
        }

        public int MaxArea(List<int> a)
        {
            if (a == null || a.Count < 2) return 0;

            var max = int.MinValue;
            var left = 0;
            var right = a.Count - 1;

            while (left < right)
            {
                max = Math.Max(max, (right - left) * Math.Min(a[right], a[left]));

                if (a[left] < a[right])
                    left++;
                else
                    right--;
            }

            return max;
        }
    }
}
