//Source  : https://leetcode.com/problems/set-mismatch/
//Author  : Xinruo Shi
//Date    : 2019-08-17
//Language: C#

/*******************************************************************************************************************************
 * 
 * The set S originally contains numbers from 1 to n. But unfortunately, due to the data error, one of the numbers 
 * in the set got duplicated to another number in the set, which results in repetition of one number and loss of another number.
 * Given an array nums representing the data status of this set after the error. Your task is to firstly find the number
 * occurs twice and then find the number that is missing. Return them in the form of an array.
 * 
 * Input: nums = [1,2,2,4]
 * Output: [2,3]
 * 
 * Note:    
 *      The given array size will in the range [2, 10000].
 *      The given array's numbers won't have any order.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution645
{
    // --------------- O(n) 312ms --------------- 44.3MB ---------------(22% 100%)
    public int[] FindErrorNums_1(int[] nums)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 1; i < nums.Length + 1; i++)
        {
            d[i] = 1;
        }

        int x = 0; int y = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                if (d[nums[i]] == 0)
                {
                    x = nums[i];
                }
                else
                {
                    d[nums[i]]--;
                }
            }
        }
        foreach (var item in d)
        {
            if (item.Value == 1)
            {
                y = item.Key;
            }
        }
        return new int[] { x, y };
    }

    // --------------- O(n) 388ms --------------- 44.3MB ---------------(7% 100%)
    /*
     * similar to 1
     */
    public int[] FindErrorNums_2(int[] nums)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        int x = 0; int y = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
            {
                x = nums[i];
            }
            else
            {
                d[nums[i]] = 1;
            }
        }

        for (int i = 1; i < nums.Length + 1; i++)
        {
            if (!d.ContainsKey(i))
            {
                y = i;
            }
        }
        return new int[] { x, y };
    }

    // --------------- O(n) 284ms --------------- 36.1MB ---------------(92% 100%) 
    /*
     * use array
     */
    public int[] FindErrorNums_3(int[] nums)
    {
        int[] a = new int[nums.Length + 1];
        int x = 0; int y = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            a[nums[i]]++;
        }

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] == 2) { x = i; }
            if (a[i] == 0) { y = i; }
        }
        return new int[] { x, y };
    }

    // --------------- O(n) 300ms --------------- 36.2MB ---------------(42% 100%)
    /*
     * use XOR
     */
    public int[] FindErrorNums_4(int[] nums)
    {
        int sum = 0;
        int number1 = 0;
        HashSet<int> h = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            sum = sum ^ nums[i] ^ (i + 1);
            if (h.Contains(nums[i]))
            {
                number1 = nums[i];
            }
            else
            {
                h.Add(nums[i]);
            }
        }

        return new[] {number1, sum ^ number1};
    }
    
    // --------------- O(n) 264ms --------------- 43.7MB ---------------(96% 100%) ※
    /* improve 4 */
    public int[] FindErrorNums_5(int[] nums)
    {
        int t = 0;
        HashSet<int> H=new HashSet<int>();
        int t1 = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            t = t ^ nums[i] ^ (i + 1);
            if (!H.Add(nums[i])) t1 = nums[i];
        }
        return new int[2]{t1,t^t1};
    }
}
/**************************************************************************************************************
 * FindErrorNums_3 FindErrorNums_5                                                                            *
 **************************************************************************************************************/
