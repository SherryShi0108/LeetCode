//Source  : https://leetcode.com/problems/plus-one/
//Author  : Xinruo Shi
//Date    : 2019-05-30
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
 * The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.
 * 
 * You may assume the integer does not contain any leading zero, except the number 0 itself.
 * 
 * Input: nums = [1,2,3]
 * Output: [1,2,4]
 * 
 * Input: nums = [4,3,2,1]
 * Output: [4,3,2,2]
 * 
 *******************************************************************************************************************************/

using System; //Math名称空间

public class Solution66
{    
    //--------------- O(n) 296ms --------------- 28.1MB --------------- (6% 96%) ※
    public int[] PlusOne_1(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] + 1 < 10)
            {
                digits[i]++;
                return digits;
            }
            else
            {
                digits[i] = 0;
            }
        }
        
        int[] result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }
}
/**************************************************************************************************************
 * PlusOne_1                                                                                                  *
 **************************************************************************************************************/
 
