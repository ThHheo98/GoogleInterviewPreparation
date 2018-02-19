using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.GoogleInternInterview2015
{
    /// <summary>
    ///     http://www.careercup.com/question?id=6285685721923584
    /// </summary>
    public class MinimizeOverlapedOrConsecutiveRegions
    {
        public static IList<Interval> MinimizeGaps(IList<Interval> list)
        {
            if (list == null)
                throw new ArgumentNullException("list")
                    ;
            if (list.Count <= 1) return list;

            var res = new List<Interval>();

            // sort these intervals by left value
//	Can I use .NET sorting methods?
//  [4, 8], [3, 5], [-1 2], [10, 12]
            var ordered = list.OrderBy(i => i.x).ToList();
//  [-1 2], [3, 5], [4, 8], [10, 12]

// minimize overlapping or consecutive
// [a,b] [c,d] b > c - overlapping
// [a,b] [c,d] b = c - consecutive
// skip these
            var lastJoined = 0;
            res.Add(ordered[lastJoined]);
            for (var k = 1; k < ordered.Count; k++)
            {
                if (ordered[lastJoined].y >= ordered[k].x - 1) // Consecutive
                {
                    res[lastJoined].y = ordered[k].y; // join interval
                }
                else if (ordered[lastJoined].x == ordered[k].x && ordered[lastJoined].y <= ordered[k].y) // overlaped
                {
                    res[lastJoined].y = ordered[k].y; // join interval
                }
                else
                {
                    res.Add(ordered[k]);
                    lastJoined++;
                }
            }
            return res;
        }
    }

    [TestFixture]
    public class Test
    {
        [TestCase]
        public void TestMethod()
        {
            IList<Interval> intervals = new List<Interval>();
            intervals.Add(new Interval(4, 8));
            intervals.Add(new Interval(3, 5));
            intervals.Add(new Interval(-1, 2));
            intervals.Add(new Interval(10, 12));
            var minimizeGaps = MinimizeOverlapedOrConsecutiveRegions.MinimizeGaps(intervals);
            Console.WriteLine(minimizeGaps.Count);
            Assert.IsTrue(minimizeGaps.Count == 2);
            Console.WriteLine(minimizeGaps[0]);
            Console.WriteLine(minimizeGaps[1]);
            intervals = new List<Interval>();
            intervals.Add(new Interval(1, 4));
            intervals.Add(new Interval(1, 5));
            minimizeGaps = MinimizeOverlapedOrConsecutiveRegions.MinimizeGaps(intervals);
            Assert.IsTrue(minimizeGaps.Count == 1);
            Console.WriteLine(minimizeGaps[0]);
        }
    }

    public class Interval
    {
        private readonly int _x;
        private int _y;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public Interval(int x, int y)
        {
            _y = y;
            _x = x;
        }

        public int y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int x
        {
            get { return _x; }
            set { _y = value; }
        }

        #region Overrides of Object

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return "[" + x + ", " + y + "]";
        }

        #endregion
    }
}