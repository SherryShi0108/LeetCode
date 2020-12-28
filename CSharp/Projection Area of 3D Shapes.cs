//Source  : https://leetcode.com/problems/projection-area-of-3d-shapes/
//Author  : Xinruo Shi
//Date    : 2019-09-19
//Language: C#

/*******************************************************************************************************************************
 * 
 * On a N * N grid, we place some 1 * 1 * 1 cubes that are axis-aligned with the x, y, and z axes.
 * Each value v = grid[i][j] represents a tower of v cubes placed on top of grid cell (i, j).
 * Now we view the projection of these cubes onto the xy, yz, and zx planes.
 * A projection is like a shadow, that maps our 3 dimensional figure to a 2 dimensional plane. 
 * Here, we are viewing the "shadow" when looking at the cubes from the top, the front, and the side.
 * Return the total area of all three projections.
 * 
 * Input: [[2]]
 * Output: 5
 * 
 * Input: [[1,2],[3,4]]
 * Output: 17
 * Explanation: Here are the three projections ("shadows") of the shape made with each axis-aligned plane.
 * 
 * Input: [[1,0],[0,2]]
 * Output: 8
 * 
 * Input: [[1,1,1],[1,0,1],[1,1,1]]
 * Output: 14
 * 
 * Input: [[2,2,2],[2,1,2],[2,2,2]]
 * Output: 21
 * 
 * Note: 1 <= grid.length = grid[0].length <= 50
 *       0 <= grid[i][j] <= 50
 * 
 *******************************************************************************************************************************/

public class Solution883
{
    // --------------- O(n) 92ms --------------- O(1) 26MB --------------- (100% 71%) ※
    /*
     * Amazing Solution
     */
    public int ProjectionArea_1(int[][] grid)
    {
        int result = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            int maxRow = 0;
            int maxCol = 0;
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] > 0)
                {
                    result++;
                }

                maxRow = maxRow > grid[i][j] ? maxRow : grid[i][j];
                maxCol = maxCol > grid[j][i] ? maxCol : grid[j][i];
            }

            result += maxRow + maxCol;
        }

        return result;
    }
}
/**************************************************************************************************************
 * ProjectionArea_1                                                                                           *
 **************************************************************************************************************/
