//Source  : https://leetcode.com/problems/subsets/
//Author  : Xinruo Shi
//Date    : 2019-08-07
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a set of distinct integers, nums, return all possible subsets (the power set).
 * 
 * Note: The solution set must not contain duplicate subsets.
 * 
 * Input: nums = [1,2,3]
 * Output:
 *      [
 *        [3],
 *        [1],
 *        [2],
 *        [1,2,3],
 *        [1,3],
 *        [2,3],
 *        [1,2],
 *        []
 *      ]
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution78
{
    //public IList<IList<int>> Subsets_1(int[] nums)
    //{

    //}



    public int[][] Transpose(int[][] A)
    {
        if (A.Length == 0 || A == null) { return null; }
        int m = A.Length;
        int n = A[0].Length;

        int[][] B = new int[n][];
        for (int i = 0; i < n; i++)
        {
            B[i] = new int[m];
            for (int k = 0; k < m; k++)
            {
                B[i][k] = A[k][i];
            }
        }
        return B;
    }

}


