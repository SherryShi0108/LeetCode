//Source  : https://leetcode.com/problems/sum-of-square-numbers/
//Author  : Xinruo Shi
//Date    : 2019-09-12
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-negative integer c, your task is to decide whether there're two integers a and b such that a^2 + b^2 = c.
 * 
 * Input: 5
 * Output: True
 * Explanation: 1 * 1 + 2 * 2 = 5
 * 
 * Input: 3
 * Output: False
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution633
{
    // --------------- O(logn) 36ms --------------- 14.1MB --------------- (99% 50%) ※
    /*
     * Binary Search
     */
    public bool JudgeSquareSum_1(int c)
    {
        int i = 0;
        int j = (int) Math.Sqrt(c);
        while (i<=j)
        {
            int cur = i * i + j * j;
            if (cur == c)
            {
                return true;
            }
            else if(cur>c)
            {
                j--;
            }
            else
            {
                i++;
            }
        }

        return false;
    }

    // --------------- O(n) 76ms --------------- 34.1MB --------------- (23% 50%) 
    public bool JudgeSquareSum_2(int c)
    {
        HashSet<int> H = new HashSet<int>();
        for (int i = 0; i <= Math.Sqrt(c); i++)
        {
            H.Add(i * i);
            if (H.Contains(c - i * i)) return true;
        }

        return false;
    }
}
/**************************************************************************************************************
 * JudgeSquareSum_1                                                                                           *
 **************************************************************************************************************/
