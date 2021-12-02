//Source  : https://leetcode.com/problems/longest-substring-without-repeating-characters/
//Author  : Xinruo Shi
//Date    : 2020-11-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string s, find the length of the longest substring without repeating characters.
 * 
 * Input: s = "abcabcbb"
 * Output: 3
 * Explanation: The answer is "abc", with the length of 3.
 * 
 * Input: s = "bbbbb"
 * Output: 1
 * Explanation: The answer is "b", with the length of 1.
 * 
 * Input: s = "pwwkew"
 * Output: 3
 * Explanation: The answer is "wke", with the length of 3.Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 * 
 * Input: s = ""
 * Output: 0
 * 
 * Constraints:
 *      0 <= s.length <= 5 * 104
 *      s consists of English letters, digits, symbols and spaces.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution3
{
    // --------------- O(n) 72s --------------- O(n) 39MB --------------- (90% 31%)
    public int LengthOfLongestSubstring_1(string s)
    {
        int maxLength = 0;
        int length = 0;
        int lastIndex = 0;

        Dictionary<char, int> dic = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (dic.ContainsKey(s[i]))
            {
                int temp = dic[s[i]];
                for (int j = lastIndex; j <= temp; j++)
                {
                    dic.Remove(s[j]);
                }
                lastIndex = temp + 1;
                length = i - lastIndex + 1;
                dic[s[i]] = i;
            }
            else
            {
                dic[s[i]] = i;
                length++;
                maxLength = maxLength > length ? maxLength : length;
            }
        }

        return maxLength;
    }

    // --------------- O(n) 72s --------------- O(n) 40MB --------------- (90% 6%)
    public int LengthOfLongestSubstring_2(string s)
    {
        int[] dict = new int[256];
        int maxLength = 0;
        int i = 0;
        int j = 0;
        for (; j < s.Length; j++)
        {
            char c = s[j];
            dict[c]++;
            while (dict[c] > 1)
            {
                dict[s[i++]]--;
            }

            maxLength = maxLength > j - i + 1 ? maxLength : j - i + 1;
        }

        return maxLength;
    }

    // --------------- O(n) 72s --------------- O(n) 39MB --------------- (90% 60%) ※
    public int LengthOfLongestSubstring_3(string s)
    {
        int maxLength = 0;
        int i = 0;
        int j = 0;
        List<char> list = new List<char>();
        while (i <= j && i < s.Length && j < s.Length)
        {
            if (list.Contains(s[j]))
            {
                list.Remove(s[i]);
                i++;
                continue;
            }

            maxLength = maxLength > j - i + 1 ? maxLength : j - i + 1;
            list.Add(s[j]);
            j++;
        }

        return maxLength;
    }

}

/**************************************************************************************************************
 *  LengthOfLongestSubstring_3                                                                                *
 **************************************************************************************************************/
