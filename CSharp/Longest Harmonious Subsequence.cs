//Source  : https://leetcode.com/problems/longest-harmonious-subsequence/
//Author  : Xinruo Shi
//Date    : 2019-08-16
//Language: C#

/*******************************************************************************************************************************
 * 
 * We define a harmounious array as an array where the difference between its maximum value and its minimum value is exactly 1.
 * Now, given an integer array, you need to find the length of its longest harmonious subsequence among all its possible subsequences.
 * 
 * Input: [1,3,2,2,5,2,3,7]
 * Output: 5
 * Explanation: The longest harmonious subsequence is [3,2,2,2,3].
 * 
 * Note: The length of the input array will not exceed 20,000.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution594
{
    // --------------- O(n) 180ms --------------- 40MB --------------- (48% 100%)
    public int FindLHS_1(int[] nums)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                d[nums[i]]++;
            }
            else
            {
                d[nums[i]] = 1;
            }
        }

        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i] - 1))
            {
                count = count > (d[nums[i]] + d[nums[i] - 1]) ? count : (d[nums[i]] + d[nums[i] - 1]);
            }
            if (d.ContainsKey(nums[i] + 1))
            {
                count = count > (d[nums[i]] + d[nums[i] + 1]) ? count : (d[nums[i]] + d[nums[i] + 1]);
            }
        }
        return count;
    }

    // --------------- O(n) 172ms --------------- 40MB --------------- (72% 100%) ※
    /*
     * improve 1
     */
    public int FindLHS_2(int[] nums)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                d[nums[i]]++;
            }
            else
            {
                d[nums[i]] = 1;
            }
        }

        int count = 0;
        foreach (var item in d)
        {
            if (d.ContainsKey(item.Key + 1))
            {
                count = count > item.Value + d[item.Key + 1] ? count : item.Value + d[item.Key + 1];
            }
        }
        return count;
    }

    // --------------- O(n) 184ms --------------- 40.1MB --------------- (40% 100%)
    /*
     * Only one loop is there
     */
    public int FindLHS_3(int[] nums)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                d[nums[i]]++;
            }
            else
            {
                d[nums[i]] = 1;
            }

            if (d.ContainsKey(nums[i] - 1))
            {
                count = count > (d[nums[i]] + d[nums[i] - 1]) ? count : (d[nums[i]] + d[nums[i] - 1]);
            }
            if (d.ContainsKey(nums[i] + 1))
            {
                count = count > (d[nums[i]] + d[nums[i] + 1]) ? count : (d[nums[i]] + d[nums[i] + 1]);
            }
        }
        return count;
    }
}
/**************************************************************************************************************
 * FindLHS_2 FindLHS_3                                                                                        *
 **************************************************************************************************************/