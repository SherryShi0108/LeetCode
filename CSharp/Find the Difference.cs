﻿//Source  : https://leetcode.com/problems/find-the-difference/
//Author  : Xinruo Shi
//Date    : 2019-08-11
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two strings s and t which consist of only lowercase letters.
 * String t is generated by random shuffling string s and then add one more letter at a random position.
 * Find the letter that was added in t.
 * 
 * Input:   s = "abcd"      t = "abcde"
 * Output: e
 * Explanation: 'e' is the letter that was added.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution389
{
    // --------------- O(n) 108ms --------------- 22.9MB ---------------(36% 20%)
    public char FindTheDifference_1(string s, string t)
    {
        char[] x = s.ToCharArray();
        char[] y = t.ToCharArray();

        Dictionary<char, int> d = new Dictionary<char, int>();
        for (int i = 0; i < x.Length; i++)
        {
            if (d.ContainsKey(x[i]))
            {
                d[x[i]]++;
            }
            else
            {
                d[x[i]] = 1;
            }
        }

        char m = '#';
        for (int i = 0; i < t.Length; i++)
        {
            if (d.ContainsKey(y[i]))
            {
                d[y[i]]--;
                if (d[y[i]] < 0)
                {
                    m = t[i];
                    break;
                }
            }
            else
            {
                m = t[i]; break;
            }
        }
        return m;
    }

    // --------------- O(n) 96ms --------------- 22.8MB ---------------(90% 20%)
    /*
     * smart solution , use array[26]
     */
    public char FindTheDifference_2(string s, string t)
    {
        int[] array = new int[26];
        foreach (char item in t)
        {
            array[item - 'a']++;
        }
        foreach (char item in s)
        {
            array[item - 'a']--;
        }

        char x = '#';
        for (int i = 0; i < 26; i++)
        {
            if (array[i] != 0)
            {
                x = (char)('a' + i);
                break;
            }
        }
        return x;
    }

    // --------------- O(n) 100ms --------------- 22.6MB ---------------(75% 20%) ※
    /*
     * use XOR , cause x^x=0 , 0^y=y
     */
    public char FindTheDifference_3(string s, string t)
    {
        int sum = 0;
        foreach (char item in s)
        {
            sum ^= item;
        }
        foreach (char item in t)
        {
            sum ^= item;
        }

        return (char)sum;
    }
}
/**************************************************************************************************************
 * FindTheDifference_2 FindTheDifference_3                                                                    *
 **************************************************************************************************************/