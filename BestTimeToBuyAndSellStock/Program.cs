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
        public int MaxProfit(int[] prices)
        {
            // [7, 1, 5, 3, 6, 4]
            // [7, 6, 4, 3, 1]
            // [2, 4, 1]
            // 1. Double pointer, at begining and end of array.
            // 2. Compute profit.
            // 3. if current profit is negative move right pointer one position to right.
            // 4. if current profit is positive move right pointer one position to right.

            int maxProfit = -1;
            int l = 0;
            int r = prices.Length - 1;
            // Fix first element (buy stock).
            for (int i = 0; i < prices.Length - 1; i++)
            {
                int buyPrice = prices[i];

                for (int j = i + 1; j < prices.Length; j++)
                {
                    int sellPrice = prices[j];

                    int profit = sellPrice - buyPrice;
                    // compare with remaining elements if there is a number greater
                    if (sellPrice > buyPrice && profit > 0 && profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }

            if (maxProfit == -1)
            {
                return 0;
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
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };

            // expected 0
            //int[] prices = new int[] { 7, 6, 4, 3, 1 };

            // expected 2
            //int[] prices = new int[] { 2, 4, 1 };

            // int[45156] Time Limit Exceeded: 5000ms.


            var stock = new Solution();
            int result = stock.MaxProfit(prices);
            Console.WriteLine($"Result: {result}");
            Console.Read();

        }
    }
}
