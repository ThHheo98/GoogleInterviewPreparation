using System;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Task2
    {
        private static readonly long[] Fibc = new long[100000000];
        private static long _sum;

        [TestCase]
        public void FactTest2()
        {
            long v = 0;
            while (true)
            {
                if (FibCache((int) v) > 4000000)
                    break;
                v++;
            }
            //     Console.WriteLine(v);
            // Console.WriteLine(FibCache((int) v - 1));
            for (int i = 0; i < v; i++)
            {
                long g = FibCache(i);
                if ((g & 1) == 0)
                    _sum += g;
            }
            Console.WriteLine(_sum);
        }

        private static long FibCache(int n)
        {
            if (n == 0 || n == 1) return n;
            if (Fibc[n] != 0) return Fibc[n];
            Fibc[n] = FibCache(n - 1) + FibCache(n - 2);
            return Fibc[n];
        }

        /// <summary>
        ///     Каждое 3-е число из ряда фибоначи четное
        /// </summary>
        [TestCase]
        public void FactTest1()
        {
            long sum = 0;
            const int limit = 4000000;
            int a = 1;
            int b = 1;
            int c = a + b;
            while (c < limit)
            {
                sum += c;
                a = c + b;
                b = c + a;
                c = a + b;
            }
            Console.WriteLine(sum);
            FactTest2();
        }


        /// <summary>
        ///     формула для вывода четных чисел фибоначи (выводится тривиально)
        ///     4*Fib(n-1) + Fib(n-2)
        /// </summary>
        [TestCase(Result = 4613732)]
        public long FactTest0()
        {
            long sum = 0;
            const int limit = 4000000;
            int c = 0;
            while (true)
            {
                int fib1 = Fib(c - 3);
                int fib2 = Fib(c - 6);
                int fib = 4*fib1 + fib2;
                if (fib < 4000000)
                {
                    sum += fib;
                }
                else
                    break;
                c += 3;
            }
            Console.WriteLine(sum);
            return sum; // потому что для Fib(3-6) не вычисляются значение 3-6 <0
        }

        [TestCase(Result = 0)]
        public long FactTestNeg()
        {
            long sum = 0;
            const int limit = 4000000;
            int c = -6;
            while (c < 0)
            {
                int fib1 = Fib(c);
                Console.WriteLine(fib1);


                c += 1;
            }
            Console.WriteLine(sum);
            return 0; // потому что для Fib(3-6) не вычисляются значение 3-6 <0
        }

        private int Fib(int n)
        {
            if (n < 0) return (n%2) == 0 ? -Fib(-n) : Fib(-n);
            if (n < 2) return n;
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}