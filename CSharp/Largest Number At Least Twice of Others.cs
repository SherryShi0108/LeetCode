//Source  : https://leetcode.com/problems/largest-number-at-least-twice-of-others/
//Author  : Xinruo Shi
//Date    : 2019-06-30
//Language: C#

/*******************************************************************************************************************************
 * 
 * In a given integer array nums, there is always exactly one largest element.
 * Find whether the largest element in the array is at least twice as much as every other number in the array.
 * If it is, return the index of the largest element, otherwise return -1.
 * 
 * Note:
 * nums will have a length in the range [1, 50].
 * Every nums[i] will be an integer in the range [0, 99].
 * 
 * Input: nums = [3, 6, 1, 0]
 * Output: 1
 * Explanation: 6 is the largest integer, and for every other number in the array x,6 is more than twice as big as x.  The index of value 6 is 1, so we return 1.
 * 
 * Input: nums = [1, 2, 3, 4]
 * Output: -1
 * Explanation: 4 isn't at least as big as twice the value of 3, so we return -1.
 * 
 *******************************************************************************************************************************/

public class Solution747
{
    // --------------- O(n) 92ms --------------- 22.7MB --------------- (93% 6%) ※
    public int DominantIndex_1(int[] nums)
    {
        int max = 0;
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            max = max > nums[i] ? max : nums[i];
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (max == nums[i])
            {
                index = i;
            }
            else if (max < 2 * nums[i])
            {
                return -1;
            }
        }
        return index;
    }

    // --------------- O(n) 112ms --------------- 22.7MB --------------- (12% 6%)
    /*
     *  1 for
     */
    public int DominantIndex_2(int[] nums)
    {
        int max1 = 0;
        int max2 = 0;
        int maxIndex = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max1)
            {
                max2 = max1;
                max1 = nums[i];
                maxIndex = i;
            }
            else if (nums[i] > max2)
            {
                max2 = nums[i];
            }
        }
        if (max1 >= max2 * 2)
        {
            return maxIndex;
        }
        return -1;
    }

    // --------------- O(n) 112ms --------------- 22.6MB --------------- (12% 21%)
    public int DominantIndex_3(int[] nums)
    {
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > nums[index])
            {
                index = i;
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[index] < 2 * nums[i] && index != i)
            {
                return -1;
            }
        }
        return index;
    }
    
    // --------------- O(n) 92ms --------------- 23.8MB --------------- (82% 20%)
    public int DominantIndex_4(int[] nums)
    {
        int index = 0;

        int max1 = nums[0];
        int max2 = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > max1)
            {
                max2 = max1;
                max1 = nums[i];
                index = i;
            }
            else if(nums[i] > max2)
            {
                max2 = nums[i];
            }
        }

        return max1 >= 2 * max2 ? index : -1;
    }
}
/**************************************************************************************************************
 * DominantIndex_1/3 DominantIndex_2 /DominantIndex_4                                                         *
 **************************************************************************************************************/
