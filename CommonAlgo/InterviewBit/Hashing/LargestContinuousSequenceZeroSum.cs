using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    /// https://www.interviewbit.com/problems/largest-continuous-sequence-zero-sum/
    /// </summary>
    public class LargestContinuousSequenceZeroSum
    {
        [Test]
        public void Test()
        {
            var ints = lszero(new List<int> { 1, 2, -2, 4, -4 });
            Utils.PrintCollection(ints);
        }

        public List<int> lszero(List<int> a)
        {
            if (a == null) return new List<int>();

            var d = new Dictionary<long, int>();
            d[0] = -1;

            var maxLen = 0;
            var sum = 0;
            var start = -1;
            var end = -1;

            for (var i = 0; i < a.Count; i++)
            {
                sum += a[i];

                int prev;
                if (!d.TryGetValue(sum, out prev))
                {
                    d[sum] = i;
                }
                else
                {
                    if (i - prev > maxLen)
                    {
                        maxLen = i - prev;
                        start = prev + 1;
                        end = i;
                    }
                }
            }

            var res = new List<int>();

            if (start >= 0 && end >= 0)
                for (var i = start; i <= end; i++)
                    res.Add(a[i]);

            return res;
        }
    }
}
