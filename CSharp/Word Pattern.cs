//Source  : https://leetcode.com/problems/word-pattern/
//Author  : Xinruo Shi
//Date    : 2019-08-07
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a pattern and a string str, find if str follows the same pattern.
 * Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.
 * 
 * Input: pattern = "abba", str = "dog cat cat dog"
 * Output: true
 * 
 * Input:pattern = "abba", str = "dog cat cat fish"
 * Output: false
 * 
 * Input: pattern = "aaaa", str = "dog cat cat dog"
 * Output: false
 * 
 * Input: pattern = "abba", str = "dog dog dog dog"
 * Output: false
 * 
 * Notes: You may assume pattern contains only lowercase letters, and str contains lowercase letters that may be separated by a single space.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution290
{
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     * "abba" "dog dog dog dog"  should be false
     */
    public bool WordPattern_1(string pattern, string str)
    {
        Dictionary<char, string> d = new Dictionary<char, string>();
        char[] a = pattern.ToCharArray();
        string[] b = str.Split(' ');
        if (a.Length != b.Length) { return false; }

        for (int i = 0; i < a.Length; i++)
        {
            if (d.ContainsKey(a[i]))
            {
                if (d[a[i]] != b[i])
                {
                    return false;
                }
            }
            else
            {
                d[a[i]] = b[i];
            }
        }
        return true;
    }
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++

    // --------------- O(n^2) 88ms --------------- 20.1MB ---------------(35% 25%)
    /*
     * because ContainsKey is O(1) and ContainsValue is O(n)
     */
    public bool WordPattern_2(string pattern, string str)
    {
        Dictionary<char, string> d = new Dictionary<char, string>();
        char[] a = pattern.ToCharArray();
        string[] b = str.Split(' ');
        if (a.Length != b.Length) { return false; }

        for (int i = 0; i < a.Length; i++)
        {
            if (d.ContainsKey(a[i]))
            {
                if (d[a[i]] != b[i])
                {
                    return false;
                }
            }
            else
            {
                if (d.ContainsValue(b[i]))
                {
                    return false;
                }
                else
                {
                    d[a[i]] = b[i];
                }
            }
        }
        return true;
    }

    // --------------- O(n) 76ms --------------- 20.1MB ---------------(99% 25%) ※
    /*
     * use 2 hashTable
     */
    public bool WordPattern_3(string pattern, string str)
    {
        Dictionary<char, string> d = new Dictionary<char, string>();
        Dictionary<string, char> e = new Dictionary<string, char>();

        char[] a = pattern.ToCharArray();
        string[] b = str.Split(' ');
        if (a.Length != b.Length) { return false; }

        for (int i = 0; i < a.Length; i++)
        {
            if (d.ContainsKey(a[i]) && d[a[i]] != b[i])
            {
                return false;
            }
            if (e.ContainsKey(b[i]) && e[b[i]] != a[i])
            {
                return false;
            }
            d[a[i]] = b[i];
            e[b[i]] = a[i];
        }
        return true;
    }

    // --------------- O(n^2) 84ms --------------- 20.1MB ---------------(74% 25%) 
    /*
     * because ContainsKey is O(1) and ContainsValue is O(n)
     */
    public bool WordPattern_4(string pattern, string str)
    {
        Dictionary<char, string> d = new Dictionary<char, string>();
        char[] a = pattern.ToCharArray();
        string[] b = str.Split(' ');
        if (a.Length != b.Length) { return false; }

        for (int i = 0; i < a.Length; i++)
        {
            if (d.ContainsKey(a[i]) && d[a[i]] != b[i])
            {
                return false;
            }
            if (!d.ContainsKey(a[i]) && d.ContainsValue(b[i]))
            {
                return false;
            }
            d[a[i]] = b[i];
        }
        return true;
    }
}
/**************************************************************************************************************
 * WordPattern_2 WordPattern_3 WordPattern_2                                                                  *
 **************************************************************************************************************/
