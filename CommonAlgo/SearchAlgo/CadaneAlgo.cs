using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.SearchAlgo
{
    public class CadaneAlgo
    {
        class Result
        {
            public int Sum { get; set; }
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
        }

        [TestCase(new[] { 2, -2, -5, 2, 2, -1, 2, -3 }, 3, 6, Result = 5)]
        public decimal FindBestSubsequence1(int[] source, int startIdx, int endIdx)
        {
            var result = FindBestSubsequence(source);
            Assert.IsTrue(result.StartIndex == startIdx);
            Assert.IsTrue(result.EndIndex == endIdx);
            return result.Sum;
        }

        private static Result FindBestSubsequence(IList<int> source)
        {
            var r = new Result();
            int sum = 0;
            int tempStart = 0;

            for (int index = 0; index < source.Count; index++)
            {
                sum += source[index];
                if (sum > r.Sum)
                {
                    r.Sum = sum;
                    r.StartIndex = tempStart;
                    r.EndIndex = index;
                }
                if (sum < 0)
                {
                    sum = 0;
                    tempStart = index + 1;
                }
            }
            return r;
        }
    }
}