//Source  : https://leetcode.com/problems/merge-sorted-array/
//Author  : Xinruo Shi
//Date    : 2019-05-31
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
 * 
 * Notes:
 * The number of elements initialized in nums1 and nums2 are m and n respectively.
 * You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.
 * 
 * Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
 * Output: [1,2,2,3,5,6]
 * 
 *******************************************************************************************************************************/

public class Solution88
{
    // --------------- O(n) 304ms --------------- 28.3MB --------------- (5% 99%)
    public void Merge_1(int[] nums1, int m, int[] nums2, int n)
    {
        int x = m - 1;
        int y = n - 1;
        for (int i = m + n - 1; i >= 0; i--)
        {
            if (x >= 0 && y >= 0)
            {
                if (nums1[x] > nums2[y])
                {
                    nums1[i] = nums1[x];
                    x--;
                }
                else
                {
                    nums1[i] = nums2[y];
                    y--;
                }
            }
            else if (x >= 0)
            {
                nums1[i] = nums1[x];
                x--;
            }
            else if (y >= 0)
            {
                nums1[i] = nums2[y];
                y--;
            }
        }
    }

    // --------------- O(n) 248ms --------------- 28.7MB --------------- (80% 24%)
    /*
     * Cause nums1 are sorted, so if only x>=0, wo can ignore
     */
    public void Merge_2(int[] nums1, int m, int[] nums2, int n)
    {
        int x = m - 1;
        int y = n - 1;
        for (int i = m + n - 1; i >= 0; i--)
        {
            if (x >= 0 && y >= 0)
            {
                if (nums1[x] > nums2[y])
                {
                    nums1[i] = nums1[x];
                    x--;
                }
                else
                {
                    nums1[i] = nums2[y];
                    y--;
                }
            }
            else if (y >= 0)
            {
                nums1[i] = nums2[y];
                y--;
            }
        }
    }
    
    // an not readable code
    public void Merge_3(int[] nums1, int m, int[] nums2, int n)
    {
        int a = m - 1;
        int b = n - 1;
        int k = m + n - 1;

        while (a >= 0 && b >= 0)
        {
            nums1[k--] = nums1[a] > nums2[b] ? nums1[a--] : nums2[b--];
        }
        while (b >= 0)
        {
            nums1[k--] = nums2[b--];
        }
    }    
}
/**************************************************************************************************************
 *   Merge_2                                                                                                  *
 **************************************************************************************************************/
