//Source  : https://leetcode.com/problems/groups-of-special-equivalent-strings/
//Author  : Xinruo Shi
//Date    : 2019-10-29
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are given an array A of strings.
 * Two strings S and T are special-equivalent if after any number of moves, S == T.
 * A move consists of choosing two indices i and j with i % 2 == j % 2, and swapping S[i] with S[j].
 * Now, a group of special-equivalent strings from A is a non-empty subset S of A such that any string not in S is not special-equivalent with any string in S.
 * Return the number of groups of special-equivalent strings from A.
 *
 * Input: ["a","b","c","a","c","c"]
 * Output: 3
 * Explanation: 3 groups ["a","a"], ["b"], ["c","c","c"]
 *
 * Input: ["aa","bb","ab","ba"]
 * Output: 4
 * Explanation: 4 groups ["aa"], ["bb"], ["ab"], ["ba"]
 *
 * Input: ["abc","acb","bac","bca","cab","cba"]
 * Output: 3
 * Explanation: 3 groups ["abc","cba"], ["acb","bca"], ["bac","cab"]
 *
 * Input: ["abcd","cdab","adcb","cbad"]
 * Output: 1
 * Explanation: 1 group ["abcd","cdab","adcb","cbad"]
 *
 * Note:
 *      1 <= A.length <= 1000
 *      1 <= A[i].length <= 20
 *      All A[i] have the same length.
 *      All A[i] consist of only lowercase letters.
 * ※
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution893
{
    // --------------- O(n*m) 128ms --------------- O(n) 29MB --------------- (48% 33%) 
    /*
     * use string = string.Join(op,list)
     */
    public int NumSpecialEquivGroups_1(string[] A)
    {
        HashSet<string> h = new HashSet<string>();
        foreach (string s in A)
        {
            int[] odd = new int[26];
            int[] even = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even[s[i] - 'a']++;
                }
                else
                {
                    odd[s[i] - 'a']++;
                }
            }

            string key = string.Join(",", odd) + string.Join(",", even);
            h.Add(key);
        }

        return h.Count;
    }

    // --------------- O(n*m) 100ms --------------- O(n) 28MB --------------- (81% 86%) ※
    /*
     * use string = new string(list)
     */
    public int NumSpecialEquivGroups_1_2(string[] A)
    {
        HashSet<string> h = new HashSet<string>();
        foreach (string s in A)
        {
            char[] odd = new char[26];
            char[] even = new char[26];
            for (int i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even[s[i] - 'a']++;
                }
                else
                {
                    odd[s[i] - 'a']++;
                }
            }

            string key = new string(even) + new string(odd);
            h.Add(key);
        }

        return h.Count;
    }


    // --------------- O(n*m) 152ms --------------- O(n) 29MB --------------- (33% 19%) 
    /*
     * Improve: use int[52] to replace int[26]*2
     */
    public int NumSpecialEquivGroups_1_3(string[] A)
    {
        HashSet<string> h = new HashSet<string>();
        foreach (string s in A)
        {
            int[] count=new int[52];
            for (int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a' + 26 * (i % 2)]++;
            }

            string key = string.Join(",", count);
            h.Add(key);
        }

        return h.Count;
    }
}
/**************************************************************************************************************
 * NumSpecialEquivGroups_1_2                                                                                  *
 **************************************************************************************************************/