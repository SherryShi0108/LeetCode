﻿//Source  : https://leetcode.com/problems/palindrome-number/
//Author  : Xinruo Shi
//Date    : 2019-09-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
 * 
 * Input: 121
 * Output: true
 * 
 * Input: -121
 * Output: false
 * Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
 * 
 * Input: 10
 * Output: false
 * Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 * 
 * Follow up: Coud you solve it without converting the integer to a string?
 * ※
 *******************************************************************************************************************************/

public class Solution9
{
    // --------------- 72ms --------------- 15.5MB --------------- (48% 15%)
    public bool IsPalindrome_1(int x)
    {
        string s = x.ToString();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    // --------------- 60ms --------------- 14.9MB --------------- (89% 20%)
    public bool IsPalindrome_2(int x)
    {
        if (x < 0 || x % 10 == 0 && x != 0)
        {
            return false;
        }

        int a = x;
        int b = 0;
        while (a > 0)
        {
            b = b * 10 + a % 10;
            a /= 10;
        }

        return b == x;
    }
}
/**************************************************************************************************************
 * IsPalindrome_2                                                                                             *
 **************************************************************************************************************/