//Source  : https://leetcode.com/problems/convert-a-number-to-hexadecimal/
//Author  : Xinruo Shi
//Date    : 2020-11-13
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer, write an algorithm to convert it to hexadecimal. For negative integer, two’s complement method is used.
 *
 * Note:
 *      1. All letters in hexadecimal (a-f) must be in lowercase.
 *      2. The hexadecimal string must not contain extra leading 0s. If the number is zero, it is represented by a single zero character '0';
 *         otherwise, the first character in the hexadecimal string will not be the zero character.
 *      3. The given number is guaranteed to fit within the range of a 32-bit signed integer.
 *      4. You must not use any method provided by the library which converts/formats the number to hex directly.
 *
 * Input: 26
 * Output: "1a"
 *
 * Input: -1
 * Output: "ffffffff"
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution405
{
    // --------------- O(n) 76ms --------------- 23MB --------------- (88% 56%) ※
    /*
     * bits = 32-0 is the condition to deal with negative numbers , because negative is 111111....0101...
     */
    public string ToHex_1(int num)
    {
        if (num == 0) return "0";
        string result = "";
        char[] charArray = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};

        int bits = 32;
        while (bits > 0 && num != 0)
        {
            result = charArray[num & 15] + result;
            num = num >> 4;
            bits -= 4;
        }

        return result;
    }
}
/**************************************************************************************************************
 * ToHex_1                                                                                                    *
 **************************************************************************************************************/