using System;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Test10
    {
        public bool[] ErathosphenSieve(int n)
        {
            var r = new bool[n];
            for (int i = 1; i < n; i+=2)
            {
                r[i] = true;
            }
            r[1] = false;
            r[2] = true;
            for (int i = 2; i < n; i++)
            {
                if (!r[i]) continue;
                for (int j = 2; j*i < n; j++)
                {
                    r[j * i] = false;
                }
            }

            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (r[i])
                {
                    sum += i;
                }
            }
            Console.WriteLine("sum = " + sum);
            
            return r;
        }

        [TestCase(10, TestName = "test1")]
        [TestCase(2000000, TestName = "test2")]
        public void test(int n)
        {
            ErathosphenSieve(n);
        }
    }
}