//Source  : https://leetcode.com/problems/array-partition-i/
//Author  : Xinruo Shi
//Date    : 2019-06-16
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of 2n integers, your task is to group these integers into n pairs of integer, 
 * say (a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.
 * 
 * Note:
 * n is a positive integer, which is in the range of [1, 10000].
 * All the integers in the array will be in the range of [-10000, 10000].
 * 
 * Input: nums = [1,4,3,2]
 * Output: 4
 * Explanation: n is 2, and the maximum sum of pairs is 4 = min(1, 2) + min(3, 4).
 * 
 *******************************************************************************************************************************/

using System;

public class Solution561
{
    // --------------- max[ O(n), O(Sort) ] 180ms --------------- 33.1MB --------------- (27% 21%)
    /*
     * use Array.Sort 
     */
    public int ArrayPairSum_1(int[] nums)
    {
        Array.Sort(nums);

        int sum = 0;
        for (int i = 0; i < nums.Length; i += 2)
        {
            sum += nums[i];
        }

        return sum;
    }

    // --------------- O(n) 164ms --------------- 39.7MB --------------- (64% 5%)
    public int ArrarPairSum_2(int[] nums)
    {
        int[] n = new int[20001];
        for (int i = 0; i < nums.Length; i++)
        {
            n[nums[i] + 10000]++;
        }

        int sum = 0;
        bool flag = true;
        for (int i = 0; i < n.Length; i++)
        {
            while (n[i] > 0)
            {
                if (flag)
                {
                    sum += i - 10000;
                }
                flag = !flag;
                n[i]--;
            }
        }

        return sum;
    }

    // --------------- O(n) 144ms --------------- 37MB --------------- (98% 6%) 
    /*
     * cannot understand ??????????
     */
    public int ArrarPairSum_3(int[] nums)
    {
        int min = int.MaxValue, max = int.MinValue;

        for (int i = 0; i < nums.Length; i++)
        {
            min = nums[i] < min ? nums[i] : min;
            max = nums[i] > max ? nums[i] : max;
        }

        int[] counts = new int[max - min + 1];

        for (int i = 0; i < nums.Length; i++)
        {
            counts[nums[i] - min]++;
        }

        int k = 0;

        for (int j = max; j >= min; j--)
        {
            for (int i = 0; i < counts[j - min]; i++)
            {
                nums[k++] = j;
            }
        }
        var sum = 0;
        for (var t = nums.Length - 1; t >= 0; t = t - 2)
        {
            sum += Math.Min(nums[t], nums[t - 1]);
        }

        return sum;
    }
}
/**************************************************************************************************************
 * ArrayPairSum_1 ArrayPairSum_2                                                                              *
 **************************************************************************************************************/