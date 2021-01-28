//Source  : https://leetcode.com/problems/reverse-words-in-a-string-iii/
//Author  : Xinruo Shi
//Date    : 2019-10-21
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.
 *
 * Input: "Let's take LeetCode contest"
 * Output: "s'teL ekat edoCteeL tsetnoc"
 *
 * Note: In the string, each word is separated by single space and there will not be any extra space in the string.
 * ※
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

public class Solution557
{
    // --------------- O(n) 112ms --------------- O(n) 43MB --------------- (37% 18%) 
    public string ReverseWords_1(string s)
    {
        string[] arrays = s.Split(' ');
        string result = string.Empty;
        foreach (string str in arrays)
        {
            string temp = ReverseStr(str);
            result = result + (string.IsNullOrEmpty(result) ? "" : " ") + temp;
        }

        return result;
    }

    private string ReverseStr(string str)
    {
        char[] chars = str.ToCharArray();
        int i = 0;
        int j = chars.Length - 1;
        while (i<j)
        {
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
            i++;
            j--;
        }

        return new string(chars);
    }

    // --------------- O(n) 80ms --------------- O(n) 32MB --------------- (99% 76%) ※
    public string ReverseWords_2(string s)
    {
        StringBuilder sb = new StringBuilder();

        int start = 0;
        int end = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ' || i + 1 == s.Length)
            {
                end = s[i] == ' ' ? i - 1 : i;
                while (start <= end)
                {
                    sb.Append(s[end--]);
                }

                start = i + 1;
                sb.Append(s[i] == ' ' ? " " : "");
            }
        }

        return sb.ToString();
    }
}
/**************************************************************************************************************
 * ReverseWords_2                                                                                             *
 **************************************************************************************************************/