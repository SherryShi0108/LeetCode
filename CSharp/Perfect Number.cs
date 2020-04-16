//Source  : https://leetcode.com/problems/perfect-number/
//Author  : Xinruo Shi
//Date    : 2019-09-11
//Language: C#

/*******************************************************************************************************************************
 * 
 * We define the Perfect Number is a positive integer that is equal to the sum of all its positive divisors except itself.
 * Now, given an integer n, write a function that returns true when it is a perfect number and false when it is not.
 * 
 * Input: 28
 * Output: True
 * Explanation: 28 = 1 + 2 + 4 + 7 + 14
 * 
 * Note: The input number n will not exceed 100,000,000. (1e8)
 * 
 *******************************************************************************************************************************/

public class Solution507
{
    ///+++++++++++++++++++++++++ Time Limited +++++++++++++++++++++++++
    /*
     * O(time) = O(n)
     * this idea is true , but cost much time
     */
    public bool CheckPerfectNumber_1(int num)
    {
        int sum = 0;
        int n = num - 1;
        while (n > 0)
        {
            if (num % n == 0)
            {
                sum += n;
            }

            n--;
        }

        return sum == num;
    }
    
    // --------------- O(n ^ 1/2) 748ms --------------- 14MB --------------- (23% 100%) ※
    /*
     * use two point
     */
    public bool CheckPerfectNumber_2(int num)
    {
        if (num <= 1) return false;

        int i = 2;
        int j = num;

        int count = 1;
        while (i < j)
        {
            if (num % i == 0)
            {
                j = num / i;
                count += i == j ? i : i + j;
                if (count > num) return false;
            }

            i++;
        }

        return count == num;
    }
    
    // --------------- O(n ^ 1/2) 944ms --------------- 14MB --------------- (5% 100%) 
    /*
     * similar to 2
     */
    public bool CheckPerfectNumber_2_2(int num)
    {
        if (num <= 1) return false;

        int sum = 1;
        int maxNum = num;

        for (int i = 2; i < maxNum; i++)
        {
            if (num % i == 0)
            {
                sum += i;
                sum += num / i;
                maxNum = num / i;
            }

            if (sum > num) break;
        }

        return sum == num;
    }

    // --------------- O(n ^ 1/2) 40ms --------------- 14MB --------------- (82% 100%) ※
    /*
     * O(time) = O(n ^ 1/2)
     */
    public bool CheckPerfectNumber_3(int num)
    {
        if (num <= 0) return false;

        int sum = 0;
        int n = 1;
        while (n * n <= num)
        {
            if (num % n == 0)
            {
                sum += n;
                if (n * n < num) sum += num / n;
            }

            n++;
        }

        return sum == 2 * num;
    }

    /*
     * Math solution :  Euclid-Euler Theorem  
     */
    public bool CheckPerfectNumber_4(int num)
    {

        return false;
    }
}
/**************************************************************************************************************
 * CheckPerfectNumber_1 CheckPerfectNumber_2 CheckPerfectNumber_3                                             *
 **************************************************************************************************************/
