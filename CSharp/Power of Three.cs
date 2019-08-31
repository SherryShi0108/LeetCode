//Source  : https://leetcode.com/problems/power-of-three/
//Author  : Xinruo Shi
//Date    : 2019-09-08
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer, write a function to determine if it is a power of three.
 * 
 * Input: 27
 * Output: true
 * 
 * Input: 0
 * Output: false
 * 
 * Input: 9
 * Output: true
 * 
 * Input: 45
 * Output: false
 * 
 * Follow up: Could you do it without using any loop / recursion?
 * 
 *******************************************************************************************************************************/

using System;

public class Solution326
{
    // --------------- O(logn) 84ms --------------- 15.8MB --------------- (75% 100%) 
    public bool IsPowerOfThree_1(int n)
    {
        if (n == 0) { return false; }
        while (n % 3 == 0)
        {
            n /= 3;
        }

        return n == 1;
    }

    // --------------- O(logn) 72ms --------------- 15.8MB --------------- (95% 100%) ※
    /*
     * improve 1 : integer!!! could be negetive
     */
    public bool IsPowerOfThree_2(int n)
    {
        if (n <= 0) { return false; }
        while (n % 3 == 0)
        {
            n /= 3;
        }

        return n == 1;
    }

    // --------------- O(1) 92ms --------------- 15.6MB --------------- (50% 100%) !!!
    /*
     * int : positive 0-2^31 
     * now 3^19=1162261467; 3^20 is bigger than 2^31
     */
    public bool IsPowerOfThree_3(int n)
    {
        if (n <= 0) { return false; }
        int max = 1162261467;
        return max % n == 0;

        // return (n>0&&1162261467%n==0);
    }

    // --------------- O(1) 84ms --------------- 16.3MB --------------- (74% 40%) 
    /*
     * loga b = logc b / logc a <换底公式>
     * log3 n = log10 n / log10 3
     */
    public bool IsPowerOfThree_4(int n)
    {
        double x = Math.Log10(n) / Math.Log10(3);
        return x - (int)x == 0;
    }
}
/**************************************************************************************************************
 * IsPowerOfThree_2 IsPowerOfThree_3 IsPowerOfThree_4                                                         *
 **************************************************************************************************************/