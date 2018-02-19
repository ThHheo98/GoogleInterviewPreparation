using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/points-on-the-straight-line/
    ///     https://github.com/nagajyothi/InterviewBit/blob/master/Hashing/Points.java
    ///     http://qa.geeksforgeeks.org/3911/find-the-maximum-number-points-that-lie-the-same-straight-line
    ///     http://www.programcreek.com/2014/04/leetcode-max-points-on-a-line-java/
    /// </summary>
    /*
     Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.

Sample Input :

(1, 1)
(2, 2)
Sample Output :

2
You will be give 2 arrays X and Y. Each point is represented by (X[i], Y[i])

        A line is made by a pair of points. 
If a,b and c lie on the same line, then line connecting a and b, and line connecting a and c will have the same slope ( (y2 - y1) / (x2 - x1)).

Make sure you handle all the corner cases.
Corner cases :

1) Have you handled overlapping points ? 
2) Have you handled negative points for the same slope ? Like (0,0), (1,1) and (-1, -1)
3) Did you make sure that there are no divisions by 0 ? Like (1, 0), (1,4), (1, -1) 
4) How do you handle when one of the differences in x and y is 0, and the other difference is negative / positive ? Like (4, -4), (8, -4), (-4, -4)
         */
    public class PointOnTheStraingtLine
    {
        [Test]
        public void Test()
        {
            var X = new List<int>();
            var Y = new List<int>();

            X.Add(0);
            Y.Add(0);
            X.Add(1);
            Y.Add(1);
            X.Add(-1);
            Y.Add(-1);
            var i = MaxPoints(X, Y);

            Assert.AreEqual(3, i);
        }

        private int gcd(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            if (a < 0) return gcd(-1 * a, b);
            if (b < 0) return gcd(a, -1 * b);
            if (a > b) return gcd(b, a);
            return gcd(b % a, a);
        }

        private int MaxPoints(IReadOnlyList<int> x, IReadOnlyList<int> y)
        {
            var dictionary = new Dictionary<Pair, int>();
            var ans = 0;

            for (var i = 0; i < x.Count; i++)
            {
                dictionary.Clear();
                int same = 1, curMax = 0;

                // Try to find all the lines with same slope with points[i] as one end.
                // Points with the same slope lie on the same line.
                // We need to make sure we handle divisions by zero in cases like these.
                // We also need to take care of overlapping points.
                for (var j = i + 1; j < x.Count; j++)
                {
                    var xdiff = x[i] - x[j];
                    var ydiff = y[i] - y[j];
                    if (xdiff == 0 && ydiff == 0)
                    {
                        // Same points
                        same++;
                        continue;
                    }

                    if (xdiff < 0)
                    {
                        xdiff = -xdiff;
                        ydiff = -ydiff;
                    }

                    var g = gcd(xdiff, ydiff);

                    var p = MakePair(xdiff / g, ydiff / g);

                    if (!dictionary.ContainsKey(p))
                        dictionary[p] = 0;

                    dictionary[p]++;

                    curMax = Math.Max(curMax, dictionary[p]);
                }

                curMax += same;
                ans = Math.Max(ans, curMax);
            }
            return ans;
        }

        private static Pair MakePair(int i, int i1)
        {
            var p = new Pair
            {
                x = i,
                y = i1
            };
            return p;
        }

        private class Pair
        {
            public int x;
            public int y;

            #region Equality members

            protected bool Equals(Pair other)
            {
                return x == other.x && y == other.y;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Pair)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return x * 397 ^ y;
                }
            }

            #endregion
        }
    }
}
