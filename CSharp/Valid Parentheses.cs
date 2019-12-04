//Source  : https://leetcode.com/problems/valid-parentheses/
//Author  : Xinruo Shi
//Date    : 2019-10-11
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
 * An input string is valid if:
 *                              Open brackets must be closed by the same type of brackets.
 *                              Open brackets must be closed in the correct order.
 * Note that an empty string is also considered valid.
 *
 * Input: "()"
 * Output: true
 *
 * Input: "()[]{}"
 * Output: true
 *
 * Input: "(]"
 * Output: false
 *
 * Input: "([)]"
 * Output: false
 *
 * Input: "{[]}"
 * Output: true
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution20
{
    // --------------- O(n) 68ms --------------- O(n) 21MB --------------- (97% 6%)
    public bool IsValid_1(string s)
    {
        Stack<char> stack=new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{')
            {
                stack.Push(s[i]);
            }
            else
            {
                if (stack.Count == 0) return false;

                if (!IsSuit(stack.Pop(), s[i]))
                {
                    return false;
                }
            }
        }
        return stack.Count==0;
    }

    private bool IsSuit(char c,char d)
    {
        if (c == '(' && d == ')' || c == '[' && d == ']' || c == '{' && d == '}')
        {
            return true;
        }

        return false;
    }

    // --------------- O(n) 76ms --------------- O(n) 21MB --------------- (66% 6%) ※
    public bool IsValid_2(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(')
            {
                stack.Push(')');
            }
            else if (c=='[')
            {
                stack.Push(']');
            }
            else if (c=='{')
            {
                stack.Push('}');
            }
            else if (stack.Count==0 || stack.Pop()!=c)
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
}
/**************************************************************************************************************
 * IsValid_2                                                                                                  *
 **************************************************************************************************************/