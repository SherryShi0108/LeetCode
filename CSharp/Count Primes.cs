//Source  : https://leetcode.com/problems/count-primes/
//Author  : Xinruo Shi
//Date    : 2019-08-03
//Language: C#

/*******************************************************************************************************************************
 * 
 * Count the number of prime numbers less than a non-negative number, n.
 * 
 * Input: 10
 * Output: 4
 * Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
 * 
 *******************************************************************************************************************************/

public class Solution204
{
    ///+++++++++++++++++++++++++ Time Limit Exceeded +++++++++++++++++++++++++
    /*
     * O(n^2) , but this solution is true
     */
    public int CountPrimes_1(int n)
    {
        int count = 0;

        for (double i = 2; i < n; i++)
        {
            bool flag = true;
            for (double j = 2; j < i; j++)
            {
                if ((i / j) % 1 == 0)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                count++;
            }
        }
        return count;
    }
    ///+++++++++++++++++++++++++ Time Limit Exceeded +++++++++++++++++++++++++

    // --------------- O(nlog(n)) 64ms --------------- 14.9MB --------------- (80% 92%) ※
    public int CountPrimes_2(int n)
    {
        int count = 0;
        bool[] notPrimes = new bool[n];
        for (int i = 2; i < n; i++)
        {
            if (notPrimes[i] == false)
            {
                count++;
                for (int j = 2; j * i < n; j++)
                {
                    notPrimes[i * j] = true;
                }
            }
        }
        return count;
    }
}
/**************************************************************************************************************
 * CountPrimes_2                                                                                              *
 **************************************************************************************************************/