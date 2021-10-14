//Source  : https://leetcode.com/problems/find-peak-element/
//Author  : Xinruo Shi
//Date    : 2021-04-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * A peak element is an element that is strictly greater than its neighbors.
 * Given an integer array nums, find a peak element, and return its index.
 * If the array contains multiple peaks, return the index to any of the peaks.
 * You may imagine that nums[-1] = nums[n] = -∞.
 *
 * Input: nums = [1,2,3,1]
 * Output: 2
 * Explanation: 3 is a peak element and your function should return the index number 2.
 *
 * Input: nums = [1,2,1,3,5,6,4]
 * Output: 5
 * Explanation: Your function can return either index number 1 where the peak element is 2, or index number 5 where the peak element is 6.
 *
 * Constraints:
 *      1 <= nums.length <= 1000
 *      -2^31 <= nums[i] <= 2^31 - 1
 *      nums[i] != nums[i + 1] for all valid i.
 *
 * Follow up: Could you implement a solution with logarithmic complexity?
 * 
 *******************************************************************************************************************************/

public class Solution162
{
    // --------------- O(logn) 80ms --------------- O(1) 25MB --------------- (99% 11%) ※
    /*
     * Using Iterative Binary Search
     */
    public int FindPeakElement_1(int[] nums)
    {
        int i = 0;
        int j = nums.Length - 1;

        while (i < j)
        {
            int mid = i + (j - i) / 2;

            if (nums[mid] > nums[mid + 1])
            {
                j = mid;
            }
            else
            {
                i = mid + 1;
            }
        }

        return i;
    }

    // --------------- O(logn) 96ms --------------- O(1) 25MB --------------- (34% 39%)
    /*
     * Using Recursive Binary Search
     */
    public int FindPeakElement_2(int[] nums)
    {
        return Search(nums, 0, nums.Length - 1);
    }

    public int Search(int[] nums, int l, int r)
    {
        if (l == r) return l;
        int mid = (l + r) / 2;
        if (nums[mid] > nums[mid + 1])
        {
            return Search(nums, l, mid);
        }
        else
        {
            return Search(nums, mid + 1, r);
        }
    }
}

/**************************************************************************************************************
 *     FindPeakElement_1  FindPeakElement_2                                                                   *
 **************************************************************************************************************/
