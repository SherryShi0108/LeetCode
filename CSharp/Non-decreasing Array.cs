//Source  : https://leetcode.com/problems/non-decreasing-array/
//Author  : Xinruo Shi
//Date    : 2019-06-24
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array with n integers, your task is to check if it could become non-decreasing by modifying at most 1 element.
 * We define an array is non-decreasing if array[i] <= array[i + 1] holds for every i (1 <= i < n).
 * 
 * Note:
 * The n belongs to [1, 10,000].
 * 
 * Input: nums = [4,2,3]
 * Output: True
 * Explanation: You could modify the first 4 to 1 to get a non-decreasing array.
 * 
 * Input: nums = [4,2,1]
 * Output: False
 * Explanation: You can't get a non-decreasing array by modify at most one element.
 * 
 *******************************************************************************************************************************/

public class Solution665
{
    // --------------- O(n) 128s --------------- 32MB --------------- (18% 100%)  
    public bool CheckPossibility_1(int[] nums)
    {
        int count = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                if (count-- == 0) return false;
                if (i == 1 || nums[i] >= nums[i - 2])
                {
                    nums[i - 1] = nums[i];
                }
                else
                {
                    nums[i] = nums[i - 1];
                }
            }
        }

        return true;
    }
    
    // --------------- O(n) 124s --------------- 32MB --------------- (44% 100%)  
    /*
     * improve 1 : reduce branch
     */
    public bool CheckPossibility_1_1(int[] nums)
    {
        int count = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                if (count-- == 0) return false;

                if (i != 1 && nums[i] < nums[i - 2])
                {
                    nums[i] = nums[i - 1];
                }
            }
        }

        return true;
    }
}
/**************************************************************************************************************
 * CheckPossibility_1                                                                                         *
 **************************************************************************************************************/
