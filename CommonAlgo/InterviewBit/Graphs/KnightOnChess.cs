using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Graphs
{
    public class KnightOnChess
    {
        private class Solution
        {
            private readonly int[] cols = { -1, 1, 2, 2, 1, -1, -2, -2 };

            private readonly int[] rows = { -2, -2, -1, 1, 2, 2, 1, -1 };

            private bool IsValidMove(Point p, int n, int m)
            {
                return p.x >= 1 && p.x <= n && p.y >= 1 && p.y <= m;
            }

            [TestCase(8, 8, 1, 1, 8, 8, Result = 6)]
            public int Knight(int n, int m, int x1, int y1, int x2, int y2)
            {
                var ans = 0;

                var q = new Queue<Point>();
                var startNode = new Point(x1, y1);
                var finishNode = new Point(x2, y2);
                q.Enqueue(startNode);
                q.Enqueue(null); // to mark next move

                var was = new HashSet<Point>();
                was.Add(startNode);

                while (q.Count > 0)
                {
                    var top = q.Dequeue();

                    if (top == null)
                    {
                        if (q.Count > 0)
                        {
                            ans++; // next move
                            q.Enqueue(null);
                        }
                        continue;
                    }

                    if (top.x == finishNode.x && top.y == finishNode.y)
                        return ans;

                    // iterate over moves
                    for (var k = 0;
                        k < 8;
                        k++)
                    {
                        var pt = new Point(top.x + rows[k], top.y + cols[k]);
                        if (IsValidMove(pt, n, m) && !was.Contains(pt))
                        {
                            q.Enqueue(pt);
                            was.Add(pt);
                        }
                    }
                }
                return -1;
            }

            private class Point
            {
                public readonly int x;
                public readonly int y;

                public Point(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }

                #region Equality members

                protected bool Equals(Point other)
                {
                    return x == other.x && y == other.y;
                }

                public override bool Equals(object obj)
                {
                    if (ReferenceEquals(null, obj))
                        return false;
                    if (ReferenceEquals(this, obj))
                        return true;
                    if (obj.GetType() != GetType())
                        return false;
                    return Equals((Point)obj);
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
}
