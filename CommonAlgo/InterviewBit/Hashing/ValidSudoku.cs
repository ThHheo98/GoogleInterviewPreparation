using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    /// https://www.interviewbit.com/problems/valid-sudoku/
    /// http://qa.geeksforgeeks.org/3927/determine-whether-given-sudoku-board-configuration-valid
    /// </summary>
    public class ValidSudoku
    {
        [Test]
        public void Test()
        {
            string[] str = { "53..7....", "6..195...", ".98....6.", "8...6...3", "4..8.3..1", "7...2...6", ".6....28.", "...419..5", "....8..79" };

            var validSudoku = isValidSudoku(str.ToList());
            Assert.AreEqual(1, validSudoku);
        }

        public int isValidSudoku(List<string> a)
        {
            var r = new bool[9, 9];
            var c = new bool[9, 9];
            var s = new bool[3, 3, 9];

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (a[i][j] > '0' && a[i][j] <= '9')
                    {
                        var n = a[i][j] - '1';
                        if (r[i, n]) return 0;
                        r[i, n] = true;

                        if (c[j, n]) return 0;
                        c[j, n] = true;

                        if (s[i / 3, j / 3, n]) return 0;
                        s[i / 3, j / 3, n] = true;
                    }
                }
            }
            return 1;
        }
    }
}
