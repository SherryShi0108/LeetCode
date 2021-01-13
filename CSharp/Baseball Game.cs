//Source  : https://leetcode.com/problems/baseball-game/
//Author  : Xinruo Shi
//Date    : 2020-11-05
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are keeping score for a baseball game with strange rules. The game consists of several rounds,
 * where the scores of past rounds may affect future rounds' scores.
 *
 * At the beginning of the game, you start with an empty record. You are given a list of strings ops,
 * where ops[i] is the ith operation you must apply to the record and is one of the following:
 *      An integer x - Record a new score of x.
 *      "+" - Record a new score that is the sum of the previous two scores. It is guaranteed there will always be two previous scores.
 *      "D" - Record a new score that is double the previous score. It is guaranteed there will always be a previous score.
 *      "C" - Invalidate the previous score, removing it from the record. It is guaranteed there will always be a previous score.
 * Return the sum of all the scores on the record.
 *
 * Input: ops = ["5","2","C","D","+"]
 * Output: 30
 * Explanation:
 *      "5" - Add 5 to the record, record is now [5].
 *      "2" - Add 2 to the record, record is now [5, 2].
 *      "C" - Invalidate and remove the previous score, record is now [5].
 *      "D" - Add 2 * 5 = 10 to the record, record is now [5, 10].
 *      "+" - Add 5 + 10 = 15 to the record, record is now [5, 10, 15].
 *      The total sum is 5 + 10 + 15 = 30.
 *
 * Input: ops = ["5","-2","4","C","D","9","+","+"]
 * Output: 27
 * Explanation:
 *      "5" - Add 5 to the record, record is now [5].
 *      "-2" - Add -2 to the record, record is now [5, -2].
 *      "4" - Add 4 to the record, record is now [5, -2, 4].
 *      "C" - Invalidate and remove the previous score, record is now [5, -2].
 *      "D" - Add 2 * -2 = -4 to the record, record is now [5, -2, -4].
 *      "9" - Add 9 to the record, record is now [5, -2, -4, 9].
 *      "+" - Add -4 + 9 = 5 to the record, record is now [5, -2, -4, 9, 5].
 *      "+" - Add 9 + 5 = 14 to the record, record is now [5, -2, -4, 9, 5, 14].
 *      The total sum is 5 + -2 + -4 + 9 + 5 + 14 = 27.
 *
 * Input: ops = ["1"]
 * Output: 1
 *
 * Constraints:
 *      1 <= ops.length <= 1000
 *      ops[i] is "C", "D", "+", or a string representing an integer in the range [-3 * 10^4, 3 * 10^4].
 *      For operation "+", there will always be at least two previous scores on the record.
 *      For operations "C" and "D", there will always be at least one previous score on the record.
 * 
 *******************************************************************************************************************************/


using System.Collections.Generic;
using System.Linq;

public class Solution682
{
    // --------------- O(n) 92ms --------------- 25MB --------------- (71% 98%) 
    /*
     * use Normal Solution
     */
    public int CalPoints_1(string[] ops)
    {
        List<int> L = new List<int>();

        for (int i = 0; i < ops.Length; i++)
        {
            if (int.TryParse(ops[i], out int temp))
            {
                L.Add(temp);
            }
            else if(ops[i]=="C")
            {
                L.RemoveAt(L.Count - 1);
            }
            else if (ops[i] == "D")
            {
                L.Add(L[L.Count - 1] * 2);
            }
            else if (ops[i] == "+")
            {
                L.Add(L[L.Count - 1] + L[L.Count - 2]);
            }
        }

        return L.Sum();
    }

    // --------------- O(n) 88ms --------------- 25MB --------------- (93% 11%) 
    /*
     * clean code , improve 1 , use switch
     */
    public int CalPoints_1_2(string[] ops)
    {
        List<int> L = new List<int>();

        foreach (string s in ops)
        {
            switch (s)
            {
                case "C":
                    L.RemoveAt(L.Count - 1);
                    break;
                case "D":
                    L.Add(L[L.Count - 1] * 2);
                    break;
                case "+":
                    L.Add(L[L.Count - 1] + L[L.Count - 2]);
                    break;
                default:
                    L.Add(int.Parse(s));
                    break;
            }
        }

        return L.Sum();
    }

    // --------------- O(n) 92ms --------------- O(n) 25MB --------------- (71% 90%) ※
    /*
     *  use Stack , use sum
     */
    public int CalPoints_2(string[] ops)
    {
        Stack<int> stack = new Stack<int>();
        int result = 0;
        foreach (string s in ops)
        {
            if (s == "C")
            {
                int temp = stack.Pop();
                result -= temp;
            }
            else if(s=="D")
            {
                int temp = stack.Peek() * 2;
                result += temp;
                stack.Push(temp);
            }
            else if (s == "+")
            {
                int last1 = stack.Pop();
                int last2 = stack.Peek();
                int temp = last1 + last2;
                result += temp;
                stack.Push(last1);
                stack.Push(temp);
            }
            else
            {
                int temp = int.Parse(s);
                result += temp;
                stack.Push(temp);
            }
        }

        return result;
    }
}

/**************************************************************************************************************
 * CalPoints_1   CalPoints_2                                                                                  *
 **************************************************************************************************************/