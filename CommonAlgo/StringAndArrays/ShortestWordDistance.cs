using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.StringAndArrays
{
    /// <summary>
    /// Leetcode ShortestWordDistance
    /// </summary>
    public class ShortestWordDistance
    {
        [TestCase]
        
        public void Test()
        {
            var list = new List<string> { "freedom", "yandex", "dotnet",  "google" };
            var w1 = "freedom";
            var w2 = "google";
            var p1 = -1;
            var p2 = -1;
            var m = int.MaxValue;
            for (int index = 0; index < list.Count; index++)
            {
                var v = list[index];
                if (v.Equals(w1))
                {
                    p1 = index;
                }
                 if (v.Equals(w2))
                {
                    p2 = index;
                }
                if (p1 != -1 && p2 != -1)
                {
                    m = Math.Min(m, Math.Abs(p1 - p2));
                }
            }
            Assert.IsTrue(m == 3);
        }
    }
}