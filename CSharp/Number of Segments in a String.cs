//Source  : https://leetcode.com/problems/number-of-segments-in-a-string/
//Author  : Xinruo Shi
//Date    : 2019-10-17
//Language: C#

/*******************************************************************************************************************************
 * 
 * Count the number of segments in a string, where a segment is defined to be a contiguous sequence of non-space characters.
 * Please note that the string does not contain any non-printable characters.
 *
 * Input: "Hello, my name is John"
 * Output: 5
 * 
 *******************************************************************************************************************************/

using System.Data;

public class Solution434
{
    // --------------- O(n) 68ms --------------- 21.3MB --------------- (96% 50%) 
    /*
     * it's important to use (i == 0 || s[i - 1] == ' ')
     */
    public int CountSegments_1(string s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if ((i == 0 || s[i - 1] == ' ') && s[i] != ' ')
            {
                count++;
            }
        }

        return count;
    }
    
    // --------------- O(n) 68ms --------------- 21.3MB --------------- (96% 50%) 
    /*
     * it's important to use (i == s.Length - 1 || s[i + 1] == ' ')
     */
    public int CountSegments_1_1(string s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ' && (i == s.Length - 1 || s[i + 1] == ' '))
            {
                count++;
            }
        }

        return count;
    }
    
     // --------------- O(n) 68ms --------------- 21.3MB --------------- (97% 50%) ※
    /*
     * similar to 1 , more easy-understanding
     */
    public int CountSegments_2(string s)
    {
        if (s == null || s.Length < 1 ) return 0;

        int count = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i - 1] == ' ' && s[i] != ' ')
            {
                count++;
            }
        }

        return s[0] == ' ' ? count : count + 1;
    }
}
/**************************************************************************************************************
 * CountSegments_1 / 2                                                                                        *
 **************************************************************************************************************/
