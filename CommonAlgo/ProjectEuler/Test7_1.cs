using System;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Test7_1
    {
        [TestCase(10001)]
        public void Test(int n)
        {
            int k = 0;
            int i;
            for (i = 1;; i+=2)
            {
                if (ferma(i))
                {
                    k++;
                    if (k == n) break;
                }
            }
            Console.WriteLine(i);
        }


        private long mul(long a, long b, long m)
        {
            if (b == 1)
                return a;
            if (b%2 == 0)
            {
                long t = mul(a, b/2, m);
                return (2*t)%m;
            }
            return (mul(a, b - 1, m) + a)%m;
        }

        private long pows(long a, long b, long m)
        {
            if (b == 0)
                return 1;
            if (b%2 == 0)
            {
                long t = pows(a, b/2, m);
                return mul(t, t, m)%m;
            }
            return (mul(pows(a, b - 1, m), a, m))%m;
        }

        private bool ferma(int x)
        {
            if (x == 2)
                return true;
            var r = new Random();
            for (int i = 0; i < 100; i++)
            {
                int next = r.Next();
                int a = (next%(x - 2)) + 2;
                if (gcd(a, x) != 1)
                    return false;
                if (pows(a, x - 1, x) != 1)
                    return false;
            }
            return true;
        }

        private decimal gcd(int a, int b)
        {
            return b > 0 ? gcd(b, a%b) : a;
        }
    }
}