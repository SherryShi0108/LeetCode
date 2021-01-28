//Source  : https://leetcode.com/problems/reverse-string-ii/
//Author  : Xinruo Shi
//Date    : 2019-10-19
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string and an integer k, you need to reverse the first k characters for every 2k characters counting from the start
 * of the string. If there are less than k characters left, reverse all of them. If there are less than 2k but greater than or
 * equal to k characters, then reverse the first k characters and left the other as original.
 *
 * Input: s = "abcdefg", k = 2
 * Output: "bacdfeg"
 *
 * Restrictions:
 *              The string consists of lower English letters only.
 *              Length of the given string and k will in the range [1, 10000]
 * 
 *******************************************************************************************************************************/

using System.Text;

public class Solution541
{
    // --------------- O(n) 100ms --------------- 25MB --------------- (13% 74%) ※
    public string ReverseStr_1(string s, int k)
    {
        char[] cArrays = s.ToCharArray();
        int first = 0;
        while (first < cArrays.Length)
        {
            int start = first;
            int end = (first + k - 1) > cArrays.Length - 1 ? cArrays.Length - 1 : (first + k - 1);
            while (start<end)
            {
                char temp = cArrays[start];
                cArrays[start++] = cArrays[end];
                cArrays[end--] = temp;
            }


           first += 2 * k;
        }

        return new string(cArrays);
    }

    // --------------- O(n) 92ms --------------- 25MB --------------- (31% 74%) 
    public string ReverseStr_1_2(string s, int k)
    {
        StringBuilder sb = new StringBuilder(s);
        int first = 0;
        while (first < sb.Length)
        {
            int start = first;
            int end = (first + k - 1) > sb.Length - 1 ? sb.Length - 1 : (first + k - 1);
            while (start < end)
            {
                char temp = sb[start];
                sb[start++] = sb[end];
                sb[end--] = temp;
            }


            first += 2 * k;
        }

        return sb.ToString();
    }
}
/**************************************************************************************************************
 * ReverseStr_1                                                                                               *
 **************************************************************************************************************/