//Source  : https://leetcode.com/problems/buddy-strings/
//Author  : Xinruo Shi
//Date    : 2019-10-28
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two strings A and B of lowercase letters, return true if and only if we can swap two letters in A so that the result equals B.
 *
 * Input: A = "ab", B = "ba"
 * Output: true
 *
 * Input: A = "ab", B = "ab"
 * Output: false
 *
 * Input: A = "aa", B = "aa"
 * Output: true
 *
 * Input: A = "aaaaaaabc", B = "aaaaaaacb"
 * Output: true
 *
 * Input: A = "", B = "aa"
 * Output: false
 *
 * Note:
 *      0 <= A.length <= 20000
 *      0 <= B.length <= 20000
 *      A and B consist only of lowercase letters.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic; // Dictionary<>

public class Solution859
{
    // --------------- O(n) 64ms --------------- 23MB --------------- (100% 100%) ※
    public bool BuddyStrings_1(string A, string B)
    {
        if (A.Length != B.Length) return false;

        if (A == B)
        {
            HashSet<char> h = new HashSet<char>(A);
            return h.Count < A.Length;
        }

        List<int> L=new List<int>();
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] != B[i])
            {
                L.Add(i);
            }

            // if (L.Count > 2) break; //add this,O(time)=76ms 67%
        }

        return L.Count == 2 && (A[L[0]] == B[L[1]]) && (A[L[1]] == B[L[0]]);
    }
}
/**************************************************************************************************************
 * BuddyStrings_1                                                                                             *
 **************************************************************************************************************/