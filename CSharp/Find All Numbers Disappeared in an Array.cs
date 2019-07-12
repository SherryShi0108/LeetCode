//Source  : https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
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

    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     * Time Limit Exceeded
     */
    public IList<int> FindDisappearedNumbers_2(int[] nums)
    {
        List<int> L = new List<int>();
        for (int i = 1; i < nums.Length + 1; i++)
        {
            L.Add(i);
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (L.Contains(nums[i]))
            {
                L.Remove(nums[i]);
            }
        }

        return L;
    }
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++

    // --------------- O(n) 336ms --------------- 43.1MB --------------- (52% 40%)
    /*
     * But O(space)!=O(1),using extra int[]  
     */
    public IList<int> FindDisappearedNumbers_3(int[] nums)
    {
        List<int> L = new List<int>();
        int[] temp = new int[nums.Length+1];

        for (int i = 0; i < nums.Length; i++)
        {
            temp[nums[i]]++;
        }
        for (int i = 1; i < temp.Length; i++)
        {
            if (temp[i] == 0)
            {
                L.Add(i);
            }
        }
        return L;
    }

    // --------------- O(n) 336ms --------------- 42.5MB --------------- (52% 53%) ※ 
    public IList<int> FindDisappearedNumbers_4(int[] nums)
    {
        List<int> L = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int x = (nums[i] > 0 ? nums[i] : -nums[i]) - 1;
            nums[x] = nums[x] > 0 ? -nums[x] : nums[x];
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

    /*
     * Time Limit Exceeded
     *  O(time)!=O(n)
     */
    public IList<int> FindDisappearedNumbers_5(int[] nums)
    {
        List<int> L = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            while (nums[i] != i + 1 && nums[i] != nums[nums[i] - 1])
            {
                int temp = nums[i];
                nums[i] = nums[nums[i] - 1];
                nums[nums[i] - 1] = temp;
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i + 1)
            {
                L.Add(i+1);
            }
        }
       
        return L;
    }
}

/**************************************************************************************************************
 * FindDisappearedNumbers_4                                                                                   *
 **************************************************************************************************************/