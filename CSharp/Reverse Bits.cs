//Source  : https://leetcode.com/problems/reverse-bits/
//Author  : Xinruo Shi
//Date    : 2020-11-11
//Language: C#

/*******************************************************************************************************************************
 * 
 * Reverse bits of a given 32 bits unsigned integer.
 *
 * Note:
 *      Note that in some languages such as Java, there is no unsigned integer type. In this case, both input and output will be
 *      given as a signed integer type. They should not affect your implementation, as the integer's internal binary representation is the same, whether it is signed or unsigned.
 *
 *      In Java, the compiler represents the signed integers using 2's complement notation. Therefore, in Example 2 above,
 *      the input represents the signed integer -3 and the output represents the signed integer -1073741825.
 *
 * Follow up: If this function is called many times, how would you optimize it?
 *
 * Input: n = 00000010100101000001111010011100
 * Output:    964176192 (00111001011110000010100101000000)
 * Explanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596,
 *              so return 964176192 which its binary representation is 00111001011110000010100101000000.
 *
 * Input: n = 11111111111111111111111111111101
 * Output:   3221225471 (10111111111111111111111111111111)
 * Explanation: The input binary string 11111111111111111111111111111101 represents the unsigned integer 4294967293,
 *              so return 3221225471 which its binary representation is 10111111111111111111111111111111.
 *
 * Constraints: The input must be a binary string of length 32
 * ※
 *******************************************************************************************************************************/

public class Solution190
{
    // --------------- O(n) 44ms --------------- 16MB --------------- (66% 52%) 
    /*
     *  i = 31-0  / reverse 0-31
     */
    public uint ReverseBits_1(uint n)
    {
        uint temp = 1;
        uint result = 0;
        for (int i = 31; i >= 0; i--)
        {
            result += (n >> i & 1) * temp;
            temp *= 2;
        }

        return result;
    }

    // --------------- O(n) 48ms --------------- 16MB --------------- (24% 86%) 
    /*
     *  i = 0-31
     */
    public uint ReverseBits_1_2(uint n)
    {
        uint result = 0;
        for (int i = 0; i < 32; i++)
        {
            result = result << 1;
            result = result | (n & 1);
            n = n >> 1;
        }

        return result;
    }

    // --------------- O(n) 48ms --------------- 16MB --------------- (24% 86%) ※
    /*
     * During the interview, one might be asked to reverse the entire 32 bits without using loop.
     * Here we propose one solution that utilizes only the bit operations.
     */
    public uint ReverseBits_2(uint n)
    {
        n = (n >> 16) | (n << 16);
        n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
        n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
        n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
        n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
        return n;
    }
}
/**************************************************************************************************************
 * ReverseBits_1/1_2    ReverseBits_2                                                                         *
 **************************************************************************************************************/