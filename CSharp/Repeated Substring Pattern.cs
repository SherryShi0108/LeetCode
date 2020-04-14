//Source  : https://leetcode.com/problems/repeated-substring-pattern/
//Author  : Xinruo Shi
//Date    : 2019-10-19
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty string check if it can be constructed by taking a substring of it and appending multiple copies of the substring together.
 * You may assume the given string consists of lowercase English letters only and its length will not exceed 10000.
 *
 * Input: "abab"
 * Output: True
 * Explanation: It's the substring "ab" twice.
 *
 * Input: "aba"
 * Output: False
 *
 * Input: "abcabcabcabc"
 * Output: True
 * Explanation: It's the substring "abc" four times. (And the substring "abcabc" twice.)
 * 
 *******************************************************************************************************************************/

public class Solution459
{
    /*
     * time limited , but this solution is true 
     */
    public bool RepeatedSubstringPattern_1(string s) 
    {
        for (int i = s.Length/2; i >0 ; i--)
        {
            if (s.Length % i == 0)
            {
                string temp = "";
                int times = s.Length / i;
                for (int j = 0; j < times; j++)
                {
                    temp += s.Substring(0, i);
                }

                if (temp.Equals(s)) return true;
            }
        }

        return false;
    }
    
    // --------------- O(n^2) 80ms --------------- 31MB --------------- (98% 67%) ※
    /*
     * easy-understanding
     */
    public bool RepeatedSubstringPattern_3(string s)
    {
        for (int i = 1; i <= s.Length / 2; i++)
        {
            if (s.Length % i == 0)
            {
                bool repeat = true;
                for (int j = i; j < s.Length; j++)
                {
                    if (s[j - i] != s[j])
                    {
                        repeat = false;
                        break;
                    }
                }

                if (repeat) return true;
            }
        }

        return false;
    }

    // --------------- O(1) 204ms --------------- 35MB --------------- (35% 67%)
    /*
     * so tricky , math knowledge
     */
    public bool RepeatedSubstringPattern_3(string s)
    {
        string str = s + s;
        return str.Substring(1, str.Length - 2).Contains(s);
    }
}
/**************************************************************************************************************
 * RepeatedSubstringPattern_2 RepeatedSubstringPattern_3                                                      *
 **************************************************************************************************************/
