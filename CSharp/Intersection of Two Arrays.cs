//Source  : https://leetcode.com/problems/intersection-of-two-arrays/
//Author  : Xinruo Shi
//Date    : 2019-08-08
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two arrays, write a function to compute their intersection.
 * 
 * Input: nums1 = [1,2,2,1], nums2 = [2,2]
 * Output: [2]
 * 
 * Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
 * Output: [9,4]
 * 
 * Note:    Each element in the result must be unique.
 *          The result can be in any order.
 * ※
 *******************************************************************************************************************************/

using System.Collections.Generic; // Dictionary NameSpace
using System.Linq; //2 result.ToArray();

public class Solution349
{
    // --------------- O(n) 268ms --------------- 29.1MB ---------------(37% 100%) ※
    /*
     * use HashSet , similar to Dictionary , add 1,1,1,2,2,2 ,result 1,2
     */
    public int[] Intersection_1(int[] nums1, int[] nums2)
    {
        var nums1Set = new HashSet<int>(nums1);
        /* 
         * var nums1Set = new HashSet<int>();
         * foreach(var item in nums1)
         * {    nums1Set.add(item)    }
         */
        var result = new HashSet<int>();

        foreach (var num in nums2)
        {
            if (nums1Set.Contains(num))
            {
                result.Add(num);
            }
        }
        
        int[] result2 = new int[result.Count];
        int k = 0;
        foreach (var i in result)
        {
            result2[k++] = i;
         }
        
        return result.ToArray(); // return result2;
    }
}
/**************************************************************************************************************
 * Intersection_1                                                                                             *
 **************************************************************************************************************/
