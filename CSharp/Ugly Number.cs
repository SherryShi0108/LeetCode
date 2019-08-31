//Source  : https://leetcode.com/problems/ugly-number/
//Author  : Xinruo Shi
//Date    : 2019-09-07
//Language: C#

/*******************************************************************************************************************************
 * 
 * Write a program to check whether a given number is an ugly number.
 * Ugly numbers are positive numbers whose prime factors only include 2, 3, 5.
 * 
 * Input: 6
 * Output: true
 * Explanation: 6 = 2 × 3
 * 
 * Input: 8
 * Output: true
 * Explanation: 8 = 2 × 2 × 2
 * 
 * Input: 14
 * Output: false 
 * Explanation: 14 is not ugly since it includes another prime factor 7.
 * 
 * Note:
 * 
 * 1 is typically treated as an ugly number.
 * Input is within the 32-bit signed integer range: [−2^31,  2^31 − 1]. 
 * 
 *******************************************************************************************************************************/

public class Solution263
{
    // --------------- O(n) 32ms --------------- 12.9MB --------------- (99.6% 100%) ※
    /*
     * attention: 0 % x == 0 !!! 
     */
    public bool IsUgly_1(int num)
    {
        if (num <= 0) { return false; }
        while (num % 2 == 0)
        {
            num = num / 2;
        }
        while (num % 3 == 0)
        {
            num = num / 3;
        }
        while (num % 5 == 0)
        {
            num = num / 5;
        }

        return num == 1;
    }

    // --------------- O(n) 32ms --------------- 12.9MB --------------- (99.6% 100%)
    public bool IsUgly_2(int num)
    {
        for (int i = 2; i < 6 && num > 0; i++)
        {
            while (num % i == 0)
            {
                num = num / i;
            }
        }
        return num == 1;
    }
}
/**************************************************************************************************************
 * IsUgly_1/2                                                                                                 *
 **************************************************************************************************************/