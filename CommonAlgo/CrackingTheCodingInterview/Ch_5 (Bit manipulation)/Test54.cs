using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test54
    {
        [TestCase(2, Result = true, TestName = "test1")]
        [TestCase(128, Result = true, TestName = "test4")]
        [TestCase(3, Result = false, TestName = "test2")]
        [TestCase(0, Result = false, TestName = "test3")]
        public bool Test(int n)
        {
            if (n == 0) return false;
            return (n & (n - 1)) == 0;
        }
    }
}