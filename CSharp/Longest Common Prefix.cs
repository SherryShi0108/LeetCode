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
    
    // --------------- O(m*n) 104ms --------------- O(1) 25MB --------------- (56% 69%) 
    public string LongestCommonPrefix_2(string[] strs)
    {
        if (strs == null || strs.Length == 0) return string.Empty;

        string result = strs[0];
        int length = result.Length;

        for (int i = 1; i < strs.Length; i++)
        {
            string cur = strs[i];
            int j = 0;
            for (; j < cur.Length; j++)
            {
                if (j >= length || result[j] != cur[j]) break;
            }

            length = length < j ? length : j;
        }

        return result.Substring(0, length);
    }
    
    // --------------- O(m*n) 100ms --------------- O(1) 26MB --------------- (78% 42%) 
    public string LongestCommonPrefix_3(string[] strs)
    {
        if (strs == null || strs.Length == 0) return string.Empty;

        string result = strs[0];

        for (int i = 0; i < strs.Length; i++)
        {
            while (strs[i].IndexOf(result) != 0)
            {
                result = result.Substring(0, result.Length - 1);
                if (string.IsNullOrEmpty(result)) return string.Empty;
            }
        }

        return result;
    }
    
    // --------------- O(m*n) 100ms --------------- O(1) 25MB --------------- (79% 7%) ※
    /*
     * easy-understand
     */
    public string LongestCommonPrefix_4(string[] strs)
    {
        if (strs == null || strs.Length == 0) return "";

        for (int i = 0; i < strs[0].Length; i++)
        {
            char c = strs[0][i];
            for (int j = 1; j < strs.Length; j++)
            {
                if (i == strs[j].Length || strs[j][i] != c)
                {
                    return strs[0].Substring(0, i);
                }
            }
        }

        return strs[0];
    }

  
    
    // --------------- O(m*n) 104ms --------------- O(1) 25MB --------------- (59% 5%) 
    public string LongestCommonPrefix_5(string[] strs)
    {
        if (strs == null || strs.Length == 0) return "";
        string result = strs[0];
        for (int i = 1; i < strs.Length; i++)
        {
            while (strs[i].IndexOf(result)!=0)
            {
                result = result.Substring(0, result.Length - 1);
            }
        }

        return result;
    }
    
   
}
/**************************************************************************************************************
 * LongestCommonPrefix_1                                                                                      *
 **************************************************************************************************************/
