﻿//Source  : https://leetcode.com/problems/count-and-say/
//Author  : Xinruo Shi
//Date    : 2019-10-16
//Language: C#

/*******************************************************************************************************************************
 * 
 * The count-and-say sequence is the sequence of integers with the first five terms as following:
 *      1.     1
 *      2.     11
 *      3.     21
 *      4.     1211
 *      5.     111221
 *      1 is read off as "one 1" or 11.
 *      11 is read off as "two 1s" or 21.
 *      21 is read off as "one 2, then one 1" or 1211.
 *      Given an integer n where 1 ≤ n ≤ 30, generate the nth term of the count-and-say sequence.
 *
 * Note: Each term of the sequence of integers will be represented as a string.
 *
 * Input: 1
 * Output: "1"
 *
 * Input: 4
 * Output: "1211"
 * 
 *******************************************************************************************************************************/

public class Solution38
{
    // --------------- O(n^2) 112ms --------------- 28MB ---------------(6% 6%)
    public string CountAndSay_1(int n)
    {
        string result = "1";
        for (int i = 1; i < n; i++)
        {
            result = CountId(result);
        }

        return result;
    }

    public string CountId(string s)
    {
        string result = "";
        char temp = s[0];
        int count = 1;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == temp)
            {
                count++;
            }
            else
            {
                result += count.ToString() + temp;

                count = 1;
                temp = s[i];
            }
        }

        result += count.ToString() + temp;
        return result;
    }
    
    // --------------- O(n^2) 88ms --------------- 28MB ---------------(49% 6%) ※
    /*
     * !!! Attention : count.ToString() NOT count
     */
    public string CountAndSay_1_2(int n)
    {
        string result = "1";
        while (n > 1)
        {
            result = CountAndSayMethod(result);
            n--;
        }

        return result;
    }
    
    private string CountAndSayMethod(string s)
    {
        string result = "";

        int count = 1;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                result = result + (count.ToString() + s[i - 1]);
                count = 1;
            }
        }

        return result + (count.ToString() + s[s.Length - 1]);
    }
}
/**************************************************************************************************************
 * CountAndSay_2                                                                                              *
 **************************************************************************************************************/
