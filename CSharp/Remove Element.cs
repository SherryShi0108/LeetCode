//Source  : https://leetcode.com/problems/remove-element/
//Author  : Xinruo Shi
//Date    : 2019-05-27
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array nums and a value val, remove all instances of that value in-place and return the new length.
 * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
 * The order of elements can be changed. It doesn't matter what you leave beyond the new length.
 * 
 * Input: nums = [3,2,2,3], val = 3
 * Output: length = 2 (nums=[2,2,....])
 * 
 * Input: nums = [0,1,2,2,3,0,4,2], val = 2
 * Output: length = 5 ([nums=[0,1,3,0,4,....]) Note that the order of those five elements can be arbitrary.
 * 
 *******************************************************************************************************************************/
public class Solution27
{
    // --------------- O(n) 248ms --------------- 28.4MB ---------------
    public int RemoveElement_1(int[] nums, int val)
    {
        int temp = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
            {
                temp++;             
            }
        }

        int n = nums.Length - temp;
        int m = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i]==val)
            {
                int t = nums[i];
                nums[i] = nums[nums.Length-1 - m];
                nums[nums.Length-1 - m] = t;
                m++;
                i--;
            }
        }
        return n;
    }

    // --------------- O(n) 236ms --------------- 28.1MB ---------------
    /*
     * !!! It doesn't matter what values are set beyond the returned length. !!!
     * 
     */
    public int RemoveElement_2(int[] nums, int val)
    {
        if (nums.Length == 0 || nums == null)
        {
            return 0;
        }

        int n = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[n] = nums[i];
                n++;
            }
        }        
        return n;
    }
}
/**************************************************************************************************************
 * RemoveElement_2                                                                                            *
 **************************************************************************************************************/
