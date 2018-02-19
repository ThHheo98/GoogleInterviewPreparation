using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Count number of bits to be flipped to convert A to B
    /// </summary>
    public class Test55
    {
        [TestCase(3, 1, Result = 1, TestName = "test1")]
        [TestCase(15, 1, Result = 3, TestName = "test2")]
        [TestCase(63, 1, Result = 5, TestName = "test3")]
        public int Test(int a, int b)
        {
            for (b = (a ^= b) ^ a; a != 0; a &= (a - 1), b++) ;
            return b;
        }
    }
}