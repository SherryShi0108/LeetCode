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
    // --------------- O(n) 100ms --------------- 29MB --------------- (89% 71%) ※
    /*
     *  if k==0 , it must to determine what is the count of this key
     */
    public int FindPairs_1(int[] nums, int k)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            d[num] = d.ContainsKey(num) ? d[num] + 1 : 1;
        }

        int count = 0;
        foreach (var item in d)
        {
            if (d.ContainsKey(item.Key + k))
            {
                if (k != 0 || k == 0 && d[item.Key] > 1)
                {
                    count++;
                }
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
