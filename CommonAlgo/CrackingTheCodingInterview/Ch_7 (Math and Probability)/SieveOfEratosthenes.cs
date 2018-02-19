using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class SieveOfEratosthenes
    {
        /// <summary>
        ///     O(n*log(log(n)))
        /// </summary>
        /// <param name="max"></param>
        [TestCase(10)]
      //  [TestCase(10001)]
        public void Test(int max)
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
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}