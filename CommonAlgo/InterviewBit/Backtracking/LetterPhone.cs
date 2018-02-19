using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Backtracking
{
    public class LetterPhone
    {
        [Test]
        public void Test()
        {
            var combinations = letterCombinations("23");
            Utils.PrintCollection(combinations);
        }

        public List<string> letterCombinations(string digits)
        {
            var map = new Dictionary<int, string> { { 2, "abc" }, { 3, "def" }, { 4, "ghi" }, { 5, "jkl" }, { 6, "mno" }, { 7, "pqrs" }, { 8, "tuv" }, { 9, "wxyz" }, { 0, "" } };

            var result = new List<string>();

            if (digits == null || digits.Length == 0)
                return result;

            var temp = new List<char>();
            getString(digits, temp, result, map);

            return result;
        }

        public void getString(string digits, List<char> temp, List<string> result, Dictionary<int, string> map)
        {
            if (digits.Length == 0)
            {
                var arr = new char[temp.Count];
                for (var i = 0;
                    i < temp.Count;
                    i++)
                    arr[i] = temp[i];
                result.Add(new string(arr));
                return;
            }

            var curr = int.Parse(digits.Substring(0, 1));
            var letters = map[curr];
            for (var i = 0;
                i < letters.Length;
                i++)
            {
                temp.Add(letters[i]);
                getString(digits.Substring(1), temp, result, map);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
