using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Greedy
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/sum-of-fibonacci-numbers/
    /// </summary>
    /*
     Approach 1 :

lets take an exmaple:

N = 10
Fibonacci elements : 1 1 2 3 5 8 ... so on
Assume:
start vertex = 0
end vertex = 10

Lets do a Breadth First Search. 

we can go from 0 to 1 2 3 5 8 .... so on
So, there will be an edge of weight 1 from 0 to vertices 1, 2, 3, 5, 8 ( We don't care about vertices > 10 for this case ).

Then from 1 2 3 5 8 
we can go to 2 4 5 10  ( We do not go to 3 again, because its already visited ). 

Thus, we reach at 10 in only 2 step so our answer will be 2
How would this approach work for big numbers ?

Approach 2 :

ANSWER[N] = MIN ( ANSWER(N - FIB[I]) for I = 1 to X where FIB[X + 1] > N and FIB[X] <= N )

Does this approach work though if the numbers are really big ?

Approach 3 :

Greedy is the winner here. 
Because of how the fibonacci numbers behave, the approach of picking the largest number less than or equal to the number N works.

So, an approach like :

solve(N) : 
  find F as the largest Fib <= N. 
  return solve(N-F) + 1
Can you prove why greedy approach will work here ?
         */
    public class SumOfFibonachiNumbers
    {
        [Test]
        public void Test()
        {
            var sum = Fibsum(4);
            Assert.AreEqual(2, sum);
        }

        public static int Fibsum(int a)
        {
            var fib = new List<int> { 1, 1 };

            for (var i = 2;
                fib[i - 1] < a;
                ++i)
            {
                var data = fib[i - 1] + fib[i - 2];
                fib.Add(data);
            }

            var ans = 0;
            var index = fib.Count - 1;
            while (a > 0)
            {
                while (fib[index] > a)
                    index--;
                a -= fib[index];
                ans++;
            }
            return ans;
        }
    }
}
