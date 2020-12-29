//Source  : https://leetcode.com/problems/reshape-the-matrix/
//Author  : Xinruo Shi
//Date    : 2019-06-17
//Language: C#

/*******************************************************************************************************************************
 * 
 * In MATLAB, there is a very useful function called 'reshape', which can reshape a matrix into a new one with different size but keep its original data.
 * You're given a matrix represented by a two-dimensional array, and two positive integers r and c representing the row number and column number of the wanted reshaped matrix, respectively.
 * The reshaped matrix need to be filled with all the elements of the original matrix in the same row-traversing order as they were.
 * If the 'reshape' operation with given parameters is possible and legal, output the new reshaped matrix; Otherwise, output the original matrix.
 * 
 * Note:
 * The height and width of the given matrix is in range [1, 100].
 * The given r and c are all positive.
 * 
 * Input: nums = 
 *  [[1,2],
 *   [3,4]] 
 *   r = 1, c = 4
 * Output: [[1,2,3,4]]
 * Explanation:
 * The row-traversing of nums is [1,2,3,4]. The new reshaped matrix is a 1 * 4 matrix, fill it row by row by using the previous list.
 * 
 * Input: nums = 
 *  [[1,2],
 *   [3,4]]
 *   r = 2, c = 4
 * Output: 
 *  [[1,2],
 *   [3,4]]
 * Explanation:
 * There is no way to reshape a 2 * 2 matrix to a 2 * 4 matrix. So output the original matrix.
 * 
 *******************************************************************************************************************************/

public class Solution566
{
    // --------------- O(n)=O(nums.L*nums.W) 260ms --------------- O(n) 34MB --------------- (55% 93%) ※
    /*
     *  use 0 - m*n
     */
    public int[][] MatrixReshape_1(int[][] nums, int r, int c)
    {
        int m = nums.Length;
        int n = nums[0].Length;
        if (m * n != r * c) return nums;

        int[][] result = new int[r][];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = new int[c];
        }

        for (int i = 0; i < m * n; i++)
        {
            result[i / c][i % c] = nums[i / n][i % n];
        }

        return result;
    }
    
    // --------------- O(n)=O(nums.L*nums.W) 276ms --------------- O(n) 33.1MB --------------- (66.3% 33%)
    public int[][] MatrixReshape_2(int[][] nums, int r, int c)
    {
        int m = nums.Length;
        int n = nums[0].Length;
        if (m * n != r * c) return nums;
       
        int[][] result = new int[r][];
        for (int i = 0; i < r; i++)
        {
            result[i] = new int[c];
            for (int j = 0; j < c; j++)
            {
                result[i][j] = nums[(i * c + j) / n][(i * c + j) % n];
            }
        }

        return result;
    }
}
/**************************************************************************************************************
 * MatrixReshape_1 MatrixReshape_2                                                                            *
 **************************************************************************************************************/
