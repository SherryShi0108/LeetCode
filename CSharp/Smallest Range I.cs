//Source  : https://leetcode.com/problems/smallest-range-i/
//Author  : Xinruo Shi
//Date    : 2019-09-20
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array A of integers, for each integer A[i] we may choose any x with -K <= x <= K, and add x to A[i].
 * After this process, we have some array B.
 * Return the smallest possible difference between the maximum value of B and the minimum value of B.
 * 
 * Input: A = [1], K = 0
 * Output: 0
 * Explanation: B = [1]
 * 
 * Input: A = [0,10], K = 2
 * Output: 6
 * Explanation: B = [2,8]
 * 
 * Input: A = [1,3,6], K = 3
 * Output: 0
 * Explanation: B = [3,3,3] or B = [4,4,4]
 * 
 * Note: 1 <= A.length <= 10000
 *       0 <= A[i] <= 10000
 *       0 <= K <= 10000
 * 
 *******************************************************************************************************************************/

using System.Linq;
using System.Runtime.InteropServices;

public class Solution908
{
    // --------------- O(n) 124ms --------------- 27.6MB --------------- (24% 100%)
    /*
     * min(A)+k,max(A)-k,and judge if these overlapping
     */
    public int SmallestRangeI_1(int[] A, int K)
    {
        int x = A.Max() - K;
        int y = A.Min() + K;

        if (x <= y)
        {
            return 0;
        }
        
        return x-y;
    }

    // --------------- O(n) 104ms --------------- 27.3MB --------------- (99% 100%) ※
    public int SmallestRangeI_2(int[] A, int K)
    {
        int max = int.MinValue;
        int min = int.MaxValue;
        foreach (int t in A)
        {
            max = max > t ? max : t;
            min = min < t ? min : t;
        }

        if (max - min <= 2 * K)
        {
            return 0;
        }

        return max - min - 2 * K;
    }
    
    // more tricky
     public int SmallestRangeI_3(int[] A, int K)
     {
         int t = (max - K) - (min + k) = max - min - 2 * K;
         return Max( 0 , t );
     } 
}
/**************************************************************************************************************
 * SmallestRangeI_2                                                                                           *
 **************************************************************************************************************/
