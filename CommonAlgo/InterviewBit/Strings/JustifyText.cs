using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     http://www.programcreek.com/2014/05/leetcode-text-justification-java/
    ///     https://www.interviewbit.com/problems/justified-text/
    /// </summary>
    public class JustifyText
    {
        [TestCase]
        public void Test()
        {
            var justify = fullJustify(new List<string> { "This", "is", "an", "example", "of", "text", "justification." }, 16);
            foreach (var v in justify)
                Console.WriteLine(v);
        }

        /// <summary>
        ///     http://www.programcreek.com/2014/05/leetcode-text-justification-java/
        /// </summary>
        /// <param name="words"></param>
        /// <param name="maxWidth"></param>
        /// <returns></returns>
        public List<string> fullJustify(List<string> words, int maxWidth)
        {
            var result = new List<string>();

            if (words == null || words.Count == 0)
                return result;

            var count = 0;
            var last = 0;
            for (var i = 0;
                i < words.Count;
                i++)
            {
                count = count + words[i].Length;

                if (count + i - last > maxWidth)
                {
                    var wordsLen = count - words[i].Length;
                    var spaceLen = maxWidth - wordsLen;
                    var eachLen = 1;
                    var extraLen = 0;

                    if (i - last - 1 > 0)
                    {
                        eachLen = spaceLen / (i - last - 1);
                        extraLen = spaceLen % (i - last - 1);
                    }

                    var sb = new StringBuilder();

                    for (var k = last;
                        k < i - 1;
                        k++)
                    {
                        sb.Append(words[k]);

                        var ce = 0;
                        while (ce < eachLen)
                        {
                            sb.Append(" ");
                            ce++;
                        }

                        if (extraLen > 0)
                        {
                            sb.Append(" ");
                            extraLen--;
                        }
                    }

                    sb.Append(words[i - 1]); //last words in the line
                    //if only one word in this line, need to fill left with space
                    while (sb.Length < maxWidth)
                        sb.Append(" ");

                    result.Add(sb.ToString());

                    last = i;
                    count = words[i].Length;
                }
            }

            var stringBuilder = new StringBuilder();

            for (var i = last;
                i < words.Count - 1;
                i++)
            {
                count = count + words[i].Length;
                stringBuilder.Append(words[i] + " ");
            }

            stringBuilder.Append(words[words.Count - 1]);
            while (stringBuilder.Length < maxWidth)
                stringBuilder.Append(" ");
            result.Add(stringBuilder.ToString());

            return result;
        }

        /// <summary>
        ///     порт кода ответа с си++ на interviewbit
        /// </summary>
        /// <param name="words"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private List<string> fullJustify1(List<string> words, int length)
        {
            var res = new List<string>();

            int k;
            int l;
            for (var i = 0;
                i < words.Count;
                i += k)
            {
                for (k = l = 0;
                    i + k < words.Count && l + words[i + k].Length <= length - k;
                    k++)
                    l += words[i + k].Length;

                var tmp = words[i];
                for (var j = 0;
                    j < k - 1;
                    j++)
                {
                    if (i + k >= words.Count)
                    {
                        tmp += " ";
                    }
                    else
                    {
                        var count = (length - l) / (k - 1);
                        var d = (length - l) % (k - 1);
                        count = count + (j < d ? 1 : 0);
                        tmp += new string(' ', count);
                    }
                    tmp += words[i + j + 1];
                }
                tmp += new string(' ', length - tmp.Length);
                res.Add(tmp);
            }
            return res;
        }
    }
}
