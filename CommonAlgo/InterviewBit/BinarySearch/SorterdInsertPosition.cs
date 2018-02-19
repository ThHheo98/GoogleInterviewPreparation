using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/sorted-insert-position/
    /// </summary>
    public class SorterdInsertPosition
    {
        [Test]
        public void test()
        {
            var insert = searchInsert(new List<int> { 1, 2, 4, 5 }, 3);
            Assert.AreEqual(2, insert);
        }

        private int searchInsert(List<int> A, int B)
        {
            var start = 0;
            var end = A.Count - 1;

            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (A[mid] == B)
                    return mid;

                if (A[mid] < B)
                    start = mid + 1;
                else if (A[mid] < B && A[mid + 1] > B)
                    return mid + 1;
                else
                    end = mid - 1;
            }
            return start;
        }
    }
}
