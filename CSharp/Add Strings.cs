//Source  : https://leetcode.com/problems/add-strings/
//Author  : Xinruo Shi
//Date    : 2019-10-25
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
 *
 * Note:
 *      The length of both num1 and num2 is < 5100.
 *      Both num1 and num2 contains only digits 0-9.
 *      Both num1 and num2 does not contain any leading zero.
 *      You must not use any built-in BigInteger library or convert the inputs to integer directly.
 * 
 *******************************************************************************************************************************/

public class Solution415
{
    // --------------- O(n) 108ms --------------- 46MB --------------- (36% 13%) ※
    public string AddStrings_1(string num1, string num2)
    {
        int m = num1.Length - 1;
        int n = num2.Length - 1;
        string result = "";
        int add = 0;

        while (m>=0||n>=0||add>0)
        {
            int t = (m >= 0 ? num1[m] - '0' : 0) + (n >= 0 ? num2[n] - '0' : 0) + add;
            add = t / 10;
            result = t % 10 + result;

            m--;
            n--;
        }

        return result;
    }
}
/**************************************************************************************************************
 *AddStrings_1                                                                                                *
 **************************************************************************************************************/