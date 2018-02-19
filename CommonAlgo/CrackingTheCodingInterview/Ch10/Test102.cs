using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch10
{
    public class Test102
    {
        [TestCase]
        public void Test()
        {
            var s = new[] {"string", "trings", "ringts", "abc", "ingttsr"};

            Sort(s);
            foreach (string s1 in s)
            {
                Console.WriteLine(s1);
            }
        }

        private void Sort(string[] strings)
        {
            var hash = new SortedDictionary<string, List<string>>();
            foreach (string s in strings)
            {
                string key = SortChars(s);
                if (!hash.ContainsKey(key))
                    hash.Add(key, new List<string>());
                List<string> anagrams = hash[key];
                anagrams.Add(s);
            }
            int i = 0;
            foreach (string v in hash.Keys)
            {
                List<string> list = hash[v];
                foreach (string item in list)
                {
                    strings[i] = item;
                    i++;
                }
            }
        }

        private string SortChars(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray);
        }
    }
}