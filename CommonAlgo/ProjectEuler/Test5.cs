using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Test5
    {
        [TestCase(20, Result = 232792560, TestName = "test1")]
        public int Test(int n)
        {
            int r = 1;
            for (int i = 1; i <= n; i++)
            {
                r = lcm(r, i);
            }
            return r;
        }

        private int lcm(int a, int b)
        {
            return a/gcd(a, b)*b;
        }


        private int gcd(int a, int b)
        {
            return b > 0 ? gcd(b, a%b) : a;
        }
    }
}