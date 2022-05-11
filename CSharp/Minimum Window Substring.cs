//Source  : https://leetcode.com/problems/minimum-window-substring/
//Author  : Xinruo Shi
//Date    : 2022-05-01
//Language: C#

/*******************************************************************************************************************************
 
    Given two strings s and t of lengths m and n respectively, return the minimum window 
    substring of s such that every character in t (including duplicates) is included in the window. 
    If there is no such substring, return the empty string "".

    The testcases will be generated such that the answer is unique.

    A substring is a contiguous sequence of characters within the string.

    Input: s = "ADOBECODEBANC", t = "ABC"
    Output: "BANC"
    Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.

    Input: s = "a", t = "a"
    Output: "a"
    Explanation: The entire string s is the minimum window.

    Input: s = "a", t = "aa"
    Output: ""
    Explanation: Both 'a's from t must be included in the window.
        Since the largest window of s only has one 'a', return empty string.
     
    Constraints:
        m == s.length
        n == t.length
        1 <= m, n <= 105
        s and t consist of uppercase and lowercase English letters.
 ※
 *******************************************************************************************************************************/

public class Solution76
{
    public string MinWindow(string s, string t)
    {

    }

}

/**************************************************************************************************************
 *                                                                                      *
 **************************************************************************************************************/