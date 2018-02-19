using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/implement-power-function/
    /// </summary>
    public class ImplementPowerFunction
    {
        [Test]
        public void Test()
        {
            var pow = Pow(2, 5, 30);
            Assert.AreEqual(2, pow);
        }

        private int Pow(int x, int n, int p)
        {
            if (n == 0)
                return 1 % p;

            long ans = 1, bas = x;

            while (n > 0)
            {
                // We need (bas ** n) % p. 
                // Now there are 2 cases. 
                // 1) n is even. Then we can make bas = bas^2 and n = n / 2.
                // 2) n is odd. So we need bas * bas^(n-1) 
                if (n % 2 == 1)
                {
                    ans = ans * bas % p;
                    n--;
                }
                else
                {
                    bas = bas * bas % p;
                    n /= 2;
                }
            }

            if (ans < 0)
                ans = (ans + p) % p;
            return (int)ans;
        }
    }
}
