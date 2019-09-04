//Source  : https://leetcode.com/problems/reverse-integer/
//Author  : Xinruo Shi
//Date    : 2019-09-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a 32-bit signed integer, reverse digits of an integer.
 * 
 * Input: 123
 * Output: 321
 * 
 * Input: -123
 * Output: -321
 * 
 * Input: 120
 * Output: 21
 * 
 * Note:
 *      Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. 
 *      For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
 * 
 *******************************************************************************************************************************/

public class Solution7
{
    // --------------- O(n) 40ms --------------- 12.9MB --------------- (87% 100%) 
    /*
     * need check overflow
     */
    public int Reverse_1(int x)
    {
        bool flag = x > 0 ? true : false;
        x = x > 0 ? x : -x;

        int result = 0;
        while (x > 0)
        {
            if (result != 0 && int.MaxValue / result < 10) { return 0; }
            result = result * 10 + x % 10;
            x = x / 10;
        }
        result = flag ? result : -result;
        return result;
    }

    // --------------- O(n) 56ms --------------- 12.8MB --------------- (13% 100%) 
    public int Reverse_2(int x)
    {
        long result = 0;

        while (x != 0)
        {
            result = result * 10 + x % 10;
            x = x / 10;
            if (result > int.MaxValue || result < int.MinValue) { return 0; }
        }

        return (int)result;
    }

    // --------------- O(n) 40ms --------------- 12.9MB --------------- (87% 100%) ※
    /*
     * improve 1+2
     */
    public int Reverse_3(int x)
    {
        bool flag = x > 0 ? true : false;
        x = x > 0 ? x : -x;

        long result = 0;
        while (x > 0)
        {
            result = result * 10 + x % 10;
            x = x / 10;
            if (result > int.MaxValue || result < int.MinValue) { return 0; };
        }

        result = flag ? result : -result;
        return (int)result;
    }

    // --------------- O(n) 44ms --------------- 12.7MB --------------- (62% 100%) 
    /*
     * use newResult overflow
     */
    public int Reverse_4(int x)
    {
        int result = 0;

        while (x != 0)
        {
            int tail = x % 10;
            int newResult = result * 10 + tail;
            if ((newResult - tail) / 10 != result) { return 0; }

            result = newResult;
            x = x / 10;
        }
        return result;
    }
}
/**************************************************************************************************************
 * Reverse_3 Reverse_4                                                                                        *
 **************************************************************************************************************/