//Source  : https://leetcode.com/problems/to-lower-case/
//Author  : Xinruo Shi
//Date    : 2019-10-
//Language: C#

/*******************************************************************************************************************************
 * 
 * Implement function ToLowerCase() that has a string parameter str, and returns the same string in lowercase.
 *
 * Input: "Hello"
 * Output: "hello"
 *
 * Input: "here"
 * Output: "here"
 *
 * Input: "LOVELY"
 * Output: "lovely"
 * 
 *******************************************************************************************************************************/

using System;

public class Solution709
{
    // --------------- O(n) 80ms --------------- 21.9MB --------------- (93% 8%) ※
    public string ToLowerCase_1(string str)
    {
        string result = "";
        foreach (char c in str)
        {
            result += (c < 91 && c > 64) ? (char)(c + 32) : c;
        }

        return result;
    }

    // --------------- O(n) 72ms --------------- 21.8MB --------------- (99.6% 8%)
    public string ToLowerCase_2(string str)
    {
        char[] a = str.ToCharArray();
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] >= 'A' && a[i] <= 'Z')
            {
                a[i]=(char)(a[i]+32) ;

            }
        }

        return new String(a);
    }
}
/**************************************************************************************************************
 * ToLowerCase_1 ToLowerCase_2                                                                                *
 **************************************************************************************************************/