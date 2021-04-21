using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://leetcode.com/problems/two-sum/
            Console.WriteLine("Two Sums...");
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            int[] result1 = TwoSum(nums, target);
            int[] result2 = TwoSumHashMap(nums, target);

            result1.ToString();
            result2.ToString();
            Console.ReadLine();
        }

        static public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { };
        }

        static public int[] TwoSumHashMap(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { i, map[complement] };
                }
                map.Add(nums[i], i);
            }

            return null;
        }
    }
}
