//Source  : https://leetcode.com/problems/number-of-1-bits/
//Author  : Xinruo Shi
//Date    : 2020-11-12
//Language: C#

/*******************************************************************************************************************************
 * 
 * Write a function that takes an unsigned integer and returns the number of '1' bits it has (also known as the Hamming weight).
 *
 * Note:
 *      Note that in some languages such as Java, there is no unsigned integer type. In this case, the input will be given as
 *      a signed integer type. It should not affect your implementation, as the integer's internal binary representation is the same, whether it is signed or unsigned.
 *      In Java, the compiler represents the signed integers using 2's complement notation. Therefore, in Example 3 above, the input represents the signed integer. -3.
 *
 * Follow up: If this function is called many times, how would you optimize it?
 *
 * Input: n = 00000000000000000000000000001011
 * Output: 3
 * Explanation: The input binary string 00000000000000000000000000001011 has a total of three '1' bits.
 *
 * Input: n = 00000000000000000000000010000000
 * Output: 1
 * Explanation: The input binary string 00000000000000000000000010000000 has a total of one '1' bit.
 *
 * Input: n = 11111111111111111111111111111101
 * Output: 31
 * Explanation: The input binary string 11111111111111111111111111111101 has a total of thirty one '1' bits.
 *
 * Constraints: The input must be a binary string of length 32
 * 
 *******************************************************************************************************************************/

public class Solution191
{
    // --------------- O(n) 44ms --------------- 15MB --------------- (49% 90%) 
    /*
     * use bit manipulation: i-> 0-31
     */
    public int HammingWeight_1(uint n)
    {
        int result = 0;
        for (int i = 0; i < 32; i++)
        {
            result += (int)(n >> i & 1);
        }

        return result;
    }
    
    // --------------- O(n) 36ms --------------- 15MB --------------- (90% 92%)
    /*
     * use a flag , flag << 1
     */
    public int HammingWeight_1_2(uint n)
    {
        int count = 0;
        int temp = 1;
        for (int i = 0; i < 32; i++)
        {
            if ((n & temp) != 0)
            {
                count++;
            }

            temp = temp << 1;
        }

        return count;
    }
    
    // --------------- O(n) 40ms --------------- 15MB --------------- (69% 35%) 
    /*
     * use bit manipulation: &1 >>1
     */
    public int HammingWeight_2(uint n)
    {
        int count = 0;
        while (n!=0)
        {
            if ((n & 1) == 1)
            {
                count++;
            }

            n = n >> 1;
        }

        return count;
    }

    // --------------- O(n) 36ms --------------- 15MB --------------- (90% 68%) ※
    /*
     * use bit manipulation: &1 >>1
     */
    public int HammingWeight_3(uint n)
    {
        int count = 0;
        while (n!=0)
        {
            count++;
            n = n & (n - 1);
        }

        return count;
    }
}
/**************************************************************************************************************
 * HammingWeight_1  HammingWeight_2  HammingWeight_3                                                          *
 **************************************************************************************************************/
