using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    public class Test171
    {
        [TestCase(1, 2)]
        public void Test171t(int a, int b)
        {
            int a1 = a;
            int b1 = b;

            b = a ^ b;
            a = b ^ a;
            b = b ^ a;

            Assert.AreEqual(a1, b);
            Assert.AreEqual(b1, a);
        }

        [TestCase(1, 2)]
        public void Test171_1(int a, int b)
        {
            int a1 = a;
            int b1 = b;

            b = a + b;
            a = b - a;
            b = b - a;

            Assert.AreEqual(a1, b);
            Assert.AreEqual(b1, a);
        }
    }
}