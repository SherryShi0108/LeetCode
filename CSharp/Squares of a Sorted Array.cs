//Source  : https://leetcode.com/problems/squares-of-a-sorted-array/
//Author  : Xinruo Shi
//Date    : 2019-07-18
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of integers A sorted in non-decreasing order, return an array of the squares of each number, also in sorted non-decreasing order.
 * 
 * Note:
 * 1 <= A.length <= 10000
 * -10000 <= A[i] <= 10000
 * A is sorted in non-decreasing order.
 * 
 * Input: [-4,-1,0,3,10]
 * Output: [0,1,9,16,100]
 * 
 * Input: [-7,-3,2,3,11]
 * Output: [4,9,9,49,121]
 * 
 *******************************************************************************************************************************/

using System;

public class Solution977
{
    // --------------- O(n+sort) 336ms --------------- 39.9MB --------------- (29% 81%) 
    public int[] SortedSquares_1(int[] A)
    {
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = A[i] * A[i];
        }
        Array.Sort(A);

        return A;
    }

    // --------------- O(n) 344ms --------------- 40.4MB --------------- (20% 29%) 
    public int[] SortedSquares_2(int[] A)
    {
        if (A.Length < 1) { return A; }

        int[] B = new int[A.Length];
        int L = 0;
        int R = A.Length - 1;

        int i = R;
        while (L <= R)
        {
            if (A[L] * A[L] > A[R] * A[R])
            {
                B[i] = A[L] * A[L];
                L++;
            }
            else
            {
                B[i] = A[R] * A[R];
                R--;
            }
            i--;
        }

        return B;
    }

    // --------------- O(n) 304ms --------------- 40.4MB --------------- (84% 29%) ※
    public int[] SortedSquares_3(int[] A)
    {
        int[] B = new int[A.Length];
        int L = 0;
        int R = A.Length - 1;

        for (int i = A.Length - 1; i >= 0; i--)
        {
            if (A[L] * A[L] > A[R] * A[R])
            {
                B[i] = A[L] * A[L];
                L++;
            }
            else
            {
                B[i] = A[R] * A[R];
                R--;
            }
        }
        return B;
    }
}
/**************************************************************************************************************
 * SortedSquares_3                                                                                            *
 **************************************************************************************************************/