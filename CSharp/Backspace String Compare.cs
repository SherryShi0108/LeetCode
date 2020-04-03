//Source  : https://leetcode.com/problems/backspace-string-compare/
//Author  : Xinruo Shi
//Date    : 2019-09-25
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.
 *
 * Input: S = "ab#c", T = "ad#c"
 * Output: true
 * Explanation: Both S and T become "ac".
 *
 * Input: S = "ab##", T = "c#d#"
 * Output: true
 * Explanation: Both S and T become "".
 *
 * Input: S = "a##c", T = "#a#c"
 * Output: true
 * Explanation: Both S and T become "c".
 *
 * Input: S = "a#c", T = "b"
 * Output: false
 * Explanation: S becomes "c" while T becomes "b".
 *
 * Note:
 *      1 <= S.length <= 200
 *      1 <= T.length <= 200
 *      S and T only contain lowercase letters and '#' characters.
 *
 * Follow up: Can you solve it in O(N) time and O(1) space?
 * 
 *******************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic; // stack namespace

public class Solution844
{
    // --------------- O(m+n) 68ms --------------- O(m+n) 22MB --------------- (97% 50%) 
    /*
     * use stack , easy-understand but O(space) != O(1)
     */
    public bool BackspaceCompare_1(string S, string T)
    {
        Stack<char> s1=new Stack<char>();
        foreach (char c in S)
        {
            if (c != '#')
            {
                s1.Push(c);
            }
            else if (s1.Count > 0)
            {
                s1.Pop();
            }
        }

        Stack<char> s2 = new Stack<char>();
        foreach (char c in T)
        {
            if (c != '#')
            {
                s2.Push(c);
            }
            else if (s2.Count > 0)
            {
                s2.Pop();
            }
        }

        while (s1.Count>0 && s2.Count>0)
        {
            if (s1.Pop() != s2.Pop()) return false;
        }

        return s1.Count == s2.Count;
    }

    // --------------- O(m+n) 76ms --------------- O(m+n) 21.7MB --------------- (61% 50%) ※ 
    /*
     * keep in mind
     */
    public bool BackspaceCompare_2(string S, string T)
    {
        int i = S.Length - 1;
        int j = T.Length - 1;
        while (true)
        {
            for (int k = 0; i >= 0 && (k != 0 || S[i] == '#'); i--)
            {
                k += S[i] == '#' ? 1 : -1;
            }

            for (int k = 0; j >= 0 && (k != 0 || T[j] == '#'); j--)
            {
                k += T[j] == '#' ? 1 : -1;
            }

            if (i < 0 || j < 0 || S[i] != T[j])
            {
                return i == -1 && j == -1;
            }

            i--;
            j--;
        }
    }
    
     // --------------- O(m+n) 76ms --------------- O(m+n) 21.7MB --------------- (61% 50%) ※ 
    /*
     * similar to 2
     */
    public bool BackspaceCompare_3(string S, string T)
    {
        int i = S.Length - 1; int count1=0;
        int j = T.Length - 1; int count2=0;

        while (i>=0 || j>=0)
        {
            while (i >= 0 && (S[i] == '#' || count1 > 0))
            {
                count1 = S[i] == '#' ? count1++ : count1--;
                i--;
            }

            while (j >= 0 && (T[j] == '#' || count2 > 0))
            {
                count2 = T[j] == '#' ? count2++ : count2--;
                j--;
            }

            if (i < 0 || j < 0) return i == j;
            if (S[i] != S[j])
            {
                return false;

            }
            else
            {
                i--;
                j--;
            }
        }

        return i == j;
    }

    // --------------- O(m+n) 88ms --------------- O(m+n) 21.9MB --------------- (9% 50%)
    /*
     * O(Space) != O(1)
     */
    public bool BackspaceCompare_4(string S, string T)
    {
        return GetString(S).Equals(GetString(T));
    }

    string GetString(string str)
    {
        int n = str.Length-1;
        int count = 0;
        string result = "";

        for (int i = n; i >=0; i--)
        {
            if (str[i] == '#')
            {
                count++;
            }
            else
            {
                if (count > 0)
                {
                    count--;
                }
                else
                {
                    result = result + str[i];
                }
            }
        }

        return result;
    }
}
/**************************************************************************************************************
 * BackspaceCompare_2 BackspaceCompare_3                                                                      *
 **************************************************************************************************************/
