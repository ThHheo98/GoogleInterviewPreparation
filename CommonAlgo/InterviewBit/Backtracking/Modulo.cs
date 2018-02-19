using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Backtracking
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/modular-expression/
    /// </summary>
    public class Modulo
    {
        [TestCase(-1, 1, 20, Result = 19)]
        public int Mod(int x, int n, int p)
        {
            if (n == 0)
                return 1 % p;

            long y;

            if (n % 2 == 0)
            {
                y = Mod(x, n / 2, p);
                y = y * y % p;
            }
            else
            {
                y = x % p;
                y = y * Mod(x, n - 1, p) % p;
            }

            return (int)((y + p) % p);
        }
    }
}
