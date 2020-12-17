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

public class Solution
{
    // --------------- O(n) 208ms --------------- 26MB --------------- (5% 8%)  
    public int SearchInsert_1(int[] nums, int target)
    {
        int i = 0;
        for (i = 0; i < nums.Length; i++)
        {
            if (nums[i] < target)
            {
                continue;
            }
            break;
        }
        return i;
    }
    
    // --------------- O(n) 132ms --------------- 25MB --------------- (5% 33%) 
    public int SearchInsert_1_2(int[] nums, int target)
    {
        int i = 0;
        for (; i < nums.Length; i++)
        {
            if (nums[i] >= target)
            {
                break;
            }
        }
        return i;
    }
    
    // --------------- O(n) 132ms --------------- 25MB --------------- (5% 33%) 
    public int SearchInsert_1_3(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (target <= nums[i])
            {
                return i;
            }
        }
        return nums.Length;
    }
    
    // --------------- O(logn) 96ms --------------- 24MB --------------- (63% 5%) ※
    /*
     * using Binary Search Mode1
     */
    public int SearchInsert_2(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length;
        while (left  <right)
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
    
    // --------------- O(logn) 96ms --------------- 23.9MB --------------- (63% 5%)
    /*
     * using Binary Search Mode2
     */
    public int SearchInsert_2_2(int[] nums, int target)
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
