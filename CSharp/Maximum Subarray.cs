﻿//Source  : https://leetcode.com/problems/maximum-subarray/
//Author  : Xinruo Shi
//Date    : 2019-05-29
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer array nums, find the contiguous subarray (containing at least one number) 
 *       which has the largest sum and return its sum.
 * 
 * Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
 * Output: 6
 * Explanation: [4,-1,2,1] has the largest sum = 6
 * 
 *******************************************************************************************************************************/

using System; // Math.max 名称空间
using System.Linq; // nums.Max() 名称空间

public class Solution53
{
    // --------------- O(n) 132ms --------------- 26MB --------------- (13% 61%) 
    /*
     *  Easy-Understanding
     */
    public int MaxSubArray_1(int[] nums)
    {
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] + nums[i] > nums[i])
            {
                nums[i] += nums[i - 1];
            }
        }
        return nums.Max();
    }

    // --------------- O(n) 112ms --------------- 23.4MB --------------- (27% 8%) ※
    public int MaxSubArray_1_2(int[] nums)
    {
        if (nums == null || nums.Length == 0) 
        {
           return int.MinValue;
        }
         
        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] = nums[i] + nums[i - 1] > nums[i] ? nums[i] + nums[i - 1] : nums[i];
            nums[0] = nums[0] > nums[i] ? nums[0] : nums[i];
        }
        return nums[0];
    }
}
/**************************************************************************************************************
 * MaxSubArray_1_2                                                                                            *
 **************************************************************************************************************/
