using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BitManipulation
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/different-bits-sum-pairwise/
    ///     http://www.geeksforgeeks.org/sum-of-bit-differences-among-all-pairs/
    /// </summary>
    public class CountBitsSumPairwise
    {
        [Test]
        public void Test()
        {
            var cntBits = CntBits(new List<int> { 1, 3, 5 });
            Assert.AreEqual(8, cntBits);
        }

        public int CntBits(List<int> A)
        {
            long ans = 0; // Initialize result
            var n = A.Count;
            long mo = 1000000007;
            // traverse over all bits
            for (var i = 0;
                i < 31;
                i++)
            {
                // count number of elements with i'th bit set
                long count = 0;
                for (var j = 0;
                    j < n;
                    j++)
                {
                    if ((A[j] & 1 << i) != 0)
                        count++;
                }

                // Add "count * (n - count) * 2" to the answer
                ans += count * (n - count) * 2 % mo;
                if (ans >= mo) ans -= mo;
            }

            return (int)ans;
        }
    }
}
