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
    // --------------- O(n) 96ms --------------- 26MB --------------- (48% 82%)
    /*
     *  string.Contains:O(n)、Foreach:O(n); 
     */
    public int RomanToInt_1(string s)
    {
        int result = 0;
        Dictionary<char, int> d = new Dictionary<char, int>()
        {
            {'I', 1}, {'V', 5},
            {'X', 10}, {'L', 50},
            {'C', 100}, {'D', 500}, {'M', 1000}
        };

        foreach (char c in s)
        {
            result += d[c];
        }

        if (s.Contains("IV") || s.Contains("IX")) result -= 2;
        if (s.Contains("XL") || s.Contains("XC")) result -= 20;
        if (s.Contains("CD") || s.Contains("CM")) result -= 200;

        return result;
    }
    
    // --------------- O(n) 80ms --------------- 26MB --------------- (96% 41%) ※
    /*
     * Using a Method to avoid Dictionary
     * Using a Foreach to remove 6* O(n) -string.Contains
     */
    public int RomanToInt_2(string s)
    {        
        if (string.IsNullOrEmpty(s)) return 0;

        int result = GetIntFromChar(s[s.Length - 1]);

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (GetIntFromChar(s[i]) >= GetIntFromChar(s[i + 1]))
            {
                result += GetIntFromChar(s[i]);
            }
            else
            {
                result -= GetIntFromChar(s[i]);
            }
        }

        return result;
    }
    
    private int GetIntFromChar(char c)
    {
        switch (c)
        {
            case 'I': return 1;
            case 'V': return 5;
            case 'X': return 10;
            case 'L': return 50;
            case 'C': return 100;
            case 'D': return 500;
            case 'M': return 1000;
            default: return 0;
        }
    }
}
/**************************************************************************************************************
 * RomanToInt_1   RomanToInt_2                                                                                *
 **************************************************************************************************************/
