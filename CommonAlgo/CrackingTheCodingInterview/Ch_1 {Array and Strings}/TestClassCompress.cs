using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class TestClassCompress
    {
        [TestCase("aaabbccccc", Result = "a3b2c5", TestName = "test1")]
        [TestCase("a", Result = "a", TestName = "test2")]
        [TestCase("ab", Result = "ab", TestName = "test3")]
        public string Test15(string toCompress)
        {
            if (string.IsNullOrEmpty(toCompress)) return toCompress;
            if (toCompress.Length == 1) return toCompress;

            string result = string.Empty;
            char current = toCompress[0];
            int cnt = 1;
            for (int i = 1; i < toCompress.Length; i++)
            {
                if (toCompress[i] == current)
                {
                    cnt++;
                }
                else
                {
                    result += current;
                    result += cnt.ToString();
                    current = toCompress[i];
                    cnt = 1;
                }
            }

            result += toCompress[toCompress.Length - 1];
            result += cnt;

            if (result.Length > toCompress.Length)
                return toCompress;
            return result;
        }
    }
}