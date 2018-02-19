using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Maths
{
    public class GenerateAllNumbersFromNumber
    {
        [Test]
        public void Test()
        {
            var ints = gen(23);
            Utils.PrintCollection(ints);
        }

        public int[] gen(int n)
        {
            var l = new List<int>();
            while (n!=0)
            {
                l.Add(n%10);
                n /= 10;
            }
            return l.ToArray();
        }
    }
}