using System;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Test4
    {
        private bool IsNumberPolindrom(int n)
        {
            // count digits
            var ndc = n;
            var dc = 0;
            while (ndc != 0)
            {
                ndc /= 10;
                dc++;
            }

            var iter = (dc & 1) == 0 ? dc / 2 : dc / 2 + 1;

            var _10_to_n = 10;
            for (var i = 0; i < dc - 2; i++)
            {
                _10_to_n *= 10;
            }

            var nl = n;
            var nr = n;

            for (var i = 1; i <= iter; i++)
            {
                var left = nl / _10_to_n;
                left %= 10;
                var right = nr % 10;
                if (left != right)
                {
                    return false;
                }
                _10_to_n /= 10;
                nr /= 10;
            }
            return true;
        }

        [TestCase(9009, Result = true)]
        [TestCase(90009, Result = true)]
        [TestCase(90008, Result = false)]
        [TestCase(123321, Result = true)]
        public bool TestPolindrom(int n)
        {
            return IsNumberPolindrom(n);
        }

        [TestCase(Result = 906609)]
        public long TestPolindrom1()
        {
            long max = int.MinValue;
            for (var i = 999; i >= 100; i--)
            {
                for (var j = 999; j >= i; j--)
                {
                    var item = i * j;
                    if (!IsNumberPolindrom(item))
                    {
                        continue;
                    }

                    if (item > max)
                    {
                        max = item;
                    }
                }
            }
            Console.WriteLine(max);
            return max;
        }
    }
}
