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
    // --------------- O(n) 372ms --------------- 49MB --------------- (63% 35%) ※
    public int[] SumEvenAfterQueries_1(int[] A, int[][] queries)
    {
        int sumEven = 0;
        foreach (int i in A)
        {
            if (i % 2 == 0)
            {
                sumEven += i;
            }
        }

        int[] result = new int[queries.Length];
        int index = 0;

        foreach (int[] item in queries)
        {
            if (A[item[1]] % 2 == 0)
            {
                sumEven -= A[item[1]];
            }

            A[item[1]] += item[0];

            if (A[item[1]] % 2 == 0)
            {
                sumEven += A[item[1]];
            }

            result[index++] = sumEven;
        }

        return result;
    }
    
    // --------------- O(n) 452ms --------------- 47MB --------------- (60% 100%)  
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
 * SumEvenAfterQueries_1                                                                                      *
 **************************************************************************************************************/
