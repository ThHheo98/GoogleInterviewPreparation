using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Backtracking
{
    /// <summary>
    /// https://www.interviewbit.com/problems/kth-permutation-sequence/
    /// https://github.com/karajrish/InterviewBit/blob/master/Backtracking/kth%20permutation%20sequence/main.cpp
    /// http://www.programcreek.com/2013/02/leetcode-permutation-sequence-java/
    /// </summary>
    /*
     The set [1,2,3,…,n] contains a total of n! unique permutations.

By listing and labeling all of the permutations in order,
We get the following sequence (ie, for n = 3 ) :

1. "123"
2. "132"
3. "213"
4. "231"
5. "312"
6. "321"
Given n and k, return the kth permutation sequence.

For example, given n = 3, k = 4, ans = "231"

 Good questions to ask the interviewer :
What if n is greater than 10. How should multiple digit numbers be represented in string?
> In this case, just concatenate the number to the answer.
> so if n = 11, k = 1, ans = "1234567891011"
Whats the maximum value of n and k?
> In this case, k will be a positive integer thats less than INT_MAX.
> n is reasonable enough to make sure the answer does not bloat up a lot.
         
         */
    public class KthPermutationSequence
    {
        private int factorial(int n)
        {
            if (n > 12)
                return int.MaxValue;
            // Can also store these values. But this is just < 12 iteration, so meh!
            var fact = 1;
            for (var i = 2; i <= n; i++) fact *= i;
            return fact;
        }

        private string getPermutationn(int k, List<int> candidateSet)
        {
            var n = candidateSet.Count;
            if (n == 0)
                return "";
            if (k > factorial(n)) return ""; // invalid. Should never reach here.

            var f = factorial(n - 1);
            var pos = k / f;
            k %= f;
            var ch = candidateSet[pos].ToString();

            // BACKTRACKING!!!!!!!!!!!!!!
            // now remove the character ch from candidateSet. 
            candidateSet.RemoveAt(pos);
            var res = ch + getPermutationn(k, candidateSet);
            candidateSet.Insert(pos, int.Parse(ch));
            return res;
        }

        private string getPermutation(int n, int k)
        {
            var candidateSet = new List<int>();
            for (var i = 1; i <= n; i++) candidateSet.Add(i);
            return getPermutationn(k - 1, candidateSet);
        }

        [Test]
        public void Test()
        {
            var permutation = getPermutation(3, 4);
            Assert.AreEqual("231", permutation);
        }
    }
}
