//Source  : https://leetcode.com/problems/largest-perimeter-triangle/
//Author  : Xinruo Shi
//Date    : 2019-09-26
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array A of positive lengths, return the largest perimeter of a triangle with non-zero area, formed from 3 of these lengths.
 * If it is impossible to form any triangle of non-zero area, return 0.
 * 
 * Input: [2,1,2]
 * Output: 5
 * 
 * Input: [1,2,1]
 * Output: 0
 * 
 * Input: [3,2,3,4]
 * Output: 10
 * 
 * Input: [3,6,2,3]
 * Output: 8
 * 
 * Note: 3 <= A.length <= 10000
 *       1 <= A[i] <= 10^6
 * 
 *******************************************************************************************************************************/

using System;

public class Solution976
{
    // --------------- O(nlogn) 140ms --------------- 30.4MB --------------- (96% 100%) ※
    public int LargestPerimeter_1(int[] A)
    {
        Array.Sort(A);
        for (int i = A.Length-1; i >= 2; i--)
        {
            if (A[i] < A[i - 1] + A[i - 2])
            {
                return A[i] + A[i - 1] + A[i - 2];
            }
        }
        return 0;
    }
    
    // O(n^3) Time Limit Exceeded
    public int LargestPerimeter_2(int[] A)
    {
        int max = 0;
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = i + 1; j < A.Length; j++)
            {
                for (int k = j + 1; k < A.Length; k++)
                {
                    if (A[i] + A[j] > A[k] &&
                        A[i] + A[k] > A[j] &&
                        A[j] + A[k] > A[i]) 
                    {
                        max = max > A[i] + A[j] + A[k] ? max : A[i] + A[j] + A[k];
                    }
                }
            }
        }

        return max;
    }
}
/**************************************************************************************************************
 * LargestPerimeter_1                                                                                         *
 **************************************************************************************************************/
