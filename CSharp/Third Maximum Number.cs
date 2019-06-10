//Source  : https://leetcode.com/problems/third-maximum-number/
//Author  : Xinruo Shi
//Date    : 2019-06-11
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty array of integers, return the third maximum number in this array. 
 * If it does not exist, return the maximum number. The time complexity must be in O(n).
 * 
 * Input: nums = [3,2,1]
 * Output: 1
 * 
 * Input: nums = [2, 2, 3, 1]
 * Output: 1
 * Explanation: Note that the third maximum here means the third maximum distinct number.
 *              Both numbers with value 2 are both considered as second maximum.
 * 
 *******************************************************************************************************************************/

public class Solution414
{
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     * integers!!! 
     * not non-negative
     */
    public int ThirdMax_1(int[] nums)
    {
        int a = -1;
        int b = -1;
        int c = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > a)
            {
                c = b;
                b = a;
                a = nums[i];
            }
            if (nums[i] > b && nums[i] < a)
            {
                c = b;
                b = nums[i];
            }
            if (nums[i] > c && nums[i] < b)
            {
                c = nums[i];
            }
        }

        if (c == -1)
        {
            return a;
        }
        return c;
    }
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++

    // --------------- O(n) 100ms --------------- 22.7MB --------------- (48.5% 39.8%)
    public int ThirdMax_2(int[] nums)
    {
        if (nums.Length < 3)
        {
            if (nums.Length == 0 || nums == null) { return 0; }
            if (nums.Length == 1) { return nums[0]; }
            else { return nums[0] > nums[1] ? nums[0] : nums[1]; }
        }

        long a = long.MinValue; long b = long.MinValue; long c = long.MinValue;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > a)
            {
                c = b;
                b = a;
                a = nums[i];
            }
            else if (nums[i] > b && nums[i] < a)
            {
                c = b;
                b = nums[i];
            }
            else if (nums[i] > c && nums[i] < b)
            {
                c = nums[i];
            }
            else
            {
                continue;
            }
            count++;
        }

        return count > 2 ? (int)c : (int)a;
    }

    // --------------- O(n) 152ms --------------- 22.8MB --------------- (5.5% 38.1%)
    public int ThirdMax_3(int[] nums)
    {
        long a = long.MinValue;
        long b = long.MinValue;
        long c = long.MinValue;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > a)
            {
                c = b;
                b = a;
                a = nums[i];
            }
            if (nums[i] > b && nums[i] < a)
            {
                c = b;
                b = nums[i];
            }
            if (nums[i] > c && nums[i] < b)
            {
                c = nums[i];
            }
        }

        return c == long.MinValue ? (int)a : (int)c;
    }
}
/**************************************************************************************************************
 * ThirdMax_3                                                                                                 *
 **************************************************************************************************************/