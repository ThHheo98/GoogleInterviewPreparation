using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch18
{
    /// <summary>
    ///     Addition without plus
    /// </summary>
    public class Test181
    {
        [TestCase(2, 3, Result = 5, TestName = "Test1")]
        [TestCase(4, 3, Result = 7, TestName = "Test2")]
        public int Test(int a, int b)
        {
            return AddWithoutPlus(a, b);
        }

        private static int AddWithoutPlus(int a, int b)
        {
            if (b == 0) return a; // recursion base
            int sum = a ^ b; // addition without register transfer
            int carry = (a & b) << 1; // only transfer without addition
            return AddWithoutPlus(sum, carry);
        }
    }
}