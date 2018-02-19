using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    public class Test174
    {
        [TestCase(4, 5, Result = 5, TestName = "test1")]
        [TestCase(6, 5, Result = 6, TestName = "test2")]
        public int Test(int a, int b)
        {
            return GetMaxWithoutConditionOperator(a, b);
        }

        public static int GetMaxWithoutConditionOperator(int a, int b)
        {
            int c = a - b;

            int sa = Sign(a); // if a >= 0 then 1, else 0
            int sb = Sign(b); // if b>=0 then 1, else 0
            int sc = Sign(c); // if c>=0 then 1, else 0

            /*
             * Goal: find k, which = 1, if a > b, and = 0 if a < b
             * if a=b the value of k is does not matter
             */
            int use_sign_of_a = sa ^ sb; // if a and b has different sign then k=sign(a)
            //if a and b has equal sign then k = (a-b)
            int use_sign_of_c = FlipBit(sa ^ sb);
            int k = use_sign_of_a*sa + use_sign_of_c*sc;
            int q = FlipBit(k);
            return a*k + b*q;
        }

        /// <summary>
        ///     Check sign of number
        /// </summary>
        /// <param name="a">Number, which sign should be returned</param>
        /// <returns>1 if a is grater than 0, 0 if a is less than sero</returns>
        public static int Sign(int a)
        {
            return FlipBit((a >> 31) & 0x1);
        }

        /// <summary>
        ///     Flip bit
        /// </summary>
        /// <param name="i">bit which shoud be flipped</param>
        /// <returns>0 if bit = 1, 1 if bit =0</returns>
        private static int FlipBit(int i)
        {
            return 1 ^ i;
        }
    }
}