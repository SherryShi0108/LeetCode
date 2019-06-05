//Source  : https://leetcode.com/problems/majority-element/
//Author  : Xinruo Shi
//Date    : 2019-06-05
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
 * You may assume that the array is non-empty and the majority element always exist in the array.
 * 
 * Input: nums=[3,2,3]
 * Output: 3
 * 
 * Input: nums=[2,2,1,1,1,2,2]
 * Output: 2
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic; // Dictionary资源字典

public class Solution169
{
    // --------------- HashMap --------------- O(n)120ms --------------- O(n)27.6MB ---------------
    public int MajorityElement_1(int[] nums)
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
            if (d[nums[i]] > nums.Length / 2)
            {
                return nums[i];
            }
        }
        return -1;
    }

    // --------------- O(n)112ms --------------- O(1)27.2MB ---------------
    /*
     * Moore Voting 
     * must have more than half of the numbers
     */
    public int MajorityElement_2(int[] nums)
    {
        int n=0;
        int cnt = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (cnt == 0)
            {
                n = nums[i];
                cnt++;
            }
            else
            {
                if (n == nums[i])
                {
                    cnt++;
                }
                else
                {
                    cnt--;
                }
            }
        }
        return n;
    }

}
/**************************************************************************************************************
 * MajorityElement_1    MajorityElement_2                                                                     *
 **************************************************************************************************************/
