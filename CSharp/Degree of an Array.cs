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
    // --------------- O(n) 132ms --------------- 30.1MB --------------- (86% 54%) 
    public int FindShortestSubArray_1(int[] nums)
    {
        Dictionary<int, int[]> d = new Dictionary<int, int[]>();
        int maxDegree = 0;
        int result = 1;

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
                
                if (a[0] > maxDegree)
                {
                    maxDegree = a[0];
                    result = a[2] + 1;
                }
                else if (a[0] == maxDegree)
                {
                    result = result < a[2] + 1 ? result : a[2] + 1;
                }
            }
        }
        return result;
    }
    
    // --------------- O(n) 120ms --------------- 31.2MB --------------- (98% 100%) 
    public int FindShortestSubArray_2(int[] nums)
    {
        Dictionary<int,int[]> d=new Dictionary<int, int[]>();

        int maxDegree = 0;
        int min = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                d[nums[i]][1]++;
            }
            else
            {
                d[nums[i]]=new int[]{i,1};
            }

            if (d[nums[i]][1] > maxDegree)
            {
                min = i - d[nums[i]][0] ;
                maxDegree = d[nums[i]][1];
            }
            else if (d[nums[i]][1] == maxDegree)
            {
                min = min < (i - d[nums[i]][0]) ? min : (i - d[nums[i]][0]);
            }
        }

        return min + 1;
    }
    
    // --------------- O(n) 136ms --------------- 33MB --------------- (67% 75%) ※
    public int FindShortestSubArray_2_2(int[] nums)
    {
        Dictionary<int, int[]> d = new Dictionary<int, int[]>();

        int degree = 1;
        int result = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                d[nums[i]][0]++;

                if (d[nums[i]][0] > degree)
                {
                    degree = d[nums[i]][0];
                    result = i - d[nums[i]][1] + 1;
                }
                else if (d[nums[i]][0] == degree)
                {
                    int temp = i - d[nums[i]][1] + 1;
                    result = result < temp ? result : temp;
                }
            }
            else
            {
                d[nums[i]] = new int[2] { 1, i };
            }
        }

        return result;
    }
}
/**************************************************************************************************************
 * FindShortestSubArray_2                                                                                     *
 **************************************************************************************************************/
