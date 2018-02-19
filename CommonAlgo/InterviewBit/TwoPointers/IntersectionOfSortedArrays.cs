using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/intersection-of-sorted-arrays/
    ///     http://www.geeksforgeeks.org/union-and-intersection-of-two-sorted-arrays-2/
    /// </summary>
    public class IntersectionOfSortedArrays
    {
        [Test]
        public void Test()
        {
            var ints = Intersect(new List<int> { 1, 2, 3, 4, 5, 6 }, new List<int> { 3, 4, 5, 6 });
            Assert.AreEqual(3, ints[0]);
            Assert.AreEqual(4, ints[1]);
            Assert.AreEqual(5, ints[2]);
            Assert.AreEqual(6, ints[3]);
        }

        private static List<int> Intersect(List<int> A, List<int> B)
        {
            var i = 0;
            var j = 0;

            var ans = new List<int>();

            while (i < A.Count && j < B.Count)
            {
                if (A[i] < B[j]) i++;
                else if (B[j] < A[i]) j++;
                else
                {
                    ans.Add(B[j]);
                    i++;
                    j++;
                }
            }

            return ans;
        }
    }
}
