//Source  : https://leetcode.com/problems/next-greater-element-i/
//Author  : Xinruo Shi
//Date    : 2020-11-04
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are given two arrays (without duplicates) nums1 and nums2 where nums1’s elements are subset of nums2.
 * Find all the next greater numbers for nums1's elements in the corresponding places of nums2.
 *
 * The Next Greater Number of a number x in nums1 is the first greater number to its right in nums2.
 * If it does not exist, output -1 for this number.
 * 
 * Input: nums1 = [4,1,2], nums2 = [1,3,4,2].
 * Output: [-1,3,-1]
 * Explanation:
 *      For number 4 in the first array, you cannot find the next greater number for it in the second array, so output -1.
 *      For number 1 in the first array, the next greater number for it in the second array is 3.
 *      For number 2 in the first array, there is no next greater number for it in the second array, so output -1.
 * 
 * Input: nums1 = [2,4], nums2 = [1,2,3,4].
 * Output: [3,-1]
 * Explanation:
 *      For number 2 in the first array, the next greater number for it in the second array is 3.
 *      For number 4 in the first array, there is no next greater number for it in the second array, so output -1.
 * 
 * Note:
 *      All elements in nums1 and nums2 are unique.
 *      The length of both nums1 and nums2 would not exceed 1000.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution496
{
    // --------------- O(n) 248ms --------------- 33MB --------------- (25% 8%) ※
    /*
     *  Using Stack
     */
    public int[] NextGreaterElement_1(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        Stack<int> stack = new Stack<int>();

        foreach (int i in nums2)
        {
            while (stack.Count != 0 && stack.Peek() < i)
            {
                d[stack.Pop()] = i;
            }

            stack.Push(i);
        }

        for (int i = 0; i < nums1.Length; i++)
        {
            nums1[i] = d.ContainsKey(nums1[i]) ? d[nums1[i]] : -1;
        }

        return nums1;
    }

    // --------------- O(n) 240ms --------------- 32MB --------------- (64% 34%) 
    public int[] NextGreaterElement_2(int[] nums1, int[] nums2)
    {
        int[] outputArray = new int[nums1.Length];
        Dictionary<int, int> calDict = new Dictionary<int, int>();
        Stack<int> stack = new Stack<int>();

        for (int i = nums2.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && nums2[i] > stack.Peek())
            {
                stack.Pop();
            }

            calDict.Add(nums2[i], stack.Count > 0 ? stack.Peek() : -1);
            stack.Push(nums2[i]);
        }

        int j = 0;
        foreach (int i in nums1)
        {
            outputArray[j++] = calDict[i];
        }

        return outputArray;
    }
}
/**************************************************************************************************************
 * NextGreaterElement_1  NextGreaterElement_2                                                                 *
 **************************************************************************************************************/