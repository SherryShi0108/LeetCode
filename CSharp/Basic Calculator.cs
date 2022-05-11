//Source  : https://leetcode.com/problems/basic-calculator/
//Author  : Xinruo Shi
//Date    : 2021-06-01
//Language: C#

/*******************************************************************************************************************************
 *
 * Given a string s representing a valid expression, implement a basic calculator to evaluate it, and return the result of the evaluation.
 * Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().
 *
 * Input: s = "1 + 1"
 * Output: 2
 *
 * Input: s = " 2-1 + 2 "
 * Output: 3
 *
 * Input: s = "(1+(4+5+2)-3)+(6+8)"
 * Output: 23
 *
 * Input: s = "+48 + -48"
 * Output: 0
 * Explanation: Numbers can have multiple digits and start with +/-.
 *
 * Constraints:
 *      1 <= s.length <= 3 * 105
 *      s consists of digits, '+', '-', '(', ')', and ' '.
 *      s represents a valid expression.
 *      Every number and running calculation will fit in a signed 32-bit integer.
 * ※
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution224
{
    // --------------- O(n) ms --------------- O(1) MB --------------- (% %) 
    /*
     * 
     */
    public int Calculate_1(string s)
    {
        int result = 0;
        int sign = 1;
        int num = 0;

        Stack<int> stack = new Stack<int>();
        stack.Push(sign);

        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '+':
                case '-':
                    result += sign * num;
                    sign = stack.Peek() * (s[i] == '+' ? 1 : -1);
                    num = 0;
                    break;
                case '(':
                    stack.Push(sign);
                    break;
                case ')':
                    stack.Pop();
                    break;
                default:
                    num = num * 10 + (s[i] - '0');
                    break;
            }
        }

        result += sign * num;
        return result;
    }
}


/**************************************************************************************************************
 *                                                                 *
 **************************************************************************************************************/
