using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.StackQueues
{
    public class SimplifyPath
    {
        [TestCase]
        public void SimplifyPathTest()
        {
            var simplifyPathTest = SimplifyPathTest("/a/./b/../../c/");

            Assert.AreEqual("/c", simplifyPathTest);
        }

        public static string SimplifyPathTest(string path)
        {
            if (string.IsNullOrEmpty(path))
                return "/";

            int N = path.Length, begin = 0;
            var res = new List<string>();
            while (begin < N)
            {
                while (begin < N && path[begin] == '/')
                    begin++;
                if (begin == N)
                    break; // cannot forget this line!!!!

                var end = begin;
                while (end < N && path[end] != '/')
                    end++;

                var sub = path.Substring(begin, end - begin);

                if (sub == "..")
                {
                    if (res.Count > 0)
                        res.RemoveAt(res.Count - 1);
                }
                else if (sub == ".")
                {
                }
                else
                {
                    res.Add("/" + sub);
                }
                begin = end;
            }

            if (res.Count == 0)
                return "/";

            var final = "";
            foreach (var s in res)
                final += s;

            return final;
        }
    }
}
