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
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     *     " - * - = + "
     * if input: [-4,-3,-2,-1,60] 
     * this method is -2 * -1 * 60 = 120, but should be -4 * -3 * 60 = 720
     */
    public int MaximumProduct_1(int[] nums)
    {
        int[] d = new int[3] { int.MinValue, int.MinValue, int.MinValue };
        d[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] >= d[0])
            {
                d[2] = d[1];
                d[1] = d[0];
                d[0] = nums[i];
            }
            else if (nums[i] < d[0] && nums[i] >= d[1])
            {
                d[2] = d[1];
                d[1] = nums[i];
            }
            else if (nums[i] > d[2] && nums[i] < d[1])
            {
                d[2] = nums[i];
            }

        }

        return d[0] * d[1] * d[2];
    }
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++

    // --------------- O(n) 144ms --------------- 32.5MB --------------- (70% 6%) ※
    public int MaximumProduct_2(int[] nums)
    {
        int[] d1 = new int[3] { int.MinValue, int.MinValue, int.MinValue };
        int[] d2 = new int[2] { int.MaxValue, int.MaxValue };

        d1[0] = nums[0];
        d2[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] >= d1[0])
            {
                d1[2] = d1[1];
                d1[1] = d1[0];
                d1[0] = nums[i];
            }
            else if (nums[i] < d1[0] && nums[i] >= d1[1])
            {
                d1[2] = d1[1];
                d1[1] = nums[i];
            }
            else if (nums[i] > d1[2] && nums[i] < d1[1])
            {
                d1[2] = nums[i];
            }

            if (nums[i] < d2[0])
            {
                d2[1] = d2[0];
                d2[0] = nums[i];
            }
            else if (nums[i] >= d2[0] && nums[i] < d2[1])
            {
                d2[1] = nums[i];
            }
        }

        int max = (d1[0] * d1[1] * d1[2]) > (d1[0] * d2[1] * d2[0]) ? (d1[0] * d1[1] * d1[2]) : (d1[0] * d2[1] * d2[0]);

        return max;
    }

    // --------------- O(nlogn) 164ms --------------- 32.5MB --------------- (32% 6%)
    /*
     * sort
     */
    public int MaximumProduct_3(int[] nums)
    {
        System.Array.Sort(nums);

        int n = nums.Length;
        int max = nums[n - 1] * nums[n - 2] * nums[n - 3] > nums[n - 1] * nums[0] * nums[1] ? nums[n - 1] * nums[n - 2] * nums[n - 3] : nums[n - 1] * nums[0] * nums[1];
        return max;
    }
}
/**************************************************************************************************************
 * MaximumProduct_2                                                                                           *
 **************************************************************************************************************/