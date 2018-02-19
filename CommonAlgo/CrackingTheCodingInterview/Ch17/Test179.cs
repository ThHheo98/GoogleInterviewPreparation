using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    /// <summary>
    ///     Design a method to find the frequency of occurrences of any given word in a book.
    /// </summary>
    public class Test179
    {
        private readonly Dictionary<string, int> _dictionary = new Dictionary<string, int>();

        private readonly List<string> _list = new List<string>
        {
            "test1",
            "test2",
            "test3",
            "test4",
            "test4",
            "test4",
            "test4",
            "test4",
            "test4",
            "test5",
            "test6",
            "test6",
            "test7",
            "test8",
            "test8",
            "test8",
        };

        [SetUp]
        public void SetUp()
        {
            _dictionary.Clear();
            foreach (string w in _list)
            {
                if (string.IsNullOrEmpty(w)) continue;
                string s = w.ToLower();
                if (_dictionary.ContainsKey(s))
                {
                    _dictionary[s] = _dictionary[s] + 1;
                }
                else
                {
                    _dictionary.Add(s, 1);
                }
            }
        }

        [TestCase("test4", Result = 6, TestName = "test1")]
        [TestCase("test8", Result = 3, TestName = "test2")]
        public int Test(string word)
        {
            return GetFrequency(word);
        }

        private int GetFrequency(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return int.MinValue;
            }
            return _dictionary[word];
        }
    }
}