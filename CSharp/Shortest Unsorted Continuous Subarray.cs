//Source  : https://leetcode.com/problems/shortest-unsorted-continuous-subarray/
//Author  : Xinruo Shi
//Date    : 2019-06-18
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer array, you need to find one continuous subarray that if you only sort this subarray in ascending order, 
 * then the whole array will be sorted in ascending order, too.You need to find the shortest such subarray and output its length.
 * 
 * Note:
 * The length of the input array is in range [1, 10,000].
 * The input array may contain duplicates, so ascending order here means <=.
 * 
 * Input: nums = [2,6,4,8,10,9,15]
 * Output: 5
 * Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.
 * 
 *******************************************************************************************************************************/

using System;

public class Solution581
{
    // --------------- O(nlogn) 152ms --------------- O(n) 30.1MB --------------- (17% 7%)
    /*
     * using sort
     */
    public int FindUnsortedSubarray_1(int[] nums)
    {
        int[] copy = (int[])nums.Clone();
        Array.Sort(copy);

        int L = nums.Length;int R = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != copy[i])
            {
                L = L < i ? L : i;
                R = R > i ? R : i;
            }
        }

        return R - L > 0 ? R - L + 1 : 0 ;
    }
    
    // --------------- O(nlogn) 136ms --------------- O(n) 32MB --------------- (47% 100%)
    /*
     * similar to 1
     */
    public int FindUnsortedSubarray_1_2(int[] nums)
    {
        int[] copy = (int[])nums.Clone();
        Array.Sort(copy);

        int L = nums.Length;
        int R = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != copy[i])
            {
                if (L > i) { L = i; }
                R = i;
            }
        }

        return R > L ? R - L + 1 : 0;
    }

    // --------------- O(nlogn) 152ms --------------- O(n) 30.3MB --------------- (17% 5%)
    /*
     * using sort 2 
     * [1,2,3,4] so should compare R-L>0?
     */
    public int FindUnsortedSubarray_2(int[] nums)
    {
        int[] copy = (int[])nums.Clone();
        Array.Sort(copy);

        int L = 0;
        int R = nums.Length - 1;
        while (L < nums.Length && nums[L] == copy[L])
        {
            L++;
        }
        while (R >= 0 && nums[R] == copy[R])
        {
            R--;
        }
        return R - L > 0 ? R - L + 1 : 0;
    }

    // --------------- O(n) 128ms --------------- O(1) 29.9MB --------------- (78% 37%)  
    public int FindUnsortedSubarray_3(int[] nums)
    {
        //if (nums.Length < 2 || nums == null) { return 0; }

        int max = int.MinValue;
        int min = int.MaxValue;
        int start = 0;
        int end = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            max = max > nums[i] ? max : nums[i];
            if (nums[i] < max)
            {
                end = i;
            }
        }
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            min = min < nums[i] ? min : nums[i];
            if (nums[i] > min)
            {
                start = i;
            }
        }

        return end - start + 1;
    }

    // --------------- O(n) 120ms --------------- O(1) 32MB --------------- (89% 100%)
    public int FindUnsortedSubarray_3_2(int[] nums)
    {
        int maxValue = int.MinValue;
        int minValue = int.MaxValue;

        int maxIndex = -1;
        int minIndex = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            maxValue = maxValue > nums[i] ? maxValue : nums[i];
            minValue = minValue < nums[nums.Length - 1 - i] ? minValue : nums[nums.Length - 1 - i];

            maxIndex = nums[i] < maxValue ? i : maxIndex;
            minIndex = nums[nums.Length - 1 - i] > minValue ? nums.Length - 1 - i : minIndex;
        }

        return maxIndex - minIndex + 1;
    }
    
    // --------------- O(n) 124ms --------------- O(1) 32MB --------------- (75% 100%) ※
    public int FindUnsortedSubarray_3_3(int[] nums)
    {
        int maxIndex = 0;
        int minIndex = 0;

        int maxValue = int.MinValue;
        int minValue = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            maxValue = maxValue > nums[i] ? maxValue : nums[i];
            maxIndex = nums[i] < maxValue ? i : maxIndex;

            minValue = minValue < nums[nums.Length - 1 - i] ? minValue : nums[nums.Length - 1 - i];
            minIndex = nums[nums.Length - 1 - i] > minValue ? nums.Length - 1 - i : minIndex;
        }

        return maxIndex > minIndex ? maxIndex - minIndex + 1 : 0;
}
/**************************************************************************************************************
 * FindUnsortedSubarray_1 FindUnsortedSubarray_3                                                              *
 **************************************************************************************************************/
