using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    public class Result
    {
        public int hits;
        public int pseudoHits;

        #region Overrides of Object

        public override string ToString()
        {
            return "(" + hits + ", " + pseudoHits + ")";
        }

        #endregion
    }


    /// <summary>
    ///     Гениальный отгадчик
    /// </summary>
    public class Test175
    {
        private const int MAX_COLORS = 4;

        [TestCase("RGBY", "GGRR", 1, 1)]
        public void Test(string solution, string guess, int hits, int pseudo)
        {
            Result estimate = Estimate(guess, solution);
            Assert.IsTrue(estimate.hits == hits);
            Assert.IsTrue(estimate.pseudoHits == pseudo);
        }

        private int Code(char c)
        {
            switch (char.ToUpper(c))
            {
                case 'B':
                    return 0;
                case 'G':
                    return 1;
                case 'R':
                    return 2;
                case 'Y':
                    return 3;
                default:
                    return -1;
            }
        }

        public Result Estimate(string guess, string solution)
        {
            if (guess.Length != solution.Length) return null;
            var res = new Result();
            var freq = new int[MAX_COLORS];
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == solution[i])
                    res.hits++;
                else
                {
                    int code = Code(solution[i]);
                    freq[i]++;
                }
            }
            for (int i = 0; i < guess.Length; i++)
            {
                int code = Code(guess[i]);
                if (code >= 0 && freq[code] > 0)
                {
                    res.pseudoHits++;
                    freq[code]--;
                }
            }
            return res;
        }
    }
}