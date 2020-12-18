//Source  : https://leetcode.com/problems/longest-palindrome/
//Author  : Xinruo Shi
//Date    : 2019-08-12
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.
 * This is case sensitive, for example "Aa" is not considered a palindrome here.
 * 
 * Note: Assume the length of given string will not exceed 1,010.
 * 
 * Input: "abccccdd"
 * Output: 7
 * 
 * Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic; // Dictionary NameSpace

public class Solution409
{
    // --------------- O(n) 80ms --------------- 20.3MB ---------------(71% 67%)
    /*
     * similar to 1
     */
    public int LongestPalindrome_1(string s)
    {
        Dictionary<char, int> d = new Dictionary<char, int>();
        foreach (char item in s)
        {
            if (d.ContainsKey(item))
            {
                d[item]++;
            }
            else
            {
                d[item] = 1;
            }
        }

        int countEqule1 = 0;
        int sum = 0;
        foreach (var item in d)
        {
            if (item.Value % 2 == 0)
            {
                sum += item.Value;
            }
            else
            {
                countEqule1 = 1;
                sum += item.Value - 1;
            }
        }
        return sum + countEqule1;
    }

    // --------------- O(n) 80ms --------------- 20.5MB ---------------(71% 33%) 
    /*
     * use array[58] , because A:65 z:122, so 0-57
     * A: 65  a: 97
     */
    public int LongestPalindrome_2(string s)
    {
        int[] array = new int[58];
        for (int i = 0; i < s.Length; i++)
        {
            array[s[i] - 'A']++;
        }

        int countEqule1 = 0;
        int sum = 0;
        for (int i = 0; i < 58; i++)
        {
            if (array[i] % 2 == 0)
            {
                sum += array[i];
            }
            else
            {
                sum += array[i] - 1;
                countEqule1 = 1;
            }
        }
        return sum + countEqule1;
    }

    // --------------- O(n) 72ms --------------- 20.3MB ---------------(99% 67%)
    /*
     * improve 2
     */
    public int LongestPalindrome_2_2(string s)
    {
        int[] array = new int[58];
        for (int i = 0; i < s.Length; i++)
        {
            array[s[i] - 'A']++;
        }

        int countEqule1 = 0;
        int sum = 0;
        for (int i = 0; i < 58; i++)
        {
            if (array[i] % 2 != 0)
            {
                countEqule1++;
            }
            sum += array[i];
        }
        sum = sum - (countEqule1 == 0 ? 0 : (countEqule1 - 1));

        return sum;
    }
    
    // --------------- O(n) 76ms --------------- 21.8MB ---------------(82% 34%) 
    public int LongestPalindrome_3(string s)
    {
        HashSet<char> h = new HashSet<char>();
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (h.Contains(s[i]))
            {
                count += 2;
                h.Remove(s[i]);
            }
            else
            {
                h.Add(s[i]);
            }
        }

        return h.Count > 0 ? count + 1 : count;
    }
    
    // --------------- O(n) 72ms --------------- 23MB ---------------(82% 68%) ※
    public int LongestPalindrome_3_2(string s)
    {
        int count = 0;

        HashSet<char> h = new HashSet<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (h.Add(s[i]) == false)
            {
                h.Remove(s[i]);
                count += 2;
            }
        }

        return count + h.Count > 0 ? 1 : 0;
    }
}
/**************************************************************************************************************
 * LongestPalindrome_3                                                                                        *
 **************************************************************************************************************/
