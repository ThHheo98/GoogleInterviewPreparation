using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     It's classical staircase with n steps problem
    /// </summary>
    public class Test91
    {
        [TestCase(3, Result = 3, TestName = "test1")]
        [TestCase(4, Result = 5, TestName = "test2")]
        [TestCase(5, Result = 8, TestName = "test3")]
        [TestCase(6, Result = 13, TestName = "test4")]
        public int Test(long n)
        {
            int countVariants = CountVariantsWith2Steps_Fibonacci(n);
            return countVariants;
        }

        private int CountVariantsWith2Steps_Fibonacci(long n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            return CountVariantsWith2Steps_Fibonacci(n - 1) + CountVariantsWith2Steps_Fibonacci(n - 2);
        }


        /// <summary>
        ///     Task from Lakman book
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [TestCase(3, Result = 4, TestName = "test1")]
        [TestCase(4, Result = 7, TestName = "test2")]
        [TestCase(5, Result = 13, TestName = "test3")]
        [TestCase(6, Result = 24, TestName = "test4")]
        public int Test91_a(long n)
        {
            return CountVariantsWith3Steps(n);
        }

        private int CountVariantsWith3Steps(long n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            return CountVariantsWith3Steps(n - 1) + CountVariantsWith3Steps(n - 2) + CountVariantsWith3Steps(n - 3);
        }

        /// <summary>
        ///     Version with dynamic programming
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [TestCase(3, Result = 4, TestName = "test1")]
        [TestCase(4, Result = 7, TestName = "test2")]
        [TestCase(5, Result = 13, TestName = "test3")]
        [TestCase(6, Result = 24, TestName = "test4")]
        public long TestDP(long n)
        {
            var map = new long[n*n];
            for (int i = 0; i < n*n; i++)
            {
                map[i] = -1;
            }
            long countVariants = CountVariantsDP(n, map);
            return countVariants;
        }

        private long CountVariantsDP(long n, long[] map)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            if (map[n] > -1) return map[n];
            map[n] = CountVariantsDP(n - 1, map) + CountVariantsDP(n - 2, map) + CountVariantsDP(n - 3, map);
            return map[n];
        }

        /*
         Given a staircase with N steps, you can go up with 1 or 2 steps each time. Output all possible way you go from bottom to top.
         * 
         * void steps(n, alreadyTakenSteps) {
    if (n == 0) {
        print already taken steps
    }
    if (n >= 1) {
        steps(n - 1, alreadyTakenSteps.append(1));
    }
    if (n >= 2) {
        steps(n - 2, alreadyTakenSteps.append(2));
    }
}
         */
    }
}