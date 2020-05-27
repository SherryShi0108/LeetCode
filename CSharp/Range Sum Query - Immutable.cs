//Source  : https://leetcode.com/problems/range-sum-query-immutable/
//Author  : Xinruo Shi
//Date    : 2019-12-03
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
 *
 * Given nums = [-2, 0, 3, -5, 2, -1]
 * sumRange(0, 2) -> 1
 * sumRange(2, 5) -> -1
 * sumRange(0, 5) -> -3
 *
 * Note: You may assume that the array does not change. There are many calls to sumRange function.
 * ※
 *******************************************************************************************************************************/

// class 303

using System;

// --------------- O(n) 284ms --------------- O(1) 36MB ---------------(40% 17%) 
/*
 * Brute Force
 */
public class NumArray
{
    private int[] arrays;
    public NumArray(int[] nums)
    {
        arrays = nums;
    }

    public int SumRange(int i, int j)
    {
        if (i < 0 || j >= arrays.Length) return 0;

        int result = 0;
        for (int k = i; k <= j; k++)
        {
            result += arrays[k];
        }

        return result;
    }
}

// --------------- O(n) 284ms --------------- O(1) 36MB ---------------(40% 17%) 
/*
 * Brute Force
 */
public class NumArray_2
{
    private int[] arrays;

    public NumArray_2(int[] nums)
    {
        arrays=new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                arrays[i] = nums[i];
            }
            else
            {
                arrays[i] = nums[i] + arrays[i - 1];
            }
        }
    }

    public int SumRange(int i, int j)
    {
        if (i == 0) return arrays[j];

        return arrays[j] - arrays[i - 1];
    }
}


/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(i,j);
 */
/**************************************************************************************************************
* NumArray_2                                                                                                  *
**************************************************************************************************************/