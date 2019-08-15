//Source  : https://leetcode.com/problems/single-number/
//Author  : Xinruo Shi
//Date    : 2019-08-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty array of integers, every element appears twice except for one. Find that single one.
 * 
 * Note: Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
 * 
 * Input: [2,2,1]
 * Output: 1
 * 
 * Input: [4,1,2,1,2]
 * Output: 4
 * 
 *******************************************************************************************************************************/

public class Solution136
{
    // --------------- O(n) 104ms --------------- 24.4MB ---------------(87% 29%) ※
    public int SingleNumber_1(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum ^= nums[i];
        }
        
        return sum;
    }
}
/**************************************************************************************************************
 * SingleNumber_1                                                                                             *
 **************************************************************************************************************/