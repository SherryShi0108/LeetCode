//Source  : https://leetcode.com/problems/transpose-matrix/
//Author  : Xinruo Shi
//Date    : 2019-07-06
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a matrix A, return the transpose of A.
 * The transpose of a matrix is the matrix flipped over it's main diagonal, switching the row and column indices of the matrix.
 * 
 * Note:
 * 1 <= A.length <= 1000
 * 1 <= A[0].length <= 1000
 * 
 * Input: [[1,2,3],[4,5,6],[7,8,9]]
 * Output: [[1,4,7],[2,5,8],[3,6,9]]
 * 
 * Input: [[1,2,3],[4,5,6]]
 * Output: [[1,4],[2,5],[3,6]]
 *  
 *******************************************************************************************************************************/

public class Solution867
{
    // --------------- O(n)=O(A.W*A.H) 268ms --------------- 33.6MB --------------- (94% 11%) ※
    public int[][] Transpose_1(int[][] A)
    {      
        int[][] result = new int[A[0].Length][];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = new int[A.length];
            for (int j = 0; j < A.Length; j++)
            {
                result[i][j] = A[j][i];
            }
        }
        return result;
    }
}
/**************************************************************************************************************
 * Transpose_1                                                                                                *
 **************************************************************************************************************/
