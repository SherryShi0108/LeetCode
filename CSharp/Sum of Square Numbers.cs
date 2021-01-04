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
    
    // --------------- O(c^1/2 * logc) 268ms --------------- O(logc) 15MB --------------- (7% 39%) 
    public bool JudgeSquareSum_1_2(int c)
    {
        for (long a = 0; a * a <= c; a++)
        {
            int b = c - (int)(a * a);
            if (BinarySearchTest(0, b, b))
            {
                return true;
            }
        }

        return false;
    }

    public bool BinarySearchTest(long s, long e, int n)
    {
        if (s > e) return false;
        long mid = s + (e - s) / 2;
        if (mid * mid == n)
        {
            return true;
        }

        if (mid * mid > n)
        {
            return BinarySearchTest(s, mid - 1, n);
        }
        else
        {
            return BinarySearchTest(mid + 1, e, n);
        }
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
    
    // --------------- O(c^1/2 * logc) 40ms --------------- O(1) 15MB --------------- (89% 39%) 
    /*
     * Use Fermat Theorem
     */
    public bool JudgeSquareSum_3(int c)
    {
        for (int i = 2; i * i <= c; i++)
        {
            int count = 0;
            if (c % i == 0)
            {
                while (c % i == 0)
                {
                    count++;
                    c /= i;
                }
                if (i % 4 == 3 && count % 2 != 0)
                    return false;
            }
        }
        return c % 4 != 3;
    }
}
/**************************************************************************************************************
 * JudgeSquareSum_1 / 2 / 3                                                                                   *
 **************************************************************************************************************/
