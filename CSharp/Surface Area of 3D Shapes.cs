//Source  : https://leetcode.com/problems/surface-area-of-3d-shapes/
//Author  : Xinruo Shi
//Date    : 2019-09-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * On a N * N grid, we place some 1 * 1 * 1 cubes.
 * Each value v = grid[i][j] represents a tower of v cubes placed on top of grid cell (i, j).
 * Return the total surface area of the resulting shapes.
 * 
 * Input: [[2]]
 * Output: 10
 * 
 * Input: [[1,2],[3,4]]
 * Output: 34
 * 
 * Input: [[1,0],[0,2]]
 * Output: 16
 * 
 * Input: [[1,1,1],[1,0,1],[1,1,1]]
 * Output: 32
 * 
 * Input: [[2,2,2],[2,1,2],[2,2,2]]
 * Output: 46
 * 
 * Note: 1 <= N <= 50
 *       0 <= grid[i][j] <= 50
 * 
 *******************************************************************************************************************************/

public class Solution892
{
    // --------------- O(n^2) 100ms --------------- O(1) 26MB --------------- (56% 56%) ※
    public int SurfaceArea_1(int[][] grid)
    {
        int result = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] > 0)
                {
                    result += 4 * grid[i][j] + 2;
                }

                if (i > 0)
                {
                    int temp = grid[i][j] < grid[i - 1][j] ? grid[i][j] : grid[i - 1][j];
                    result -= temp * 2;
                }

                if (j > 0)
                {
                    int temp = grid[i][j] < grid[i][j - 1] ? grid[i][j] : grid[i][j - 1];
                    result -= temp * 2;
                }
            }
        }

        return result;
    }
}
/**************************************************************************************************************
 * SurfaceArea_1                                                                                              *
 **************************************************************************************************************/