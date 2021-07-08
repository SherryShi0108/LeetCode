//Source  : https://leetcode.com/problems/is-subsequence/
//Author  : Xinruo Shi
//Date    : 2019-12-05
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string s and a string t, check if s is subsequence of t.
 * You may assume that there is only lower case English letters in both s and t. t is potentially a very long (length ~= 500,000) string,
 * and s is a short string (<=100).
 *
 * A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the
 * characters without disturbing the relative positions of the remaining characters. (ie, "ace" is a subsequence of "abcde" while "aec" is not).
 *
 * s = "abc", t = "ahbgdc"
 * Return true.
 *
 * s = "axc", t = "ahbgdc"
 * Return false.
 *
 * Follow up:
 * If there are lots of incoming S, say S1, S2, ... , Sk where k >= 1B, and you want to check one by one to see
 * if T has its subsequence. In this scenario, how would you change your code?
 *
 * Credits: Special thanks to @pbrother for adding this problem and creating all test cases.
 * 
 *******************************************************************************************************************************/

public class Solution392
{
    // --------------- O(n) 88ms --------------- 37.1MB ---------------(71% 100%) 
    /*
     * great solution!
     */
    public bool IsSubsequence_1(string s, string t)
    {
        if (s.Length == 0) return true;
        int j = 0;
        for (int i = 0; i < t.Length; i++)
        {
            if (s[j] == t[i])
            {
                j++;
                if (j == s.Length) return true;
            }
        }

        return false;
    }
    
    // --------------- O(n) 96ms --------------- 37.1MB ---------------(15% 100%) ※
    public bool IsSubsequence_1_2(string s, string t)
    {
        int i = 0;
        int j = 0;

        while (i < t.Length && j < s.Length)
        {
            if (t[i] == s[j])
            {
                i++;
                j++;
            }
            else
            {
                i++;
            }
        }

        return j == s.Length;
    }
    
    /* Follow up:  using Dictionary<char,int[]> , int[] invoved each char index in T */
    // --------------- O(n*m) 128ms --------------- 22MB ---------------(6% 41%) 
    public bool IsSubsequence_2(string s, string t)
    {
        Dictionary<char, List<int>> d = new Dictionary<char, List<int>>();
        for (int i = 0; i < t.Length; i++)
        {
            if (d.ContainsKey(t[i]) == false)
            {
                d[t[i]] = new List<int>();
            }
            d[t[i]].Add(i);
        }

        int prev = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (d.ContainsKey(s[i]) == false) return false;
            int temp = -1;
            foreach (int i1 in d[s[i]])
            {
                if (i1 >= prev)
                {
                    temp = i1;
                    break;
                }
            }

            if (temp == -1) return false;
            prev = temp + 1;
        }

        return true;
    }
    
    // --------------- O(nlogm) 120ms --------------- 23MB ---------------(7% 16%) 
    /*
     * improve: using Array.BinarySearch
     */
    public bool IsSubsequence_2_2(string s, string t)
    {
        Dictionary<char, List<int>> d = new Dictionary<char, List<int>>();
        for (int i = 0; i < t.Length; i++)
        {
            if (d.ContainsKey(t[i]) == false)
            {
                d[t[i]] = new List<int>();
            }

            d[t[i]].Add(i);
        }

        int prev = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (d.ContainsKey(s[i]) == false) return false;
            int temp = Array.BinarySearch(d[s[i]].ToArray(), prev);
            temp = temp < 0 ? -(temp + 1) : temp; // BinarySearch Method Return Rule
            if (temp == d[s[i]].Count) return false;
            prev = d[s[i]][temp] + 1;
        }

        return true;
    }
}
/**************************************************************************************************************
 * IsSubsequence_1     IsSubsequence_2                                                                        *
 **************************************************************************************************************/
