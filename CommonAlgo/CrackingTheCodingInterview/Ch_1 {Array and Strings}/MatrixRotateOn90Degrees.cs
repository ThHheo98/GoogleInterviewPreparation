using System;
using NUnit.Framework;

// http://www.geeksforgeeks.org/turn-an-image-by-90-degree/

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class MatrixRotateOn90Degrees
    {
        private void PrintMatrix(int[,] matrix, int n, int m, string text)
        {
            Console.WriteLine(text);
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,5}", matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        [TestCase(10, TestName = "test1")]
        public void RotationTestPositive90(int n)
        {
            var matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = i*n + j;
                }
            }

            PrintMatrix(matrix, n, n, "Initial matrix");

            // Rotation on +90 degrees consists of two steps
            // 1. Transpose a matrix
            // 2. Reverse each row in transposed matrix

            // 1. transpose matrix in place
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int tmp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = tmp;
                }
            }

            // 2. reverse each row of transposed matrix
            for (int k = 0; k < n; k++)
            {
                for (int i = 0, j = n - 1; i < n/2; i++, j--)
                {
                    int t = matrix[k, i];
                    matrix[k, i] = matrix[k, j];
                    matrix[k, j] = t;
                }
            }

            PrintMatrix(matrix, n, n, "Rotated matrix on +90 degrees");
        }

        [TestCase(10, TestName = "test1")]
        public void RotationTestNeg90(int n)
        {
            var matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = i*n + j;
                }
            }

            PrintMatrix(matrix, n, n, "Initial matrix");

            // Rotation on +90 degrees consists of two steps
            // 1. Transpose a matrix
            // 2. Reverse each COLUMN in transposed matrix

            // 1. transpose matrix in place
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int tmp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = tmp;
                }
            }

            // 2. reverse each COLUMN of transposed matrix
            for (int k = 0; k < n; k++)
            {
                for (int i = 0, j = n - 1; i < n/2; i++, j--)
                {
                    int t = matrix[i, k];
                    matrix[i, k] = matrix[j, k];
                    matrix[j, k] = t;
                }
            }

            PrintMatrix(matrix, n, n, "Rotated matrix on -90 degrees");
        }
    }
}