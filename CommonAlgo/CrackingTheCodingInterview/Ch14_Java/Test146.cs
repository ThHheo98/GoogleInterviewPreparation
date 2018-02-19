using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch14_Java
{
    public class Test146
    {
        [TestCase]
        public void Test()
        {
            var c = new CircularArray<int>(2);
            c.Set(0, 1);
            c.Set(0, 1);
            foreach (var i in c)
            {
                Console.WriteLine(i);
            }
        }
    }
}