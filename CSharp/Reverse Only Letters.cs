//Source  : https://leetcode.com/problems/reverse-only-letters/
//Author  : Xinruo Shi
//Date    : 2019-10-30
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string S, return the "reversed" string where all characters that are not a letter stay in the same place, and all letters reverse their positions.
 * Input: "ab-cd"
 * Output: "dc-ba"
 *
 * Input: "a-bC-dEf-ghIj"
 * Output: "j-Ih-gfE-dCba"
 *
 * Input: "Test1ng-Leet=code-Q!"
 * Output: "Qedo1ct-eeLg=ntse-T!"
 *
 * Note:
 *      S.length <= 100
 *      33 <= S[i].ASCIIcode <= 122 
 *      S doesn't contain \ or "
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution917
{
    // --------------- O(n) 84ms --------------- 22.2MB --------------- (75% 20%) ※
    public string ReverseOnlyLetters_1(string S)
    {
        char[] chars = S.ToCharArray();
        int i = 0;
        int j = chars.Length - 1;
        while (i<j)
        {
            if (!IsLetter(chars[i]))
            {
                i++;
            }
            else if(!IsLetter(chars[j]))
            {
                j--;
            }
            else
            {
                char temp = chars[i];
                chars[i++] = chars[j];
                chars[j--] = temp;
            }
        }
        return new String(chars);
    }

    private bool IsLetter(char c)
    {
        if (c <= 90 && c >= 65 || c <= 122 && c >= 97) return true;
        return false;
    }

    // --------------- O(n) 88ms --------------- 22.3MB --------------- (42% 20%)
    /*
     * use stack
     */
    public string ReverseOnlyLetters_2(string S)
    {
        Stack<char> stack=new Stack<char>();
        foreach (char c in S)
        {
            if (IsLetter(c))
            {
                stack.Push(c);
            }
        }

        string result = "";
        foreach (char c in S)
        {
            if (IsLetter(c))
            {
                result += stack.Pop();
            }
            else
            {
                result += c;
            }
        }

        return result;
    }
}
/**************************************************************************************************************
 * ReverseOnlyLetters_1 ReverseOnlyLetters_2                                                                  *
 **************************************************************************************************************/