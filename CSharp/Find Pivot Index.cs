//Source  : https://leetcode.com/problems/find-pivot-index/
//Author  : Xinruo Shi
//Date    : 2019-06-28
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of integers nums, write a method that returns the "pivot" index of this array.
 * We define the pivot index as the index where the sum of the numbers to the left of the index is equal to the sum of the numbers to the right of the index.
 * If no such index exists, we should return -1. If there are multiple pivot indexes, you should return the left-most pivot index.
 * 
 * Note:
 * The length of nums will be in the range [0, 10000].
 * Each element nums[i] will be an integer in the range [-1000, 1000].
 * 
 * Input: nums = [1, 7, 3, 6, 5, 6]
 * Output: 3
 * Explanation: The sum of the numbers to the left of index 3 (nums[3] = 6) is equal to the sum of numbers to the right of index 3.Also, 3 is the first index where this occurs.
 * 
 * Input: nums = [1, 2, 3]
 * Output: -1
 * Explanation: There is no index that satisfies the conditions in the problem statement.
 * 
 *******************************************************************************************************************************/

public class Solution724
{
    // --------------- O(n^2) 1116ms --------------- 28.8MB --------------- (9% 48%)
    public int PivotIndex_1(int[] nums)
    {
        int L = 0;
        int R = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                L += nums[j];
            }
            for (int j = i + 1; j < nums.Length; j++)
            {
                R += nums[j];
            }
            if (L == R)
            {
                return i;
            }

            L = 0; R = 0;
        }
        return -1;
    }

    // --------------- O(n) 116ms --------------- 29MB --------------- (90% 15%) ※
    public int PivotIndex_2(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        int leftSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (leftSum == sum - leftSum - nums[i])
            {
                return i;
            }
            leftSum += nums[i];

        }
        return -1;
    }

    // --------------- O(n) 120ms --------------- 28.9MB --------------- (68% 17%)
    public int PivotIndex_3(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        int sumL = 0;
        int sumR = sum;
        for (int i = 0; i < nums.Length; i++)
        {
            sumL = sum - sumR;
            sumR = sumR - nums[i];

            if (sumL == sumR)
            {
                return i;
            }
        }
        return -1;
    }

    // --------------- O(n) 148ms --------------- 29MB --------------- (21% 15%) 
    public int PivotIndex_4(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        int leftSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (leftSum * 2 + nums[i] == sum)
            {
                return i;
            }
            leftSum += nums[i];          
        }

        return -1;
    }

    // --------------- O(n) 120ms --------------- 28.9MB --------------- (38% 20%) 
    public int PivotIndex_5(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        int leftSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if ((sum = (sum - nums[i])) == leftSum)
                return i;
            else
                leftSum += nums[i];
        }

        return -1;
    }



}
/**************************************************************************************************************
 * PivotIndex_2 PivotIndex_3/4/5                                                                              *
 **************************************************************************************************************/
