using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Backtracking
{
    public class LetterPhone2
    {
        private readonly Dictionary<int, string> _charmap = new Dictionary<int, string>();

        [Test]
        public void Test()
        {
            var list = LetterCombinations("23");
            Utils.PrintCollection(list);
        }

        private void GenerateHelper(List<char> current, int index, string digits, List<string> ans)
        {
            if (index == digits.Length)
            {
                ans.Add(new string(current.ToArray()));
                return;
            }
            var digit = digits[index] - '0';
            for (var i = 0;
                i < _charmap[digit].Length;
                i++)
            {
                current.Add(_charmap[digit][i]);
                GenerateHelper(current, index + 1, digits, ans);
                current.RemoveAt(current.Count - 1);
            }
        }

        private List<string> LetterCombinations(string digits)
        {
            var ans = new List<string>();
            var current = new List<char>();
            _charmap[0] = "0";
            _charmap[1] = "1";
            _charmap[2] = "abc";
            _charmap[3] = "def";
            _charmap[4] = "ghi";
            _charmap[5] = "jkl";
            _charmap[6] = "mno";
            _charmap[7] = "pqrs";
            _charmap[8] = "tuv";
            _charmap[9] = "wxyz";
            GenerateHelper(current, 0, digits, ans);
            return ans;
        }
    }
}
