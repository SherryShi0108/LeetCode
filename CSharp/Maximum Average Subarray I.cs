//Source  : https://leetcode.com/problems/maximum-average-subarray-i/
//Author  : Xinruo Shi
//Date    : 2019-06-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array consisting of n integers, find the contiguous subarray of given length k that has the maximum average value. 
 * And you need to output the maximum average value.
 * 
 * Note:
 * 1 <= k <= n <= 30,000.
 * Elements of the given array will be in the range [-10,000, 10,000].
 * 
 * Input: nums = [1,12,-5,-6,50,3], k = 4
 * Output: 12.75
 * Explanation: Maximum average is (12-5-6+50)/4 = 51/4 = 12.75
 * 
 *******************************************************************************************************************************/

public class Solution643
{
    // --------------- O(n) 264ms --------------- 42.4MB --------------- (41% 6%)
    public double FindMaxAverage_1(int[] nums, int k)
    {
        if (nums.Length == 0 || nums == null) { return 0; }

        double max = double.MinValue;
        double n = 0;
        int temp = k;
        for (int i = 0; i < nums.Length; i++)
        {
            while (k > 0)
            {
                n += nums[i];
                k--;
                i++;      
            }
            max = max > n ? max : n;

            if (i<nums.Length)
            {
                n = n + nums[i] - nums[i - temp];
                max = max > n ? max : n;
            }
        }
        return max/temp;
    }

    // --------------- O(n) 280ms --------------- 42.3MB --------------- (15% 6%)
    public double FindMaxAverage_2(int[] nums, int k)
    {
        double sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
        }
        double max = sum;
        for (int i = k; i < nums.Length; i++)
        {
            sum = sum + nums[i] - nums[i - k];
            max = max > sum ? max : sum;
        }
        return max/k;
    }

    // --------------- O(n) 256ms --------------- 42.4MB --------------- (58% 6%) ※
    /*
     * var instead double, time will less than
     */
    public double FindMaxAverage_3(int[] nums, int k)
    {
        var sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
        }
        var max = sum;
        for (int i = k; i < nums.Length; i++)
        {
            sum = sum + nums[i] - nums[i - k];
            max = max > sum ? max : sum;
        }
        return (double)max / k;
    }
}
/**************************************************************************************************************
 * FindMaxAverage_3                                                                                           *
 **************************************************************************************************************/