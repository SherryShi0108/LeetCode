//Source  : https://leetcode.com/problems/isomorphic-strings/
//Author  : Xinruo Shi
//Date    : 2019-08-04
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two strings s and t, determine if they are isomorphic.
 * Two strings are isomorphic if the characters in s can be replaced to get t.
 * All occurrences of a character must be replaced with another character while preserving the order of characters. 
 * No two characters may map to the same character but a character may map to itself.
 * 
 * Input: s = "egg", t = "add"
 * Output: true
 *
 * Input: s = "foo", t = "bar"
 * Output: false
 * 
 * Input: s = "paper", t = "title"
 * Output: true
 * 
 * Note: You may assume both s and t have the same length.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic; //Dictionary NameSpace

public class Solution205
{
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     * cause not only a-z , but character!!!  contains 123... length = 128
     */
    public bool IsIsomorphic_1(string s, string t)
    {
        int[] array = new int[27];
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (array[s[i] - 'a' + 1] == 0)
            {
                array[s[i] - 'a' + 1] = t[i] - 'a' + 1;
                count++;
            }
            else
            {
                if (array[s[i] - 'a' + 1] != t[i] - 'a' + 1)
                {
                    return false;
                }
            }
        }

        HashSet<int> H = new HashSet<int>(array);
        return H.Count == count + 1;
    }
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++

    // --------------- O(n) 76ms --------------- 21.4MB --------------- (96% 50%) ※
    public bool IsIsomorphic_2(string s, string t)
    {
        Dictionary<char, char> d1 = new Dictionary<char, char>();
        Dictionary<char, char> d2 = new Dictionary<char, char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (d1.ContainsKey(s[i]))
            {
                if (d1[s[i]] != t[i])
                {
                    return false;
                }
            }
            else
            {
                d1[s[i]] = t[i];
            }
        }
        for (int i = 0; i < t.Length; i++)
        {
            if (d2.ContainsKey(t[i]))
            {
                if (d2[t[i]] != s[i])
                {
                    return false;
                }
            }
            else
            {
                d2[t[i]] = s[i];
            }
        }

        return true;
    }

    // --------------- O(n) 80ms --------------- 21.5MB --------------- (83% 25%)
    public bool IsIsomorphic_3(string s, string t)
    {
        int[] array = new int[256];
        for (int i = 0; i < s.Length; i++)
        {
            if (array[s[i]] != 0 && array[s[i]] != t[i]) { return false; }
            if (array[128 + t[i]] != 0 && array[128 + t[i]] != s[i]) { return false; }

            array[s[i]] = t[i];
            array[128 + t[i]] = s[i];
        }
        return true;
    }

    // --------------- O(n) 80ms --------------- 21.6MB --------------- (83% 25%)
    public bool IsIsomorphic_4(string s, string t)
    {
        int[] a = new int[128];
        int[] b = new int[128];
        for (int i = 0; i < s.Length; i++)
        {
            if (a[s[i]] != b[t[i]])
            {
                return false;
            }
            a[s[i]] = i + 1;
            b[t[i]] = i + 1;
        }
        return true;
    }
    
    // --------------- O(n) 72ms --------------- 23.3MB --------------- (95% 13%)
    public bool IsIsomorphic_5(string s, string t)
    {
        if (s.Length != t.Length) return false;

            int[] c = new int[256];

            for (int i = 0; i < s.Length; i++)
            {
                if (c[s[i]] != c[128 + t[i]]) return false;

                c[s[i]] = i + 1;
                c[128 + t[i]] = i + 1;
            }
            return true;
    }
    
}
/**************************************************************************************************************
 * IsIsomorphic_2 IsIsomorphic_3 IsIsomorphic_4 IsIsomorphic_5                                                *
 **************************************************************************************************************/
