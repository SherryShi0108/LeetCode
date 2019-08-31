//Source  : https://leetcode.com/problems/excel-sheet-column-title/
//Author  : Xinruo Shi
//Date    : 2019-09-03
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a positive integer, return its corresponding column title as appear in an Excel sheet.
 * For example:
 *              1 -> A
 *              2 -> B
 *              3 -> C
 *              ...
 *              26 -> Z
 *              27 -> AA
 *              28 -> AB 
 *              ...
 * 
 * Input: 1
 * Output: "A"
 * 
 * Input: 28
 * Output: "AB"
 * 
 * Input: 701
 * Output: "ZY"
 * 
 *******************************************************************************************************************************/

public class Solution168
{
    // --------------- O(n) 84ms --------------- 20.4MB --------------- (72% 100%) 
    public string ConvertToTitle_1(int n)
    {
        string result = "";
        while (n > 0)
        {
            n--;
            int x = n % 26;
            result = (char)(x + 65) + result;
            n = n / 26;
        }

        return result;
    }

    // --------------- O(n) 80ms --------------- 20.3MB --------------- (90% 100%) 
    public string ConvertToTitle_2(int n)
    {
        string t = "ZABCDEFGHIJKLMNOPQRSTUVWXY";
        string result = "";
        while (n > 0)
        {
            result = t[n % 26] + result;
            n = (n % 26 == 0) ? n / 26 - 1 : n / 26;
        }
        return result;
    }

    // --------------- O(n) 80ms --------------- 20.3MB --------------- (90% 100%) ※
    /*
     * improve 1
     */
    public string ConvertToTitle_3(int n)
    {
        string result = "";
        while (n > 0)
        {
            result = (char)((n - 1) % 26 + 65) + result;
            n = (n - 1) / 26;
        }

        return result;
    }
}
/**************************************************************************************************************
 * ConvertToTitle_2 ConvertToTitle_30                                                                         *
 **************************************************************************************************************/