//Source  : https://leetcode.com/problems/length-of-last-word/
//Author  : Xinruo Shi
//Date    : 2019-10-12
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
 * If the last word does not exist, return 0.
 *
 * Note: A word is defined as a character sequence consists of non-space characters only.
 *
 * Input: "Hello World"
 * Output: 5
 * 
 *******************************************************************************************************************************/

public class Solution58
{
    // --------------- O(n) 76ms --------------- O(n) 22MB --------------- (76% 7%) ※
    public int LengthOfLastWord_1(string s)
    {
        int len = 0;
        int i = s.Length - 1;
        while (i>=0 && s[i]==' ')
        {
            i--;
        }

        while (i>=0 && s[i]!=' ')
        {
            len++;
            i--;
        }

        return len;
    }
}
/**************************************************************************************************************
 * LengthOfLastWord_1                                                                                         *
 **************************************************************************************************************/