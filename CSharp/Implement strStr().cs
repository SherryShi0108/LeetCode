//Source  : https://leetcode.com/problems/implement-strstr/
//Author  : Xinruo Shi
//Date    : 2019-09-20
//Language: C#

/*******************************************************************************************************************************
 *
 * Implement strStr(). Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
 *
 * Input: haystack = "hello", needle = "ll"
 * Output: 2
 *
 * Input: haystack = "aaaaa", needle = "bba"
 * Output: -1
 *
 * Clarification:
 *      What should we return when needle is an empty string? This is a great question to ask during an interview.
 *      For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().
 * 
 *******************************************************************************************************************************/

public class Solution28
{
    // --------------- 108ms --------------- 23.6MB --------------- (82% 100%) 
    public int StrStr_1(string haystack, string needle)
    {
        if (needle.Length == 0 || needle == null)
        {
            return 0;
        }

        for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            if (haystack[i] == needle[0])
            {
                bool flag = true;
                for (int j = 1; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    // --------------- 76ms --------------- 21.8MB --------------- (83% 7%) ※
    /*
     * Amazing solution , cannot understand
     */
    public int StrStr_2(string haystack, string needle) 
    {
        for (int i = 0; ; i++)
        {
            for (int j = 0; ; j++)
            {
                if (j == needle.Length)
                {
                    return i;
                }

                if (i + j == haystack.Length)
                {
                    return -1;
                }

                if (needle[j] != haystack[i + j])
                {
                    break;
                }
            }
        }
    }

    // --------------- 72ms --------------- 21.8MB --------------- (95% 7%) 
    public int StrStr_3(string haystack, string needle)
    {
        if (needle.Length == 0 || needle == null)
        {
            return 0;
        } 

        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            for (int j = 0; j < needle.Length && haystack[i + j] == needle[j]; j++)
                if (j == needle.Length - 1)
                    return i;
        }

        return -1;
    }
}
/**************************************************************************************************************
 * StrStr_2 / 3                                                                                               *
 **************************************************************************************************************/