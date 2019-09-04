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

    public int Dis(int[] p1, int[] p2)
    {
        int x0 = p1[0] - p2[0];
        int y0 = p1[1] - p2[1];
        int mul = x0 * x0 + y0 * y0;
        return mul;
    }
    // --------------- O(n^2) 264ms --------------- 44MB --------------- (53% 100%) ※
    public int NumberOfBoomerangs_1(int[][] points)
    {
        int count = 0;        
        for (int i = 0; i < points.Length; i++)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int j = 0; j < points.Length; j++)
            {
                if (j != i)
                {
                    int mul = Dis(points[i], points[j]);
                    if (d.ContainsKey(mul))
                    {
                        d[mul]++;
                    }
                    else
                    {
                        d[mul] = 1;
                    }
                }
            }
            foreach (var item in d)
            {
                count += (item.Value * (item.Value - 1));
            }
        }       
        return count;
    }
}
/**************************************************************************************************************
 * NumberOfBoomerangs_1                                                                                       *
 **************************************************************************************************************/