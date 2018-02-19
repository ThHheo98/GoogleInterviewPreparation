using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/3-sum-zero/
    ///     https://en.wikipedia.org/wiki/3SUM
    ///     https://github.com/nagajyothi/InterviewBit/blob/master/TwoPointers/ThreeSumZero.java
    /// </summary>
    public class _3SumZero
    {
        [Test]
        public void Test()
        {
            var sum = ThreeSum(new List<int> { -1, 0, 1, 2, -1, -4 });

            Assert.AreEqual(2, sum.Count);
            Assert.AreEqual(-1, sum[0][0]);
            Assert.AreEqual(0, sum[0][1]);
            Assert.AreEqual(1, sum[0][2]);

            Assert.AreEqual(-1, sum[1][0]);
            Assert.AreEqual(-1, sum[1][1]);
            Assert.AreEqual(2, sum[1][2]);
        }

        private static List<List<int>> ThreeSum(List<int> a)
        {
            var res = new List<List<int>>();

            a = a.OrderBy(i => i).ToList();

            for (var i = 0;
                i < a.Count - 2;
                i++)
            {
                if (i > 0 && a[i] == a[i - 1])
                    continue;

                var j = i + 1;
                var k = a.Count - 1;
                while (j < k)
                {
                    var s = a[i] + a[j];
                    if (s + a[k] < 0)
                    {
                        j++;
                    }
                    else if (s + a[k] > 0)
                    {
                        k--;
                    }
                    else
                    {
                        var l = new List<int> { a[i], a[j], a[k] };
                        res.Add(l);

                        // skip all duplicates
                        var leftVal = a[j];
                        while (j < k && a[j] == leftVal)
                            j++;

                        var rightVal = a[k];
                        while (k > j && a[k] == rightVal)
                            k--;
                    }
                }
            }
            return res;
        }
    }
}
