//Source  : https://leetcode.com/problems/kth-largest-element-in-a-stream/
//Author  : Xinruo Shi
//Date    : 2020-11-07
//Language: C#

/*******************************************************************************************************************************
 * 
 * Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.
 *
 * Implement KthLargest class:
 *      KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
 *      int add(int val) Returns the element representing the kth largest element in the stream.
 *
 * Input: ["KthLargest", "add", "add", "add", "add", "add"]
 *        [[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
 * Output: [null, 4, 5, 5, 8, 8]
 * Explanation:
 *      KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
 *      kthLargest.add(3);   // return 4
 *      kthLargest.add(5);   // return 5
 *      kthLargest.add(10);  // return 5
 *      kthLargest.add(9);   // return 8
 *      kthLargest.add(4);   // return 8
 *
 * Constraints:
 *      1 <= k <= 104
 *      0 <= nums.length <= 104
 *      -104 <= nums[i] <= 104
 *      -104 <= val <= 104
 *      At most 104 calls will be made to add.
 *      It is guaranteed that there will be at least k elements in the array when you search for the kth element.
 * 
 *******************************************************************************************************************************/

// class 703

using System;
using System.Collections.Generic;
using System.Linq;

// --------------- O(nlogn) 148ms --------------- 41MB --------------- (99% 65%) 
/*
 * use list.BinarySearch , attention: ~
 */
public class KthLargest1
{
    private List<int> list;
    private int k;

    public KthLargest1(int k, int[] nums)
    {
        this.k = k;
        list = new List<int>(nums);
        list.Sort();
    }

    public int Add(int val)
    {
        if (list.Count < k || val > list[list.Count - k])
        {
            int index = list.BinarySearch(val);
            if (index < 0)
            {
                index = ~index;
            }

            list.Insert(index, val);
        }
        return list[list.Count - k];
    }
}

// --------------- O(nlogn) 208ms --------------- 41MB --------------- (53% 28%) ※
/*
 * use SortedDictionary
 */

public class KthLargest2
{
    private int kth;
    private SortedDictionary<int, int> minHeap;
    private int actualSize;

    public KthLargest2(int k, int[] nums)
    {
        kth = k;
        minHeap = new SortedDictionary<int, int>();
        foreach (int i in nums)
        {
            Add(i);
        }
    }

    public int Add(int val)
    {
        if (minHeap.ContainsKey(val))
        {
            minHeap[val]++;
        }
        else
        {
            minHeap.Add(val, 1);
        }

        actualSize++;

        if (actualSize > kth)
        {
            if (minHeap.First().Value == 1)
            {
                minHeap.Remove(minHeap.First().Key);
            }
            else
            {
                minHeap[minHeap.First().Key]--;
            }

            actualSize--;
        }

        return minHeap.First().Key;
    }
}


/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */

/**************************************************************************************************************
* KthLargest1  KthLargest2                                                                                    *
**************************************************************************************************************/