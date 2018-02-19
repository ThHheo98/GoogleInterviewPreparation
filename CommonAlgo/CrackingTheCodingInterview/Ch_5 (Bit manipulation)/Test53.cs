using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Get next smallest and prev bigger numbers that has equal count of 1
    /// </summary>
    public class Test53
    {
        [TestCase(8, Result = 16)]
        public int GetNext(int i)
        {
            int c = i;
            int c0 = 0;
            int c1 = 0;
            while ((c & 1) == 0 && c != 0)
            {
                c0++;
                c >>= 1;
            }

            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            if (c0 + c1 == 31 || c0 + c1 == 0)
                return -1;

            int p = c0 + c1;
            i |= (1 << p);
            i &= ~ ((1 << p) - 1);
            i |= (1 << (c1 - 1)) - 1;
            return i;
        }

        [TestCase(8, Result = 4)]
        public int GetPrev(int i)
        {
            int tmp = i;
            int c0 = 0;
            int c1 = 0;
            while ((tmp & 1) == 1 && tmp != 0)
            {
                c1++;
                tmp >>= 1;
            }

            if (tmp == 0) return -1;

            while ((tmp & 1) == 0 && tmp != 0)
            {
                c0++;
                tmp >>= 1;
            }

            int p = c0 + c1;
            i &= ((~0) << (p + 1));
            int mask = (1 << (c1 + 1)) - 1;
            i |= mask << (c0 - 1);

            return i;
        }
    }
}