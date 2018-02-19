using System;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Task3
    {
        [TestCase(17, Result = 17, TestName = "test1")]
        [TestCase(19, Result = 19, TestName = "test2")]
        [TestCase(600851475143, Result = 6857, TestName = "test3")]
        public int PrimeNumbers(long n)
        {
            int divider = 0; // :)
            while (n != 1)
            {
                divider = 2;
                while (n%divider != 0)
                {
                    divider++;
                }
                Console.WriteLine(divider);
                n /= divider;
            }
            return divider;
        }

        /// <summary>
        /// решение из объяснения на projecteuler
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [TestCase(17, Result = 17, TestName = "test1")]
        [TestCase(19, Result = 19, TestName = "test2")]
        [TestCase(600851475143, Result = 6857, TestName = "test3")]
        
        public long PrimeNumbers1(long n)
        {
            int lastFactor; // :)
            long maxFactor = n;
            if (n%2 == 0)
            {
                lastFactor = 2;
                n /= 2;
                while (n%2 == 0) n /= 2;
            }
            else
            {
                lastFactor = 1;
            }
            int factor = 3;
            while (n > 1 && factor <= maxFactor)
            {
                if (n%factor == 0)
                {
                    n /= factor;
                }
                lastFactor = factor;
                while (n%factor == 0)
                {
                    n /= factor;
                }
                maxFactor = n;
                factor += 2;
            }
            if (n == 1)
            {
                Console.WriteLine(lastFactor);
                return lastFactor;
            }
            Console.WriteLine(n);
            return n;
        }
    }
}