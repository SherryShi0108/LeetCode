//Source  : https://leetcode.com/problems/fair-candy-swap/
//Author  : Xinruo Shi
//Date    : 2019-07-20
//Language: C#

/*******************************************************************************************************************************
 * 
 * Alice and Bob have candy bars of different sizes: A[i] is the size of the i-th bar of candy that Alice has, and B[j] is the size of the j-th bar of candy that Bob has.
 * Since they are friends, they would like to exchange one candy bar each so that after the exchange, 
 * they both have the same total amount of candy.  (The total amount of candy a person has is the sum of the sizes of candy bars they have.)
 * Return an integer array ans where ans[0] is the size of the candy bar that Alice must exchange, and ans[1] is the size of the candy bar that Bob must exchange.
 * If there are multiple answers, you may return any one of them.  It is guaranteed an answer exists.
 * 
 * Note:
 * 1 <= A.length <= 10000
 * 1 <= B.length <= 10000
 * 1 <= A[i] <= 100000
 * 1 <= B[i] <= 100000
 * It is guaranteed that Alice and Bob have different total amounts of candy.
 * It is guaranteed there exists an answer.
 * 
 * Input: A = [1,1], B = [2,2]
 * Output: [1,2]
 * 
 * Input: A = [1,2], B = [2,3]
 * Output: [1,2]
 * 
 * Input: A = [2], B = [1,3]
 * Output: [2,3]
 * 
 * Input: A = [1,2,5], B = [2,4]
 * Output: [5,4]
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution888
{
    // --------------- O(n+m) 320ms --------------- 46.3MB --------------- (98% 6%) ※
    public int[] FairCandySwap_1(int[] A, int[] B)
    {
        int sum1 = 0;
        int sum2 = 0;
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < A.Length; i++)
        {
            sum1 += A[i];
            d[A[i]]=1 ;
        }
        for (int i = 0; i < B.Length; i++)
        {
            sum2 += B[i];
        }
        int avgSum = (sum1 + sum2) / 2;
        int temp = avgSum - sum1;
        // temp=(sum2-sum1)/2

        for (int i = 0; i < B.Length; i++)
        {
            if (d.ContainsKey(B[i] - temp))
            {
                return new int[] { B[i] - temp, B[i] };
            }
        }
        return null;
    }
}
/**************************************************************************************************************
 * FairCandySwap_1                                                                                            *
 **************************************************************************************************************/