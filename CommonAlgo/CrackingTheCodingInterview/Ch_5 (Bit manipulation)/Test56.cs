using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Swap even and odd bits
    /// </summary>
    public class Test56
    {
        [TestCase(8, Result = 4)]
        public int Test(int a)
        {
            return ((a & 0xaaaaaaa) >> 1) | ((a & 0x5555555) << 1);
        }
    }
}