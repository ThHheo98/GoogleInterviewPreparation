using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.GoogleInternInterview2015
{
    /// <summary>
    ///     Dynamic programming, arrays
    ///     
    ///     http://www.geeksforgeeks.org/stock-Buy-Sell/
    ///     https://www.quora.com/Is-there-an-O-nlogn-algorithm-for-maximum-profit-from-buying-and-selling-stocks
    ///     http://articles.leetcode.com/2010/11/best-time-to-Buy-and-Sell-stock.html
    ///     https://www.hackerrank.com/challenges/stockmax
    ///     Say you have an array for which the ith element is the price of a given stock on day i.
    ///     If you were only permitted to Buy one share of the stock and Sell one share of the stock, design an algorithm to
    ///     find the best times to Buy and Sell.
    ///     Find i and j that maximizes Aj – Ai, where i < j.
    /// </summary>
    public class BestTimeToSellStock
    {
        public static void MaxProfit() // for R# search
        {
        }

        [TestCase]
        public void Test()
        {
            var a = new[] {100, 180, 260, 310, 40, 535, 695};
            var t = GetBestTime(a);
            var t1 = StockBuySell(a);
            Console.WriteLine(t.Item1);
            Console.WriteLine(t.Item2);

            Console.WriteLine();
            for (var i = 0; i < t1.Item2; i++)
            {
                Console.WriteLine(t1.Item1[i].Buy);
                Console.WriteLine(t1.Item1[i].Sell);
            }
        }


        /// <summary>
        /// To solve this problem efficiently, you would need to track the minimum value’s index. 
        /// As you traverse, update the minimum value’s index when a new minimum is met. 
        /// Then, compare the difference of the current element with the minimum value. 
        /// Save the buy and sell time when the difference exceeds our maximum difference (also update the maximum difference).
        /// </summary>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public Tuple<int, int> GetBestTime(int[] stocks)
        {
            var minIdx = 0;
            var maxDiff = 0;
            var buy = 0;
            var sell = 0;
            for (var i = 0; i < stocks.Length; i++)
            {
                if (stocks[i] < stocks[minIdx])
                    minIdx = i;
                var diff = stocks[i] - stocks[minIdx];
                if (diff > maxDiff)
                {
                    buy = minIdx;
                    sell = i;
                    maxDiff = diff;
                }
            }
            return new Tuple<int, int>(buy, sell);
        }

        // This function finds the Buy Sell schedule for maximum profit
        public Tuple<IList<Interval>, int> StockBuySell(int[] price)
        {
            var n = price.Length;
            // Prices must be given for at least two days
            if (n == 1)
                return new Tuple<IList<Interval>, int>(new List<Interval>(), 0);

            var count = 0; // count of solution pairs

            // solution vector
            var sol = new Interval[n/2 + 1];

            // Traverse through given price array
            var i = 0;
            while (i < n - 1)
            {
                // Find Local Minima. Note that the limit is (n-2) as we are
                // comparing present element to the next element. 
                while ((i < n - 1) && (price[i + 1] <= price[i]))
                    i++;

                // If we reached the end, break as no further solution possible
                if (i == n - 1)
                    break;

                // Store the index of minima
                sol[count].Buy = i++;

                // Find Local Maxima.  Note that the limit is (n-1) as we are
                // comparing to previous element
                while ((i < n) && (price[i] >= price[i - 1]))
                    i++;

                // Store the index of maxima
                sol[count].Sell = i - 1;

                // Increment count of Buy/Sell pairs
                count++;
            }
            return new Tuple<IList<Interval>, int>(sol, count);
        }

        // Program to find best buying and selling days
        // solution structure
        public struct Interval
        {
            public int Buy;
            public int Sell;
        }
    }


    public class TestSellBuy
    {
        [TestCase]
        public void Test11()
        {
            // a = new [] {3,1,4}
            // 1) price = 3
            /*
             prevBuy = int.MinValue
             buy = max(0 - 3,int.MinValue) = -3
             prevSell = 0
             sell = max(int.MinValue + 3, 0) = 0

            2) Price = 1
             prevBuy = -3
             buy = max(0 - 1,-3) = -1
             prevSell = 0
             sell = max(-3 + 1, 0) = -2
             3) Price = 4
             prevBuy = -1
             buy = max(0 - 4,-1) = -1
             prevSell = -2
             sell = max(-1 + 4, -2) = 2
            */
        }
        //http://www.careercup.com/question?id=5711211989565440
        public int MaxProfit(int[] prices)
        {
            int sell = 0;
            int prevSell = 0;
            int buy = int.MinValue;
            int prevBuy = 0;
            foreach (int price in prices)
            {
                prevBuy = buy;
                buy = Math.Max(prevSell - price, prevBuy);
                prevSell = sell;
                sell = Math.Max(prevBuy + price, prevSell);
            }
            return sell;
        }


        /// <summary>
        /// Kadane alghoritm
        /// https://leetcode.com/discuss/48378/kadanes-algorithm-since-mentioned-about-interviewer-twists
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int maxProfit(int[] prices)
        {
            int maxCur = 0, maxSoFar = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                maxCur = Math.Max(0, maxCur += prices[i] - prices[i - 1]);
                maxSoFar = Math.Max(maxCur, maxSoFar);
            }
            return maxSoFar;
        }

        [TestCase]
        public void Test()
        {
            var a = new[] { 10, 9, 12, 20, 1 };
            int buy;
            int sell;
            GetMaxProfit(a, out buy, out sell);
            System.Console.WriteLine(buy);
            System.Console.WriteLine(sell);
        }
        public static void GetMaxProfit(int[] a, out int buy, out int sell)
        {
            sell = 0;
            buy = 0;
            // need save index of min
            int minIdx = 0; // assume first element is min
                            // need save difference 
            int maxDiff = int.MinValue;
            //iterate over prices
            for (int i = 1; i < a.Length; i++)
            {
                // check min
                if (a[minIdx] > a[i])
                {
                    minIdx = i;

                }
                // find current difference of min element and current
                int diff = a[i] - a[minIdx];
                if (diff > maxDiff)
                {
                    buy = minIdx;
                    maxDiff = diff;
                    sell = i;
                }
            }
        }
    }


}