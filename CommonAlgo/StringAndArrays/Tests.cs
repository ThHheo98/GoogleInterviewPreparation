using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.StringAndArrays
{
    [TestFixture]
    // Programming interview exposed!
    public class Tests
    {
        [TestCase("TEST", Result = 'E')]
        public char? FindFirstNotRepeatedCharacter(string s)
        {
            var dictionary = new Dictionary<char, bool>();

            foreach (char t in s)
            {
                if (dictionary.ContainsKey(t))
                {
                    dictionary[t] = true;
                }
                else
                {
                    dictionary.Add(t, false);
                }
            }

            foreach (char t in s)
            {
                bool b;
                if (dictionary.TryGetValue(t, out b))
                {
                    if (b == false) return t;
                }
            }
            return null;
        }

        [TestCase("REMOVECHARS", "ER", Result = "MOVCHAS", TestName = "Test1")]
        [TestCase("TESTREMOVEFROMSTRING", "TESTREMOVEFROMSTRING", Result = "", TestName = "Test2")]
        public string FindFirstNotRepeatedCharacter(string str, string remove)
        {
            char[] s = str.ToCharArray();
            char[] r = remove.ToCharArray();
            var b = new Boolean[128]; // ASCII only

            for (int i = 0; i < remove.Length; i++)
            {
                b[r[i]] = true;
            }

            int src = 0;
            int dst = 0;
            while (src < str.Length)
            {
                if (!b[str[src]])
                {
                    s[dst++] = str[src];
                }
                src++;
            }
            return new string(s, 0, dst);
        }

        [TestCase("TEST TEST", Result = "TEST TEST", TestName = "Test3")]
        [TestCase("REMOVE CHARS", Result = "CHARS REMOVE", TestName = "Test1")]
        [TestCase("TEST REMOVE FROM STRING", Result = "STRING FROM REMOVE TEST", TestName = "Test2")]
        public string ReverseTheWords(string str)
        {
            int start = 0;
            int end = 0;
            string reversedString = ReverseString(str, start, str.Length - 1);

            while (end < reversedString.Length)
            {
                if (reversedString[end] != ' ')
                {
                    start = end;
                    while (end < reversedString.Length && reversedString[end] != ' ')
                    {
                        end++;
                    }
                    end--; // cause of 0 based array

                    reversedString = ReverseString(reversedString, start, end);
                } 
                end++;
            }

            return reversedString;
        }

        private string ReverseString(string s, int start, int end)
        {
            char[] st = s.ToCharArray();
            while (end > start)
            {
                char t = st[start];
                st[start++] = st[end];
                st[end--] = t;
            }

            return new string(st);
        }


        [TestCase("139", Result = 139, TestName = "Test1")]
        [TestCase("-139", Result = -139, TestName = "Test2")]
        public int StrToInt(string str)
        {
            bool neg = false;
            int k = 0;
            int r = 0;

            if (str[0] == '-')
            {
                neg = true;
                k = 1;
            }

            while (k < str.Length)
            {
                r *= 10;
                int i = str[k++] - '0';
                r += i;
            }
            if (neg)
                r = r* -1;
            return r;
        }


        [TestCase(123, Result = "123", TestName = "test1")]
        [TestCase(-123, Result = "-123", TestName = "test2")]
        public string IntToStr(int i)
        {
            const int max_string_length = 11; // 10 digits and the '-' sign
            bool neg = false;
            if (i < 0)
            {
                i *= -1;
                neg = true;
            }

            var res = new char[max_string_length];
            int k = 0;
            do
            {
                int i1 = i%10 + '0';
                res[k] = (char) i1;
                k++;
                i /= 10;
            } while (i != 0);

            var sb = new StringBuilder();

            if (neg)
            {
                sb.Append('-');
            }

            while (k > 0)
            {
                sb.Append(res[--k]);
            }
            return sb.ToString();
        }
    }
}