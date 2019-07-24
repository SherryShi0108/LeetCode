//Source  : https://leetcode.com/problems/pascals-triangle-ii/
//Author  : Xinruo Shi
//Date    : 2019-06-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle.
 * Note that the row index starts from 0.
 * 
 * Input: 3
 * Output: [1,3,3,1]
 * ※
 *******************************************************************************************************************************/

using System.Collections.Generic; //IList名称空间

public class Solution119
{
    // --------------- O(n^2) 240ms --------------- 23.9MB --------------- (14% 5%) ※
    public IList<int> GetRow_1(int rowIndex)
    {
        int[] nums = new int[rowIndex + 1];
        nums[0] = 1;
        for (int i = 1; i < rowIndex + 1; i++)
        {
            for (int j = i; j > 0; j--)
            {
                nums[j] = nums[j] + nums[j - 1];
            }
        }
        return nums;
    }

    // --------------- O(n) 228ms --------------- 23.7MB --------------- (33% 7%) 
    /*
     * The idea deprives from binomial factor.
     * For example: rowIndex=5
     *              1: 1
     *              2: 5 / 1
     *              3: 5*4 / 1*2
     *              4: 5*4*3 / 1*2*3
     *              5: 5*4*3*2 / 1*2*3*4
     *              6: 5*4*3*2*1 / 1*2*3*4*5
     *              
     *  Attention: * result overflow
     */
    public IList<int> GetRow_2(int rowIndex)
    {
        List<int> L = new List<int>();

        int a = rowIndex; int b = 1;
        long m = 1; long n = 1;
        for (int i = 0; i < rowIndex + 1; i++)
        {
            if (i == 0)
            {
                L.Add(1);
            }
            else
            {
                m = m * a;
                n = n * b;

                int x = (int)(m / n);
                L.Add(x);

                a--;
                b++;

                m = x;
                n = 1;
            }
        }
        return L;
    }


    // --------------- O(n^2) 276ms --------------- 24MB --------------- (6% 8%) 
    /*
     * easy-understanding
     */
    public IList<int> GetRow_3(int rowIndex) 
    {
        List<int> old = new List<int>();

        for (int i = 0; i < rowIndex+1; i++)
        {
            List<int> current = new List<int>();

            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    current.Add(1);
                }
                else
                {
                    current.Add(old[j - 1] + old[j]);
                }
            }
            old = current;
        }
                     
        return old;
    }
}
/**************************************************************************************************************
 * GetRow_1 GetRow_2 GetRow_3                                                                                 *
 **************************************************************************************************************/