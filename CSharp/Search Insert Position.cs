//Source  : https://leetcode.com/problems/search-insert-position/
//Author  : Xinruo Shi
//Date    : 2019-05-28
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a sorted array and a target value, return the index if the target is found. If not, return the index 
 * where it would be if it were inserted in order.
 * You may assume no duplicates in the array.
 * 
 * Input: nums = [1,3,5,6], target = 5
 * Output: 2
 * 
 * Input: nums = [1,3,5,6], target = 7
 * Output: 4
 * 
 *******************************************************************************************************************************/

public class Solution35
{        
    // --------------- O(logn) 96ms --------------- 24MB --------------- (63% 5%)
    /*
     * using Binary Search Mode1
     */
    public int SearchInsert_1(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length;
        while (left  < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target) 
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
    
    // --------------- O(logn) 92ms --------------- 25MB --------------- (77% 52%) ※
    /*
     *  Improve 1: use >>1 instead of /2
     */
    public int SearchInsert_1_2(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length;
        while (left  < right)
        {
            int mid = left + ((right - left) >> 1);
            if (nums[mid] == target) 
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
    
    // --------------- O(logn) 96ms --------------- 23.9MB --------------- (63% 5%)
    /*
     * using Binary Search Mode2
     */
    public int SearchInsert_2(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length-1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}
/**************************************************************************************************************
 * SearchInsert_2                                                                                             *
 **************************************************************************************************************/
