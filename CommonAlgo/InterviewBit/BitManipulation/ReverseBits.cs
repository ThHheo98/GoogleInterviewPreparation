using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BitManipulation
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/reverse-bits/
    ///     http://articles.leetcode.com/reverse-bits/
    /// </summary>
    public class ReverseBits
    {
        [Test]
        public void Test()
        {
        }

        private uint swapBits(uint x, int i, int j)
        {
            var lo = x >> i & 1;
            var hi = x >> j & 1;
            if ((lo ^ hi) != 0)
                x ^= 1U << i | 1U << j;
            return x;
        }

        private uint reverse(uint x)
        {
            uint n = sizeof(int) * 8;
            for (var i = 0;
                i < n / 2;
                i++)
                x = swapBits(x, i, (int)(n - i - 1));
            return x;
        }
    }
}
