using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    public class IsValidPolindrome
    {
        [TestCase("A man, a plan, a canal: Panama", Result = 1)]
        public int IsPalindrome(string s)
        {
            var strBuf = new StringBuilder();

            for (var i = 0;
                i < s.Length;
                i++)
            {
                if (s[i] >= 'a' && s[i] <= 'z' || s[i] >= 'A' && s[i] <= 'Z' || s[i] >= '0' && s[i] <= '9')
                    strBuf.Append(char.ToLower(s[i]));
            }

            var str = strBuf.ToString();
            var n = str.Length;

            for (var i = 0;
                i < n / 2;
                i++)
            {
                if (str[i] != str[n - i - 1])
                    return 0;
            }

            return 1;
        }
    }
}
