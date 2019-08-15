//Source  : https://leetcode.com/problems/valid-anagram/
//Author  : Xinruo Shi
//Date    : 2019-08-06
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two strings s and t , write a function to determine if t is an anagram of s.
 * 
 * Input: s = "anagram", t = "nagaram"
 * Output: true
 * 
 * Input: s = "rat", t = "car"
 * Output: false
 * 
 * Note: You may assume the string contains only lowercase alphabets.
 * 
 * Follow up: What if the inputs contain unicode characters? How would you adapt your solution to such case?
 * 
 *******************************************************************************************************************************/

public class Solution242
{
    // --------------- O(n) 76ms --------------- 21.8MB ---------------(96% 25%) ※
    /*
     * if unicode , change 26 to 256
     */
    public bool IsAnagram_1(string s, string t)
    {
        if (s.Length != t.Length) { return false; }

        int[] array = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            array[s[i] - 'a']++;
            array[t[i] - 'a']--;
        }
        for (int i = 0; i < 26; i++)
        {
            if (array[i] != 0)
            {
                return false;
            }
        }
        return true;
    }
}
/**************************************************************************************************************
 * IsAnagram_1                                                                                                *
 **************************************************************************************************************/