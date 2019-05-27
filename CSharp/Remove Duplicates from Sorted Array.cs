//Source  : https://leetcode.com/problems/remove-duplicates-from-sorted-array/
//Author  : Xinruo Shi
//Date    : 2019-05-20
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
 * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
 * 
 * Input: nums = [1,1,2]
 * Output: 2 (nums=[1,2...])
 * 
 * Input: nums = [0,0,1,1,1,2,2,3,3,4]
 * Output: 5 ([nums=[0,1,2,3,4....])
 * 
 *******************************************************************************************************************************/

public class Solution
{
    // --------------- O(n) 292ms --------------- 31.5MB ---------------
    /*
     * When null or length=0, we should return 0 not 1
     */
    public int RemoveDuplicates_1(int[] nums)
    {       
        if (nums.Length == 0 || nums == null)
        {
            return 0;
        }

        int n = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[n] = nums[i];
                n++;
            }
        }
        return n;
    }

    // --------------- O(n) 260ms --------------- 31.7MB ---------------
    /*
     * asymptotic time complexity for this solution is least 
     * Because this compare nums[n] ,it cost time less than nums[i-1]
     */
    public int RemoveDuplicates_2(int[] nums)
    {
        if (nums.Length < 2)
            return nums.Length;

        int n = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[n] != nums[i])
            {
                nums[++n] = nums[i];
            }
        }
        return n + 1;
    } 
}
/**************************************************************************************************************
 * RemoveDuplicates_1 RemoveDuplicates_2                                                                      *
 **************************************************************************************************************/
