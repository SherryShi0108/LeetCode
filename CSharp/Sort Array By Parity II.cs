﻿//Source  : https://leetcode.com/problems/sort-array-by-parity-ii/
//Author  : Xinruo Shi
//Date    : 2019-07-14
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array A of non-negative integers, half of the integers in A are odd, and half of the integers are even.
 * Sort the array so that whenever A[i] is odd, i is odd; and whenever A[i] is even, i is even.
 * You may return any answer array that satisfies this condition.
 * 
 * Note:
 * 2 <= A.length <= 20000
 * A.length % 2 == 0
 * 0 <= A[i] <= 1000
 * 
 * Input: [4,2,5,7]
 * Output: [4,5,2,7]
 * Explanation: [4,7,2,5], [2,5,4,7], [2,7,4,5] would also have been accepted.
 *
 *******************************************************************************************************************************/

public class Solution922
{
    // --------------- O(n) 292ms --------------- O(n) 5.2MB --------------- (51% 22%)
    /*
     * use extra space
     */
    public int[] SortArrayByParityII_1(int[] A)
    {
        int[] B = new int[A.Length];
        int m = 0; int n = 1;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 0)
            {
                B[m] = A[i];
                m = m + 2;
            }
            else
            {
                B[n] = A[i];
                n = n + 2;
            }
        }
        return B;
    }

    // --------------- O(n) 296ms --------------- 34.6MB --------------- (42% 76%)
    /*
     * use while-if
     */
    public int[] SortArrayByParityII_2(int[] A)
    {
        int m = 0;
        int n = 1;
        while (m < A.Length && n < A.Length)
        {
            if (A[m] % 2 != 0 && A[n] % 2 == 0)
            {
                int temp = A[m];
                A[m] = A[n];
                A[n] = temp;
            }
            if (A[m] % 2 == 0)
            {
                m += 2;
            }
            if (A[n] % 2 != 0)
            {
                n += 2;
            }
        }
        return A;
    }
    
    // --------------- O(n) 276ms --------------- 37MB --------------- (34% 91%) ※
    /*
     * use while-while
     */
    public int[] SortArrayByParityII_2_2(int[] A)
    {
        int i = 0;
        int j = 1;
        while (i < A.Length)
        {
            while (i < A.Length && A[i] % 2 == 0)
            {
                i += 2;
            }

            while (j < A.Length && A[j] % 2 != 0)
            {
                j += 2;
            }

            if (i < A.Length)
            {
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
                i += 2;
                j += 2;
            }
        }

        return A;
    }
    
    // --------------- 300ms --------------- 34.6MB --------------- (46% 72%) 
    public int[] SortArrayByParityII_3(int[] A)
    {
        int j = 1;
        for (int i = 0; i < A.Length; i+=2)
        {
            if (A[i] % 2 != 0)
            {
                while (A[j] % 2 != 0)
                {
                    j += 2;
                }

                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
            }
        }
        return A;
    }
}
/**************************************************************************************************************
 * SortArrayByParityII_2                                                                                      *
 **************************************************************************************************************/
