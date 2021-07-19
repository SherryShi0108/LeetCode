//Source  : https://leetcode.com/problems/power-of-four/
//Author  : Xinruo Shi
//Date    : 2020-11-12
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer n, return true if it is a power of four. Otherwise, return false.
 *
 * An integer n is a power of four, if there exists an integer x such that n == 4^x.
 *
 * Input: n = 16
 * Output: true
 *
 * Input: n = 5
 * Output: false
 *
 * Input: n = 1
 * Output: true
 *
 * Constraints: -2^31 <= n <= 2^31 - 1
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution342
{
    // --------------- O(n) 36ms --------------- 15MB --------------- (99% 83%) ※
    /*
     * general solution
     */
    public bool IsPowerOfFour_1(int n)
    {
        if (n <= 0) return false;
        if (n == 1) return true;

        while (n > 1)
        {
            if (n % 4 != 0)
            {
                return false;
            }

            n >>= 2;
        }

        return true;
    }
    
    // --------------- O(n) 44ms --------------- 15MB --------------- (44% 64%) 
    /*
     *  Using Bit
     */
    public bool IsPowerOfFour_2(int n)
    {
        if (n <= 0) return false;

        if ((n & (n - 1)) != 0) return false;

        for (int i = 1; i < 32; i+=2)
        {
            if (((n >> i) & 1) == 1)
            {
                return false;
            }
        }

        return true;
    }

    // --------------- O(n) 76ms --------------- 15MB --------------- (44% 85%) 
    /*
     * use tricky
     * 0x55555555 = 10101010101010101...
     */
    public bool IsPowerOfFour_2_2(int n)
    {
        return n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) != 0;
    }

    // --------------- O(n) 56ms --------------- 15MB --------------- (44% 99%)
    /*
     * 4^n-1 must be 3*k
     * 4^n-1 = ( 2^n+1 ) * ( 2^n-1 ), among any 3 consecutive numbers, there must be one that is a multiple of 3
     * 2^n must not be 3k,so 2^n-1 / 2^n+1 must has one is 3k,so 4^n-1 must be 3K
     */
    public bool IsPowerOfFour_3(int n)
    {
        return n > 0 && (n & (n - 1)) == 0 && (n - 1) % 3 == 0;
    }

    // --------------- O(n) 64ms --------------- 16MB --------------- (44% 15%)
    /*
     * use Math 
     */
    public bool IsPowerOfFour_3_2(int n)
    {
        double temp = Math.Log(n) / Math.Log(4);
        return n > 0 && temp - (int) temp == 0;
    }

    // --------------- O(n) 48ms --------------- 16B --------------- (44% 15%)
    /*
     * Direct 
     */
    public bool IsPowerOfFour_4(int n)
    {
        List<int> powersOfFour=new List<int>(){1, 4, 16, 64, 256, 1024, 4096, 16384, 65536, 262144, 1048576,
            4194304, 16777216, 67108864, 268435456, 1073741824};

        return powersOfFour.Contains(n);
    }
}

/**************************************************************************************************************
 * IsPowerOfFour_1 IsPowerOfFour_2 IsPowerOfFour_3                                                            *
 **************************************************************************************************************/
