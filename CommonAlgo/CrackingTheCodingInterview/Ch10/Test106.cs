using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch10
{
    public class Test106
    {
        [TestCase]
        public void Test()
        {
            const int n = 4;
            const int m = 4;
            var a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = new int[m];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i][j] = i*n + j;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("to find" + n + m);

            Assert.IsTrue(FineElem(a, n + m));
        }

        private bool FineElem(int[][] a, int toFind)
        {
            /*
                example of matrix
                10  20  30  40
                50  60  70  80
                51  62  71  81
                52  63  73  85              
             */
            int row = 0;
            int col = a[0].Length - 1; // height of matrix

            while (row < a.Length && col >= 0)
            {
                if (a[row][col] == toFind)
                {
                    return true;
                }

                if (toFind < a[row][col])
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            return false;
        }
    }

    public class Test106_1
    {
        [TestCase]
        public void Test()
        {
            const int n = 4;
            const int m = 4;
            var a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = new int[m];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i][j] = i*n + j;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("to find " + (n + m));

            Coordinate findElement = FindElement(a, new Coordinate(0, 0), new Coordinate(a.Length - 1, a[0].Length - 1),
                n + m);
            Assert.IsTrue(findElement !=
                          null);
            int i1 = a[findElement.row][findElement.column];
            Assert.IsTrue(i1 == n + m);
        }

        public Coordinate FindElement(int[][] matrix, Coordinate origin, Coordinate dest, int toFind)
        {
            if (!origin.InBounds(matrix) || !dest.InBounds(matrix))
            {
                return null;
            }
            if (matrix[origin.row][origin.column] == toFind)
            {
                return origin;
            }
            if (!origin.IsBefore(dest))
            {
                return null;
            }
            var start = (Coordinate) origin.Clone(); // начало диагонали
            int diagDist = Math.Min(dest.row - origin.row, dest.column - origin.column);
            // учтем, что матрица может быть не квадратная
            var end = new Coordinate(start.row + diagDist, start.column + diagDist); // конец диагонали

            var p = new Coordinate(0, 0);

            /*
             * Бинарный поиск по диагонали, ищем первый элемент больше, чем х
             */
            while (start.IsBefore(end))
            {
                p.SetToAverage(start, end);
                if (toFind > matrix[p.row][p.column])
                {
                    //сдвигаем начало диагонали вниз
                    start.row = p.row + 1;
                    start.column = p.column + 1;
                }
                else
                {
                    //сдвигаем конец диагонали вверх
                    end.row = end.row - 1;
                    end.column = end.column - 1;
                }
                // разделим матрицу на квадранты, ищем в нижнем левом и верхнем правом квадранте
            }
            return PartitionSearch(matrix, origin, dest, start, toFind);
        }

        private Coordinate PartitionSearch(int[][] matrix, Coordinate origin, Coordinate dest, Coordinate pivot,
            int toFind)
        {
            var lowerLeftOrigin = new Coordinate(pivot.row, origin.column);
            var lowerLeftDest = new Coordinate(dest.row, pivot.column - 1);
            var upperRightOrigin = new Coordinate(origin.row, pivot.column);
            var upperRightDest = new Coordinate(pivot.row - 1, dest.column);

            Coordinate lowerLeft = FindElement(matrix, lowerLeftOrigin, lowerLeftDest, toFind);
            if (lowerLeft == null)
            {
                return FindElement(matrix, upperRightOrigin, upperRightDest, toFind); // lowerRight ?
            }
            return lowerLeft;
        }
    }

    public class Coordinate : ICloneable
    {
        public int column;
        public int row;

        public Coordinate(int row, int column)
        {
            this.column = column;
            this.row = row;
        }

        public object Clone()
        {
            return new Coordinate(row, column);
        }

        public void SetToAverage(Coordinate min, Coordinate max)
        {
            row = (min.row + max.row)/2;
            column = (min.column + max.column)/2;
        }

        public bool IsBefore(Coordinate c)
        {
            return row <= c.row && column <= c.column;
        }

        /// <summary>
        ///     Проверяет, что координата находится внутри указанной матрицы
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public bool InBounds(int[][] matrix)
        {
            return row >= 0 && column >= 0
                   && row < matrix.Length && column < matrix[0].Length;
        }
    }
}