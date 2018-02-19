using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test99
    {
        private const int GridSize = 8;

        [TestCase]
        public void Test()
        {
            var c = new int[GridSize];
            var r = new List<int[]>();
            PlaceQueen(0,c,r);
            foreach (var intse in r)
            {
                for (int i = 0; i < intse.Length; i++)
                {
                    Console.Write(intse[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private void PlaceQueen(int row, int[] columns, List<int[]> results)
        {
            if (row == GridSize)
            {
                results.Add((int[]) columns.Clone());
            }
            else
            {
                for (int col = 0; col < GridSize; col++)
                {
                    if (!CheckValid(columns, row, col)) continue;
                    columns[row] = col; // place queen
                    PlaceQueen(row + 1, columns, results);
                }
            }
        }

        private bool CheckValid(int[] columns, int row1, int column1)
        {
            for (int row2 = 0; row2 < row1; row2++)
            {
                int column2 = columns[row2];
                //check queen on the same vertices
                if (column1 == column2)
                {
                    return false;
                }
                // check diagonal
                int columnDistance = Math.Abs(column2 - column1);
                int rowDistance = row1 - row2;

                if (columnDistance == rowDistance)
                {
                    return false;
                }
            }
            return true;
        }
    }
}