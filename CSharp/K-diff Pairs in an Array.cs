//Source  : https://leetcode.com/problems/k-diff-pairs-in-an-array/
//Author  : Xinruo Shi
//Date    : 2019-06-15
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of integers and an integer k, you need to find the number of unique k-diff pairs in the array. 
 * Here a k-diff pair is defined as an integer pair (i, j), where i and j are both numbers in the array and their absolute difference is k.
 * 
 * Note:
 * The pairs (i, j) and (j, i) count as the same pair.
 * The length of the array won't exceed 10,000.
 * All the integers in the given input belong to the range: [-1e7, 1e7].
 * 
 * Input: nums = [3, 1, 4, 1, 5], k = 2
 * Output: 2
 * Explanation: There are two 2-diff pairs in the array, (1, 3) and (3, 5).
 * Although we have two 1s in the input, we should only return the number of unique pairs.
 * 
 * Input: nums = [1, 3, 1, 5, 4], k = 0
 * Output: 1
 * Explanation: There is one 0-diff pair in the array, (1, 1).
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution532
{
    // --------------- O(n) 120ms --------------- 31.9MB --------------- (66% 8%) ※
    /*
     * Why k>=-1? cause absolute difference!!! so k>=0!!!
     */
    public int FindPairs_1(int[] nums, int k)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();

        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                d[nums[i]]++;
            }
            else
            {
                d[nums[i]]=1;
            }
        }
        foreach (var item in d)
        {
            if (k == 0 && item.Value > 1)
            {
                count++;
            }
            if (k >= 1 && d.ContainsKey(item.Key+k))
            {
                count++;
            }
        } 
        return count;
    }
    
    // --------------- O(n) 116ms --------------- 32MB --------------- (58% 100%)
    public int FindPairs_2(int[] nums, int k)
    {
        if (k < 0) return 0;
        HashSet<int> h = new HashSet<int>();
        HashSet<int> result = new HashSet<int>();

        foreach (int i in nums)
        {
            if (h.Contains(i + k)) result.Add(i);
            if (h.Contains(i - k)) result.Add(i - k);

            h.Add(i);
        }

        return result.Count;
    }
}
/**************************************************************************************************************
 * FindPairs_1                                                                                                *
 **************************************************************************************************************/
