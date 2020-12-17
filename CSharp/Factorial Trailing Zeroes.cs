//Source  : https://leetcode.com/problems/factorial-trailing-zeroes/
//Author  : Xinruo Shi
//Date    : 2019-09-04
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer n, return the number of trailing zeroes in n!.
 * 
 * Input: 3
 * Output: 0
 * Explanation: 3! = 6, no trailing zero.
 * 
 * Input: 5
 * Output: 1
 * Explanation: 5! = 120, one trailing zero.
 * 
 * Note: Your solution should be in logarithmic time complexity.
 * 
 *******************************************************************************************************************************/

public class Solution172
{
    // --------------- O(n^0.5) 36ms --------------- 12.7MB --------------- (96% 100%) ※
    /*
     * it's amazing solution , all trailing 0 is from factors 5 * 2
     */
    public int TrailingZeroes_1(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n / 5;
            n /= 5;
        }

        return count;
    }

    // --------------- O(n^0.5) 36ms --------------- 12.6MB --------------- (96% 100%)
    /*
     * 3 is better than this solution , because / is greater than * , * can cause overflow 
     * in this solution , should use long i , to avoid overflow number like 1808548329
     */
    public int TrailingZeroes_1_2(int n)
    {
        long count = 0;
        for (long i = 5; n / i > 0; i *= 5)
        {
            count += (n / i);
        }
        return (int)count;
    }
}
/**************************************************************************************************************
 * TrailingZeroes_1                                                                                           *
 **************************************************************************************************************/
