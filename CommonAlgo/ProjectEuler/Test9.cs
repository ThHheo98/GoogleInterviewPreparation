using System;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Test9
    {
        [TestCase]
        public void Test()
        {
            var a = new int[1000];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i;
            }

            int l, r;
            for (int i = 0; i < a.Length - 2; i++)
            {
                l = i + 1;
                r = a.Length - 1;
                while (l < r)
                {
                    int sum = a[i] + a[l] + a[r];
                    if (sum == 1000)
                    {
                        if (a[i]*a[i] + a[l]*a[l] == a[r]*a[r])
                        {
                            Console.WriteLine(a[i]);
                            Console.WriteLine(a[l]);
                            Console.WriteLine(a[r]);
                            Console.WriteLine(a[i] * a[l] * a[r]);
                            return;
                        }
                        l++;
                        r--;
                    }
                    if (sum < 1000)
                    {
                        l++;
                    }
                    if (sum > 1000)
                    {
                        r--;
                    }
                }
            }
        }
    }
}