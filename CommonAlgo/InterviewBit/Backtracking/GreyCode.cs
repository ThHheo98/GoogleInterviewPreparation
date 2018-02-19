using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Backtracking
{
    public class GreyCode
    {
        [TestCase(2)]
        public void Test(int num)
        {
            var list = new List<int>();

            for (var i = 0;
                i < 1 << num;
                i++)
                list.Add(i ^ i >> 1);

            foreach (var i in list)
                Console.WriteLine(i);
        }
    }
}
