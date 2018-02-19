using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Test7
    {
        [TestCase(1000000, Result = 104743)]
        public int Test(int max)
        {
            var primes = new bool[max];

            for (int i = 2; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            primes[0] = primes[1] = false;

            for (int i = 2; i < primes.Length; i++)
            {
                if (!primes[i]) continue;
                for (int j = 2; i*j < primes.Length; j++)
                {
                    primes[i*j] = false;
                }
            }

            int k = 0;
            int i1 = 0;
            while (k < 10001)
            {
                if (primes[i1])
                {
                    k++;
                    if (k == 10001) break;
                }
                i1++;
            }
            return i1;
        }
    }
}