//Source  : https://leetcode.com/problems/degree-of-an-array/
//Author  : Xinruo Shi
//Date    : 2019-06-26
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty array of non-negative integers nums, the degree of this array is defined as the maximum frequency of any one of its elements.
 * Your task is to find the smallest possible length of a (contiguous) subarray of nums, that has the same degree as nums.
 * 
 * Note:
 * nums.length will be between 1 and 50,000.
 * nums[i] will be an integer between 0 and 49,999.
 * 
 * Input: nums = [1, 2, 2, 3, 1]
 * Output: 2
 * Explanation: The input array has a degree of 2 because both elements 1 and 2 appear twice.Of the subarrays that have the same degree:
 * [1, 2, 2, 3, 1], [1, 2, 2, 3], [2, 2, 3, 1], [1, 2, 2], [2, 2, 3], [2, 2] The shortest length is 2. So return 2.
 * 
 * Input: nums = [1,2,2,3,1,4,2]
 * Output: 6
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution697
{
    // --------------- O(n) 176ms --------------- 30.2MB --------------- (19% 50%)
    /*
     * int[] 0:出现次数 1：这个数字出现的第一个位置 2：最新位置到第一个位置之间举例
     */
    public int FindShortestSubArray_1(int[] nums)
    {
        Dictionary<int, int[]> d = new Dictionary<int, int[]>();

        int max = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                int[] a = d[nums[i]];
                a[0]++;
                a[2] = i - a[1];

                max = a[0] > max ? a[0] : max;
            }
            else
            {
                d[nums[i]] = new int[] { 1, i, 0 };
            }
        }

        int min = int.MaxValue;
        foreach (var item in d)
        {
            int[] a = item.Value;
            if (a[0] == max)
            {
                min = min < a[2] ? min : a[2];
            }
        }

        return min + 1;
    }

    // --------------- O(n) 132ms --------------- 30.1MB --------------- (86% 54%) ※
    public int FindShortestSubArray_2(int[] nums)
    {
        Dictionary<int, int[]> d = new Dictionary<int, int[]>();
        int max = 0;
        int min = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (!d.ContainsKey(nums[i]))
            {
                d[nums[i]] = new int[] { 1, i, 0 };
            }
            else
            {
                int[] a = d[nums[i]];
                a[0]++;
                a[2] = i - a[1];
                
                if (a[0] > max)
                {
                    max = a[0];
                    min = a[2] + 1;
                }
                else if (a[0]==max)
                {
                    min = min < a[2] + 1 ? min : a[2] + 1;
                }
            }
        }
        return min;
    }
    
    // --------------- O(n) 144ms --------------- 29.7MB --------------- (68% 100%) 
    public int FindShortestSubArray_3(int[] nums)
    {
        Dictionary<int, int[]> d = new Dictionary<int, int[]>();
        int min = int.MaxValue;
        int count = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                d[nums[i]][1]++;
                if (d[nums[i]][1] > count)
                {
                    min = i - d[nums[i]][0];
                    count = d[nums[i]][1];
                }
                else if (d[nums[i]][1] == count)
                {
                    int x = i - d[nums[i]][0];
                    min = min < x ? min : x;
                }
            }
            else
            {
                d[nums[i]] = new int[] { i, 1 };
            }
        }
        return min == int.MaxValue ? 1 : min + 1;
    }
}
/**************************************************************************************************************
 * FindShortestSubArray_2 / 3                                                                                 *
 **************************************************************************************************************/
