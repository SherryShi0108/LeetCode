//Source  : https://leetcode.com/problems/number-complement/
//Author  : Xinruo Shi
//Date    : 2020-11-15
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a positive integer num, output its complement number. The complement strategy is to flip the bits of its binary representation.
 *
 * Input: num = 5
 * Output: 2
 * Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
 *
 * Input: num = 1
 * Output: 0
 * Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
 *
 * Constraints:
 *      The given integer num is guaranteed to fit within the range of a 32-bit signed integer.
 *      num >= 1
 *      You could assume no leading zero bit in the integer’s binary representation.
 *      This question is the same as 1009
 * 
 *******************************************************************************************************************************/

using System;

public class Solution476
{
    // --------------- O(n) 40ms --------------- 15MB --------------- (67% 80%) ※
    /* 
     * use &1 get last number ; ^1 get complement number
     */
    public int FindComplement_1(int num)
    {
        int result = 0;
        int mul = 1;
        while (num != 0)
        {
            result += ((num & 1) ^ 1) * mul;
            mul *= 2;
            num = num >> 1;
        }

        return result;
    }

    // --------------- O(n) 40ms --------------- 16B --------------- (67% 6%)
    /* 
     * get 1111111(n) - 1001010(n)
     */
    public int FindComplement_2(int num)
    {
        double i = 0;
        double j = 0;

        while (i < num)
        {
            i += Math.Pow(2, j);
            j++;
        }

        return (int) i - num;
    }
}
/**************************************************************************************************************
 * FindComplement_1  FindComplement_2                                                                         *
 **************************************************************************************************************/