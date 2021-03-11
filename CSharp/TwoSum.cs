//Source  : https://leetcode.com/problems/two-sum/
//Author  : Xinruo Shi
//Date    : 2019-05-20
//Language: C#

/**************************************************************************************************************
 * 
 * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
 * You may assume that each input would have exactly one solution, and you may not use the same element twice.
 * 
 * Input: nums = [2, 7, 11, 15], target = 9
 * Output: [0,1]
 * 
 * Input: nums = [6, 6, 3, 5], target = 8
 * Output: [2,3]
 * 
 **************************************************************************************************************/

using System.Collections.Generic; //Dictionary NameSpace

public class Solution
{   
    // --------------- O(n) 248s --------------- O(n) 32MB --------------- (40% 75%) ※
    public int[] TwoSum_1(int[] nums, int target)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                return new int[] { d[nums[i]], i };
            }

            int temp = target - nums[i];
            d[temp] = i;
        }

        return null;
    }
    
    // --------------- O(n) 240ms --------------- O(1) 32MB --------------- (78% 89%) 
    /*
     *  Using Dictionary
     */
    public int[] TwoSum_1_2(int[] nums, int target)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(target - nums[i]))
            {
                return new int[] { d[target - nums[i]], i };
            }

            d[nums[i]] = i;
        }

        return null;
    }
    /**************************************************************************************************************
     * TwoSum_1                                                                                                   *
     **************************************************************************************************************/
