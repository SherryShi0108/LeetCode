﻿//Source  : https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
//Author  : Xinruo Shi
//Date    : 2019-06-12
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.
 * Find all the elements of [1, n] inclusive that do not appear in this array.
 * Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
 * 
 * Input: nums = [4,3,2,7,8,2,3,1]
 * Output: [5,6]
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution448
{
    // --------------- O(n) 352ms --------------- 45.1MB --------------- (29% 30%)
    /*
     * But O(space)!=O(1),using extra dictionary  
     */
    public IList<int> FindDisappearedNumbers_1(int[] nums)
    {
        List<int> L = new List<int>();
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 1; i < nums.Length + 1; i++)
        {
            d.Add(i, 1);
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                d.Remove(nums[i]);
            }
        }
        foreach (var item in d)
        {
            L.Add(item.Key);
        }

        return L;
    }

    // --------------- O(n) 324ms --------------- 42.5MB --------------- (91% 53%) ※ 
    /*
     * Modify nums : [4,3,2,7,8,2,3,1] => [-4,-3,-2,-7,8,2,-3,-1]
     */
    public IList<int> FindDisappearedNumbers_2(int[] nums)
    {
        List<int> L = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int tempIndex = (nums[i] > 0 ? nums[i] : -nums[i]) - 1;
            nums[tempIndex] = nums[tempIndex] > 0 ? -nums[tempIndex] : nums[tempIndex];
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                L.Add(i + 1);
            }
        }
        return L;
    }
    
    // --------------- O(n) 304ms --------------- 44MB --------------- (66% 91%)  
    /*
     * Modify nums : [4,3,2,7,8,2,3,1] => [1,2,3,4,3,2,7,8]
     */
    public IList<int> FindDisappearedNumbers_3(int[] nums)
    {
        List<int> L = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            while (nums[i] != i + 1 && nums[i] != nums[nums[i] - 1])
            {
                int temp = nums[i];
                nums[i] = nums[temp - 1];
                nums[temp - 1] = temp;
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i + 1)
            {
                L.Add(i + 1);
            }
        }

        return L;
    }
}

/**************************************************************************************************************
 * FindDisappearedNumbers_2 FindDisappearedNumbers_3                                                          *
 **************************************************************************************************************/
