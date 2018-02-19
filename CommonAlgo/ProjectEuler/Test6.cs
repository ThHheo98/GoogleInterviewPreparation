using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    public class Test6
    {
        [TestCase(10, Result = 2640, TestName = "test1")]
        [TestCase(100, Result = 25164150, TestName = "test2")]
        public int Test(int n)
        {
            int sq_of_sum = n*(n + 1)/2;
            sq_of_sum *= sq_of_sum;
            int sum_of_sq = n*(n + 1)*(2*n + 1)/6;
            return (sq_of_sum - sum_of_sq);
        }
    }
}