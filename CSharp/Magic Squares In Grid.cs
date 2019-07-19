//Source  : https://leetcode.com/problems/magic-squares-in-grid/
//Author  : Xinruo Shi
//Date    : 2019-07-04
//Language: C#

/*******************************************************************************************************************************
 * 
 * A 3 x 3 magic square is a 3 x 3 grid filled with distinct numbers from 1 to 9 such that each row, column, and both diagonals all have the same sum.
 * Given an grid of integers, how many 3 x 3 "magic square" subgrids are there?  (Each subgrid is contiguous).
 * 
 * Note:
 * 1 <= grid.length <= 10
 * 1 <= grid[0].length <= 10
 * 0 <= grid[i][j] <= 15
 * 
 * Input: [[4,3,8,4],
 *         [9,5,1,9],
 *         [2,7,6,2]]
 * Output: 1
 * Explanation: 
 *      The following subgrid is a 3 x 3 magic square:
 *             438
 *             951
 *             276
 *      while this one is not:
 *             384
 *             519
 *             762
 *      In total, there is only one magic square inside the given grid.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution840
{
    // --------------- O(n)=O(grid.length) 88ms --------------- 22.4MB --------------- (100% 20%) 
    /*
     * Boring problem
     */
    public int NumMagicSquaresInside_1(int[][] grid)
    {
        int N1 = grid.Length;
        int N2 = grid[0].Length;
        int count = 0;

        for (int i = 0; i < N1 - 2; i++)
        {
            for (int j = 0; j < N2 - 2; j++)
            {
                if (grid[i][j] + grid[i][j + 1] + grid[i][j + 2] != 15) continue;
                if (grid[i + 1][j] + grid[i + 1][j + 1] + grid[i + 1][j + 2] != 15) continue;
                if (grid[i + 2][j] + grid[i + 2][j + 1] + grid[i + 2][j + 2] != 15) continue;
                if (grid[i][j] + grid[i + 1][j] + grid[i + 2][j] != 15) continue;
                if (grid[i][j + 1] + grid[i + 1][j + 1] + grid[i + 2][j + 1] != 15) continue;
                if (grid[i][j + 2] + grid[i + 1][j + 2] + grid[i + 2][j + 2] != 15) continue;
                if (grid[i][j] + grid[i + 1][j + 1] + grid[i + 2][j + 2] != 15) continue;
                if (grid[i + 2][j] + grid[i + 1][j + 1] + grid[i][j + 2] != 15) continue;

                List<int> L = new List<int>();
                L.Add(grid[i][j]);L.Add(grid[i][j + 1]);L.Add(grid[i][j + 2]);
                L.Add(grid[i + 1][j]);L.Add(grid[i + 1][j + 1]);L.Add(grid[i + 1][j + 2]);
                L.Add(grid[i + 2][j]);L.Add(grid[i + 2][j + 1]);L.Add(grid[i + 2][j + 2]);
                if (IsAll9(L))
                {
                    count++;
                }
            }
        }
        return count;
    }
    public bool IsAll9(List<int> a)
    {
        if (!a.Contains(1)) return false;
        if (!a.Contains(2)) return false;
        if (!a.Contains(3)) return false;
        if (!a.Contains(4)) return false;
        if (!a.Contains(5)) return false;
        if (!a.Contains(6)) return false;
        if (!a.Contains(7)) return false;
        if (!a.Contains(8)) return false;
        if (!a.Contains(9)) return false;

        return true;
    }
}
/**************************************************************************************************************
 * NumMagicSquaresInside_1                                                                                    *
 **************************************************************************************************************/