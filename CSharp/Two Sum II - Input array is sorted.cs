//Source  : https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
//Author  : Xinruo Shi
//Date    : 2019-06-04
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
 * The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.
 * 
 * Note:
 * Your returned answers (both index1 and index2) are not zero-based.
 * You may assume that each input would have exactly one solution and you may not use the same element twice.
 * 
 * Input: numbers = [2,7,11,15], target = 9
 * Output: [1,2]
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution167
{
    // --------------- O(n) 292ms --------------- 29.2MB ---------------(15%,43%)
    public int[] TwoSum_1(int[] nums, int target)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int n = target - nums[i];
            if (d.ContainsKey(n))
            {
                return new int[] { d[n] + 1, i + 1 };
            }
            else
            {
                d[nums[i]] = i;
            }
        }
        return null;
    }

    // --------------- O(n) 252ms --------------- 29.3MB ---------------(73%,28%) ※
    /*
     * the input nums is already sorted
     */
    public int[] TwoSum_2(int[] nums, int target)
    {
        int i = 0;
        int j = nums.Length - 1;
        while (i < j)
        {
            int sum = nums[i] + nums[j];
            if (sum == target)
            {
                return new int[] { i + 1, j + 1 };
            }
            else if (sum < target)
            {
                i++;
            }
            else
            {
                j--;
            }
        }
        return null;
    }
}
/**************************************************************************************************************
 * TwoSum_2                                                                                                   *
 **************************************************************************************************************/
