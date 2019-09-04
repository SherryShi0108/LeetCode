//Source  : https://leetcode.com/problems/roman-to-integer/
//Author  : Xinruo Shi
//Date    : 2019-09-02
//Language: C#

/*******************************************************************************************************************************
 * 
 * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
 *      Symbol       Value
 *      I             1
 *      V             5
 *      X             10
 *      L             50
 *      C             100
 *      D             500
 *      M             1000
 *      
 * For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II.
 * The number twenty seven is written as XXVII, which is XX + V + II.
 * 
 * Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead,
 * the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies 
 * to the number nine, which is written as IX. There are six instances where subtraction is used:
 * 
 * I can be placed before V (5) and X (10) to make 4 and 9. 
 * X can be placed before L (50) and C (100) to make 40 and 90. 
 * C can be placed before D (500) and M (1000) to make 400 and 900.
 * Given a roman numeral, convert it to an integer. Input is guaranteed to be within the range from 1 to 3999.
 * 
 * Input: "III"
 * Output: 3
 * 
 * Input: "IV"
 * Output: 4
 * 
 * Input: "IX"
 * Output: 9
 * 
 * Input: "LVIII"
 * Output: 58
 * Explanation: L = 50, V= 5, III = 3.
 * 
 * Input: "MCMXCIV"
 * Output: 1994
 * Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution13
{
    // --------------- O(n) 92ms --------------- 23.7MB --------------- (75% 22%) ※
    public int RomanToInt_1(string s)
    {
        Dictionary<char, int> d = new Dictionary<char, int>() { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
        //d.Add('I', 1); d.Add('V', 5); d.Add('X', 10); d.Add('L', 50); d.Add('C', 100); d.Add('D', 500); d.Add('M', 1000);

        if (s.Length == 0) { return 0; }
        int result = d[s[0]];
        for (int i = 1; i < s.Length; i++)
        {
            if (d[s[i]] <= d[s[i - 1]])
            {
                result += d[s[i]];
            }
            else
            {
                result = result - 2 * d[s[i - 1]] + d[s[i]];
            }
        }
        return result;
    }

    // --------------- O(n) 112ms --------------- 23.6MB --------------- (19% 26%)
    public int RomanToInt_2(string s)
    {
        Dictionary<char, int> d = new Dictionary<char, int>();
        d.Add('I', 1); d.Add('V', 5); d.Add('X', 10); d.Add('L', 50); d.Add('C', 100); d.Add('D', 500); d.Add('M', 1000);

        int result = 0;
        foreach (char c in s)
        {
            result += d[c];
        }

        if (s.Contains("CD") || s.Contains("CM"))
        {
            result -= 200;
        }
        if (s.Contains("XL") || s.Contains("XC"))
        {
            result -= 20;
        }
        if (s.Contains("IV") || s.Contains("IX"))
        {
            result -= 2;
        }
        return result;
    }
}
/**************************************************************************************************************
 * RomanToInt_1 RomanToInt_2                                                                                  *
 **************************************************************************************************************/