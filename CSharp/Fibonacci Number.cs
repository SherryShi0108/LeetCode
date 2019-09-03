//Source  : https://leetcode.com/problems/fibonacci-number/
//Author  : Xinruo Shi
//Date    : 2019-06-14
//Language: C#

/*******************************************************************************************************************************
 * 
 * The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, 
 * such that each number is the sum of the two preceding ones, starting from 0 and 1. That is, Given N, calculate F(N).
 *          F(0) = 0,   F(1) = 1
 *          F(N) = F(N - 1) + F(N - 2), for N > 1.
 * 
 * Note:
 * 0 ≤ N ≤ 30.
 * 
 * Input: 2
 * Output: 1
 * Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.
 * 
 *******************************************************************************************************************************/

public class Solution509
{
    // --------------- O(n) 36ms --------------- 12.7MB --------------- (99.3% 99.4%)
    public int Fib_1(int N)
    {
        if (N < 2) { return N; }

        int[] a = new int[N];
        a[0] = 0; a[1] = 1;
        for (int i = 2; i < N; i++)
        {
            a[i] = a[i - 1] + a[i - 2];
        }

        return a[N - 1] + a[N - 2];
    }

    // --------------- O(n) 36ms --------------- 12.7MB --------------- (99.3% 99.4%) ※
    public int Fib_2(int N)
    {
        if (N == 0) { return 0; }

        int a = 0; int b = 1;
        for (int i = 2; i < N; i++)
        {
            int c = a + b;
            a = b;
            b = c;
        }

        return a + b;
    }

    // --------------- O(n) 40ms --------------- 12.6MB --------------- (63% 100%)
    /*
     * But really, repeatedly recalculating unchanging constants is stupid.
     * Do you start summing infinite series to figure out the value of pi every time you want the area of a circle?
     * Of course not! The work is already done, and you just use the pre-calculated constant. It's the same idea here.
     */
    static readonly int[] Fibs = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584,
        4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040 };
    public int Fib_3(int N)
    {
        return Fibs[N];
    }
    
    //--------------- O(2^n) 56ms --------------- 12.6MB --------------- (35% 100%)
    /* Recursive */
    public int Fib(int n)
    {
        if (n < 2)
        {
            return n;
        }
        else
        {
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
/**************************************************************************************************************
 * Fib_1 Fib_2                                                                                                *
 **************************************************************************************************************/
