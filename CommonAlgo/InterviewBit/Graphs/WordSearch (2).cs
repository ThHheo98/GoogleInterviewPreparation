using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Graphs
{
    public class WordSearch
    {
        private static int[] rows = { 0, 0, -1, 1 };
        private static int[] cols = { 1, -1, 0, 0 };

        private bool IsAdjacent(List<string> list, int i, int j)
        {
            return (i >= 0) && (i < list.Count) && (j >= 0) && (j < list[0].Length);
        }

        private bool Dfs(List<string> list, string word, HashSet<Cell> was, int i, int j, int pos)
        {
            if (pos == word.Length)
            {
                return true;
            }

            if ((pos < 0) || (pos > word.Length))
            {
                return false;
            }
            if (word[pos] != list[i][j])
            {
                return false;
            }

            var item = new Cell(i, j, pos);
            was.Add(item);

            var status = false;

            for (var k = 0; k < 4; k++)
            {
                var row = i + rows[k];
                var col = j + cols[k];

                if (IsAdjacent(list, row, col) && !was.Contains(new Cell(row, col, pos)))
                {
                    status = Dfs(list, word, was, row, col, pos + 1);
                    if (status)
                    {
                        break;
                    }
                }
            }
            was.Remove(item);
            return status;
        }

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
            {
                return 0;
            }
            if (list == null)
            {
                return 0;
            }

            // use dfs

            var n = list.Count;
            var m = list[0].Length;

            var was = new HashSet<Cell>();

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    if (Dfs(list, word, was, i, j, 0))
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        [TestCase(Result = 0)]
        public int Exist2()
        {
            var list = new List<string>
            {
                "FCBCFFDEEC", "FDCDFCGGGA", "CGCGDDGBGA", "GACBFCGACE", "CEFDFDCGBA", "CGAACCGDCB", "GCBCDEEBBC", "ADCEDFDCCE"
            };
            var word = "AADCFFB";

            if (word == "")
            {
                return 0;
            }
            if (list == null)
            {
                return 0;
            }

            // use dfs
            var was = new HashSet<Cell>();
            var n = list.Count;
            var m = list[0].Length;

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    if (Dfs(list, word, was, i, j, 0))
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        private class Cell
        {
            public readonly int i;
            public readonly int j;
            public readonly int pos;

            public Cell(int i, int j, int pos)
            {
                this.i = i;
                this.j = j;
                this.pos = pos;
            }

            #region Equality members

            protected bool Equals(Cell other)
            {
                return (i == other.j) && (j == other.j);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (obj.GetType() != GetType())
                {
                    return false;
                }
                return Equals((Cell)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (i * 397) ^ j;
                }
            }

            #endregion
        }
    }
}
