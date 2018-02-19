using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test96
    {
        [TestCase(2, TestName = "test2")]
        [TestCase(3, TestName = "test3")]
        [TestCase(4, TestName = "test4")]
        [TestCase(5, TestName = "test5")]
        public void TestIneffective(int remaining)
        {
            HashSet<string> generateParens = GenerateParens(remaining);
            foreach (string paren in generateParens)
            {
                Console.WriteLine(paren);
            }
            Console.WriteLine(generateParens.Count);
        }

        private HashSet<string> GenerateParens(int remaining)
        {
            var hash = new HashSet<string>();
            if (remaining == 0)
            {
                hash.Add("");
            }
            else
            {
                HashSet<string> prev = GenerateParens(remaining - 1);
                foreach (string str in prev)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] != '(') continue;

                        string s = InsertInside(str, i);
                        if (!hash.Contains(s))
                        {
                            hash.Add(s);
                        }
                    }
                    if (!hash.Contains("()" + str))
                    {
                        hash.Add("()" + str);
                    }
                }
            }
            return hash;
        }

        private string InsertInside(string s, int leftIndex)
        {
            string left = s.Substring(0, leftIndex + 1);
            string right = s.Substring(leftIndex + 1, s.Length - leftIndex - 1);
            return left + "()" + right;
        }

        [TestCase(2, TestName = "test2")]
        [TestCase(3, TestName = "test3")]
        [TestCase(4, TestName = "test4")]
        [TestCase(5, TestName = "test5")]
        public void TestEffective(int count)
        {
            var list = new List<string>();
            var str = new char[count*2];

            GenerateParensEffective(list, count, count, str, 0);
            foreach (string paren in list)
            {
                Console.WriteLine(paren);
            }
            Console.WriteLine(list.Count);
        }

        private static void GenerateParensEffective(IList<string> list, int leftRem, int rightRem, char[] str, int count)
        {
            if (leftRem < 0 || rightRem < leftRem) return;
            if (leftRem == 0 && rightRem == 0)
            {
                list.Add(new string(str));
            }
            else
            {
                if (leftRem > 0)
                {
                    str[count] = '(';
                    GenerateParensEffective(list, leftRem - 1, rightRem, str, count + 1);
                }

                if (rightRem > leftRem)
                {
                    str[count] = ')';
                    GenerateParensEffective(list, leftRem, rightRem - 1, str, count + 1);
                }
            }
        }
    }
}