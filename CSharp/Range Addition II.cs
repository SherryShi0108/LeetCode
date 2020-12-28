//Source  : https://leetcode.com/problems/range-addition-ii/
//Author  : Xinruo Shi
//Date    : 2019-09-12
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are given an m x n matrix M initialized with all 0's and an array of operations ops, where ops[i] = [ai, bi]
 * means M[x][y] should be incremented by one for all 0 <= x < ai and 0 <= y < bi.
 * Count and return the number of maximum integers in the matrix after performing all the operations.
 * 
 * Input: m = 3, n = 3 , operations = [[2,2],[3,3]]
 * Output: 4
 * Explanation: Initially, M = 
 *                              [[0, 0, 0],
 *                               [0, 0, 0],
 *                               [0, 0, 0]]
 *              After performing [2,2], M = 
 *                                          [[1, 1, 0],
 *                                           [1, 1, 0],
 *                                           [0, 0, 0]]
 *              After performing [3,3], M = 
 *                                          [[2, 2, 1],
 *                                           [2, 2, 1],
 *                                           [1, 1, 1]]
 *              So the maximum integer in M is 2, and there are four of it in M. So return 4.
 *              
 * Note:
 *      1 <= m, n <= 4 * 104
 *      1 <= ops.length <= 104
 *      ops[i].length == 2
 *      1 <= ai <= m
 *      1 <= bi <= n
 * 
 *******************************************************************************************************************************/

public class Solution598
{
    // --------------- O(n) 104ms --------------- O(1) 27MB --------------- (44% 44%) ※
    public int MaxCount_1(int m, int n, int[][] ops)
    {
        int hori = m;
        int veri = n;
        foreach (int[] ints in ops)
        {
            hori = hori < ints[0] ? hori : ints[0];
            veri = veri < ints[1] ? veri : ints[1];
        }
        return hori*veri;
    }
}
/**************************************************************************************************************
 * MaxCount_1                                                                                                 *
 **************************************************************************************************************/