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
    ///+++++++++++++++++++++++++ Time Limit Exceeded +++++++++++++++++++++++++
    /*
     * Test(480/481) : too long
     * Should use new String(chars) to add char to string
     */
    public string ReverseVowels_1(string s)
    {
        string vowels = "aeiouAEIOU";
        char[] array = s.ToCharArray();

        int i = 0;
        int j = array.Length - 1;
        while (i<j)
        {
            if (!vowels.Contains(array[i].ToString()))
            {
                i++;
            }
            else if(!vowels.Contains(array[j].ToString()))
            {
                j--;
            }
            else
            {
                char temp = array[i];
                array[i++] = array[j];
                array[j--] = temp;
            }
        }
        string result = "";
        foreach (char c in array)
        {
            result += c;
        }

        return result;
    }
    ///+++++++++++++++++++++++++ Time Limit Exceeded +++++++++++++++++++++++++

    // --------------- O(n) 112ms --------------- O(n) 27.3MB --------------- (23% 25%)
    public string ReverseVowels_2(string s)
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

    // --------------- O(n) 88ms --------------- O(n) 26.2MB --------------- (95% 25%)
    /*
     * using IsVowel to Judge are much faster than Judging string.contains()
     */
    public string ReverseVowels_3(string s)
    {
        StringBuilder sb=new StringBuilder(s);
        int i = 0;
        int j = sb.Length - 1;
        while (i<j)
        {
            while (i<j&&!IsVowel(sb[i]))
            {
                i++;
            }

            while (i<j && !IsVowel(sb[j]))
            {
                j--;
            }

            if (i < j)
            {
                char temp = sb[i];
                sb[i++] = sb[j];
                sb[j--] = temp;
            }
        }

        return sb.ToString();
    }

    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' ||
               c == 'O' || c == 'U';
    }

    // --------------- O(n) 84ms --------------- O(n) 26.2MB --------------- (99% 25%) ※
    /*
     * 1. use new String(chars) to make chars to string
     * 2. use IsVowel to judge rather than string.contains()
     */
    public string ReverseVowels_4(string s)
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
 * ReverseVowels_4                                                                                            *
 **************************************************************************************************************/