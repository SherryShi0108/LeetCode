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
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution202
{   
    // --------------- O(n) 44ms --------------- 16.6MB --------------- (60% 33%)
    /*
     * use hashset
     */
    public bool IsHappy_1(int n)
    {
       HashSet<int> d=new HashSet<int>();
       while (n!=1)
       {
           int sum = 0;
           while (n>0)
           {
                sum += (n % 10) * (n % 10);
                n /= 10;
           }
           if (!d.Add(sum)) return false;
           n = sum;
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
        if (!H.Add(n)) return false;
        int sum = 0;
        while (n>0)
        {
            sum += (n % 10) * (n % 10);
            n /= 10;
        }
        if (sum == 1) return true;
        return  IdHappy(sum);
    }

    // --------------- O(n) 40ms --------------- 14.7MB --------------- (88% 67%) ※
    /* 
     * difficute understanding use the Floyd Cycle detection algorithm
     */
    public bool IsHappy_3(int n)
    {
        int a = GetSum(n);
        int b = GetSum(GetSum(n));
        while (a!=b)
        {
            a = GetSum(a);
            b = GetSum(GetSum(b));
        }
        return a == 1;
    }
    public int GetSum(int n)
    {
        int sum = 0;
        while (n>0)
        {
            sum += (n % 10) * (n % 10);
            n /= 10;
        }
         return sum;
    }
}
/**************************************************************************************************************
 * IsHappy_1 IsHappy_2 IsHappy_3                                                                              *
 **************************************************************************************************************/
