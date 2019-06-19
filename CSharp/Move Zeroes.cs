//Source  : https://leetcode.com/problems/move-zeroes/
//Author  : Xinruo Shi
//Date    : 2019-06-10
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
 * 
 * Note:
 * You must do this in-place without making a copy of the array.
 * Minimize the total number of operations.
 * 
 * Input: nums = [0,1,0,3,12]
 * Output: [1,3,12,0,0]
 * 
 *******************************************************************************************************************************/

public class Solution283
{
    // --------------- O(n) 264ms --------------- 29.8MB --------------- (40% 95%)
    public void MoveZeroes_1(int[] nums)
    {
        int count0 = 0;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                count0++;
            }
            else
            {
                nums[count] = nums[i];
                count++;
            }
        }

        while (count0 > 0)
        {
            nums[nums.Length - count0] = 0;
            count0--;
        }
    }

    // --------------- O(n) 252ms --------------- 30MB --------------- (75% 57%)
    public void MoveZeroes_2(int[] nums)
    {
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[count++] = nums[i];
            }
        }
        while (count < nums.Length)
        {
            nums[count] = 0;
            count++;
        }
    }

    // --------------- O(n) 260ms --------------- 30MB --------------- (50% 57%)
    public void MoveZeroes_3(int[] nums)
    {
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[count] = nums[i];
                if (i > count)
                {
                    nums[i] = 0;
                }

                count++;
            }
        }
    }

    // --------------- O(n) 256ms --------------- 30MB --------------- (60% 57%)
    public void MoveZeroes_4(int[] nums)
    {
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                int temp = nums[count];
                nums[count] = nums[i];
                nums[i] = temp;

                count++;
            }
        }
    }
}
/**************************************************************************************************************
 * MoveZeroes_2 MoveZeroes_3 MoveZeroes_4                                                                     *
 **************************************************************************************************************/