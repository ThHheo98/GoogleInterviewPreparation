using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/search-for-a-range/
    ///     https://www.interviewbit.com/problems/count-element-occurence/
    /// </summary>
    public class SearchForARange
    {
        [Test]
        public void Test()
        {
            var range = searchRange(new List<int> { 1, 2, 3, 4, 4, 4, 4, 4, 4, 5 }, 4);
            Assert.AreEqual(3, range[0]);
            Assert.AreEqual(8, range[1]);
        }

        private int BinarySearch(List<int> list, int val, bool findFirst)
        {
            var start = 0;
            var end = list.Count - 1;
            var ans = -1;
            while (start <= end)
            {
                var m = start + (end - start) / 2;

                if (list[m] == val)
                {
                    ans = m;
                    if (findFirst)
                        end = m - 1;
                    else
                        start = m + 1;
                }

                else if (list[m] < val)
                {
                    start = m + 1;
                }
                else
                {
                    end = m - 1;
                }
            }
            return ans;
        }

        private List<int> searchRange(List<int> list, int val)
        {
            var ans = new List<int>(2);

            var f = BinarySearch(list, val, true);
            var l = BinarySearch(list, val, false);

            ans.Add(f);
            ans.Add(l);

            return ans;
        }
    }
}
