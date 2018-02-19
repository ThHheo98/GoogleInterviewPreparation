using NUnit.Framework;

namespace CommonAlgo
{
    public class TestBits
    {
        [TestCase(2, 1, Result = true, TestName = "test2")]
        [TestCase(4, 2, Result = true, TestName = "test1")]
        [TestCase(3, 0, Result = true, TestName = "test3")]
        public bool IsBitSetted(int n, int bn)
        {
            return (n & (1 << bn)) != 0;
        }

        [TestCase(1, 1, Result = 3, TestName = "test2")]
        public int SetBit(int n, int bn)
        {
            n = n | (1 << bn);
            return n;
        }

        [TestCase(1, 0, Result = 0, TestName = "test2")]
        [TestCase(2, 1, Result = 0, TestName = "test3")]
        public int ClearBit(int n, int bn)
        {
            n = n & ~(1 << bn);
            return n;
        }

        [TestCase(4, 0, 1, TestName = "test1", Result = 5)]
        public int UpdateBit(int n, int i, int v)
        {
            return (n & ~(1 << i)) | (v << i);
        }

        [TestCase(4, TestName = "test1", Result = true)]
        [TestCase(3, TestName = "test2", Result = false)]
        [TestCase(0, TestName = "test3", Result = true)]
        public bool Is2Power(int n)
        {
            return (n & (n - 1)) == 0;
        }
    }
}