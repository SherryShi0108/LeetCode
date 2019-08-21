//Source  : https://leetcode.com/problems/happy-number/
//Author  : Xinruo Shi
//Date    : 2019-08-02
//Language: C#

/*******************************************************************************************************************************
 * 
 * Write an algorithm to determine if a number is "happy".
 * A happy number is a number defined by the following process: Starting with any positive integer, replace the number 
 * by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), 
 * or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
 * 
 * Input: 19
 * Output: true
 * Explanation: 
 *              1^2 + 9^2 = 82
 *              8^2 + 2^2 = 68
 *              6^2 + 8^2 = 100
 *              1^2 + 0^2 + 0^2 = 1
 * ※
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution202
{
    // --------------- O(n) 44ms --------------- 14.8MB --------------- (68% 67%)
    public bool IsHappy_1(int n)
    {
        HashSet<int> H = new HashSet<int>();
        int sum = n;

        while (sum != 1)
        {
            int currentSum = 0;
            while (sum > 0)
            {
                int t = sum % 10;
                sum = sum / 10;
                currentSum += t * t;
            }
            sum = currentSum;

            if (H.Contains(sum))
            {
                return false;
            }
            else
            {
                H.Add(sum);
            }
        }
        return true;
    }

    // --------------- O(n) 44ms --------------- 15MB --------------- (68% 33%)
    /*
     * use recursive way
     */
    HashSet<int> H = new HashSet<int>();
    public bool IsHappy(int n)
    {
        int sum = n;
        int currentSum = 0;

        while (sum > 0)
        {
            int t = sum % 10;
            sum = sum / 10;
            currentSum += t * t;
        }
        sum = currentSum;

        if (sum == 1) { return true; }
        if (H.Contains(sum)) { return false; }
        else { H.Add(sum); }

        return IsHappy(sum);
    }

    /* 
     * difficute understanding use the Floyd Cycle detection algorithm
     * https://leetcode.com/problems/happy-number/discuss/56917/My-solution-in-C(-O(1)-space-and-no-magic-math-property-involved-)
     * https://leetcode.com/problems/happy-number/discuss/56919/Explanation-of-why-those-posted-algorithms-are-mathematically-valid
     */
    public bool IsHappy_3(int n)
    {
        return false;
    }
}
/**************************************************************************************************************
 * IsHappy_1 IsHappy_2 IsHappy_3                                                                              *
 **************************************************************************************************************/