//Pots of gold game
// http://stackoverflow.com/questions/22195300/understanding-solution-to-finding-optimal-strategy-for-game-involving-picking-po
// http://www.dsalgo.com/2013/02/gold-coins-in-pots-game.html
// classic dynamic programming
/*
 Problem
 * Some pots filled with gold coins and arranged in a line. 
 * There are different number of gold coins in different pots. 
 * The number is mentioned on each of the pots. 
 * Two players will take turn alternatively. 
 * In each turn a player can pick any one the two pots at the two ends of the line. 
 * Find the winning strategy for a player getting chance to play first, assuming the opponent player is also playing optimally. 
 * How many coins will the first player get if he plays optimally?
 */

//It classic task of dynamic programming
// We can use recursive algo and memoization techics

using System;
using System.Collections.Generic;
using NUnit.Framework;

//It classic task of dynamic programming
// We can use recursive algo and memoization techics
// O(n^2)
namespace CommonAlgo.GoogleInternInterview2015
{
    public class PostOfCoin
    {
        private static readonly int _notFilled = int.MaxValue;

        public static int GetMaxCoins(IList<int> pots)
        {
            if (pots == null) throw new ArgumentNullException("pots");

            var memo = new int[pots.Count, pots.Count];
            for (var i = 0; i < pots.Count; i++)
                for (var j = 0; j < pots.Count; j++)
                {
                    memo[i, j] = _notFilled;
                }
            var r = GetMax(pots, 0, pots.Count - 1, memo);
            return r;
        }

        private static int GetMax(IList<int> pots, int start, int finish, int[,] memo)
        {
            if (start > finish) return 0;
            if (memo[start, finish] != _notFilled)
            {
                return memo[start, finish];
            }
            var startCoins = pots[start] +
                             Math.Min(GetMax(pots, start + 2, finish, memo), GetMax(pots, start + 1, finish - 1, memo));
            var finishCoins = pots[finish] +
                              Math.Min(GetMax(pots, start, finish - 2, memo), GetMax(pots, start + 1, finish - 1, memo));
            memo[start, finish] = Math.Max(startCoins, finishCoins);
            return memo[start, finish];
        }

        [TestCase]
        public void Test()
        {
            var pots = new List<int> {12, 32, 4, 23, 6, 42, 16, 3, 85, 23, 4, 7, 3, 5, 45, 34, 2, 1};
            var max = GetMaxCoins(pots);
            Console.WriteLine(max);
        }
    }
}