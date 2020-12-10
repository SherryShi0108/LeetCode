//Source  : https://leetcode.com/problems/powerful-integers/
//Author  : Xinruo Shi
//Date    : 2019-08-24
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two positive integers x and y, an integer is powerful if it is equal to x^i + y^j for some integers i >= 0 and j >= 0.
 * Return a list of all powerful integers that have value less than or equal to bound.
 * You may return the answer in any order.  In your answer, each value should occur at most once.
 * 
 * Input: x = 2, y = 3, bound = 10
 * Output: [2,3,4,5,7,9,10]
 * Explanation: 
 *              2 = 2^0 + 3^0
 *              3 = 2^1 + 3^0
 *              4 = 2^0 + 3^1
 *              5 = 2^1 + 3^1
 *              7 = 2^2 + 3^1
 *              9 = 2^3 + 3^0
 *              10 = 2^0 + 3^2
 *              
 * Input: x = 3, y = 5, bound = 15
 * Output: [2,4,6,8,10,14]
 * 
 * Note:
 *      1 <= x <= 100
 *      1 <= y <= 100
 *      0 <= bound <= 10^6
 * 
 *******************************************************************************************************************************/

using System;//Math NameSpace
using System.Collections.Generic;

public class Solution970
{
    // --------------- O(m*n) 216ms --------------- 24.1MB --------------- (98% 100%) ※
    public IList<int> PowerfulIntegers_1(int x, int y, int bound)
    {
        HashSet<int> H = new HashSet<int>();
        for (int i = 1; i <= bound; i*=x)
        {
            for (int j = 1; i+j <= bound; j*=y)
            {
                H.Add(i + j);
                if (y == 1) { break; }
            }
            if (x == 1) { break; }
        }
        return new List<int>(H);
    }
    
    // --------------- O(m*n) 204ms --------------- 25MB --------------- (95% 100%)
    public IList<int> PowerfulIntegers_2(int x, int y, int bound)
    {
        List<int> L1=new List<int>();
        List<int> L2 = new List<int>();

        int t1 = 1;
        while (t1<=bound)
        {
            L1.Add(t1);
            t1 *= x;
            if (t1 == 1) break;
        }

        int t2 = 1;
        while (t2 <= bound)
        {
            L2.Add(t2);
            t2 *= y;
            if(t2==1)break;
        }

        HashSet<int> H=new HashSet<int>();
        foreach (int i1 in L1)
        {
            foreach (int i2 in L2)
            {
                if (i1 + i2 <= bound)
                {
                    H.Add(i1 + i2);
                }
            }
        }
        List<int> result=new List<int>(H);
        return result;
    }
}
/**************************************************************************************************************
 * PowerfulIntegers_1                                                                                         *
 **************************************************************************************************************/
