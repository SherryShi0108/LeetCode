//Source  : https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/
//Author  : Xinruo Shi
//Date    : 2020-11-17
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two integers L and R, find the count of numbers in the range [L, R] (inclusive) having a prime number of set bits in their binary representation.
 * (Recall that the number of set bits an integer has is the number of 1s present when written in binary. For example, 21 written in binary is 10101 which has 3 set bits. Also, 1 is not a prime.)
 *
 * Input: L = 6, R = 10
 * Output: 4
 * Explanation:
 *      6 -> 110 (2 set bits, 2 is prime)
 *      7 -> 111 (3 set bits, 3 is prime)
 *      9 -> 1001 (2 set bits , 2 is prime)
 *      10->1010 (2 set bits , 2 is prime)
 *
 * Input: L = 10, R = 15
 * Output: 5
 * Explanation:
 *      10 -> 1010 (2 set bits, 2 is prime)
 *      11 -> 1011 (3 set bits, 3 is prime)
 *      12 -> 1100 (2 set bits, 2 is prime)
 *      13 -> 1101 (3 set bits, 3 is prime)
 *      14 -> 1110 (3 set bits, 3 is prime)
 *      15 -> 1111 (4 set bits, 4 is not prime)
 *
 * Note:
 *      L, R will be integers L <= R in the range [1, 10^6].
 *      R - L will be at most 10000.
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution762
{
    // --------------- O(n) 240ms --------------- 19MB --------------- (12% 27%) ※
    /*
     * General Solution
     */
    public int CountPrimeSetBits_1(int L, int R)
    {
        int count = 0;
        for (int i = L; i <= R; i++)
        {
            if (IsPrimeOne(i))
            {
                count++;
            }
        }
        return count;
    }

    private bool IsPrimeOne(int i)
    {
        List<int> partPrime=new List<int>(){2,3,5,7,11,13,17,19,23,29,31,37,41,47};
        int countOne = 0;
        while (i!=0)
        {
            if ((i & 1) == 1)
            {
                countOne++;
            }

            i = i >> 1;
        }

        return partPrime.Contains(countOne);
    }
}

/**************************************************************************************************************
 * HasAlternatingBits_1  HasAlternatingBits_2                                                                 *
 **************************************************************************************************************/