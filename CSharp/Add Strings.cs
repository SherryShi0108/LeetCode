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
    // --------------- O(n) 92ms --------------- 48MB --------------- (70% 11%) ※
    public string AddStrings_1(string num1, string num2)
    {
        string result = "";
        int i = num1.Length - 1;
        int j = num2.Length - 1;
        int k = 0;

        while (i>=0 || j>=0 || k>0)
        {
            int t1 = i >= 0 ? num1[i] - '0' : 0;
            int t2 = j >= 0 ? num2[j] - '0' : 0;

            k += t1 + t2;

            result = (k % 10).ToString() + result;
            k /= 10;

            i--;
            j--;
        }

        return result;
    }
}
/**************************************************************************************************************
 *AddStrings_1                                                                                                *
 **************************************************************************************************************/
