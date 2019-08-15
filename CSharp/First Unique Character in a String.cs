//Source  : https://leetcode.com/problems/first-unique-character-in-a-string/
//Author  : Xinruo Shi
//Date    : 2019-08-10
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
 * 
 * Input: s = "leetcode"
 * Output: 0.
 * 
 * Input: s = "loveleetcode",
 * Output: 2.
 * 
 * Note: You may assume the string contain only lowercase letters.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution387
{
    // --------------- O(n) 144ms --------------- 30.1MB ---------------(22% 10%)
    public int FirstUniqChar_1(string s)
    {
        Dictionary<char, int> d = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (d.ContainsKey(s[i]))
            {
                d[s[i]]++;
            }
            else
            {
                d[s[i]] = 1;
            }
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (d[s[i]] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    // --------------- O(n) 88ms --------------- 30MB ---------------(93% 10%) ※
    public int FirstUniqChar_2(string s)
    {
        int[] array = new int[26];

        foreach (char item in s)
        {
            array[item - 'a']++;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (array[s[i] - 'a'] == 1)
            {
                return i;
            }
        }
        return -1;
    }
}
/**************************************************************************************************************
 * FirstUniqChar_2                                                                                            *
 **************************************************************************************************************/