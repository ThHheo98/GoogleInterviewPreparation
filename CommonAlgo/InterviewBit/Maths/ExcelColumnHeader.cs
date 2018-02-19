using System;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Maths
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/excel-column-number/
    /// </summary>
    public class ExcelColumnHeadertitleToNumber2
    {
        [TestCase]
        public void Test()
        {
            var i = 28;
            var toTitle = convertToTitle(i);
            Assert.AreEqual("AB", toTitle);
        }

        public string convertToTitle(int n)
        {
            if (n <= 0)
                return "";

            var sb = new StringBuilder();

            while (n > 0)
            {
                n--;
                var ch = (char)(n % 26 + 'A');
                n /= 26;
                sb.Append(ch.ToString());
            }

            // sb.Reverse();
            var charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    /// <summary>
    ///     https://www.interviewbit.com/problems/excel-column-number/
    /// </summary>
    public class ExcelColumnHeadertitleToNumber
    {
        [TestCase]
        public void Test()
        {
            var s = "AB";
            var toNumber = titleToNumber(s);
            Assert.AreEqual(28, toNumber);
        }

        public int titleToNumber(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            var result = 0;
            var t = 0;
            for (var i = s.Length - 1;
                i >= 0;
                --i)
            {
                result = result + (int)Math.Pow(26, t) * (s[i] - 'A' + 1);
                t++;
                i--;
            }

            return result;
        }
    }
}
