//Source  : https://leetcode.com/problems/longest-word-in-dictionary/
//Author  : Xinruo Shi
//Date    : 2019-08-18
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a list of strings words representing an English Dictionary, find the longest word in words that can be built 
 * one character at a time by other words in words. If there is more than one possible answer, return the longest word 
 * with the smallest lexicographical order. If there is no answer, return the empty string.
 * 
 * Input:  words = ["w","wo","wor","worl", "world"]
 * Output: "world"
 * Explanation: The word "world" can be built one character at a time by "w", "wo", "wor", and "worl".
 * 
 * Input: words = ["a", "banana", "app", "appl", "ap", "apply", "apple"]
 * Output: "apple"
 * Explanation: Both "apply" and "apple" can be built from other words in the dictionary. However, "apple" is lexicographically smaller than "apply".
 * 
 * Note:
 *      All the strings in the input will only contain lowercase letters.
 *      The length of words will be in the range [1, 1000].
 *      The length of words[i] will be in the range [1, 30].
 * ※
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution720
{
    // --------------- O(n) 320ms --------------- 30.5MB --------------- (60% 100%)
    public string LongestWord_1(string[] words)
    {
        string[] x = (string[])words.Clone();
        Array.Sort(x);

        HashSet<string> H = new HashSet<string>();
        string result = "";
        int count = 0;

        foreach (string item in x)
        {
            string t = item.Substring(0, item.Length - 1);
            if (H.Contains(t) || item.Length == 1)
            {
                H.Add(item);
                result = item.Length > count ? item : result;
                count = item.Length > count ? item.Length : count;
            }
        }
        return result;
    }

    /*
     * use trie tree
     */
    public string LongestWord_2(string[] words)
    {
        return "";
    }
}
/**************************************************************************************************************
 * LongestWord_1  LongestWord_2                                                                               *
 **************************************************************************************************************/