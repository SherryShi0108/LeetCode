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
    // --------------- O(n) 260ms --------------- O(n) 31.9MB --------------- (75% 46%)
    /*
     * But Memory is O(n)
     */
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

    // --------------- O(n) 264ms --------------- O(n) 31.8MB --------------- (56% 50%)
    public int[] SortArrayByParity_1_2(int[] A)
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

    // --------------- O(n) 288ms --------------- 31.8MB --------------- (17% 50%)
    /*
     * But should exchange all even , even if all even
     */
    public int[] SortArrayByParity_2(int[] A)
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

    // --------------- O(n) 244ms --------------- 34MB --------------- (77% 83%) ※
    public int[] SortArrayByParity_3(int[] A)
    {
        int i = 0;
        int j = A.Length - 1;
        
        while (i < j)
        {
            while (i < j && A[i] % 2 == 0)
            {
                i++;
            }

            while (i < j && A[j] % 2 == 1)
            {
                j--;
            }

            if (i < j)
            {
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
                i++;
                j--;
            }
        }

        return A;
    }
}
/**************************************************************************************************************
 *  SortArrayByParity_3                                                                                       *
 **************************************************************************************************************/
