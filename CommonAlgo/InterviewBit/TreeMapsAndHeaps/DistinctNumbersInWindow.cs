using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TreeMapsAndHeaps
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/distinct-numbers-in-window/
    ///     http://www.geeksforgeeks.org/count-distinct-elements-in-every-window-of-size-k/
    ///     http://qa.geeksforgeeks.org/3934/find-the-count-distinct-numbers-windows-size-amazon-latest
    /// </summary>
    public class DistinctNumbersInWindow
    {
        [Test]
        public void Test()
        {
            var list = DistinctNumbersInWindowTest(new List<int> { 1, 2, 1, 3, 4, 3 }, 3);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(2, list[3]);
        }

        public List<int> DistinctNumbersInWindowTest(List<int> a, int k)
        {
            if (a == null)
                return null;

            if (a.Count < k)
                return new List<int>();

            var s = new Dictionary<int, int>();

            var res = new List<int>();

            var idx = 0;
            foreach (var i in a)
            {
                if (s.ContainsKey(i))
                    s[i]++;
                else
                    s.Add(i, 1);

                if (idx >= k - 1)
                {
                    res.Add(s.Count);

                    if (s[a[idx - (k - 1)]] > 1)
                        s[a[idx - (k - 1)]]--;
                    else
                        s.Remove(a[idx - (k - 1)]);
                }

                idx++;
            }

            return res;
        }
    }
}
