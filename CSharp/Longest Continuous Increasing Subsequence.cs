//Source  : https://leetcode.com/problems/longest-continuous-increasing-subsequence/
//Author  : Xinruo Shi
//Date    : 2019-06-25
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an unsorted array of integers, find the length of longest continuous increasing subsequence (subarray).
 * 
 * Note:
 * Length of the array will not exceed 10,000.
 * 
 * Input: nums = [1,3,5,4,7]
 * Output: 3
 * Explanation: The longest continuous increasing subsequence is [1,3,5], its length is 3. 
 * Even though [1,3,5,7] is also an increasing subsequence, it's not a continuous one where 5 and 7 are separated by 4. 
 * 
 *******************************************************************************************************************************/

public class Solution674
{
    // --------------- O(n) 116ms --------------- 23.9MB --------------- (10% 87%)
    public int FindLengthOfLCIS_1(int[] nums)
    {
        if (nums.Length == 0 || nums == null) { return 0; }

        int max = 0;
        int count = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                count++;
                max = max > count ? max : count;
            }
            else
            {
                count = 1;
            }
        }

        max = max > count ? max : count;
        return max;
    }

    // --------------- O(n) 104ms --------------- 24.3MB --------------- (38% 5%)
    public int FindLengthOfLCIS_2(int[] nums)
    {
        if (nums.Length == 0 || nums == null) { return 0; }

        int max =1;
        int count = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                count++;
                max = max > count ? max : count;
            }
            else
            {
                count = 1;
            }
        }    
        return max;
    }

    // --------------- O(n) 100ms --------------- 24.3MB --------------- (55% 5%)
    public int FindLengthOfLCIS_3(int[] nums)
    {
        int max = 0;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i==0||nums[i] > nums[i - 1])
            {
                count++;
                max = max > count ? max : count;
            }
            else
            {
                count = 1;
            }
        }
        return max;
    }   
    
    // --------------- O(n) 100ms --------------- 23.8MB --------------- (75% 96%) ※
    public int FindLengthOfLCIS_4(int[] nums)
    {
        if (nums.Length == 0 || nums == null) { return 0; }

        int max = 1;
        int count = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                count++;
                max = max > count ? max : count;
            }
            else
            {
                count = 1;
            }
        }

        return max;
    }
}
/**************************************************************************************************************
 * FindLengthOfLCIS_3 / 4                                                                                     *
 **************************************************************************************************************/
