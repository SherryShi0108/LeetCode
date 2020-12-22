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
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution720
{
    // --------------- O(n) 320ms --------------- 33MB --------------- (60% 100%)
    public string LongestWord_1(string[] words)
    {
        Array.Sort(words);
        HashSet<string> h = new HashSet<string>();
        string result = "";

        foreach (string word in words)
        {
            if (word.Length == 1 || h.Contains(word.Substring(0, word.Length - 1)))
            {
                h.Add(word);

                if (word.Length > result.Length)
                {
                    result = word;
                }
            }
        }

        return result;
    }

    // --------------- O(n * m) 144ms --------------- 30MB --------------- (88% 100%)
    /*
     * Brute Force
     */
    public string LongestWord_2(string[] words)
    {
        string result = "";
        HashSet<string> h = new HashSet<string>(words);
        foreach (string word in words)
        {
            if (word.Length > result.Length || word.Length == result.Length && word.CompareTo(result) < 0)
            {
                bool flag = true;
                for (int i = 1; i < word.Length; i++)
                {
                    if (!h.Contains(word.Substring(0, i)))
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag) result = word;
            }
        }

        return result;
    }
    
    // --------------- O(n * m) 116ms --------------- 34MB --------------- (96% 36%) ※
    /*
     * use trie + Breadth-First Search
     */
    public string LongestWord_3(string[] words)
    {
        TrieNode root = new TrieNode() { IsWord = true, Word = "" };

        // build trie
        foreach (string word in words)
        {
            TrieNode temp = root;
            foreach (char c in word)
            {
                if (temp.Children[c - 'a'] == null)
                {
                    temp.Children[c - 'a'] = new TrieNode();
                }

                temp = temp.Children[c - 'a'];
            }

            temp.IsWord = true;
            temp.Word = word;
        }

        // find longest
        Queue<TrieNode> queue = new Queue<TrieNode>();
        queue.Enqueue(root);
        string result = "";

        while (queue.Count > 0)
        {
            TrieNode temp = queue.Dequeue();

            if (temp.Word.Length > result.Length)
            {
                result = temp.Word;
            }

            for (int i = 0; i < 26; i++)
            {
                if (temp.Children[i] != null && temp.Children[i].IsWord)
                {
                    queue.Enqueue(temp.Children[i]);
                }
            }
        }

        return result;
    }
    
    public class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsWord;
        public string Word;
    }
}
/**************************************************************************************************************
 * LongestWord_3                                                                                              *
 **************************************************************************************************************/
