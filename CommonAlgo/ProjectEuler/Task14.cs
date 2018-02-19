using System;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Task14
    {
        [TestCase]
        public void Test()
        {
            var r = new Tuple<int, int>[1000000];
            var cnt = 0;
            var maxValue = 0;
            for (var i = 2; i < 1000000; i++)
            {
                cnt = 0;
                maxValue = 0;
                var t = i;
                while (t != 1)
                {
                    if (t%2 == 0)
                    {
                        t /= 2;
                    }
                    else
                    {
                        t = 3*t + 1;
                        if (maxValue < t)
                            maxValue = t;
                    }
                    cnt++;
                }
                r[i] = new Tuple<int, int>(cnt, maxValue);
                Console.WriteLine(i);
            }
            Console.WriteLine(r.Max());
        }
    }
}