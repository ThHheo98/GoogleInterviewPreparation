using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    public class CountAndSay
    {
        [Test]
        public void Test()
        {
            var test = CountAndSayTest(4);
            Assert.AreEqual("1211", test);
        }

        public string CountAndSayTest(int n)
        {
            // base cases
            if (n == 1)
                return "1";

            var res = "1";
            for (var i = 1;
                i < n;
                i++)
            {
                var s = new StringBuilder();
                for (var j = 0;
                    j < res.Length;
                    j++)
                {
                    var cnt = 1;

                    while (j + 1 < res.Length && res[j] == res[j + 1])
                    {
                        cnt++;
                        j++;
                    }

                    s.Append(cnt.ToString());
                    s.Append(res[j]);
                }

                res = s.ToString();
            }
            return res;
        }
    }
}
