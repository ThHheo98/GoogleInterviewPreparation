using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BitManipulation
{
    /**
     * Think in terms of bits.

How do you do the division with bits?

How do you determine the most significant bit in the answer?
Iterate on the bit position ‘i’ from 31 to 1 and find the first bit for which divisor«i is less than dividend.

How do you use (1) to move forward in similar fashion?
     */

    /// <summary>
    ///     https://www.interviewbit.com/problems/divide-integers/
    /// </summary>
    public class Divideintegers
    {
        [Test]
        public void test()
        {
            var i = Divide(6, 2);
            Assert.AreEqual(3, i);
        }

        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
                return int.MaxValue;

            if (dividend == int.MinValue && divisor == -1)
                return int.MaxValue;

            if (dividend == divisor)
                return 1;

            if (divisor == 1)
                return dividend;

            if (divisor == -1)
                return -dividend;

            if (divisor == 2)
                return dividend >> 1;

            var r = (int)Res(dividend, divisor);

            return r;
        }

        private long Res(long dividend, long divisor)
        {
            var sign = dividend < 0 && divisor > 0 || dividend > 0 && divisor < 0;

            dividend = Math.Abs(dividend);

            divisor = Math.Abs(divisor);

            var result = (int)Math.Floor(Math.Exp(Math.Log(dividend) - Math.Log(divisor)));

            return sign ? -result : result;
        }
    }
}
