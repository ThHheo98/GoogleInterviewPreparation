using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/remove-duplicates-from-sorted-array-ii/
    /// </summary>
    public class RemoveDuplicatesFromSortedArray2
    {
        [Test]
        public void Test()
        {
            var i = RemoveDuplicates(new List<int> { 1, 1, 1, 2 }, 2);
            Assert.AreEqual(3, i);
        }

        private int RemoveDuplicates(List<int> a, int times)
        {
            if (a.Count < 2)
                return a.Count;

            var cnt = 1;
            var j = 1;

            for (var i = 1;
                i < a.Count;
                i++)
            {
                if (a[i - 1] != a[i])
                {
                    a[j++] = a[i];
                    cnt = 1;
                }
                else
                {
                    if (cnt < times)
                    {
                        a[j++] = a[i];
                        cnt++;
                    }
                }
            }
            return j;
        }
    }
}
