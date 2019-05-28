﻿//Source  : https://leetcode.com/problems/search-insert-position/
//Author  : Xinruo Shi
//Date    : 2019-05-28
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a sorted array and a target value, return the index if the target is found. If not, return the index 
 * where it would be if it were inserted in order.
 * You may assume no duplicates in the array.
 * 
 * Input: nums = [1,3,5,6], terget = 5
 * Output: 2
 * 
 * Input: nums = [1,3,5,6], target = 7
 * Output: 4
 * 
 *******************************************************************************************************************************/

public class Solution
{
    // ---------------searchInsert --------------- O(n) 96ms --------------- 22.8MB ---------------
    public int SearchInsert_1(int[] nums, int target)
    {
        if (nums.Length==0||nums==null)
        {
            return 0;
        }
        if (nums[0] > target)
        {
            return 0;
        }
        if (nums[nums.Length - 1] < target)
        {
            return nums.Length ;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                return i;
            }
            if (nums[i] > target)
            {
                return i ;
            }
        }
        return 0;
    }

    // --------------- O(n) 92ms --------------- 22.5MB ---------------  
    public int SearchInsert_2(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (target == nums[i])
                return i;
            if (target < nums[i])
                return i;
            if (i == nums.Length - 1)
                return i + 1;
        }
        return 0;
    }

    // --------------- O(n) 96ms --------------- 22.6MB ---------------  
    public int SearchInsert_3(int[] nums, int target)
    {
        var i = 0;
        for (i = 0; i < nums.Length; i++)
        {
            if (nums[i] < target)
            {
                continue;
            }
            break;
        }
        return i;
    }
}
/**************************************************************************************************************
 * SearchInsert_3                                                                                             *
 **************************************************************************************************************/
