//Source  : https://leetcode.com/problems/arranging-coins/
//Author  : Xinruo Shi
//Date    : 2019-09-10
//Language: C#

/*******************************************************************************************************************************
 * 
 * You have a total of n coins that you want to form in a staircase shape, where every k-th row must have exactly k coins.
 * Given n, find the total number of full staircase rows that can be formed.
 * n is a non-negative integer and fits within the range of a 32-bit signed integer.
 * 
 * n = 5
 * The coins can form the following rows:
 *          ¤
 *          ¤ ¤
 *          ¤ ¤
 * Because the 3rd row is incomplete, we return 2.
 * 
 * n = 8
 * The coins can form the following rows:
 *          ¤
 *          ¤ ¤
 *          ¤ ¤ ¤
 *          ¤ ¤
 * Because the 4th row is incomplete, we return 3.
 * ※
 *******************************************************************************************************************************/

public class Solution441
{
    // --------------- O(n) 56ms --------------- 12.9MB --------------- (57% 100%)
    public int ArrangeCoins_1(int n)
    {
        int i = 1;    // or i=0;
        while (n >= 0)
        {
            n = n - i;
            i++;
        }

        return i - 2;
    }
    
    // --------------- O(n) 56ms --------------- 16MB --------------- (35% 17%)
    public int ArrangeCoins_1_2(int n)
    {
        int i = 1;    // or i=0;
        while (n >= i)
        {
            n -= i;
            i++;
        }

        return i - 1;
    }

    // --------------- O(logn) 44ms --------------- 14.2MB --------------- (83% 100%)
    /* 
     * logn Binary Search 
     * use long
     */
    public int ArrangeCoins_2(int n)
    {
        long i = 1;
        long j = n;

        while (i<=j)
        {
            long mid = i + (j - i) / 2;
            long temp = mid * (mid + 1) / 2;
            if (temp == n) return (int)mid;
            else if(temp>n)
            {
                j = mid - 1;
            }
            else
            {
                i = mid + 1;
            }
        }

        return (int)j;
    }

    // --------------- O(1) 40ms --------------- 12.7MB --------------- (93% 100%)
    /*
     * (1+x)*x/2 <= n
     * 4*x*x + 4*x <= 8*n => x <= (sqrt(8*n + 1) - 1) / 2
     * 
     * should use long/double to extend n , or 8.0
     */
    public int ArrangeCoins_3(int n)
    {
        double x = (System.Math.Sqrt(8.0 * n + 1) - 1) / 2;
        return (int)x;
    }
}
/**************************************************************************************************************
 * ArrangeCoins_1 ArrangeCoins_2 ArrangeCoins_3                                                               *
 **************************************************************************************************************/
