using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    public enum Piece
    {
        Empty,
        Tic,
        Tac
    }

    /// <summary>
    ///     Крестики нолики Tic Tac Toe NxN
    /// </summary>
    public class Test172
    {
        [TestCase(3)]
        public void Test(int n)
        {
            var p = new Piece[n][];
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new Piece[n];
            }

            for (int i = 0; i < n; i++)
            {
                p[0][i] = Piece.Tac;
            }

            Piece hw = HasWon(p);
            Assert.IsTrue(hw == Piece.Tac);
        }

        private Piece HasWon(Piece[][] pieces)
        {
            int n = pieces.Length;
            int col;
            int row;

            //check rows
            for (row = 0; row < n; row++)
            {
                if (pieces[row][0] != Piece.Empty)
                {
                    for (col = 1; col < n; col++)
                    {
                        if (!pieces[row][col - 1].Equals(pieces[row][col]))
                            break;
                    }
                    if (col == n)
                        return pieces[row][0];
                }
            }

            //check cols
            for (col = 0; col < n; col++)
            {
                if (pieces[0][col] != Piece.Empty)
                {
                    for (row = 1; row < n; row++)
                    {
                        if (!pieces[row][col].Equals(pieces[row - 1][col]))
                            break;
                    }
                    if (row == n)
                        return pieces[0][col];
                }
            }

            //check diagonal from upper left to bottom right
            if (pieces[0][0] != Piece.Empty)
            {
                for (row = 1; row < n; row++)
                {
                    if (!pieces[row][row].Equals(pieces[row - 1][row - 1])) break;
                }
                if (row == n)
                    return pieces[0][0];
            }

            //check diagonal from bottom left to upper right
            if (pieces[0][0] != Piece.Empty)
            {
                for (row = 1; row < n; row++)
                {
                    if (!pieces[n - row - 1][row].Equals(pieces[n - row][row - 1])) break;
                }
                if (row == n)
                    return pieces[n - 1][0];
            }
            return Piece.Empty;
        }
    }
}