//Source  : https://leetcode.com/problems/reverse-vowels-of-a-string/
//Author  : Xinruo Shi
//Date    : 2019-09-26
//Language: C#

/*******************************************************************************************************************************
 * 
 * Write a function that takes a string as input and reverse only the vowels of a string.
 *
 * Input: "hello"
 * Output: "holle"
 *
 * Input: "leetcode"
 * Output: "leotcede"
 *
 * Note: The vowels does not include the letter "y".
 * 
 *******************************************************************************************************************************/

using System;
using System.Text; // StringBuilder namespace

public class Solution345
{
    // --------------- O(n) 112ms --------------- O(n) 27.3MB --------------- (23% 25%)
    public string ReverseVowels_1(string s)
    {
        string vowels = "aeiouAEIOU";
        char[] chars = s.ToCharArray();
        int i = 0;
        int j = chars.Length - 1;
        while (i<j)
        {
            while (i<j&&!vowels.Contains(chars[i].ToString()))
            {
                i++;
            }

            while (i<j&&!vowels.Contains(chars[j].ToString()))
            {
                j--;
            }

            char temp = chars[i];
            chars[i++] = chars[j];
            chars[j--] = temp;
        }

        return new String(chars);
    }

    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' ||
               c == 'O' || c == 'U';
    }

    // --------------- O(n) 84ms --------------- O(n) 26.2MB --------------- (99% 25%) ※
    /*
     * imorove 1
     * 1. use new String(chars) to make chars to string
     * 2. use IsVowel to judge rather than string.contains()
     */
    public string ReverseVowels_1_1(string s)
    {
        char[] chars = s.ToCharArray();
        int i = 0;
        int j = chars.Length - 1;
        while (i < j)
        {
            while (i < j && !IsVowel(chars[i]))
            {
                i++;
            }

            while (i < j && !IsVowel(chars[j]))
            {
                j--;
            }

            char temp = chars[i];
            chars[i++] = chars[j];
            chars[j--] = temp;
        }

        return new String(chars);
    }
}
/**************************************************************************************************************
 * ReverseVowels_2                                                                                            *
 **************************************************************************************************************/
