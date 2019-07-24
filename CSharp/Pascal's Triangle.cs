//Source  : https://leetcode.com/problems/pascals-triangle/
//Author  : Xinruo Shi
//Date    : 2019-05-31
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
 * 
 * Input: 5
 * Output:
 * [
 *      [1],
 *     [1,1],
 *    [1,2,1],
 *   [1,3,3,1],
 *  [1,4,6,4,1]
 * ]
 *  
 *******************************************************************************************************************************/

using System.Collections.Generic; //IList名称空间

public class Solution118
{
    // --------------- O(n^2) 220ms --------------- 24.3MB --------------- (80% 5%) 
    public IList<IList<int>> Generate_1(int numRows)
    {
        List<IList<int>> L = new List<IList<int>>();
        if (numRows == 0) { return L; }

        int[] a = new int[1] { 1 };
        L.Add(a);
        if (numRows == 1) { return L; }

        for (int i = 1; i < numRows; i++)
        {
            int[] temp = new int[i + 1];
            temp[0] = 1; temp[i] = 1;
            for (int j = 1; j < i; j++)
            {
                temp[j] = L[i - 1][j - 1] + L[i - 1][j];
            }
            L.Add(temp);
        }
        return L;
    }

    // --------------- O(n^2) 224ms --------------- 24.3MB --------------- (63% 5%) 
    public IList<IList<int>> Generate_2(int numRows)
    {
        List<IList<int>> L = new List<IList<int>>();
        if (numRows == 0) { return L; }

        var previousRow = new List<int>();
        previousRow.Add(1);
        L.Add(previousRow);

        for (int i = 1; i < numRows; i++)
        {
            var currentRow = new List<int>();
            int previous = 0;
            foreach (int val in previousRow)
            {
                currentRow.Add(previous + val);
                previous = val;
            }
            currentRow.Add(1);

            L.Add(currentRow);
            previousRow = currentRow;
        }
        return L;
    }

    // --------------- O(n^2) 216ms --------------- 24.3MB --------------- (97% 5%)  ※
    public IList<IList<int>> Generate_3(int numRows)
    {
        List<IList<int>> result = new List<IList<int>>();

        for (int i = 0; i < numRows; i++)
        {
            List<int> list = new List<int>();

            for (int j = 0; j < i + 1; j++)
            {
                if (j == 0 || j == i)
                {
                    list.Add(1);
                }
                else
                {
                    int a = result[i - 1][j - 1];
                    int b = result[i - 1][j];
                    list.Add(a + b);
                }
            }
            result.Add(list);
        }
        return result;
    }
}
/**************************************************************************************************************
 * Generate_3                                                                                                 *
 **************************************************************************************************************/