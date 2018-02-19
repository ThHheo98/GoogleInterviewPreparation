using System;
using NUnit.Framework;

// http://www.geeksforgeeks.org/a-boolean-matrix-question/

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class TestClassBooleanMartixQuestion
    {
        public void PrintMatrix<T>(T[,] a, int n, int m, string text = "")
        {
            Console.WriteLine(text);
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0, 5} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }

        [TestCase(6, 5)]
        public void TestCase17(int n, int m)
        {
            // time complexity = O(n*m)
            // Space: O(1)

            var a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = i*n + j + 1;
                    if (a[i, j] == 25)
                    {
                        a[i, j] = 0;
                    }
                    if (a[i, j] == 17)
                    {
                        a[i, j] = 0;
                    }
                }
            }

            PrintMatrix(a, n, m, "Initial matrix");

            bool hasRowFlag = false;
            bool hasColFlag = false;

            // we should know if we need fill the first row and the first column in array
            for (int i = 0; i < m; i++)
            {
                if (a[0, i] == 0)
                {
                    hasRowFlag = true;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (a[i, 0] == 0)
                {
                    hasColFlag = true;
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (a[i, j] == 0)
                    {
                        a[0, j] = 0;
                        a[i, 0] = 0;
                    }
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (a[i, 0] == 0 || a[0, j] == 0)
                    {
                        a[i, j] = 0;
                    }
                }
            }

            if (hasRowFlag)
            {
                for (int j = 0; j < m; j++) a[0, j] = 0;
            }

            if (hasColFlag)
            {
                for (int i = 0; i < n; i++) a[i, 0] = 0;
            }

            PrintMatrix(a, n, m, "Changed matrix");
        }
    }
}