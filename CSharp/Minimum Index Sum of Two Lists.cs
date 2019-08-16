//Source  : https://leetcode.com/problems/minimum-index-sum-of-two-lists/
//Author  : Xinruo Shi
//Date    : 2019-08-16
//Language: C#

/*******************************************************************************************************************************
 * 
 * Suppose Andy and Doris want to choose a restaurant for dinner, and they both have a list of favorite restaurants represented by strings.
 * You need to help them find out their common interest with the least list index sum. If there is a choice tie between answers, 
 * output all of them with no order requirement. You could assume there always exists an answer.
 * 
 * Input:   ["Shogun", "Tapioca Express", "Burger King", "KFC"]
 *          ["Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun"]
 * Output:  ["Shogun"]
 * Explanation: The only restaurant they both like is "Shogun".
 * 
 * Input:   ["Shogun", "Tapioca Express", "Burger King", "KFC"]
 *          ["KFC", "Shogun", "Burger King"]
 * Output:  ["Shogun"]
 * Explanation: The restaurant they both like and have the least index sum is "Shogun" with index sum 1 (0+1).
 * 
 * Note:
 *      The length of both lists will be in the range of [1, 1000].
 *      The length of strings in both lists will be in the range of [1, 30].
 *      The index is starting from 0 to the list length minus 1.
 *      No duplicates in both lists.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution599
{
    // --------------- O(n1+n2) 332ms --------------- 41.3MB --------------- (70% 100%) ※
    public string[] FindRestaurant_1(string[] list1, string[] list2)
    {
        Dictionary<string, int> d = new Dictionary<string, int>();
        for (int i = 0; i < list1.Length; i++)
        {
            d[list1[i]] = i;
        }

        List<string> result = new List<string>();
        int count = int.MaxValue;
        for (int i = 0; i < list2.Length; i++)
        {
            if (d.ContainsKey(list2[i]))
            {
                int temp = d[list2[i]] + i;
                if (temp < count)
                {
                    count = temp;
                    result = new List<string>() { list2[i] };
                }
                else if (temp == count)
                {
                    result.Add(list2[i]);
                }
            }
        }
        return result.ToArray();
    }
}
/**************************************************************************************************************
 * FindRestaurant_1                                                                                           *
 **************************************************************************************************************/