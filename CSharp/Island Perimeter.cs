//Source  : https://leetcode.com/problems/island-perimeter/
//Author  : Xinruo Shi
//Date    : 2019-08-13
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water.
 * Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water,
 * and there is exactly one island (i.e., one or more connected land cells).
 * The island doesn't have "lakes" (water inside that isn't connected to the water around the island). 
 * One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. 
 * Determine the perimeter of the island.
 * 
 * Input:
 *      [[0,1,0,0],
 *      [1,1,1,0],
 *      [0,1,0,0],
 *      [1,1,0,0]]
 *      
 * Output: 16
 * Explanation: The perimeter is the 16 yellow stripes in the image below:https://assets.leetcode.com/uploads/2018/10/12/island.png
 * 
 *******************************************************************************************************************************/

public class Solution463
{
    // --------------- O(m*n) 212ms --------------- 27.2MB --------------- (89% 50%)
    public int IslandPerimeter_1(int[][] grid)
    {
        if (grid.Length == 0 || grid == null) { return 0; }
        int sum = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    //n
                    if (i == 0 || grid[i - 1][j] == 0) { sum++; }
                    //s
                    if (i == grid.Length - 1 || grid[i + 1][j] == 0) { sum++; }
                    //w
                    if (j == 0 || grid[i][j - 1] == 0) { sum++; }
                    //e
                    if (j == grid[0].Length - 1 || grid[i][j + 1] == 0) { sum++; }
                }
            }
        }
        return sum;
    }

    // --------------- O(m*n) 216ms --------------- 27.2MB --------------- (80% 50%) 
    public int IslandPerimeter_2(int[][] grid)
    {
        if (grid.Length == 0 || grid == null) { return 0; }
        int island = 0; int neighbours = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    island++;
                    if (i < grid.Length - 1 && grid[i + 1][j] == 1)
                    {
                        neighbours++;
                    }
                    if (j < grid[0].Length - 1 && grid[i][j + 1] == 1)
                    {
                        neighbours++;
                    }
                }
            }
        }
        return island * 4 - neighbours * 2;
    }

    // --------------- O(m*n) 224ms --------------- 27.2MB --------------- (57% 50%) ※
    /*
     * similar to 2
     */
    public int IslandPerimeter_3(int[][] grid)
    {
        if (grid.Length == 0 || grid == null) { return 0; }
        int result = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    result += 4;
                    if (i > 0 && grid[i - 1][j] == 1)
                    {
                        result -= 2;
                    }
                    if (j > 0 && grid[i][j - 1] == 1)
                    {
                        result -= 2;
                    }
                }
            }
        }
        return result;
    }
}
/**************************************************************************************************************
 * IslandPerimeter_1 IslandPerimeter_2 IslandPerimeter_3                                                      *
 **************************************************************************************************************/