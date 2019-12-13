//Source  : https://leetcode.com/problems/ransom-note/
//Author  : Xinruo Shi
//Date    : 2019-10-16
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an arbitrary ransom note string and another string containing letters from all the magazines, write a function that
 * will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false.
 * Each letter in the magazine string can only be used once in your ransom note.
 *
 * Note: You may assume that both strings contain only lowercase letters.
 *       canConstruct("a", "b") -> false
 *       canConstruct("aa", "ab") -> false
 *       canConstruct("aa", "aab") -> true
 * 
 *******************************************************************************************************************************/

public class Solution383
{
    // --------------- O(n) 84ms --------------- 26.6MB --------------- (72% 100%) ※
    public bool CanConstruct_1(string ransomNote, string magazine)
    {
        int[] array=new int[26];
        foreach (char c in magazine)
        {
            array[c - 'a']++;
        }

        foreach (char c in ransomNote)
        {
            if (array[c - 'a'] < 1) return false;
            array[c - 'a']--;
        }

        return true;
    }
}
/**************************************************************************************************************
 * CanConstruct_1                                                                                             *
 **************************************************************************************************************/