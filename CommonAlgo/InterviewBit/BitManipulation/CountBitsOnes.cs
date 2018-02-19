using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BitManipulation
{
    /// <summary>
    ///     http://www.geeksforgeeks.org/count-set-bits-in-an-integer/
    ///     https://www.quora.com/How-do-you-count-the-number-of-1-bits-in-a-number-using-only-bitwise-operations
    ///     http://www.programcreek.com/2014/03/leetcode-number-of-1-bits-java/
    ///     http://articles.leetcode.com/number-of-1-bits/
    /// </summary>
    public class CountBitsOnes
    {
        [Test]
        public void Test()
        {
            var c = Count(3);
            Assert.AreEqual(2, c);
        }

        public int Count(int A)
        {
            var cnt = 0;
            while (A != 0)
            {
                var t = A & 1;
                A = A >> 1;
                if (t == 1)
                    cnt++;
            }
            return cnt;
        }
    }
}
