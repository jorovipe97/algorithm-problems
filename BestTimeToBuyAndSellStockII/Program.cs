using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTimeToBuyAndSellStockII
{

    /// <summary>
    /// Explanation of thecniques
    /// https://medium.com/@punitkmr/best-time-to-buy-and-sell-stock-ii-7826845144eb
    /// </summary>
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            // The min is like the buy price.
            int min = int.MaxValue;
            int totalOperationProfit = 0;
            int lastOperationProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {

                // Do we found a new min?
                if (prices[i] < min)
                {
                    // and are we still on an operation?
                    if (lastOperationProfit > 0)
                    {
                        // Reset sell variables.
                        lastOperationProfit = 0;
                    }

                    min = prices[i];
                }
                // Is the operation profit bigger than last profit?
                else if (prices[i] - min > lastOperationProfit)
                {
                    // Save profits.
                    // Remove profits generated if we would have sold on previous day.
                    totalOperationProfit -= lastOperationProfit;
                    lastOperationProfit = prices[i] - min;
                    // Add profits generated if we would have sold today.
                    totalOperationProfit += lastOperationProfit;
                }
                // if this profit is not bigger than the one in last operation.
                // sell, and start buying again.
                else
                {
                    // Reset buy/sell variables.
                    lastOperationProfit = 0;
                    min = prices[i];
                }

            }

            return totalOperationProfit;
        }




        public int MaxProfitV2(int[] prices)
        {

            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxProfit += prices[i] - prices[i - 1];
            }

            return maxProfit;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
            // Then buy on day 4(price = 3) and sell on day 5(price = 6), profit = 6 - 3 = 3.
            // expected 7
            //int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };

            // expected 4
            //int[] prices = new int[] { 1, 2, 3, 4, 5 };

            // expected 0
            //int[] prices = new int[] { 7, 6, 4, 3, 1 };

            // expected 7
            //int[] prices = new int[] { 6, 1, 3, 2, 4, 7 };

            // expected 2
            //int[] prices = new int[] { 2, 1, 2, 0, 1 };



            var stock = new Solution();
            //int result = stock.MaxProfit(prices);
            int result = stock.MaxProfit(prices);
            Console.WriteLine($"Result: {result}");
            Console.Read();
        }
    }
}
