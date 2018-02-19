using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/remove-duplicates-from-sorted-array/
    /// </summary>
    public class RemoveDuplicatesFromSortedArray
    {
        [Test]
        public void Test()
        {
            var solution = Solution(new List<int> { 1, 1, 1, 2, 3 });
            Assert.AreEqual(3, solution);
        }

        public int Solution(List<int> a)
        {
            if (a.Count < 2)
                return a.Count;

            var j = 1;
            for (var i = 1;
                i < a.Count;
                i++)
            {
                if (a[i - 1] != a[i])
                    a[j++] = a[i];
            }
            return j;
        }
    }
}
