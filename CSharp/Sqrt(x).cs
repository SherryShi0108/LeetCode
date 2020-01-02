﻿//Source  : https://leetcode.com/problems/sqrtx/
//Author  : Xinruo Shi
//Date    : 2019-09-03
//Language: C#

/*******************************************************************************************************************************
 * 
 * Implement int sqrt(int x).
 * Compute and return the square root of x, where x is guaranteed to be a non-negative integer.
 * Since the return type is an integer, the decimal digits are truncated and only the integer part of the result is returned.
 * 
 * Input: 4
 * Output: 2
 * 
 * Input: 8
 * Output: 2
 * Explanation: The square root of 8 is 2.82842..., and since the decimal part is truncated, 2 is returned.
 * ※
 *******************************************************************************************************************************/

public class Solution69
{
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     * 2147395600 output:289398 need:46340,but 46341^2>int.max,
     * long double same false
     */
    public int MySqrt_1(int x)
    {
        int i = 0;
        int sum = 0;
        while (sum <= x)
        {
            i++;
            sum = i * i;
        }

        return i - 1;
    }

    ///+++++++++++++++++++++++++ O(n) Time Limit Exceeded +++++++++++++++++++++++++
    /*
     * O(time) = O(n)
     */
    public int MySqrt_2(int x)
    {
        int i = 0;
        while (i * i < x)
        {
            i++;
        }

        return x == i * i ? i : i - 1;
    }

    // --------------- O(logn) 36ms --------------- 14.1MB --------------- (96% 7%) 
    /*
     * Binary Search
     * 1. but mid * mid > maxValue , can cause -xxxxxx ; so use mid > x / mid instead mid * mid > x
     * 2. 0 cannot be divide , so x/mid mid!=0 , so i/j!=0
     */
    public int MySqrt_3(int x)
    {
        if (x == 0) return 0;
        int i = 1;
        int j = x;
        while (i <= j)
        {
            int mid = i + (j - i) / 2;
            if (mid == x / mid) return mid;
            else if (mid > x / mid)
            {
                j = mid - 1;
            }
            else
            {
                i = mid + 1;
            }
        }

        return j;
    }

    // --------------- O(logn) 44ms --------------- 14.1MB --------------- (57% 7%) 
    /*
     * Binary Search
     * 1. j should be x+1 , but x+1 maybe overflow , so use x and consider j = x , but always x*x>x except 1 
     */
    public int MySqrt_4(int x)
    {
        if (x <2) return x;
        int i = 1;
        int j = x;
        while (i < j)
        {
            int mid = i + (j - i) / 2;
            if (mid == x / mid) return mid;
            else if (mid > x / mid)
            {
                j = mid;
            }
            else
            {
                i = mid + 1;
            }
        }

        return j-1;
    }

    // --------------- O(logn) 52ms --------------- 14.1MB --------------- (25% 7%) 
    /*
     * Math solution : Newton's method
     */
    public int MySqrt_5(int x)
    {
        long r = x;
        while (r * r > x)
            r = (r + x / r) / 2;
        return (int) r;
    }

    // --------------- O(1) 44ms --------------- 14.1MB --------------- (57% 7%) 
    /*
     * use bit manipulation , amazing solution , but donot understand
     */
    public int MySqrt_6(int x)
    {
        if (x == 0) return 0;

        int h = 0;

        while ((long) (1 << h) * (long) (1 << h) <= x) // firstly, find the most significant bit
        {
            h++;
        }
        h--;
        int b = h - 1;
        int res = (1 << h);
        while (b >= 0)
        {  // find the remaining bits
            long log2 = (1 << b);
            long log3 = (long) (res | (1 << b));

            if ((long) (res | (1 << b)) * (long) (res | (1 << b)) <= x)
            {
                res |= (1 << b);
            }
            b--;
        }
        return res;
    }
}
/**************************************************************************************************************
 * MySqrt_3  MySqrt_4  MySqrt_6                                                                               *
 **************************************************************************************************************/