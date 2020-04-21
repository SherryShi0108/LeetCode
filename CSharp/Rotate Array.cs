//Source  : https://leetcode.com/problems/rotate-array/
//Author  : Xinruo Shi
//Date    : 2019-06-06
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array, rotate the array to the right by k steps, where k is non-negative.
 * 
 * Note:
 * Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
 * Could you do it in-place with O(1) extra space?
 * 
 * Input: nums=[1,2,3,4,5,6,7], k = 3
 * Output: [5,6,7,1,2,3,4]
 * Explanation:
 * rotate 1 steps to the right: [7,1,2,3,4,5,6]
 * rotate 2 steps to the right: [6,7,1,2,3,4,5]
 * rotate 3 steps to the right: [5,6,7,1,2,3,4]
 * 
 * Input: nums=[-1,-100,3,99], k = 2
 * Output: [3,99,-1,-100]
 * Explanation: 
 * rotate 1 steps to the right: [99,-1,-100,3]
 * rotate 2 steps to the right: [3,99,-1,-100]
 * 
 *******************************************************************************************************************************/

using System;

public class Solution189
{
    // --------------- O(n) 256ms --------------- 30.5MB --------------- (79% 73%)
    /*
     * But O(space)=O(n) ， use extra space
     * Another array of the same size is used.
     */
    public void Rotate_1(int[] nums, int k)
    {
        int[] a = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            a[(i + k) % nums.Length] = nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = a[i];
        }
    }

    // --------------- O(n) 260ms --------------- O(1)30.5MB --------------- (68% 85%)
    /*
     * use Reverse
     */
    public void Rotate_2(int[] nums, int k)
    {
        Array.Reverse(nums);

        int temp = k % nums.Length;
        Array.Reverse(nums, 0, temp);
        Array.Reverse(nums, temp, nums.Length - temp);
    }

    // --------------- O(n) 260ms --------------- O(1)30.5MB --------------- (68% 85%)
    /*
     * use user-defined method
     */
    public void Rotate_2_2(int[] nums, int k)
    {
        RecerseArray(nums, 0, nums.Length);

        int temp = k % nums.Length;
        RecerseArray(nums, 0, temp);
        RecerseArray(nums, temp, nums.Length - temp);
    }
    public void RecerseArray(int[] nums, int index, int length)
    {
        int i = index;
        int j = index + length - 1;
        while (i < j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            i++;
            j--;
        }
    }

    // --------------- O(n) 264ms --------------- O(1)30.5MB --------------- (56% 85%) ※
    public void Rotate_3(int[] nums, int k)
    {
        int count = 0;
        for (int i = 0; ; i++)
        {
            int prevValue = nums[i];
            int currentIndex = i;
            do
            {
                int nextIndex = (currentIndex + k) % nums.Length;
                int nextValue = nums[nextIndex];
                nums[nextIndex] = prevValue;
                prevValue = nextValue;
                currentIndex = nextIndex;

                if (++count == nums.Length) return;
            } while (i != currentIndex);
        }
    }
    
    // --------------- O(n) 240ms --------------- O(1)32MB --------------- (86% 9%) ※
    public void Rotate_3(int[] nums, int k)
    {
        int count = 0;
        int i = -1;
        while (true)
        {
            i++;
            int prevValue = nums[i];
            int currentIndex = i;
            do
            {
                int nextIndex = (currentIndex + k) % nums.Length;
                int nextValue = nums[nextIndex];
                nums[nextIndex] = prevValue;
                prevValue = nextValue;
                currentIndex = nextIndex;

                if (++count == nums.Length) return;
            } while (i != currentIndex);
        }
    }
}
/**************************************************************************************************************
 * Rotate_2 Rotate_3                                                                                          *
 **************************************************************************************************************/
