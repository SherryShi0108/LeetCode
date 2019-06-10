//Source  : https://leetcode.com/problems/max-consecutive-ones/
//Author  : Xinruo Shi
//Date    : 2019-06-13
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a binary array, find the maximum number of consecutive 1s in this array.
 * 
 * Note:
 * The input array will only contain 0 and 1.
 * The length of input array is a positive integer and will not exceed 10,000
 * 
 * Input: nums = [1,1,0,1,1,1]
 * Output: 3
 * Explanation: The first two digits or the last three digits are consecutive 1s.The maximum number of consecutive 1s is 3.
 * 
 *******************************************************************************************************************************/

public class Solution485
{
    // --------------- O(n) 152ms --------------- 33.1MB --------------- (23.6% 5.6%)
    /*
     * Attention:if all i cross one-if, what's the return 
     */
    public int FindMaxConsecutiveOnes_1(int[] nums)
    {
        int max = 0;
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                sum = sum + 1;
            }
            else
            {
                max = max > sum ? max : sum;
                sum = 0;
            }
        }
        max = max > sum ? max : sum;
        return max;
    }

    // --------------- O(n) 164ms --------------- 33.2MB --------------- (5.6% 5.6%)
    public int FindMaxConsecutiveOnes_2(int[] nums)
    {
        int max = 0;
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                sum++;
                max = max > sum ? max : sum;
            }
            else
            {
                sum = 0;
            }
        }
        return max;
    }
}
/**************************************************************************************************************
 * FindMaxConsecutiveOnes_2                                                                                   *
 **************************************************************************************************************/