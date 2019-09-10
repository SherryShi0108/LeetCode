//Source  : https://leetcode.com/problems/image-smoother/
//Author  : Xinruo Shi
//Date    : 2019-06-23
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a 2D integer matrix M representing the gray scale of an image, you need to design a smoother to make the gray scale of each 
 * cell becomes the average gray scale (rounding down) of all the 8 surrounding cells and itself. If a cell has less than 8 surrounding cells, then use as many as you can.
 * 
 * Note:
 * The value in the given matrix is in the range of [0, 255].
 * The length and width of the given matrix are in the range of [1, 150].
 * 
 * Input:
 *   [[1,1,1],
 *    [1,0,1],
 *    [1,1,1]]
 * Output:
 *   [[0, 0, 0],
 *    [0, 0, 0],
 *    [0, 0, 0]]
 * Explanation:
 * For the point (0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
 * For the point (0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
 * For the point (1,1): floor(8/9) = floor(0.88888889) = 0
 * ※ 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution661
{
    // --------------- O(n)=O(M.Length*M.Width) 444ms --------------- 33.7MB --------------- (6% 75%) 
    public int[][] ImageSmoother_1(int[][] M)
    {
        int m = M.Length;
        int n = M[0].Length;              
        int[][] result = new int[m][];

        for (int i = 0; i < m; i++)
        {
            result[i] = new int[n]; //C#特性需要实例化每行
            for (int j = 0; j < n; j++)
            {
                int count = 0;
                int sum = 0;

                for (int k = i-1; k <= i+1; k++)
                {                 
                    for (int l = j-1; l <= j+1; l++)
                    {
                        if (k >= 0 && k < m&&l>=0&&l<n)
                        {
                            count++;
                            sum += M[k][l];
                        }
                    }
                }
                result[i][j] = sum / count;
            }
        }

        return result;
    }
    
    // --------------- O(n)=O(M.Length*M.Width) 320ms --------------- 33.7MB --------------- (100% 75%) 
    public int[][] ImageSmoother_2(int[][] M)
    {
        int m = M.Length;
        int n = M[0].Length;
        int[][] N = new int[m][];
        for (int i = 0; i < m; i++)
        {
            N[i] = new int[n];
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int sum = 0;
                int count = 0;
                for (int k = i - 1 < 0 ? 0 : i - 1; k < (i + 2 > m ? m : i + 2); k++)
                {
                    for (int l = j - 1 < 0 ? 0 : j - 1; l < (j + 2 > n ? n : j + 2); l++)
                    {
                        sum += M[k][l];
                        count++;
                    }
                }
               
                N[i][j] = sum / count;
            }
        }

        return N;
    }
}
/**************************************************************************************************************
 * ImageSmoother_1 / 2                                                                                        *
 **************************************************************************************************************/
