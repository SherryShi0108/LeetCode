//Source  : https://leetcode.com/problems/sort-array-by-parity/
//Author  : Xinruo Shi
//Date    : 2019-07-10
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array A of non-negative integers, return an array consisting of all the even elements of A, followed by all the odd elements of A.
 * You may return any answer array that satisfies this condition.
 * 
 * Note:
 * 1 <= A.length <= 5000
 * 0 <= A[i] <= 5000
 * 
 * Input: [3,1,2,4]
 * Output: [2,4,3,1]
 * The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
 * 
 *******************************************************************************************************************************/

public class Solution905
{
    // --------------- O(n) 260ms --------------- 31.9MB --------------- (75% 46%)
    public int[] SortArrayByParity_1(int[] A)
    {
        int[] B = new int[A.Length];
        int n = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 0)
            {
                B[n++] = A[i];
            }
        }
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 1)
            {
                B[n++] = A[i];
            }
        }
        return B;
    }

    // --------------- O(n) 264ms --------------- 31.8MB --------------- (56% 50%)
    public int[] SortArrayByParity_2(int[] A)
    {
        int[] B = new int[A.Length];
        int m = 0;
        int n = A.Length - 1;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 0)
            {
                B[m++] = A[i];
            }
            else
            {
                B[n--] = A[i];
            }
        }
        return B;
    }

    // --------------- in-place --------------- O(n) 264ms --------------- 31.7MB --------------- (56% 80%)
    public int[] SortArrayByParity_3(int[] A)
    {
        int k = A.Length - 1;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 != 0)
            {
                int temp = A[i];
                A[i] = A[k];
                A[k] = temp;
                k--;
                i--;
            }
            if (i + 1 >= k)
            {
                break;
            }
        }
        return A;
    }

    // --------------- O(n) 288ms --------------- 31.8MB --------------- (17% 50%)
    public int[] SortArrayByParity_4(int[] A)
    {
        int j = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 0)
            {
                int temp = A[j];
                A[j++] = A[i];
                A[i] = temp;
            }
        }
        return A;
    }

    // --------------- O(n) 348ms --------------- 31.9MB --------------- (5% 46%)
    public int[] SortArrayByParity_5(int[] A)
    {
        int m = 0;
        int n = A.Length - 1;

        while (m < n)
        {
            if (A[m] % 2 == 0)
            {
                m++;
            }
            else
            {
                int temp = A[m];
                A[m] = A[n];
                A[n] = temp;

                n--;
            }
        }
        return A;
    }

    // --------------- O(n) 300ms --------------- 31.9MB --------------- (10% 46%) ※
    public int[] SortArrayByParity_6(int[] A)
    {
        int m = 0;
        int n = A.Length - 1;

        while (m < n)
        {
            if (A[m] % 2 != 0 && A[n] % 2 == 0)
            {
                int temp = A[m];
                A[m] = A[n];
                A[n] = temp;
            }
            if (A[m] % 2 == 0)
            {
                m++;
            }
            if (A[n] % 2 != 0)
            {
                n--;
            }
        }
        return A;
    }
}
/**************************************************************************************************************
 * Two Solution:new int[],in-place   SortArrayByParity_2/3/4/5/6                                              *
 **************************************************************************************************************/
