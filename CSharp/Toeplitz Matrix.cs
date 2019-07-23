//Source  : https://leetcode.com/problems/toeplitz-matrix/
//Author  : Xinruo Shi
//Date    : 2019-07-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * A matrix is Toeplitz if every diagonal from top-left to bottom-right has the same element.
 * Now given an M x N matrix, return True if and only if the matrix is Toeplitz.
 * 
 * Note:
 * matrix will be a 2D array of integers.
 * matrix will have a number of rows and columns in range [1, 20].
 * matrix[i][j] will be integers in range [0, 99].
 * 
 * Input:
 *      matrix = [
 *                 [1,2,3,4],
 *                 [5,1,2,3],
 *                 [9,5,1,2]
 *               ]
 * Output: True
 * Explanation: 
 *      In the above grid, the diagonals are:"[9]", "[5, 5]", "[1, 1, 1]", "[2, 2, 2]", "[3, 3]", "[4]".
 *      In each diagonal all elements are the same, so the answer is True.
 * 
 * Input:
 *      matrix = [
 *                 [1,2],
 *                 [2,2]
 *               ]
 * Output: False
 * Explanation: The diagonal "[1, 2]" has different elements.
 * 
 * Follow up:
 * What if the matrix is stored on disk, and the memory is limited such that you can only load at most one row of the matrix into the memory at once?
 * What if the matrix is so large that you can only load up a partial row into the memory at once?
 * ※ 
 *******************************************************************************************************************************/

public class Solution766
{
    // --------------- O(n)=O(matrix.W*matrix.H) 112ms --------------- 25.6MB --------------- (58% 29%) ※
    public bool IsToeplitzMatrix_1(int[][] matrix)
    {
        int x = matrix.Length;
        int y = matrix[0].Length;

        for (int i = 1; i < y; i++)
        {
            for (int j = 1; j < x; j++)
            {
                if (matrix[j][i] != matrix[j - 1][i - 1])
                {
                    return false;
                }
            }
        }
        return true ;
    }
}
/**************************************************************************************************************
 * IsToeplitzMatrix_1                                                                                         *
 **************************************************************************************************************/