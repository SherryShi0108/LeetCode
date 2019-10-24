//Source  : https://leetcode.com/problems/reverse-string/
//Author  : Xinruo Shi
//Date    : 2019-09-24
//Language: C#

/*******************************************************************************************************************************
 * 
 * Write a function that reverses a string. The input string is given as an array of characters char[].
 * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
 * You may assume all the characters consist of printable ascii characters.
 *
 * Input: ["h","e","l","l","o"]
 * Output: ["o","l","l","e","h"]
 *
 * Input: ["H","a","n","n","a","h"]
 * Output: ["h","a","n","n","a","H"]
 * ※
 *******************************************************************************************************************************/

public class Solution344
{
    // --------------- O(n) 392ms --------------- 34.1MB --------------- (80% 12%) ※
    public void ReverseString_1(char[] s)
    {
        for (int i = 0; i < s.Length/2; i++)
        {
            char temp = s[i];
            s[i] = s[s.Length - 1 - i];
            s[s.Length - 1 - i] = temp;
        }
    }

    // --------------- O(n) 436ms --------------- 34.1MB --------------- (9% 12%)
    /*
     * use while
     */
    public void ReverseString_2(char[] s)
    {
        int i = 0;
        int j = s.Length - 1;
        while (i<j)
        {
            char temp = s[i];
            s[i] = s[j];
            s[j] = temp;

            i++;
            j--;
        }
    }
}
/**************************************************************************************************************
 * ReverseString_1                                                                                            *
 **************************************************************************************************************/