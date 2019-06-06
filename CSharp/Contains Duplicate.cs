//Source  : https://leetcode.com/problems/contains-duplicate/
//Author  : Xinruo Shi
//Date    : 2019-06-07
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of integers, find if the array contains any duplicates.
 * Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
 * 
 * Input: nums=[1,2,3,1]
 * Output: true
 * 
 * Input: nums=[1,2,3,4]
 * Output: false
 *
 * Input: nums=[1,1,1,3,3,4,3,2,4,2]
 * Output: true
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution217
{
    // --------------- O(n) 116ms --------------- 31.2MB ---------------(48%,5%)
    public bool ContainsDuplicate_1(int[] nums)
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
        for (int i = 0; i < nums.Length; i++)
        {
            if (d[nums[i]] > 1)
            {
                return true;
            }
        }
        return false;
    }


    public bool ContainsDuplicate_2(int[] nums)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                return true;
            }
            else
            {
                d[nums[i]] = 1;
            }
        }
        return false;
    }
}
/**************************************************************************************************************
 * ContainsDuplicate_2                                                                                        *
 **************************************************************************************************************/