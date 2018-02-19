using System;
using System.IO;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch13
{
    public class Test131
    {
        [TestCase("TestData.txt")]
        public void Test(string fileName)
        {
            const int n = 10;
            var a = new string[n];
            var size = 0;
            using (var f = new StreamReader(fileName))
            {
                string line;
                while ((line = f.ReadLine()) != null)
                {
                    a[size%n] = line;
                    size++;
                }
            }

            // get start point of cycled array
            var start = size > n ? size%n : 0;
            var count = Math.Min(n, size);
            for (var i = 0; i < count; i++)
                Console.WriteLine(a[(start + i)%n]);
        }
    }
}