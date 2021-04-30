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
            // [7,1,5,3,6,4]
            // 1. from left to right which is the lowest number.
            // 2. save position of lowest number.
            // 3. from right to left which is the biggest number.

            int lowestIndex = -1;
            int lowestValue = int.MaxValue;
            // Find from left to right which is the lowest number.
            for (int i = 0; i < prices.Length; i++)
            {
                int todayPrice = prices[i];

                if (todayPrice < lowestValue)
                {
                    lowestIndex = i;
                    lowestValue = todayPrice;
                }
            }

            // If the lowest is en the tail of the array.
            // then we dont have a possible solution.
            if (lowestIndex == prices.Length - 1)
            {
                return 0;
            }

            int biggestIndex = -1;
            int biggestValue = -1;
            // find from right to left which is the biggest number.
            for (int i = prices.Length - 1; i > lowestIndex; i--)
            {
                int todayPrice = prices[i];

                if (todayPrice > lowestValue && todayPrice > biggestValue)
                {
                    biggestIndex = i;
                    biggestValue = todayPrice;
                }
            }

            if (biggestValue == -1)
            {
                return 0;
            }

            return biggestValue - lowestValue;
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
            int[] prices = new int[] { 2, 4, 1 };


            var stock = new Solution();
            int result = stock.MaxProfit(prices);
            Console.WriteLine($"Result: {result}");
            Console.Read();

        }
    }
}
