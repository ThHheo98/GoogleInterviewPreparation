using System;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Test12
    {
        [TestCase]
        public void Test()
        {
            int n = 7;
            while (true)
            {
                int sum = n*(n + 1)/2;
                int cnt = 0;
                int i;
                for (i = 1; i < (int)Math.Sqrt(sum); i++)
                {
                    if (sum%i == 0)
                    {
                        cnt += 2;
               //         Console.Write(i + " " + sum/i);
                 //       Console.WriteLine();
                    }
                }
                if (i*i == sum)
                {
                    cnt++;
                }
                if (cnt >= 500)
                {
                    Console.WriteLine(sum);
                    Console.WriteLine(cnt);
                    return;
                }
                if (n%100==0)
                {
                    Console.WriteLine(n);
                    Console.WriteLine(cnt);
                   // Console.Clear();
                }
                
               // if (n==7) return;
                n++;
            }
        }
    }
}