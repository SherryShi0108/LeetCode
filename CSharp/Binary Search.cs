//Source  : https://leetcode.com/problems/binary-search/
//Author  : Xinruo Shi
//Date    : 2019-12-08
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a sorted (in ascending order) integer array nums of n elements and a target value, write a function
 * to search target in nums. If target exists, then return its index, otherwise return -1.
 *
 * Input: nums = [-1,0,3,5,9,12], target = 9
 * Output: 4
 * Explanation: 9 exists in nums and its index is 4
 *
 * Input: nums = [-1,0,3,5,9,12], target = 2
 * Output: -1
 * Explanation: 2 does not exist in nums so return -1
 *
 * Note:
 *      You may assume that all elements in nums are unique.
 *      n will be in the range [1, 10000].
 *      The value of each element in nums will be in the range [-9999, 9999].
 * 
 *******************************************************************************************************************************/

public class Solution704
{
    // --------------- O(logn) 136ms --------------- 34.7MB --------------- (61% 25%) ※
    /*
     * (left+right)/2 is not true , it could overflow
     * (left+(right-left)/2) is always <= right , so it cannot overflow
     */
    public int Search_1(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left<=right)
        {
            int mid = left + (right-left) / 2;
            if (nums[mid] > target)
            {
                right = mid-1;
            }
            else if(nums[mid]<target)
            {
                left = mid+1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }

    // --------------- O(logn) 132ms --------------- 34.8MB --------------- (79% 25%)
    public int Search_2(int[] nums, int target)
    {
        int i = 0;
        int j = nums.Length;
        while (i < j)
        {
            int mid = i + (j - i) / 2;
            if (nums[mid] == target) return mid;
            else if (nums[mid] > target)
            {
                j = mid;
            }
            else
            {
                i = mid + 1;
            }
        }

        return -1;
    }
}
/**************************************************************************************************************
 * Search_1 / 2                                                                                               *
 **************************************************************************************************************/