//Source  : https://leetcode.com/problems/add-to-array-form-of-integer/
//Author  : Xinruo Shi
//Date    : 2019-07-24
//Language: C#

/*******************************************************************************************************************************
 * 
 * For a non-negative integer X, the array-form of X is an array of its digits in left to right order.  For example, if X = 1231, then the array form is [1,2,3,1].
 * Given the array-form A of a non-negative integer X, return the array-form of the integer X+K.
 * 
 * Note:
 * 1 <= A.length <= 10000
 * 0 <= A[i] <= 9
 * 0 <= K <= 10000
 * If A.length > 1, then A[0] != 0
 * 
 * Input: A = [1,2,0,0], K = 34
 * Output: [1,2,3,4]
 * Explanation: 1200 + 34 = 1234
 * 
 * Input: A = [2,7,4], K = 181
 * Output: [4,5,5]
 * Explanation: 274 + 181 = 455
 * 
 * Input: A = [2,1,5], K = 806
 * Output: [1,0,2,1]
 * Explanation: 215 + 806 = 1021
 * 
 * Input: A = [9,9,9,9,9,9,9,9,9,9], K = 1
 * Output: [1,0,0,0,0,0,0,0,0,0,0]
 * Explanation: 9999999999 + 1 = 10000000000
 *  
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution989
{
    // --------------- O(n) 308ms --------------- 37.9MB --------------- (72% 18%) 
    public IList<int> AddToArrayForm_1(int[] A, int K)
    {
        List<int> d = new List<int>();

        for (int i = A.Length - 1; i >= 0; i--)
        {
            int x = A[i] + K;
            d.Add(x % 10);
            K = x / 10;
        }

        while (K > 0)
        {
            d.Add(K % 10);
            K = K / 10;
        }

        d.Reverse();
        return d;
    }
    
    // --------------- O(n) 296ms --------------- 36.7MB --------------- (95% 88%) ※ 
    /*
     * improve 1 : use Insert(index,value) API , better than Add
     */
    public IList<int> AddToArrayForm_1_2(int[] A, int K)
    {
        List<int> d = new List<int>(A);

        for (int i = A.Length - 1; i >= 0; i--)
        {
            int x = A[i] + K;
            d[i] = x % 10;
            K = x / 10;
        }

        while (K > 0)
        {
            d.Insert(0, K % 10);
            K = K / 10;
        }

        return d;
    }

    // --------------- O(n) 312ms --------------- 37.7MB --------------- (63% 70%) 
    public IList<int> AddToArrayForm_2(int[] A, int K)
    {
        List<int> d = new List<int>();

        int i = A.Length - 1;
        while (i >= 0 || K > 0)
        {
            K = K + (i >= 0 ? A[i--] : 0);
            d.Add(K % 10);
            K = K / 10;
        }

        d.Reverse();
        return d;
    }
}
/**************************************************************************************************************
 * AddToArrayForm_1 / AddToArrayForm_2                                                                        *
 **************************************************************************************************************/
