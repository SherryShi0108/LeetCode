//Source  : https://leetcode.com/problems/sum-of-even-numbers-after-queries/
//Author  : Xinruo Shi
//Date    : 2019-07-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * We have an array A of integers, and an array queries of queries.
 * For the i-th query val = queries[i][0], index = queries[i][1], we add val to A[index].  Then, the answer to the i-th query is the sum of the even values of A.
 * (Here, the given index = queries[i][1] is a 0-based index, and each query permanently modifies the array A.)
 * Return the answer to all queries.  Your answer array should have answer[i] as the answer to the i-th query.
 * 
 * Note:
 * 1 <= A.length <= 10000
 * -10000 <= A[i] <= 10000
 * 1 <= queries.length <= 10000
 * -10000 <= queries[i][0] <= 10000
 * 0 <= queries[i][1] < A.length
 * 
 * Input: A = [1,2,3,4], queries = [[1,0],[-3,1],[-4,0],[2,3]]
 * Output: [8,6,2,4]
 * Explanation: 
 *      At the beginning, the array is [1,2,3,4].
 *      After adding 1 to A[0], the array is [2,2,3,4], and the sum of even values is 2 + 2 + 4 = 8.
 *      After adding -3 to A[1], the array is [2,-1,3,4], and the sum of even values is 2 + 4 = 6.
 *      After adding -4 to A[0], the array is [-2,-1,3,4], and the sum of even values is -2 + 4 = 2.
 *      After adding 2 to A[3], the array is [-2,-1,3,6], and the sum of even values is -2 + 6 = 4.
 * 
 *******************************************************************************************************************************/

public class Solution985
{
    ///+++++++++++++++++++++++++ Time Limit Exceeded +++++++++++++++++++++++++
    // O(n^2)
    public int[] SumEvenAfterQueries_1(int[] A, int[][] queries)
    {
        int[] B = new int[A.Length];
        for (int i = 0; i < B.Length; i++)
        {
            int index = queries[i][1];
            int value = queries[i][0];

            A[index] += value;
            for (int j = 0; j < A.Length; j++)
            {
                if (A[j] % 2 == 0)
                {
                    B[i] +=A[j];
                }
            }           
        }
        return B;
    }

    // --------------- O(n) 456ms --------------- 47.1MB --------------- (33.3% 6%) 
    public int[] SumEvenAfterQueries_2(int[] A, int[][] queries)
    {
        int sum = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 0)
            {
                sum += A[i];
            }
        }

        int[] B = new int[A.Length];

        for (int i = 0; i < A.Length; i++)
        {
            int index = queries[i][1];
            int value = queries[i][0];

            if (A[index] % 2 == 0)
            {
                sum = sum - A[index];
            }
            A[index] += value;
            if (A[index] % 2 == 0)
            {
                sum = sum + A[index];
            }

            B[i] = sum;
        }
        return B;
    }
    
     // --------------- O(n) 452ms --------------- 47MB --------------- (60% 100%)  ※
    public int[] SumEvenAfterQueries_3(int[] A, int[][] queries)
    {
        int sum = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 0)
            {
                sum += A[i];
            }
        }

        int[] B = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int[] C = queries[i];

            if (A[C[1]] % 2 == 0 && C[0] % 2 == 0)
            {
                sum = sum + C[0] ;
            }
            else if (A[C[1]] % 2 != 0 && C[0] % 2 != 0)
            {
                sum = sum + A[C[1]] + C[0];
            }
            else if (A[C[1]] % 2 == 0 && C[0] % 2 != 0)
            {
                sum = sum - A[C[1]];
            }
            B[i] = sum;
            A[C[1]] += C[0];
        }

        return B;
    }
}
/**************************************************************************************************************
 * SumEvenAfterQueries_3                                                                                      *
 **************************************************************************************************************/
