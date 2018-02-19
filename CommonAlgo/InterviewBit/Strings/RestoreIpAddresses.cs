using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    public class RestoreIpAddresses
    {
        [Test]
        public void Test()
        {
            var ipAddresses = restoreIpAddresses("25525511135");
            Assert.AreEqual(2, ipAddresses.Count);
        }

        public List<string> restoreIpAddresses(string s)
        {
            var result = new List<List<string>>();
            var t = new List<string>();
            dfs(result, s, 0, t);

            var finalResult = new List<string>();

            foreach (var l in result)
            {
                var sb = new StringBuilder();
                foreach (var str in l)
                    sb.Append(str + ".");

                finalResult.Add(sb.ToString().TrimEnd('.'));
            }

            return finalResult;
        }

        public void dfs(List<List<string>> result, string s, int start, List<string> t)
        {
            //if already get 4 numbers, but s is not consumed, return
            if (t.Count >= 4 && start != s.Length)
                return;

            //make sure t's size + remaining string's length >=4
            if (t.Count + s.Length - start + 1 < 4)
                return;

            //t's size is 4 and no remaining part that is not consumed.
            if (t.Count == 4 && start == s.Length)
            {
                var temp = new List<string>(t);
                result.Add(temp);
                return;
            }

            for (var i = 1;
                i <= 3;
                i++)
            {
                //make sure the index is within the boundary
                if (start + i > s.Length)
                    break;

                var sub = s.Substring(start, start + i);
                //handle case like 001. i.e., if length > 1 and first char is 0, ignore the case.
                if (i > 1 && s[start] == '0')
                    break;

                //make sure each number <= 255
                if (int.Parse(sub) > 255)
                    break;

                t.Add(sub);
                dfs(result, s, start + i, t);
                t.RemoveAt(t.Count - 1);
            }
        }
    }
}
