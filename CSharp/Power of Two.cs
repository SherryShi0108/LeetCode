//Source  : https://leetcode.com/problems/power-of-two/
//Author  : Xinruo Shi
//Date    : 2019-09-05
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer, write a function to determine if it is a power of two.
 * 
 * Input: 1
 * Output: true 
 * Explanation: 20 = 1
 * 
 * Input: 16
 * Output: true
 * Explanation: 24 = 16
 * 
 * Input: 218
 * Output: false
 * 
 *******************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;

public class Solution231
{
    // --------------- O(logn) 44ms --------------- 13.8MB --------------- (59% 10%)
    /*
     * attention: integer!!!
     */
    public bool IsPowerOfTwo_1(int n)
    {
        if (n < 1)
        {
            return false;
        }

        while (n > 1)
        {
            if (n % 2 > 0)
            {
                return false;
            }

            n = n / 2;
        }

        return true;
    }
    
    // --------------- O(logn) 40ms --------------- 15MB --------------- (82% 10%) ※
    /*
     * improve 1
     */
    public bool IsPowerOfTwo_1_2(int n)
    {
        if (n < 1) return false;

        while (n % 2 == 0)
        {
            n /= 2;
        }

        return n == 1;
    }

    // --------------- O(logn) 44ms --------------- 13.8MB --------------- (59% 10%)
    public bool IsPowerOfTwo_2(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        bool a = (n & (n - 1)) == 0;

        return a;
    }

    // --------------- O(logn) 44ms --------------- 13.7MB --------------- (59% 10%)
    /*
     * improve 2
     */
    public bool IsPowerOfTwo_2_2(int n)
    {
        return n > 0 && ((n & (n - 1)) == 0);
    }

    // --------------- O(1) 56ms --------------- 17.1MB --------------- (10% 10%)
    /*
     * use math table
     */
    public bool IsPowerOfTwo_3(int n)
    {
        HashSet<int> H=new HashSet<int>(){1,2,4,8,16,32,64, 128, 256, 512, 1024, 2048, 4096, 8192,
            16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216,
            33554432, 67108864, 134217728, 268435456, 536870912, 1073741824 };

        return H.Contains(n);

        //return n > 0 && (1073741824 % n == 0);
    }
}
/**************************************************************************************************************
 * IsPowerOfTwo_1 IsPowerOfTwo_2                                                                              *
 **************************************************************************************************************/
