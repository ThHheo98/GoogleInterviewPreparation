using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Числа Каталана
    /// </summary>
    public class Test911
    {
        [TestCase]
        public void Test()
        {
        }

        public int f(string exp, bool result, int s, int e, Dictionary<string, int> q)
        {
            string key = string.Empty + s + e;
            int c = 0;
            if (!q.ContainsKey(key))
            {
                if (s == e)
                {
                    c = exp[s] == '1' ? 1 : 0;
                }
                for (int i = s + 1; i < e; i += 2)
                {
                    char op = exp[i];
                    if (op == '&')
                    {
                        c += f(exp, true, s, i - 1, q)*f(exp, true, i + 1, e, q);
                    }
                    else if (op == '|')
                    {
                        int left_ops = (i - 1 - s)/2; // left parens
                        int right_ops = (e - i - s)/2; // right parens
                        int total_ways = Total(left_ops)*Total(right_ops);
                        int total_false = f(exp, false, s, i - 1, q)*f(exp, false, i + 1, e, q);
                        f(exp, false, i + 1, e, q);
                        c += total_ways - total_false;
                    }
                    else if (op == '^')
                    {
                        c += f(exp, true, s, i - 1, q)*f(exp, false, i + 1, e, q);
                        c += f(exp, false, s, i - 1, q)*f(exp, true, i + 1, e, q);
                    }
                }
            }
            else
            {
                c = q[key];
            }
            if (result)
                return c;
            int num_ops = (e - s)/2;
            return Total(num_ops) - c;
        }


        /// <summary>
        ///     Return Catalan's number
        /// </summary>
        /// <param name="numOps"></param>
        /// <returns></returns>
        private int Total(int numOps)
        {
            return 1;
        }
    }
}