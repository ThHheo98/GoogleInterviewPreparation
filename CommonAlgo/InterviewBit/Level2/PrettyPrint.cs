using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Level2
{
    public class PrettyPrint
    {
        //https://www.interviewbit.com/problems/prettyprint/

        [TestCase(3), TestCase(4)]
        public void prettyPrint(int n)
        {
            var r = new List<List<int>>();

            var size = 2 * n - 1;
            for (var i = 0;
                i < size;
                i++)
            {
                var row = new List<int>();
                for (var j = 0;
                    j < size;
                    j++)
                    row.Add(0);

                r.Add(row);
            }

            // here we have a matrix of zeroes

            var val = n;

            var a = 0;
            var b = size - 1;

            var d = 0;
            var c = size - 1;
            var dir = 0;

            while (b - a >= 0 && c - d >= 0)
            {
                if (dir == 0)
                {
                    for (var j = a;
                        j <= b;
                        j++)
                        r[a][j] = val;

                    a = a + 1;
                    dir = 1;
                }
                else if (dir == 1)
                {
                    for (var i = a;
                        i <= c;
                        i++)
                        r[i][b] = val;
                    b = b - 1;
                    dir = 2;
                }
                else if (dir == 2)
                {
                    for (var j = b;
                        j >= d;
                        j--)
                        r[c][j] = val;
                    c = c - 1;
                    dir = 3;
                }
                else if (dir == 3)
                {
                    for (var i = c;
                        i >= a;
                        i--)
                        r[i][d] = val;
                    d = d + 1;
                    dir = 0;
                    val = val - 1;
                }
            }

            Utils.PrintMatrix(r);
        }
    }
}
