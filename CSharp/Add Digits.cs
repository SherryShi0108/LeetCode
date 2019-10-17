//Source  : https://leetcode.com/problems/add-digits/
//Author  : Xinruo Shi
//Date    : 2019-09-07
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.
 * 
 * Input: 38
 * Output: 2 
 * Explanation: The process is like: 3 + 8 = 11, 1 + 1 = 2. Since 2 has only one digit, return it.
 * 
 * Follow up:Could you do it without any loop/recursion in O(1) runtime?
 * 
 *******************************************************************************************************************************/

public class Solution258
{
    // --------------- O(n?) 44ms --------------- 12.8MB --------------- (54% 100%)
    public int AddDigits_1(int num)
    {
        while (num > 9)
        {
            int sum = 0;
            int temp = num;
            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
            }
            num = sum;
        }

        return num;
    }

    // --------------- O(1) 40ms --------------- 12.7MB --------------- (84% 100%)
    /*
     * congruence formula
     */
    public int AddDigits_2(int num)
    {
        if (num == 0) { return 0; }
        if (num % 9 == 0)
        {
            return 9;
        }
        return num % 9;
    }

    // --------------- O(1) 44ms --------------- 12.7MB --------------- (54% 100%) ※
    public int AddDigits_3(int num)
    {
        if (num == 0) { return 0; }
        int x = (num - 1) % 9 + 1;
        return x;
        // return (num - 1) % 9 + 1;      //  One Line
    }
}
/**************************************************************************************************************
 * AddDigits_3                                                                                                *
 **************************************************************************************************************/
