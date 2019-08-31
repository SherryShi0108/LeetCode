//Source  : https://leetcode.com/problems/largest-triangle-area/
//Author  : Xinruo Shi
//Date    : 2019-09-16
//Language: C#

/*******************************************************************************************************************************
 * 
 * You have a list of points in the plane. Return the area of the largest triangle that can be formed by any 3 of the points.
 * 
 * Input: points = [[0,0],[0,1],[1,0],[0,2],[2,0]]
 * Output: 2
 * Explanation: The five points are show in the figure below. The red triangle is the largest.
 * 
 * Notes:
 *      3 <= points.length <= 50.
 *      No points will be duplicated.
 *      -50 <= points[i][j] <= 50.
 *      Answers within 10^-6 of the true value will be accepted as correct.
 * ※
 *******************************************************************************************************************************/

public class Solution812
{
    // --------------- O(n^3) 108ms --------------- 22.2MB --------------- (69% 100%) ※
    /*
     * stupid question , it's a Math question more than a Programming question
     * use the Heron's formula : RectangleArea = 0.5 * a * b * sinC = 0.5 * ( x[0]y[1]+y[0]z[1]+z[0]x[1]-x[1]y[0]-y[1]z[0]-z[1]x[0] )
     */
    public double LargestTriangleArea_1(int[][] points)
    {
        double result = 0;
        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i+1; j < points.Length; j++)
            {
                for (int k = j+1; k < points.Length; k++)
                {
                    double temp = 0.5 * (points[i][0] * points[j][1] + points[j][0] * points[k][1] + points[k][0] * points[i][1]
                        - points[i][1] * points[j][0] - points[j][1] * points[k][0] - points[k][1] * points[i][0]);
                    double t = temp > 0 ? temp : -temp;
                    result = result > t ? result : t;
                }
            }
        }
        return result;
    }
}
/**************************************************************************************************************
 * LargestTriangleArea_1                                                                                      *
 **************************************************************************************************************/