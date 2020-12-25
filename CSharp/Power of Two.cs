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
    // --------------- O(logn) 40ms --------------- 15MB --------------- (82% 10%) ※
    /*
     *  using 
     */
    public bool IsPowerOfTwo_1(int n)
    {
        if (n < 1) return false;

        while (n % 2 == 0)
        {
            n /= 2;
        }

        return n == 1;
    }

    // --------------- O(logn) 44ms --------------- 13.8MB --------------- (59% 10%)
    /*
     * attention : n=0 is special
     */
    public bool IsPowerOfTwo_2(int n)
    {
        return n > 0 && (n & n - 1) == 0;
    }
    
    // --------------- O(logn) 40ms --------------- 15MB --------------- (83% 10%)
    /*
     * attention : 0 | any num == 0
     * int.MinValue (n-1) is overflow 
     */
    public bool IsPowerOfTwo_2_2(int n)
    {
        return n != 0 && n != int.MinValue && (n & n - 1) == 0;
        
         // if (n == 0 || n == int.MinValue) return false;
         // return (n & (n - 1)) == 0;
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
