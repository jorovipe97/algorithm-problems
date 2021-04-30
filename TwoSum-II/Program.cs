using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum_II
{
    class Program
    {
        /// <summary>
        /// Given an array of integers numbers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
        /// Return the indices of the two numbers(1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.length.
        /// You may assume that each input would have exactly one solution and you may not use the same element twice.
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // https://leetcode.com/problems/two-sum/
            Console.WriteLine("Two Sums...");
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            int[] result1 = TwoSum(nums, target);
            int[] result2 = TwoSumTwoPointer(nums, target);
            Console.ReadLine();
        }

        /// <summary>
        /// Brute force solution.
        /// O(n^2)
        /// 
        /// This solution is not considered correct for this problem, since
        /// it's too slow compared to solutions by other people on leetcode.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static public int[] TwoSum(int[] numbers, int target)
        {

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int sum = numbers[i] + numbers[j];

                    if (sum == target)
                    {
                        return new int[] { i + 1, j + 1 };
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Two pointer solution.
        /// O(n), or even O(1) in the best case.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static public int[] TwoSumTwoPointer(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length - 1;

            // Are we lucky?
            int sum = numbers[l] + numbers[r];
            if (sum == target)
            {
                return new int[] { l + 1, r + 1 };
            }

            while (sum != target && l < r)
            {
                sum = numbers[l] + numbers[r];

                if (sum > target)
                {
                    // This decreases the sum, because the array is sorted.
                    r--;
                }
                else if (sum < target)
                {
                    // This increases the sum, because the array is sorted.
                    l++;
                }
                else
                {
                    // If reach here, then, the sum is equals to the target.
                    return new int[] { l + 1, r + 1 };
                }
            }

            return null;
        }


    }
}
