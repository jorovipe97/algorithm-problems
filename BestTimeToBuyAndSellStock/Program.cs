using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTimeToBuyAndSellStock
{
    /// <summary>
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    /// You are given an array prices where prices[i] is the price of a given stock on the ith day.
    /// You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
    /// Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Brute force solution.
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            // [7, 1, 5, 3, 6, 4]
            // [7, 6, 4, 3, 1]
            // [2, 4, 1]
            // [3, 4, 2, 1]
            // [7, 5, 1, 3, 6, 4]
            // 1. Save all items on a map<profit>.
            // 2. 

            // the max profit will be obtained by getting the min number
            // that has the max diff ahead.

            // 1. Double pointer, at begining and end of array.
            // 2. Compute profit.
            // 3. if current profit is negative move right pointer one position to right.
            // 4. if current profit is positive move right pointer one position to right.

            int maxProfit = -1;
            // Fix first element (buy stock).
            for (int i = 0; i < prices.Length - 1; i++)
            {
                int buyPrice = prices[i];

                for (int j = i + 1; j < prices.Length; j++)
                {
                    int sellPrice = prices[j];
                    int profit = sellPrice - buyPrice;
                    // compare with remaining elements if there is a number greater
                    if (sellPrice > buyPrice && profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }

            //Console.WriteLine($"count: {count}");

            if (maxProfit <= 0)
            {
                return 0;
            }

            return maxProfit;
        }

        /// <summary>
        /// This solution doesn't work for all cases.
        /// See case where prices is:
        /// int[] prices = new int[] { 3, 3, 5, 0, 0, 3, 1, 4 };
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfitV2(int[] prices)
        {
            // [7, 1, 5, 3, 6, 4]
            // [7, 6, 4, 3, 1]
            // [2, 4, 1]
            // [3, 4, 2, 1]
            // [7, 5, 1, 3, 6, 4]
            // 1. Fix the first price as the buy price.
            // 2. Iterate all sell elements looking and save the one which returns the max profit.
            // 3. Fix the sell element which gave the max profit.
            // 4. Iterate all buy elements until the position of the sell element.
            if (prices.Length <= 1)
            {
                return 0;
            }

            int buyPrice = prices[0];
            int maxProfit = int.MinValue;
            // map<profit, sell indexes>
            // Can happen that multiple sell days has the same profit.
            var sellPriceIndexes = new Dictionary<int, List<int>>();
            // Iterate all sell elements looking and save the one which returns the max profit.
            for (int i = 1; i < prices.Length; i++)
            {
                int _sellPrice = prices[i];

                int profit = _sellPrice - buyPrice;
                if (profit >= maxProfit)
                {
                    // Add profit to map.
                    if (!sellPriceIndexes.ContainsKey(profit))
                    {
                        sellPriceIndexes.Add(profit, new List<int>() { i } );
                    }
                    else
                    {
                        sellPriceIndexes[profit].Add(i);
                    }

                    maxProfit = profit;
                }
            }
            
            // Iterate all the sell prices that generated the max profit.
            var sellPricesMaxProfit = sellPriceIndexes[maxProfit];
            maxProfit = int.MinValue;
            for (int i = 0; i < sellPricesMaxProfit.Count; i++)
            {
                int sellPriceIndex = sellPricesMaxProfit[i];
                int sellPrice = prices[sellPriceIndex];

                // Iterate all buy elements until the sellPriceIndex
                for (int j = 0; j < sellPriceIndex; j++)
                {
                    int _buyPrice = prices[j];
                    int profit = sellPrice - _buyPrice;
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }

            // If max profit wasn't initialized, return 0
            if (maxProfit <= 0)
            {
                return 0;
            }

            return maxProfit;
        }

        public int MaxProfitV3(int[] prices)
        {
            // [7, 1, 5, 3, 6, 4]
            // [7, 6, 4, 3, 1]
            // [2, 4, 1]
            // [3, 4, 2, 1]
            // [7, 5, 1, 3, 6, 4]
            // 1. Save all items on a map<profit>.
            // 2. 

            // the max profit will be obtained by getting the min number
            // that has the max diff ahead.

            // 1. Double pointer, at begining and end of array.
            // 2. Compute profit.
            // 3. if current profit is negative move right pointer one position to right.
            // 4. if current profit is positive move right pointer one position to right.

            // Optimization, if computed for a previously computed buyPrice
            // then continue to next buyPrice.

            // The value of this map is not used for nothing.
            var computedBuyPrices = new Dictionary<int, int>();

            int maxProfit = -1;
            // Fix first element (buy stock).
            for (int i = 0; i < prices.Length - 1; i++)
            {
                int buyPrice = prices[i];

                if (!computedBuyPrices.ContainsKey(buyPrice))
                {
                    computedBuyPrices.Add(buyPrice, 0);
                }
                else
                {
                    // Already computed for current buy price.
                    // move to next.
                    continue;
                }

                for (int j = i + 1; j < prices.Length; j++)
                {
                    int sellPrice = prices[j];
                    int profit = sellPrice - buyPrice;
                    // compare with remaining elements if there is a number greater
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }

            //Console.WriteLine($"count: {count}");

            if (maxProfit <= 0)
            {
                return 0;
            }

            return maxProfit;
        }

        /// <summary>
        /// After looking on a O(n) solution.
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfitV4(int[] prices)
        {
            int min = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }
                else if (prices[i] - min > maxProfit)
                {
                    maxProfit = prices[i] - min;
                }
            }

            return maxProfit;
        }
    }

    class Program
    {
        /// <summary>
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // expected 5
            //int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };

            // expected 0
            //int[] prices = new int[] { 7, 6, 4, 3, 1 };

            // expected 2
            //int[] prices = new int[] { 2, 4, 1 };

            // int[45156] Time Limit Exceeded: 5000ms.

            // expected 0
            //int[] prices = new int[] { 1 };

            // expected 2
            //int[] prices = new int[] { 2, 1, 2, 1, 0, 1, 2 };

            // expected 4
            int[] prices = new int[] { 3, 3, 5, 0, 0, 3, 1, 4 };


            var stock = new Solution();
            //int result = stock.MaxProfit(prices);
            int result = stock.MaxProfitV3(prices);
            Console.WriteLine($"Result: {result}");
            Console.Read();

        }
    }
}
