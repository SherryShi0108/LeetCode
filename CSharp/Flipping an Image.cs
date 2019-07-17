//Source  : https://leetcode.com/problems/flipping-an-image/
//Author  : Xinruo Shi
//Date    : 2019-07-03
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a binary matrix A, we want to flip the image horizontally, then invert it, and return the resulting image.
 * To flip an image horizontally means that each row of the image is reversed.  For example, flipping [1, 1, 0] horizontally results in [0, 1, 1].
 * To invert an image means that each 0 is replaced by 1, and each 1 is replaced by 0. For example, inverting [0, 1, 1] results in [1, 0, 0].
 * 
 * Note:
 * 1 <= A.length = A[0].length <= 20
 * 0 <= A[i][j] <= 1
 * 
 * Input: [[1,1,0],[1,0,1],[0,0,0]]
 * Output: [[1,0,0],[0,1,0],[1,1,1]]
 * Explanation: First reverse each row: [[0,1,1],[1,0,1],[0,0,0]].Then, invert the image: [[1,0,0],[0,1,0],[1,1,1]]
 * 
 * Input: [[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]]
 * Output: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
 * Explanation: First reverse each row: [[0,0,1,1],[1,0,0,1],[1,1,1,0],[0,1,0,1]].Then invert the image: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
 * 
 *******************************************************************************************************************************/

public class Solution832
{
    // --------------- O(n)=O(A.Length) 268ms --------------- 30.1MB --------------- (49% 90%) 
    public int[][] FlipAndInvertImage_1(int[][] A)
    {
        foreach (int[] item in A)
        {
            for (int i = 0; i < A[0].Length / 2; i++)
            {
                int temp = item[i];
                item[i] = item[A[0].Length - i - 1];
                item[A[0].Length - i - 1] = temp;
            }
            for (int i = 0; i < A[0].Length; i++)
            {
                if (item[i] == 0)
                {
                    item[i] = 1;
                }
                else
                {
                    item[i] = 0;
                }
            }
        }
        return A;
    }

    // --------------- O(n)=O(A.Length) 292ms --------------- 30.1MB --------------- (8% 90%) 
    public int[][] FlipAndInvertImage_2(int[][] A)
    {
        foreach (int[] item in A)
        {
            for (int i = 0; i < (A[0].Length + 1) / 2; i++)
            {
                int temp = item[i] ^ 1;
                item[i] = item[A[0].Length - i - 1] ^ 1;
                item[A[0].Length - i - 1] = temp;
            }
        }
        return A;
    }

    // --------------- O(n)=O(A.Length) 284ms --------------- 30MB --------------- (17% 97%) ※
    public int[][] FlipAndInvertImage_3(int[][] A)
    {
        foreach (int[] item in A)
        {
            for (int i = 0; i * 2 < A[0].Length; i++)
            {
                if (item[i] == item[A[0].Length - 1 - i])
                {
                    int x = item[i] ^ 1;     //或者 x=1-item[i];
                    item[i] = item[A[0].Length - 1 - i] = x;
                }
            }
        }
        return A;
    }
}
/**************************************************************************************************************
 * FlipAndInvertImage_1/2/3                                                                                   *
 **************************************************************************************************************/