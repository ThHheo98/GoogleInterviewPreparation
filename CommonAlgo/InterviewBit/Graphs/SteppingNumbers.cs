using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Graphs
{
    public class Point
    {
        public int x;
        public int y;

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
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return x * 397 ^ y;
            }
        }

        public static bool operator ==(Point left, Point right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !Equals(left, right);
        }

        #endregion
    }

    /// <summary>
    ///     http://www.geeksforgeeks.org/stepping-numbers/
    /// </summary>
    public class SolutionRight
    {
        // Prints all stepping numbers reachable from num
        // and in range [n, m]
        private static void Bfs(int n, int m, int num, List<int> res)
        {
            // Queue will contain all the stepping Numbers
            var q = new Queue<int>();

            q.Enqueue(num);

            while (q.Count > 0)
            {
                // Get the front element and pop from
                // the queue
                var stepNum = q.Dequeue();

                // If the Stepping Number is in
                // the range [n,m] then display
                if (stepNum <= m && stepNum >= n)
                    res.Add(stepNum);

                // If Stepping Number is 0 or greater
                // then m ,need to explore the neighbors
                if (stepNum == 0 || stepNum > m)
                    continue;

                // Get the last digit of the currently
                // visited Stepping Number
                var lastDigit = stepNum % 10;

                // There can be 2 cases either digit
                // to be appended is lastDigit + 1 or
                // lastDigit - 1
                var stepNumA = stepNum * 10 + (lastDigit - 1);
                var stepNumB = stepNum * 10 + lastDigit + 1;

                // If lastDigit is 0 then only possible
                // digit after 0 can be 1 for a Stepping
                // Number
                if (lastDigit == 0)
                {
                    q.Enqueue(stepNumB);
                }
                // If lastDigit is 9 then only possible
                // digit after 9 can be 8 for a Stepping
                // Number
                else if (lastDigit == 9)
                {
                    q.Enqueue(stepNumA);
                }
                else
                {
                    q.Enqueue(stepNumA);
                    q.Enqueue(stepNumB);
                }
            }
        }

        [TestCase(10, 20)]
        public void Stepnum(int a, int b)
        {
            var res = new List<int>();
            for (var i = 0;
                i <= 9;
                i++)
                Bfs(a, b, i, res);

            res = res.OrderBy(i => i).ToList();
            Utils.PrintCollection(res);
        }
    }

    /// <summary>
    ///     My solution TLE
    ///     it is bruteforce with using of BFS
    /// </summary>
    internal class Solution
    {
        private int GetLength(int a)
        {
            if (a < 10)
                return 1;

            var numLen = 0;

            while (a > 0)
            {
                numLen++;
                a = a / 10;
            }

            return numLen;
        }

        private int getDigit(int number, int pos)
        {
            return pos == 0 ? number % 10 : getDigit(number / 10, --pos);
        }

        private bool IsAdj(int a)
        {
            var numLen = GetLength(a);
            if (numLen == 1)
                return true;

            for (var i = 1;
                i < numLen;
                i++)
            {
                var d1 = getDigit(a, i - 1);
                var d2 = getDigit(a, i);
                if (Math.Abs(d1 - d2) != 1)
                    return false;
            }

            return true;
        }

        [TestCase(10, 20)]
        public void Stepnum(int a, int b)
        {
            var res = new List<int>();

            var queue = new Queue<int>();
            queue.Enqueue(a);

            while (queue.Count > 0)
            {
                var enq = queue.Dequeue();

                if (enq > b)
                {
                    Utils.PrintCollection(res);
                    return;
                }

                if (IsAdj(enq))
                    res.Add(enq);
                queue.Enqueue(enq + 1);
            }

            Utils.PrintCollection(res);
        }
    }
}
