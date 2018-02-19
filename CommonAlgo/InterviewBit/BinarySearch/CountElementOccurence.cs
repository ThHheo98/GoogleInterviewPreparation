using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/count-element-occurence/
    /// </summary>
    public class CountElementOccurence
    {
        [Test]
        public void Test()
        {
            var count = FindCount(new List<int> { 1, 2, 3, 4, 5, 5, 5, 5, 6 }, 5);
            Assert.AreEqual(4, count);
        }

        public int FindCount(List<int> a, int b)
        {
            var n = a.Count;

            var firstOccurence = fc(a, 0, n - 1, b, true);
            if (firstOccurence != -1)
            {
                var lastOccurence = fc(a, 0, n - 1, b, false);
                return lastOccurence - firstOccurence + 1;
            }

            return 0;
        }

        // 0 1 2 3 4 5
        // 5 7 7 8 8 10 
        // mid = 2 a[mid] = 7
        // start = 3 end = 5 mid = 4
        private int fc(List<int> a, int start, int end, int b, bool firstOccurence)
        {
            var res = -1;
            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (a[mid] == b)
                {
                    res = mid;
                    if (firstOccurence)
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else if (a[mid] < b)
                {
                    start = mid + 1;
                }
                else if (a[mid] > b)
                {
                    end = mid - 1;
                }
            }
            return res;
        }
    }
}
