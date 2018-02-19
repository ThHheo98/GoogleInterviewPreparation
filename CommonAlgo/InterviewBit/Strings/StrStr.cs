using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    public class StrStr
    {
        [Test]
        public void Test()
        {
            const string s = "abcdef";
            var str = strStr(s, "ef");
            Assert.AreEqual(4, str);
        }

        private static int strStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle))
                return -1;

            for (var i = 0;
                i < haystack.Length;
                i++)
            {
                for (var j = 0;
                    j < needle.Length && i + j < haystack.Length;
                    j++)
                {
                    if (needle[j] != haystack[i + j])
                        break;
                    if (j == needle.Length - 1)
                        return i;
                }
            }
            return -1;
        }
    }
}
