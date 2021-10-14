//Source  : https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
//Author  : Xinruo Shi
//Date    : 2021-04-21
//Language: C#

/*******************************************************************************************************************************
 * 
 * Suppose an array of length n sorted in ascending order is rotated between 1 and n times.
 * For example, the array nums = [0,1,2,4,5,6,7] might become:
 *      [4,5,6,7,0,1,2] if it was rotated 4 times.
 *      [0,1,2,4,5,6,7] if it was rotated 7 times.
 *
 * Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].
 * Given the sorted rotated array nums of unique elements, return the minimum element of this array.
 *
 * Input: nums = [3,4,5,1,2]
 * Output: 1
 * Explanation: The original array was [1,2,3,4,5] rotated 3 times.
 *
 * Input: nums = [4,5,6,7,0,1,2]
 * Output: 0
 * Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.
 *
 * Input: nums = [11,13,15,17]
 * Output: 11
 * Explanation: The original array was [11,13,15,17] and it was rotated 4 times.
 *
 * Constraints:
 *      n == nums.length
 *      1 <= n <= 5000
 *      -5000 <= nums[i] <= 5000
 *      All the integers of nums are unique.
 *      nums is sorted and rotated between 1 and n times.
 * 
 *******************************************************************************************************************************/

public class Solution153
{
    // --------------- O(logn) 88ms --------------- O(1) 25MB --------------- (87% 99%) ※
    public int FindMin_1(int[] nums)
    {
        if (nums == null || nums.Length == 0) return -1;

        int i = 0;
        int j = nums.Length;
        int min = nums[0];

        while (i < j)
        {
            int mid = i + (j - i) / 2;
            if (nums[mid] < min)
            {
                min = nums[mid];
                j = mid;
            }
            else
            {
                i = mid + 1;
            }
        }

        return min;
    }

    // --------------- O(logn) 88ms --------------- O(1) 25MB --------------- (87% 64%)
    public int FindMin_1_2(int[] nums)
    {
        if (nums == null || nums.Length == 0) return -1;

        int i = 0;
        int j = nums.Length - 1;
        int min = nums[0];

        while (i <= j)
        {
            int mid = i + (j - i) / 2;
            if (nums[mid] < min)
            {
                min = nums[mid];
                j = mid - 1;
            }
            else
            {
                i = mid + 1;
            }
        }

        return min;
    }

    // --------------- O(logn) 92ms --------------- O(1) 25MB --------------- (70% 64%)
    /*
     * Improve 1: direct use 'left'
     * But Don't Understand???
     */
    public int FindMin_2(int[] nums)
    {
        if (nums == null || nums.Length == 0) return -1;
        int i = 0;
        int j = nums.Length - 1;

        while (i < j)
        {
            int mid = i + (j - i) / 2;

            if (nums[mid] >= nums[j])
            {
                i = mid + 1;
            }
            else
            {
                j = mid;
            }
        }

        return nums[i];
    }
}

/**************************************************************************************************************
 *     FindMin_1   FindMin_2                                                                                  *
 **************************************************************************************************************/
