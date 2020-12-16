//Source  : https://leetcode.com/problems/binary-number-with-alternating-bits/
//Author  : Xinruo Shi
//Date    : 2020-11-16
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a positive integer, check whether it has alternating bits: namely, if two adjacent bits will always have different values.
 *
 * Input: n = 5
 * Output: true
 * Explanation: The binary representation of 5 is: 101
 *
 * Input: n = 7
 * Output: false
 * Explanation: The binary representation of 7 is: 111.
 *
 * Input: n = 11
 * Output: false
 * Explanation: The binary representation of 11 is: 1011.
 *
 * Input: n = 10
 * Output: true
 * Explanation: The binary representation of 10 is: 1010.
 *
 * Input: n = 3
 * Output: false
 *
 * Constraints: 1 <= n <= 2^31 - 1
 * 
 *******************************************************************************************************************************/

public class Solution693
{
    // --------------- O(n) 40ms --------------- 15MB --------------- (63% 89%)
    /*
     * General Solution
     */
    public bool HasAlternatingBits_1(int n)
    {
        bool isZero = n % 2 == 0;
        n /= 2;

        while (n>0)
        {
            if ((n % 2 == 0) == isZero)
            {
                return false;
            }

            isZero = !isZero;
            n /= 2;
        }

        return true;
    }

    // --------------- O(n) 48ms --------------- 15MB --------------- (12% 50%)
    /*
     * d is last digit of n
     * 1 & X = X ; 1 & ABC = C
     */
    public bool HasAlternatingBits_1_1(int n)
    {
        int d = n & 1;
        while (d == (n & 1))
        {
            d = 1 - d;
            n = n >> 1;
        }

        return n == 0;
    }

    // --------------- O(n) 40ms --------------- 15MB --------------- (63% 50%) ※
    /*
     * Amazing Solution !!! use Bit Manipulation
     */
    public bool HasAlternatingBits_2(int n)
    {
        n = n ^ (n >> 1);
        return (n & n + 1) == 0;
    }
}

/**************************************************************************************************************
 * HasAlternatingBits_1  HasAlternatingBits_2                                                                 *
 **************************************************************************************************************/