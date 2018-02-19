using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/pretty-json/
    ///     https://discuss.leetcode.com/topic/249/print-json-format-string
    ///     почему то этот тест на interviewbit не проходит
    /// </summary>
    public class PrettyJson
    {
        [Test]
        public void Test()
        {
            var printJsonString = PrintJsonString("{\"id\":100,\"firstName\":\"Jack\",\"lastName\":\"Jones\",\"age\":12}");
            foreach (var v in printJsonString)
                Console.WriteLine(v);
            Console.WriteLine();
            var printJsonString1 = prettyJSON("{\"id\":100,\"firstName\":\"Jack\",\"lastName\":\"Jones\",\"age\":12}");
            foreach (var v in printJsonString1)
                Console.WriteLine(v);
        }

        public List<string> prettyJSON(string A)
        {
            var res = new List<string>();
            var n = A.Length;
            var tabs = 0;

            for (var i = 0;
                i < n;)
            {
                i = skipSpace(A, i);

                if (i >= n)
                    break;

                var str = new StringBuilder();
                var c = A[i];

                if (delimiter(c))
                {
                    if (isOpenBracket(c))
                    {
                        for (var j = 0;
                            j < tabs;
                            j++)
                            str.Append("\t");
                        tabs++;
                    }
                    else if (isClosedBracket(c))
                    {
                        tabs--;
                        for (var j = 0;
                            j < tabs;
                            j++)
                            str.Append("\t");
                    }

                    str.Append(c);
                    i++;

                    if (i < n && canAdd(A[i]))
                    {
                        str.Append(A[i]);
                        i++;
                    }

                    res.Add(str.ToString());

                    continue;
                }

                while (i < n && !delimiter(A[i]))
                {
                    str.Append(A[i]);
                    i++;
                }

                if (i < n && canAdd(A[i]))
                {
                    str.Append(A[i]);
                    i++;
                }

                var strB = new StringBuilder();

                for (var j = 0;
                    j < tabs;
                    j++)
                    strB.Append("\t");

                strB.Append(str);
                res.Add(strB.ToString());
            }

            return res;
        }

        public bool canAdd(char c)
        {
            if (c == ',' || c == ':')
                return true;

            return false;
        }

        public bool delimiter(char c)
        {
            if (c == ',' || isOpenBracket(c) || isClosedBracket(c))
                return true;
            return false;
        }

        public bool isOpenBracket(char c)
        {
            if (c == '[' || c == '{')
                return true;
            return false;
        }

        public bool isClosedBracket(char c)
        {
            if (c == ']' || c == '}')
                return true;
            return false;
        }

        public int skipSpace(string A, int i)
        {
            var n = A.Length;
            while (i < n && A[i] == ' ')
                i++;
            return i;
        }

        private List<string> PrintJsonString(string jsonStr)
        {
            if (jsonStr == null || jsonStr.Trim().Length == 0)
                return null;

            var ret = "\n";
            var formattedJson = new StringBuilder();
            var spaces = new StringBuilder();
            var stack = new Stack<char>();
            for (var i = 0;
                i < jsonStr.Length;)
            {
                var c = jsonStr[i];
                switch (c)
                {
                    case '{':
                    case '[':
                        stack.Push(c);
                        spaces.Append("\t");
                        formattedJson.Append(c).Append(ret).Append(spaces);
                        i++;
                        break;
                    case '}':
                    case ']':
                        stack.Pop();
                        spaces.Remove(spaces.Length - 1, 1);
                        formattedJson.Append(ret).Append(spaces).Append(c);
                        i++;
                        if (!(i < jsonStr.Length && jsonStr[i] == ','))
                            formattedJson.Append(ret).Append(spaces);
                        break;
                    case ',':
                        formattedJson.Append(c).Append(ret).Append(spaces);
                        i++;
                        break;
                    default:
                        formattedJson.Append(c);
                        i++;
                        break;
                }
            }
            var s = formattedJson.ToString();
            return s.Split(Convert.ToChar(ret)).ToList();
        }
    }
}
