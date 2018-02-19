using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.GoogleInternInterview2015
{
    /// <summary>
    ///     http://articles.leetcode.com/2010/11/finding-minimum-window-in-s-which.html
    ///     http://careercup.com/question?id=6326674964611072
    /// </summary>
    public class FindingTheMinimumWindowInSWhichContainsAllElementsFromT
    {
        /*
           Given a long string s and short strings t1, t2, t3 (which can have different length) 
           find the shortest substring of s which contains t1, t2 and t3
       */

        [TestCase]
        public void Test()
        {
            var text = "abbacaba";
            var p1 = "bb";
            var p2 = "baba";
            var p3 = "abb";

//            //Got distance of 12
//            var text = "00as0de00000as00bp1000de000bp000as000de120bp";
//            var p1 = "as";
//            var p2 = "bp1";
//            var p3 = "de";

            //Got distance of 4. 
            //		String text = "Mississippi";
            //		String p1 = "is";
            //		String p2 = "si";
            //		String p3 = "ssi";

            var vals = CalcSize(text, new[] {p1, p2, p3});

            Console.WriteLine("distance: " + vals.Item1 + ", min loc: " + vals.Item2 + ", max loc: " + vals.Item3);
        }

        private static Tuple<int, int, int> CalcSize(string text, string[] strings)
        {
            Tuple<int, int, int> r = null;

            var matchLocations = new List<int>(strings.Length);
            var listArrays = new List<int[]>();
            foreach (var s in strings)
            {
                var slowMatcher = SlowMatcher(text, s);
                listArrays.Add(slowMatcher);
            }
            var smallDist = int.MaxValue;

            for (var i = 0; i < text.Length; i++)
            {
                for (var index = 0; index < listArrays.Count; index++)
                {
                    var listArray = listArrays[index];
                    if (listArray[i] == 1)
                        matchLocations[index] = i;
                }
                if (matchLocations.TrueForAll(i1 => i1 != 0))
                {
                    var min1 = matchLocations.Min();
                    var max1 = int.MinValue;
                    for (var index = 0; index < listArrays.Count; index++)
                    {
                        var listArray = listArrays[index];

                        var i1 = matchLocations[index] + listArray.Length;
                        if (i1 > max1)
                            max1 = i1;
                    }
                    

                    var curDist = max1 - min1;
                    if (curDist > smallDist)
                    {
                        smallDist = curDist;
                        r = new Tuple<int, int, int>(smallDist, min1, max1);
                    }
                }
            }

            return r;
        }

        //O(nm): This can definitely be improved with KMP algorithm. 
        private static int[] SlowMatcher(string text, string pattern)
        {
            var ret = new int[text.Length];
            for (var i = 0; i < text.Length; i++)
            {
                var temp = text.Substring(i, pattern.Length);
                if (!temp.Equals(pattern, StringComparison.InvariantCultureIgnoreCase)) continue;
                ret[i] = 1;
                i = i + pattern.Length;
            }
            return ret;
        }
    }
}