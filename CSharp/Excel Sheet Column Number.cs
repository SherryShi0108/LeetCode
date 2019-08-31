//Source  : https://leetcode.com/problems/excel-sheet-column-number/
//Author  : Xinruo Shi
//Date    : 2019-09-04
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a column title as appear in an Excel sheet, return its corresponding column number.
 * 
 * For example:
 *              A -> 1
 *              B -> 2
 *              C -> 3
 *              ...
 *              Z -> 26
 *              AA -> 27
 *              AB -> 28 
 *              ...
 *              
 * Input: "A"
 * Output: 1
 * 
 * Input: "AB"
 * Output: 28
 * 
 * Input: "ZY"
 * Output: 701
 * ※
 *******************************************************************************************************************************/

public class Solution171
{
    // --------------- O(n) 80ms --------------- 22.9MB --------------- (69% 100%) ※
    public int TitleToNumber_1(string s)
    {
        int result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            result = result * 26 + (s[i] - 64);
        }
        return result;
    }
}
/**************************************************************************************************************
 * TitleToNumber_1                                                                                            *
 **************************************************************************************************************/