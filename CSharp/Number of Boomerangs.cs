//Source  : https://leetcode.com/problems/number-of-boomerangs/
//Author  : Xinruo Shi
//Date    : 2019-08-13
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given n points in the plane that are all pairwise distinct, a "boomerang" is a tuple of points (i, j, k) 
 * such that the distance between i and j equals the distance between i and k (the order of the tuple matters).
 * Find the number of boomerangs. You may assume that n will be at most 500 and coordinates of points are all in the range [-10000, 10000] (inclusive).
 * 
 * Input: [[0,0],[1,0],[2,0]]
 * Output: 2
 * Explanation: The two boomerangs are [[1,0],[0,0],[2,0]] and [[1,0],[2,0],[0,0]]
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution447
{
    // --------------- O(n^2) 260ms --------------- 47MB --------------- (93% 91%) ※
    public int NumberOfBoomerangs_1(int[][] points)
    {
        int result = 0;
        for (int i = 0; i < points.Length; i++)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int j = 0; j < points.Length; j++)
            {
                if (i == j) continue;
                int temp = Distict(points[i], points[j]);
                d[temp] = d.ContainsKey(temp) ? d[temp] + 1 : 1;
            }

            foreach (var item in d)
            {
                result += item.Value * (item.Value - 1);
            }
        }

        return result;
    }
    
    public int Distict(int[] p1, int[] p2)
    {
        int x = p1[0] - p2[0];
        int y = p1[1] - p2[1];

        return x * x + y * y;
    }
}
/**************************************************************************************************************
 * NumberOfBoomerangs_1                                                                                       *
 **************************************************************************************************************/
