//Source  : https://leetcode.com/problems/edit-distance/
//Author  : Xinruo Shi
//Date    : 2022-05-01
//Language: C#

/*******************************************************************************************************************************
 
    Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

    You have the following three operations permitted on a word:
        Insert a character
        Delete a character
        Replace a character

    Input: word1 = "horse", word2 = "ros"
    Output: 3
    Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

    Input: word1 = "intention", word2 = "execution"
    Output: 5
    Explanation: 
        intention -> inention (remove 't')
        inention -> enention (replace 'i' with 'e')
        enention -> exention (replace 'n' with 'x')
        exention -> exection (replace 'n' with 'c')
        exection -> execution (insert 'u')
     
    Constraints:
        0 <= word1.length, word2.length <= 500
        word1 and word2 consist of lowercase English letters.
 ※
 *******************************************************************************************************************************/

public class Solution72
{
    public int MinDistance(string word1, string word2)
    {

    }

}

/**************************************************************************************************************
 *                                                                                      *
 **************************************************************************************************************/