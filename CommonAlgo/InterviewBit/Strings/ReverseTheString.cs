using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/reverse-the-string/
    /// </summary>
    internal class ReverseTheString
    {
        [Test]
        public void Test()
        {
            var strings = ReverseWordsInStrings("test test1 test2");
            Assert.AreEqual("test2 test1 test", strings);
        }

        public string ReverseWordsInStrings(string a)
        {
            var s = new Stack<string>();

            var ch = a.ToCharArray();
            var sb = new StringBuilder();
            var n = ch.Length;
            var i = 0;
            while (i < n)
            {
                while (i < n && ch[i] == ' ')
                    i++;
                if (i == n)
                    break;

                var j = i;
                while (j < n && ch[j] != ' ')
                    j++;

                for (var k = i;
                    k < j;
                    k++)
                    sb.Append(ch[k]);
                s.Push(sb.ToString());
                sb.Clear();
                i = j + 1;
            }

            sb.Clear();
            while (s.Count > 0)
            {
                var t = s.Pop();
                sb.Append(t);
                if (s.Count != 0)
                    sb.Append(' ');
            }

            return sb.ToString();
        }
    }
}
