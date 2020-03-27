//Source  : https://leetcode.com/problems/verifying-an-alien-dictionary/
//Author  : Xinruo Shi
//Date    : 2019-08-21
//Language: C#

/*******************************************************************************************************************************
 * 
 * In an alien language, surprisingly they also use english lowercase letters, but possibly in a different order. 
 * The order of the alphabet is some permutation of lowercase letters.
 * Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the 
 * given words are sorted lexicographicaly in this alien language.
 * 
 * Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
 * Output: true
 * Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.
 * 
 * Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
 * Output: false
 * Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.
 * 
 * Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
 * Output: false
 * Explanation: The first three characters "app" match, and the second string is shorter (in size.) 
 *              According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character 
 *              which is less than any other character (More info).
 *              
 * Note:
 *      1 <= words.length <= 100
 *      1 <= words[i].length <= 20
 *      order.length == 26
 *      All characters in words[i] and order are english lowercase letters.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution953
{
    // --------------- O(n) 100ms --------------- 23.3MB --------------- (38% 50%)
    public bool IsAlienSorted_1(string[] words, string order)
    {
        Dictionary<char, int> d = new Dictionary<char, int>();
        for (int i = 0; i < order.Length; i++)
        {
            d[order[i]] = i;
        }

        for (int i = 1; i < words.Length; i++)
        {
            string t1 = words[i - 1];
            string t2 = words[i];
            for (int j = 0; j < t1.Length || j < t2.Length; j++)
            {
                if (j >= t2.Length)
                {
                    return false;
                }
                if (j >= t1.Length)
                {
                    continue;
                }
                if (d[t2[j]] < d[t1[j]])
                {
                    return false;
                }
                if (d[t2[j]] > d[t1[j]])
                {
                    break;
                }
            }
        }
        return true;
    }

    // --------------- O(n) 100ms --------------- 23.1MB --------------- (38% 50%)
    /*
     * similar to 1 
     */
    public bool IsAlienSorted_2(string[] words, string order)
    {
        Dictionary<char, int> d = new Dictionary<char, int>();
        for (int i = 0; i < order.Length; i++)
        {
            d[order[i]] = i;
        }

        for (int i = 1; i < words.Length; i++)
        {
            string t1 = words[i - 1];
            string t2 = words[i];

            int min = t1.Length < t2.Length ? t1.Length : t2.Length;

            int j = 0;
            for (; j < min; j++)
            {
                if (d[t2[j]] < d[t1[j]])
                {
                    return false;
                }
                if (d[t2[j]] > d[t1[j]])
                {
                    break;
                }
            }
            if (t2.Length == j) { return false; }
        }
        return true;
    }

    // --------------- O(n) 112ms --------------- 23MB --------------- (17% 50%) ※
    /*
     * use int[26]
     */
    public bool IsAlienSorted_3(string[] words, string order)
    {
        int[] array = new int[26];
        for (int i = 0; i < order.Length; i++)
        {
            array[order[i] - 'a'] = i;
        }

        for (int i = 1; i < words.Length; i++)
        {
            string t1 = words[i - 1];
            string t2 = words[i];
            int min = t1.Length < t2.Length ? t1.Length : t2.Length;

            int j = 0;
            for (j = 0; j < min; j++)
            {
                if (array[t2[j] - 'a'] < array[t1[j] - 'a'])
                {
                    return false;
                }
                else if (array[t2[j] - 'a'] > array[t1[j] - 'a'])
                {
                    break;
                }
            }
            if (j == t2.Length)
            {
                return false;
            }
        }
        return true;
    }
}
/**************************************************************************************************************
 * IsAlienSorted_2 IsAlienSorted_3                                                                            *
 **************************************************************************************************************/
