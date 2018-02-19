using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/colorful-number/
    /// </summary>
    public class ColorfulNumber
    {
        [Test]
        public void Test()
        {
            var i = colorful(23);
            Assert.AreEqual(1,i);
            var i1 = colorful(222);
            Assert.AreEqual(0, i1);
        }

        public int colorful(int a)
        {
            var d = new HashSet<long>();

            var s = a.ToString();
            for (var i = 0; i < s.Length; i++)
            {
                long mul = 1;
                for (var j = i; j < s.Length; j++)
                {
                    mul *= s[j] - '0';
                    if (d.Contains(mul)) return 0;
                    d.Add(mul);
                }
            }
            return 1;
        }
    }
}
