//Source  : https://leetcode.com/problems/intersection-of-two-arrays-ii/
//Author  : Xinruo Shi
//Date    : 2019-08-09
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two arrays, write a function to compute their intersection.
 * 
 * Input: nums1 = [1,2,2,1], nums2 = [2,2]
 * Output: [2,2]
 * 
 * Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
 * Output: [4,9]
 * 
 * Note:
 *      Each element in the result should appear as many times as it shows in both arrays.
 *      The result can be in any order.
 *      
 * Follow up:
 *      What if the given array is already sorted? How would you optimize your algorithm?
 *      What if nums1's size is small compared to nums2's size? Which algorithm is better?
 *      What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution350
{
    // --------------- O(n) 272ms --------------- 29.6MB --------------- (30% 10%) ※
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            if (d.ContainsKey(nums1[i]))
            {
                d[nums1[i]]++;
            }
            else
            {
                d[nums1[i]] = 1;
            }
        }

        List<int> L = new List<int>();
        for (int i = 0; i < nums2.Length; i++)
        {
            if (d.ContainsKey(nums2[i]) && d[nums2[i]] > 0)
            {
                L.Add(nums2[i]);
                d[nums2[i]]--;
            }
        }
        
        return L.ToArray();
    }

}