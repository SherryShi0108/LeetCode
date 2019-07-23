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
    /*
     *  [-1,4,2,3] true ???
     *  [2,3,3,2,4] true
     *  [3,4,2,3] false
     *  [4,2,3] true
     */
    // --------------- O(n) 144ms --------------- 29.7MB --------------- (17% 8%) ※ 
    public bool CheckPossibility_1(int[] nums)
    {
        int count = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] >= nums[i - 1])
            {
                continue;
            }
            else
            {
                if (count == 0)
                {
                    count++;
                    if (i < 2 || nums[i - 2] < nums[i])
                    {
                        nums[i - 1] = nums[i];
                    }
                    else
                    {
                        nums[i] = nums[i - 1];
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        return true;
    }

    // --------------- O(n) 132ms --------------- 29.7MB --------------- (39% 8%)
    public bool CheckPossibility_2(int[] nums)
    {
        int count = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] >= nums[i - 1])
            {
                continue;
            }
            else
            {
                if (count == 0)
                {
                    count++;
                    if (i > 1 && nums[i - 2] > nums[i])
                    {
                        nums[i] = nums[i - 1];
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        return true;
    }
}
/**************************************************************************************************************
 * CheckPossibility_1                                                                                         *
 **************************************************************************************************************/