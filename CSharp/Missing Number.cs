//Source  : https://leetcode.com/problems/missing-number/
//Author  : Xinruo Shi
//Date    : 2019-06-09
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.
 * 
 * Note:
 * Your algorithm should run in linear runtime complexity. Could you implement it using only constant extra space complexity?
 * 
 * Input: nums = [3,0,1]
 * Output: 2
 * 
 * Input: nums = [9,6,4,2,3,5,7,0,1]
 * Output: 8
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution268
{
    // --------------- HashTable --------------- O(n) 128ms --------------- 34.3MB --------------- (24% 5%)
    public int MissingNumber_1(int[] nums)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length + 1; i++)
        {
            d.Add(i, 1);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            d.Remove(nums[i]);
        }

        foreach (var key in d.Keys)
        {
            return key;
        }
        return -1;
    }

    // --------------- O(n) 116ms --------------- 27.9MB --------------- (53% 15%)
    public int MissingNumber_2(int[] nums)
    {
        long sum = 0; long sum2 = 0;
        for (int i = 0; i < nums.Length + 1; i++)
        {
            sum += i;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            sum2 += nums[i];
        }

        return (int)(sum - sum2);
    }

    // --------------- Gauss' Formula --------------- O(n) 144ms --------------- 27.6MB --------------- (7% 25%)
    public int MissingNumber_2_2(int[] nums)
    {
        long sum = nums.Length * (nums.Length + 1) / 2;
        for (int i = 0; i < nums.Length; i++)
        {
            sum = sum - nums[i];
        }
        return (int)sum;
    }

    // --------------- Bit Manipulation --------------- O(n) 148ms --------------- 27.5MB --------------- (6% 38%) 
    public int MissingNumber_3(int[] nums)
    {
        int missing = nums.Length;

        for (int i = 0; i < nums.Length; i++)
            missing = missing ^ i ^ nums[i];

        return missing;
    }
    
    // --------------- O(n) 116ms --------------- 30MB --------------- (37% 32) ※
    public int MissingNumber_3_2(int[] nums)
    {
        int result = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            result ^= nums[i] ^ (i+1);
        }
        
        return result;
    }
}
/**************************************************************************************************************
 *  MissingNumber_2 / MissingNumber_3                                                                         *
 **************************************************************************************************************/
