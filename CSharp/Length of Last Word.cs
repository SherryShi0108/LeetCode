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
    // --------------- O(n) 76ms --------------- O(n) 22MB --------------- (76% 7%) 
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
    
    // --------------- O(n) 72ms --------------- O(n) 22MB --------------- (80% 7%) ※
    /*
     * easy-understand
     */
    public int LengthOfLastWord_2(string s)
    {
        int i = s.Length - 1;
        for (; i >=0; i--)
        {
            if (s[i] != ' ') break;
        }

        int count = 0;
        for (; i>=0; i--)
        {
            if (s[i] != ' ') count++;
            else
            {
                break;
            }
        }

        return count;
    }
}
/**************************************************************************************************************
 * LengthOfLastWord_2                                                                                         *
 **************************************************************************************************************/
