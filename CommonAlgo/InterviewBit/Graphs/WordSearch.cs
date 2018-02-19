using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Graphs
{
    public class WordSearch
    {
        private readonly int[] cols = { -1, 0, 1, 0 };

        private readonly int[] rows = { 0, -1, 0, 1 };

        private bool IsAdjacent(List<string> list, Cell cell)
        {
            return cell.i >= 0 && cell.i < list.Count && cell.j >= 0 && cell.j < list[0].Length;
        }

        private bool dfs(List<string> list, string word, HashSet<Cell> was, int i, int j, int num)
        {
            var n = list.Count;
            var m = list[0].Length;

            var q = new Queue<Cell>();

            var cell = new Cell(i, j, word[num]);
            q.Enqueue(cell); // initial values
            was.Add(cell);

            while (q.Count > 0)
            {
                var top = q.Dequeue();

                if (top.ch == word[num])
                {
                    num = num + 1;
                    if (num == word.Length)
                        return true;

                    // traverse on adjecent cells
                    for (var p = 0;
                        p < 4;
                        ++p)
                    {
                        var row = i + rows[p];
                        var col = j + cols[p];
                        var ch = list[i][j];
                        var tempCell = new Cell(row, col, ch);
                        if (IsAdjacent(list, tempCell))
                            /*&& !was.Contains(tempCell)*/
                        {
                            was.Add(tempCell);
                            q.Enqueue(new Cell(row, col, list[row][col]));
                        }
                    }
                }
            }
            return false;
        }

        // 
        /*
            [
                ["ABCE"],
                ["SFCS"],
                ["ADEE"]
            ]

            word = "SG"
            1 top = s q = "" num 1 => q = a f a
            2 top = a q = f a num 1
            3 top f q = a num = 1
            4 top a q = {} num = 1
            5 return

            word "abcced" num = 6
            0 q = a
            1 top a num 1 > q = b a
            2 top b num = 2 > q = a c f 
            3 top a num = 2 > q = c f
            4 top c num = 3 > q = f e c 
            5 top f num = 3 > q = e c 
            6 top e num 3 > q = c
            7 top c num 4 > q = s e
            8 top s num 4 > q = e
            9 top e num 5 > q = d e
            10 top d num 6 > return

            word ""
            return 0

            word "F"
            0 i = 1 j = 1 q = F num = 0
            1 top f num = 1 return because num = w.Length

        */

        [TestCase(Result = 1)]
        public int Exist1()
        {
            var list = new List<string>
            {
                "CDGCG",
                "CDAAA",
                "ECDDB",
                "FBGEC",
                "BEBBF",
                "DFGEF",
                "CGGAD",
                "AACGG",
                "BDGGB"
            };
            var word = "BABABC";

            if (word == "")
                return 0;
            if (list == null)
                return 0;

            // use dfs

            var n = list.Count;
            var m = list[0].Length;

            var was = new HashSet<Cell>();

            for (var i = 0;
                i < n;
                i++)
            {
                for (var j = 0;
                    j < m;
                    j++)
                {
                    if (list[i][j] == word[0])
                    {
                        if (dfs(list, word, was, i, j, 0))
                            return 1;

                        was.Clear();
                    }
                }
            }

            return 0;
        }

        private class Cell
        {
            public readonly char ch;
            public readonly int i;
            public readonly int j;

            public Cell(int i, int j, char ch)
            {
                this.i = i;
                this.j = j;
                this.ch = ch;
            }

            #region Equality members

            protected bool Equals(Cell other)
            {
                return i == other.j && j == other.j;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj.GetType() != GetType())
                    return false;
                return Equals((Cell)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return i * 397 ^ j;
                }
            }

            #endregion
        }
    }
}
