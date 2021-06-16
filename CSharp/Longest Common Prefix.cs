//Source  : https://leetcode.com/problems/longest-common-prefix/
//Author  : Xinruo Shi
//Date    : 2019-10-11
//Language: C#

/*******************************************************************************************************************************
 * 
 * Write a function to find the longest common prefix string amongst an array of strings.
 * If there is no common prefix, return an empty string "".
 *
 * Input: ["flower","flow","flight"]
 * Output: "fl"
 *
 * Input: ["dog","racecar","car"]
 * Output: ""
 * Explanation: There is no common prefix among the input strings.
 *
 * Note: All given inputs are in lowercase letters a-z.
 * 
 *******************************************************************************************************************************/

public class Solution14
{
    // --------------- O(m*n) 104ms --------------- O(1) 28MB --------------- (56% 6%) 
    /*
     * Compare each two strings 
     */
    public string LongestCommonPrefix_1(string[] strs)
    {
        if (strs == null || strs.Length == 0) return string.Empty;

        string result = strs[0];
        foreach (string str in strs)
        {
            result = CommonStrs(result, str);
            if (string.IsNullOrEmpty(result)) break;
        }

        return result;
    }

    private string CommonStrs(string s1, string s2)
    {
        string result = string.Empty;
        int minLength = s1.Length < s2.Length ? s1.Length : s2.Length;
        for (int i = 0; i < minLength; i++)
        {
            if (s1[i] == s2[i])
            {
                result += s1[i];
            }
            else
            {
                break;
            }
        }

        return result;
    }
    
    // --------------- O(m*n) 104ms --------------- O(1) 25MB --------------- (50% 60%) 
    /*
     * Compare all string ith char
     */
    public string LongestCommonPrefix_2(string[] strs)
    {
        if (strs == null || strs.Length == 0) return "";

        string result = "";
        for (int i = 0; i < strs[0].Length; i++)
        {
            char c = strs[0][i];
            for (int j = 1; j < strs.Length; j++)
            {
                if (i == strs[j].Length || strs[j][i] != c)
                {
                    return result;
                }
            }

            result += c;
        }

        return result;
    }
  
    // --------------- O(m*n) 100ms --------------- O(1) 25MB --------------- (75% 69%) ※
    /*
     * Improve 2: remove one string
     */
    public string LongestCommonPrefix_2_2(string[] strs)
    {
        if (strs == null || strs.Length == 0) return "";

        for (int i = 0; i < strs[0].Length; i++)
        {
            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j].Length == i || strs[0][i] != strs[j][i])
                {
                    return strs[0].Substring(0, i);
                }
            }
        }

        return strs[0];
    }
    
    // --------------- O(m*n) 112ms --------------- O(1) 26MB --------------- (22% 21%) 
    /*
     * Using Sort
     */
    public string LongestCommonPrefix_3(string[] strs)
    {
        if (strs == null || strs.Length == 0) return "";

        Array.Sort(strs);
        int minLength = strs[0].Length < strs[strs.Length - 1].Length
            ? strs[0].Length
            : strs[strs.Length - 1].Length;

        int i = 0;
        for (; i < minLength; i++)
        {
            if (strs[0][i] != strs[strs.Length - 1][i])
            {
                break;
            }
        }

        return strs[0].Substring(0, i);
    }
}
/**************************************************************************************************************
 * LongestCommonPrefix_2 / 3                                                                                  *
 **************************************************************************************************************/
