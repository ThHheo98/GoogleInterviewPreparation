using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/array-3-pointers/
    ///     http://www.geeksforgeeks.org/find-three-closest-elements-from-given-three-sorted-arrays/
    /// </summary>
    public class ArrayOf3Pointers
    {
        [Test]
        public void Test()
        {
            var i = Minimize(new List<int> { 1, 4, 10 }, new List<int> { 2, 15, 20 }, new List<int> { 10, 12 });
            Assert.AreEqual(5, i);
        }

        public int Minimize(List<int> a, List<int> b, List<int> c)
        {
            var i = 0;
            var j = 0;
            var k = 0;

            var diff = int.MaxValue;

            while (i < a.Count && j < b.Count && k < c.Count)
            {
                var min1 = Math.Min(a[i], Math.Min(b[j], c[k]));
                var max1 = Math.Max(a[i], Math.Max(b[j], c[k]));

                if (max1 - min1 < diff)
                    diff = max1 - min1;

                if (diff == 0)
                    break;

                if (a[i] == min1)
                    i++;
                else if (b[j] == min1)
                    j++;
                else
                    k++;
            }

            return diff;
        }
    }
}
