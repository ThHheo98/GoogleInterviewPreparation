using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    public class CompareVersionNumber
    {
        private static string Transform(string str)
        {
            // In our current context, "" is equivalent to version 0.
            if (str.Length == 0)
                return "0";
            return str;
        }

        private string NextSubstr(string str)
        {
            for (var i = 0;
                i < str.Length;
                i++)
            {
                if (str[i] == '.')
                    return str.Substring(i + 1);
            }
            return Transform("");
        }

        private static string CurSubstr(string str)
        {
            var zeroIndex = 0;
            for (var i = 0;
                i < str.Length;
                i++)
            {
                if (str[i] == '.')
                    return Transform(str.Substring(zeroIndex, i - zeroIndex));
                if (str[i] == '0' && zeroIndex == i)
                    zeroIndex++;
            }
            return Transform(str.Substring(zeroIndex, str.Length - zeroIndex));
        }

        [Test]
        public void Test()
        {
            var v1 = "1.0.1";
            var v2 = "1.2";
            var compareVersion = CompareVersion(v1, v2);
            Assert.AreEqual(-1, compareVersion);
        }

        public int CompareVersion(string version1, string version2)
        {
            while (version1 != version2)
            {
                version1 = NextSubstr(version1);
                version2 = NextSubstr(version2);

                var current1 = CurSubstr(version1);
                var current2 = CurSubstr(version2);

                var lenGap = current1.Length - current2.Length;
                if (lenGap != 0)
                    return lenGap > 0 ? 1 : -1;

                if (current1 != current2)
                    return string.Compare(current1, current2, StringComparison.Ordinal) > 0 ? 1 : -1;
            }

            return 0;
        }
    }
}
