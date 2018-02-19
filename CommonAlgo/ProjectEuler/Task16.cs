using System;
using System.Numerics;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Task16
    {
        [TestCase(1000, Result = 1366)]
        public int Test(int exp)
        {
            var format = BigInteger.Pow(new BigInteger(2), 1000).ToString();
            var s = 0;
            foreach (var v in format)
            {
                var i = int.Parse(v.ToString());
                s += i;
            }
            Console.WriteLine(s);
            return s;
        }
    }
}