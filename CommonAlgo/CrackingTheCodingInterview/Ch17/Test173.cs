using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    /// <summary>
    ///     Count number of trailong zeroes in factorial
    /// </summary>
    public class Test173
    {
        /// <summary>
        /// </summary>
        [TestCase(1, Result = 0, TestName = "test1")]
        [TestCase(5, Result = 1, TestName = "test2")]
        public int Test(int n)
        {
            return CountFactZeroes(n);
        }

        public int CountFactZeroes(int n)
        {
            int count = 0;
            if (n < 0) return -1;
            for (int i = 5; n/i > 0; i *= 5)
            {
                count += n/i;
            }
            return count;
        }
    }
}