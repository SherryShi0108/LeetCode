//Source  : https://leetcode.com/problems/climbing-stairs/
//Author  : Xinruo Shi
//Date    : 2019-12-10
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are climbing a stair case. It takes n steps to reach to the top.
 * Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
 *
 * Note: Given n will be a positive integer.
 *
 * Input: 2
 * Output: 2
 * Explanation: There are two ways to climb to the top.
 * 1. 1 step + 1 step
 * 2. 2 steps
 *
 * Input: 3
 * Output: 3
 * Explanation: There are three ways to climb to the top.
 * 1. 1 step + 1 step + 1 step
 * 2. 1 step + 2 steps
 * 3. 2 steps + 1 step
 * ※
 *******************************************************************************************************************************/

public class Solution70
{
    // --------------- O(n) 40ms --------------- O(n) 14.6MB --------------- (67% 6%) 
    public int ClimbStairs_1(int n)
    {
        if (n <= 2) return n;

        int[] arrays = new int[n + 1];
        arrays[1] = 1;
        arrays[2] = 2;

        for (int i = 3; i <= n; i++)
        {
            arrays[i] = arrays[i - 1] + arrays[i - 2];
        }

        return arrays[n];
    }

    // --------------- O(n) 56ms --------------- O(1) 14.6MB --------------- (9% 6%) 
    public int ClimbStairs_2(int n)
    {
        if (n <= 2) return n;

        int pre2 = 1;
        int pre1 = 2;

        int result = 0;
        for (int i = 3; i <= n; i++)
        {
            result = pre1 + pre2;
            pre2 = pre1;
            pre1 = result;
        }

        return result;
    }
    
    // --------------- O(n) 56ms --------------- O(1) 14.6MB --------------- (9% 6%) ※
    public int ClimbStairs2_2(int n)
    {
        if (n == 1) return 1;
        if (n == 2) return 2;
        return ClimbStairs2_2(n - 1) + ClimbStairs2_2(n - 2);
    }

    // --------------- O(n) 40ms --------------- O(1) 14.7MB --------------- (67% 6%)
    public int ClimbStairs_3(int n)
    {
        int a = 1, b = 1;
        while (n-- > 0)
            a = (b += a) - a;
        return a;
    }
}

/**************************************************************************************************************
 * ClimbStairs_2 ClimbStairs_3                                                                                *
 **************************************************************************************************************/
