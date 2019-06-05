//Source  : https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
//Author  : Xinruo Shi
//Date    : 2019-06-02
//Language: C#

/*******************************************************************************************************************************
 * 
 * Say you have an array for which the i^th element is the price of a given stock on day i.
 * 
 * If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), 
 * design an algorithm to find the maximum profit.
 * Note that you cannot sell a stock before you buy one.
 * 
 * Input:  [7,1,5,3,6,4]
 * Output: 5
 * Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
 *              Not 7-1 = 6, as selling price needs to be larger than buying price.
 *
 * Input:  [7,6,4,3,1]
 * Output: 0
 * 
 *******************************************************************************************************************************/

public class Solution121
{
    // ---------------Brute Force --------------- O(n^2) 892ms --------------- 23.4MB ---------------
    public int MaxProfit_1(int[] nums)
    {
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if ((nums[j] - nums[i]) > max && (nums[j] - nums[i]) > 0)
                {
                    max = nums[j] - nums[i];
                }
            }
        }

        return max;
    }

    // --------------- Kadane's Algorithm --------------- O(n) 100ms --------------- 23.3MB --------------- 
    public int MaxProfit_2(int[] nums)
    {
        int sum = 0;
        int max = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (sum + (nums[i] - nums[i - 1]) > 0)
            {
                sum = sum + (nums[i] - nums[i - 1]);
            }
            else
            {
                sum = 0;
            }
            max = max >= sum ? max : sum;
        }

        return max;
    }

    // --------------- O(n) 104ms --------------- 23.4MB ---------------
    public int MaxProfit_3(int[] nums)
    {
        if (nums.Length == 0 || nums == null)
        {
            return 0;
        }

        int max = 0;
        int min = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            max = max > nums[i] - min ? max : nums[i] - min;
            min = min > nums[i] ? nums[i] : min;
        }
        return max;
    }

    // --------------- dynamic programming  --------------- 
    public int MaxProfit_4(int[] nums)
    {

        return 0;
    }
}
/**************************************************************************************************************
 * MaxProfit_2 MaxProfit_3                                                                                    *
 **************************************************************************************************************/
