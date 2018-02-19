using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/3-sum/
    ///     https://en.wikipedia.org/wiki/3SUM
    ///     http://www.programcreek.com/2013/02/leetcode-3sum-closest-java/
    /// </summary>
    public class _3Sum
    {
        [Test]
        public void Test()
        {
            var threeSumClosest = ThreeSumClosest(new List<int> { 1, 2, 3, 4, 5, 6 }, 15);
            Assert.AreEqual(15, threeSumClosest);
        }

        public int ThreeSumClosest(List<int> a, int b)
        {
            var minDiff = int.MaxValue;
            var res = 0;

            a = a.OrderBy(i => i).ToList();

            for (var i = 0;
                i < a.Count - 2;
                i++)
            {
                var j = i + 1;
                var k = a.Count - 1;
                while (j < k)
                {
                    var s = a[i] + a[j] + a[k];
                    if (s == b)
                        return s;

                    var abs = Math.Abs(b - s);
                    if (abs < minDiff)
                    {
                        minDiff = abs;
                        res = s;
                    }

                    if (s <= b)
                        j++;
                    else
                        k--;
                }
            }
            return res;
        }
    }
}
