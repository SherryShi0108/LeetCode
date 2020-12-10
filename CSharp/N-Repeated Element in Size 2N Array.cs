//Source  : https://leetcode.com/problems/n-repeated-element-in-size-2n-array/
//Author  : Xinruo Shi
//Date    : 2019-08-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * In a array A of size 2N, there are N+1 unique elements, and exactly one of these elements is repeated N times.
 * Return the element repeated N times.
 * 
 * Input: [1,2,3,3]
 * Output: 3
 * 
 * Input: [2,1,2,5,3,2]
 * Output: 2
 * 
 * Input: [5,1,5,2,5,3,5,4]
 * Output: 5
 * 
 * Note:
 *      4 <= A.length <= 10000
 *      0 <= A[i] < 10000
 *      A.length is even
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution961
{
    // --------------- O(n) 124ms --------------- 34MB ---------------(80% 73%) 
    /*
     * use HashSet
     */
    public int RepeatedNTimes_1(int[] A)
    {
        HashSet<int> h = new HashSet<int>();
        for (int i = 0; i < A.Length; i++)
        {
            if (h.Add(A[i]) == false)
            {
                return A[i];
            }
        }

        return 0;
    }

    // --------------- O(n) 124ms --------------- 31MB ---------------(98% 11%) ※
    /*
     * smart solution
     */
    public int RepeatedNTimes_2(int[] A)
    {
        for (int i = 0; i < A.Length - 2; i++)
        {
            if (A[i] == A[i + 1] || A[i] == A[i + 2])
            {
                return A[i];
            }
        }
        return A[A.Length - 1]; // A[0] Error,because [1,2,3,3] 
    }

    // --------------- O(4) 136ms --------------- 31MB ---------------(70% 33%)
    /*
     * amazing solution
     * here is a 25% chance you bump into the repeated number,So, in average, we will find the answer in 4 attempts, thus O(4) runtime.
     */
    public int RepeatedNTimes_3(int[] A)
    {
        int m = 0;int n = 0;
        Random r = new Random();
        while (m == n || A[m] != A[n])
        {
            m = r.Next() % A.Length;
            n = r.Next() % A.Length;
        }
        return A[m];
    }
}
/**************************************************************************************************************
 * RepeatedNTimes_1 RepeatedNTimes_2 RepeatedNTimes_3                                                         *
 **************************************************************************************************************/
