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
    // --------------- O(n ^ 1/2) 748ms --------------- 14MB --------------- (23% 100%) 
    /*
     * use two point
     */
    public bool CheckPerfectNumber_1(int num)
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

    // --------------- O(n ^ 1/2) 36ms --------------- 14MB --------------- (95% 100%) ※
    /*
     * O(time) = O(n ^ 1/2)
     */
    public bool CheckPerfectNumber_2(int num)
    {
        if (num <= 1) return false;

        int sum = 1;
        int n = 2;
        while (n * n <= num)
        {
            if (num % n == 0)
            {
                sum += num / n == n ? n : num / n + n;
                if (sum > num) return false;
            }

            n++;
        }

        return sum == num;
    }

    /*
     * Math solution :  Euclid-Euler Theorem  
     */
    public bool CheckPerfectNumber_3(int num)
    {

        return false;
    }
}
/**************************************************************************************************************
 * CheckPerfectNumber_1 CheckPerfectNumber_2                                                                  *
 **************************************************************************************************************/
