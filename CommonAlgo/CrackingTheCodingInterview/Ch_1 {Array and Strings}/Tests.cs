using System;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Tests
    {
        [TestCase("ABC", Result = true, TestName = "test1")]
        [TestCase("ABCA", Result = false, TestName = "test2")]
        public bool Test11ASCII(string s) // string has all unique characters
        {
            //1 use dictionary, dirty solution
            //2 use array[256] ascii
            // ascing interviver about UNICODE AND ASCII

            //2
            if (s.Length > 256) return false;
            var array = new bool[256];
            for (byte i = 0; i < s.Length; i++)
            {
                if (array[i]) array[i] = true;
                else return false;
            }
            return true;
        }

        [TestCase("ABC", "ACB", Result = true, TestName = "test1")]
        [TestCase("HAROLD", "HARODL", Result = true, TestName = "test2")]
        [TestCase("HAROLD", "RODL", Result = false, TestName = "test3")]
        public bool Test13(string first, string second) // string has all unique characters
        {
            var chars = new int[256];
            for (int i = 0; i < first.Length; i++)
            {
                chars[first[i]]++;
            }
            for (int i = 0; i < second.Length; i++)
            {
                chars[second[i]]--;
            }
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != 0) return false;
            }
            return true;
        }

        // Test 13 см. в CrackingTheCodingInterview.cpp

        [TestCase("A B C    ", 5, ' ', "%20", Result = "A%20B%20C", TestName = "test1")]
        [TestCase("Mr John Smith    ", 13, ' ', "%20", Result = "Mr%20John%20Smith", TestName = "test2")]
        [TestCase("Mr John  Smith      ", 14, ' ', "%20", Result = "Mr%20John%20%20Smith", TestName = "test3")]
        [TestCase("Mr John Smit h      ", 14, ' ', "%20", Result = "Mr%20John%20Smit%20h", TestName = "test4")]
        public string Test14(string input, int trueLength, char oldChar, string newChars)
        {
            // решение плохое, требует N! на копирование в общем случае, зато не требует доп. памяти
            char[] chs = input.ToCharArray();

            int left = 0;
            int tl = trueLength;

            while (left < tl - 1 && tl < input.Length)
            {
                Console.WriteLine(chs);
                while (left < tl && chs[left] != oldChar)
                {
                    left++;
                }

                int pos = tl - 1;
                while (pos > left)
                {
                    char t = chs[pos + newChars.Length - 1];
                    chs[pos + newChars.Length - 1] = chs[pos];
                    chs[pos] = t;
                    pos--;
                }

                for (int i = 0; i < newChars.Length; i++)
                {
                    chs[left + i] = newChars[i];
                }
                Console.WriteLine(chs);
                left += newChars.Length;
                tl += newChars.Length - 1;
            }

            return new string(chs);
        }

        [TestCase("A B C    ", 5, ' ', "%20", Result = "A%20B%20C", TestName = "test1")]
        [TestCase("Mr John Smith    ", 13, ' ', "%20", Result = "Mr%20John%20Smith", TestName = "test2")]
        [TestCase("Mr John  Smith      ", 14, ' ', "%20", Result = "Mr%20John%20%20Smith", TestName = "test3")]
        [TestCase("Mr John Smit h      ", 14, ' ', "%20", Result = "Mr%20John%20Smit%20h", TestName = "test4")]
        public string Test14_1(string input, int trueLength, char oldChar, string newChars)
        {
            // решение за O(N) времени, O(n) памяти
            char[] chs = input.ToCharArray();
            int cnt = 0;
            for (int i = 0; i < trueLength; i++)
            {
                if (chs[i] == ' ')
                    cnt++;
            }

            int newLength = trueLength + (newChars.Length - 1)*cnt;
            var result = new char[newLength];

            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (chs[i] == ' ')
                {
                    result[newLength - 1] = '0';
                    result[newLength - 2] = '2';
                    result[newLength - 3] = '%';
                    newLength -= 3;
                }
                else
                {
                    result[newLength - 1] = chs[i];
                    newLength--;
                }
            }

            return new string(result);
        }

        [TestCase("aaabbccccc", Result = "a3b2c5", TestName = "test1")]
        [TestCase("a", Result = "a", TestName = "test2")]
        [TestCase("ab", Result = "ab", TestName = "test3")]
        public string Test15(string toCompress) // compress string
        {
            if (string.IsNullOrEmpty(toCompress)) return toCompress;
            if (toCompress.Length == 1) return toCompress;

            var result = new StringBuilder();
            char current = toCompress[0];
            int cnt = 1;
            for (int i = 1; i < toCompress.Length; i++)
            {
                if (toCompress[i] == current)
                {
                    cnt++;
                }
                else
                {
                    result.Append(current);
                    result.Append(cnt.ToString());
                    current = toCompress[i];
                    cnt = 1;
                }
            }

            result.Append(toCompress[toCompress.Length - 1]);
            result.Append(cnt);

            if (result.Length > toCompress.Length)
                return toCompress;
            return result.ToString();
        }

        [TestCase("aaabbccccc", Result = "a3b2c5", TestName = "test1")]
        [TestCase("a", Result = "a", TestName = "test2")]
        [TestCase("ab", Result = "ab", TestName = "test3")]
        public string Test15_1(string toCompress) // compress string
        {
            if (string.IsNullOrEmpty(toCompress)) return toCompress;
            if (toCompress.Length == 1) return toCompress;

            // check if compressed string would be greater than not compressed
            int symbolCnt = CountCompress(toCompress);
            if (symbolCnt > toCompress.Length)
                return toCompress;

            var result = new StringBuilder();
            char current = toCompress[0];
            int cnt = 1;
            for (int i = 1; i < toCompress.Length; i++)
            {
                if (toCompress[i] == current)
                {
                    cnt++;
                }
                else
                {
                    result.Append(current);
                    result.Append(cnt.ToString());
                    current = toCompress[i];
                    cnt = 1;
                }
            }

            result.Append(toCompress[toCompress.Length - 1]);
            result.Append(cnt);

            return result.ToString();
        }

        private int CountCompress(string toCompress)
        {
            char last = toCompress[0];
            int res = 0;
            int count = 1;
            for (int i = 1; i < toCompress.Length; i++)
            {
                if (toCompress[i] == last)
                {
                    count++;
                }
                else
                {
                    last = toCompress[i];
                    res += 1 + count.ToString().Length;
                    count = 0;
                }
            }
            res += 1 + count.ToString().Length;
            return res;
        }

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
        public void RotationTest16(int n)
            // Given an image represented by an NxN matrix, where each pixel in the image is
            // 4 bytes, write a method to rotate the image by 90 degrees. Can you do this in
            // place?
        {
            // Rotation on +90
            // 1. Transpose
            // 2. Reverse each row
            // Rotation on -90
            // 1. Transpose
            // 2. Reverse each column

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

        [TestCase("ASSA", "AASS", Result = true, TestName = "test1")]
        [TestCase("TEST", "TEDT", Result = false, TestName = "test2")]
        public bool Test18(string s, string isMaybeRotation) // is polindrom
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(isMaybeRotation)) return false;
            if (s.Length != isMaybeRotation.Length) return false;
            // work with spaces? 

            string isMaybeRotationTo = isMaybeRotation.ToUpperInvariant().Replace(" ", "");
            string originalString = s.ToUpperInvariant();
            return (isMaybeRotationTo + isMaybeRotationTo)
                .Contains(originalString);
        }
    }
}