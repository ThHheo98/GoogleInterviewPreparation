using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.GoogleInternInterview2014
{
    public class Solver2
    {
        private string[] _tickets;

        [SetUp]
        public void SetUp()
        {
            _tickets = new[] {"RA 12 GE", "TE 33 ST"};
        }

        [TestCase]
        public void Test()
        {
            if (_tickets == null) throw new ArgumentException();
            if (_tickets.Length <= 0) return;

            for (var index = 0; index < _tickets.Length; index++)
            {
                var ticket = _tickets[index];
                var splitted = ticket.Split(' ');
                var word = (splitted[0] + splitted[2]).ToLower();

                var words = new List<string>
                {
                    "Test",
                    "weekend",
                    "table",
                    "characters",
                    "development",
                    "downgrade",
                    "rampage",
                    "ranger"
                };

                var minWordIdx = FindShortestWordThatContainsAllCharacters(words, word);
                Console.WriteLine(minWordIdx != -1 ? words[minWordIdx] : "Not found");
                if (index == 1) Assert.IsTrue(words[minWordIdx] == "Test");
                if (index == 0) Assert.IsTrue(words[minWordIdx] == "ranger");
            }
        }

        private static int FindShortestWordThatContainsAllCharacters(IList<string> words, string word)
        {
            if (string.IsNullOrEmpty(word)) throw new ArgumentException("word");
            if (words.Count <= 0) throw new ArgumentException("words");

            var chars = new int[256];

            var minWordIdx = -1;
            var minWordLen = int.MaxValue;
            for (var wordIdx = 0; wordIdx < words.Count; wordIdx++)
            {
                foreach (var c in words[wordIdx])
                {
                    chars[c]++;
                }

                var chrCnt = 0;
                foreach (var c in word)
                {
                    if (chars[c] > 0)
                    {
                        chars[c]--;
                        chrCnt++;
                    }
                }

                if (chrCnt == word.Length && words[wordIdx].Length < minWordLen)
                {
                    minWordIdx = wordIdx;
                    minWordLen = words[wordIdx].Length;
                }
            }
            return minWordIdx;
        }
    }
}