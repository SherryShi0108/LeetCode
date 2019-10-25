//Source  : https://leetcode.com/problems/contains-duplicate-ii/
//Author  : Xinruo Shi
//Date    : 2019-06-08
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array 
 * such that nums[i] = nums[j] and the absolute difference between i and j is at most k.
 * 
 * Input: nums = [1,2,3,1], k = 3
 * Output: true
 * 
 * Input: nums = [1,0,1,1], k = 1
 * Output: true
 *
 * Input: nums = [1,2,3,1,2,3], k = 2
 * Output: false
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution219
{
    // --------------- O(n) 108ms --------------- 27.2MB ---------------(64%,20%)
    public bool ContainsNearbyDuplicate_1(int[] nums, int k)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                if ((i - d[nums[i]]) <= k)
                {
                    return true;
                }
                else
                {
                    d[nums[i]] = i;
                }
            }
            else
            {
                d[nums[i]] = i;
            }
        }
        return false;
    }

    // --------------- simplify Method1 --------------- 116ms --------------- 27.3MB ---------------(36%,16%)  
    public bool ContainsNearbyDuplicate_2(int[] nums, int k)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]) && (i - d[nums[i]]) <= k)
            {
                return true;
            }
            else
            {
                d[nums[i]] = i;
            }
        }
        return false;
    }
    
    // --------------- O(n) 108ms --------------- 27.1MB ---------------(79% 100%) ※
    public bool ContainsNearbyDuplicate_3(int[] nums, int k)
    {
        HashSet<int> h = new HashSet<int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > k)
            {
                h.Remove(nums[i - k - 1]);
            }

            if (!h.Add(nums[i]))
            {
                return true;
            }
        }

        return false;
    }
}
/**************************************************************************************************************
 * ContainsNearbyDuplicate_1 / 3                                                                              *
 **************************************************************************************************************/
