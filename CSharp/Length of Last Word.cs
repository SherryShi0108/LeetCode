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
    // --------------- O(n) 72ms --------------- O(n) 23MB --------------- (88% 24%) ※
    public int LengthOfLastWord_1(string s)
    {
        if (s == null) return 0;
        
        int length = 0;
        bool flag = true;
        
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ')
            {
                if (flag == true) continue;
                return length;
            }
            else
            {
                flag = false;
                length++;
            }
        }

        return length;
    }
    
    /*
     * using API: s.TrimEnd() / s.Split(char[],StringSplitOptions.RemoveEmptyEntries) 
     */
    public int LengthOfLastWord_2(string s)
    {
        if (s == null) return 0;  // string.IsNullOrWhiteSpace(s)

        string[] list = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return list[list.Length - 1].Length;
    }
}
/**************************************************************************************************************
 * LengthOfLastWord_1                                                                                         *
 **************************************************************************************************************/
