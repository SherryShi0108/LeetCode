//Source  : https://leetcode.com/problems/maximum-product-of-three-numbers/
//Author  : Xinruo Shi
//Date    : 2019-06-21
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer array, find three numbers whose product is maximum and output the maximum product.
 * 
 * Note:
 * The length of the given array will be in range [3,10^4] and all elements are in the range [-1000, 1000].
 * Multiplication of any three numbers in the input won't exceed the range of 32-bit signed integer.
 * 
 * Input: nums = [1,2,3]
 * Output: 6
 * 
 * Input: nums = [1,2,3,4]
 * Output: 24
 * 
 *******************************************************************************************************************************/

public class Solution628
{
    // --------------- O(n) 132ms --------------- 35MB --------------- (86% 51%)  ※
    public int MaximumProduct_1(int[] nums)
    {
        int max1 = int.MinValue;
        int max2 = int.MinValue;
        int max3 = int.MinValue;

        int min1 = int.MaxValue;
        int min2 = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max1)
            {
                max3 = max2;
                max2 = max1;
                max1 = nums[i];
            }
            else if (nums[i] > max2)
            {
                max3 = max2;
                max2 = nums[i];
            }
            else if (nums[i] > max3)
            {
                max3 = nums[i];
            }

            if (nums[i] < min1)
            {
                min2 = min1;
                min1 = nums[i];
            }
            else if (nums[i] < min2)
            {
                min2 = nums[i];
            }
        }

        return max1 * max2 * max3 > max1 * min1 * min2 ? max1 * max2 * max3 : max1 * min1 * min2;
    }

    // --------------- O(nlogn) 164ms --------------- 32.5MB --------------- (32% 6%)
    /*
     * sort
     */
    public int MaximumProduct_2(int[] nums)
    {
        System.Array.Sort(nums);

        int n = nums.Length;
        int max = nums[n - 1] * nums[n - 2] * nums[n - 3] > nums[n - 1] * nums[0] * nums[1] ? nums[n - 1] * nums[n - 2] * nums[n - 3] : nums[n - 1] * nums[0] * nums[1];
        return max;
    }
}
/**************************************************************************************************************
 * MaximumProduct_1                                                                                           *
 **************************************************************************************************************/
