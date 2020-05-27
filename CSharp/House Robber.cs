//Source  : https://leetcode.com/problems/house-robber/
//Author  : Xinruo Shi
//Date    : 2019-12-02
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed,
 * the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and
 * it will automatically contact the police if two adjacent houses were broken into on the same night.
 *
 * Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money
 * you can rob tonight without alerting the police.
 *
 * Input: [1,2,3,1]
 * Output: 4
 * Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3). Total amount you can rob = 1 + 3 = 4.
 *
 * Input: [2,7,9,3,1]
 * Output: 12
 * Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1). Total amount you can rob = 2 + 9 + 1 = 12.
 * ※
 *******************************************************************************************************************************/

using System;

public class Solution198
{
    // --------------- O(n) 84ms --------------- O(1) 24MB ---------------(95% 9%) 
    /*
     * easy-understanding DP
     * using Iterative 
     */
    public int Rob_1(int[] nums)
    {
        if (nums == null || nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return nums[0] > nums[1] ? nums[0] : nums[1];
        if (nums.Length == 3) return nums[0] + nums[2] > nums[1] ? nums[0] + nums[2] : nums[1];

        nums[2] += nums[0];
        for (int i = 3; i < nums.Length; i++)
        {
            nums[i] += nums[i - 2] > nums[i - 3] ? nums[i - 2] : nums[i - 3];
        }

        return nums[nums.Length - 1] > nums[nums.Length - 2] ? nums[nums.Length - 1] : nums[nums.Length - 2];
    }

    // --------------- O(n) 84ms --------------- O(1) 24MB ---------------(95% 9%) 
    /*
     * improve 1
     */
    public int Rob_1_2(int[] nums)
    {
        if (nums == null || nums.Length == 0) return 0;

        for (int i = 2; i < nums.Length; i++)
        {
            if (i == 2)
            {
                nums[i] += nums[i - 2];
            }
            else
            {
                nums[i] += nums[i - 2] > nums[i - 3] ? nums[i - 2] : nums[i - 3];
            }
        }

        return nums.Length==1? nums[0]:nums[nums.Length - 1] > nums[nums.Length - 2] ? nums[nums.Length - 1] : nums[nums.Length - 2];
    }

    // --------------- O(n) 84ms --------------- O(1) 24MB ---------------(92% 9%) 
    /*
     * another DP solution
     * using Iterative 
     */
    public int Rob_2(int[] nums)
    {
        int robEven = 0;
        int robOdd = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0)
            {
                robEven = robEven + nums[i] > robOdd ? robEven + nums[i] : robOdd;
            }
            else
            {
                robOdd = robEven > robOdd + nums[i] ? robEven : robOdd + nums[i];
            }
        }

        return robOdd > robEven ? robOdd : robEven;
    }

    // --------------- O(n) 84ms --------------- O(1) 24MB ---------------(92% 9%) 
    /*
     * hard to understanding
     */
    public int Rob_3(int[] nums)
    {
        int rob = 0;
        int notRob = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int temp = rob > notRob ? rob : notRob;
            rob = notRob + nums[i];
            notRob = temp;
        }

        return rob > notRob ? rob : notRob;
    }

    // --------------- O(n) 88ms --------------- O(1) 24MB ---------------(75% 9%) 
    /*
     * similar to 3
     */
    public int Rob3_2(int[] nums)
    {
        int rob = 0; //max monney can get if rob current house
        int notrob = 0; //max money can get if not rob current house
        for (int i = 0; i < nums.Length; i++)
        {
            int currob = notrob + nums[i]; //if rob current value, previous house must not be robbed
            notrob = Math.Max(notrob, rob); //if not rob ith house, take the max value of robbed (i-1)th house and not rob (i-1)th house
            rob = currob;
        }
        return Math.Max(rob, notrob);
    }
}

/**************************************************************************************************************
 * Rob1 Rob2 Rob3                                                                                             *
 **************************************************************************************************************/