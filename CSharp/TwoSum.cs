//Source  : https://leetcode.com/problems/two-sum/
//Author  : Xinruo Shi
//Date    : 2019-05-20
//Language: C#

/**************************************************************************************************************
 * 
 * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
 * You may assume that each input would have exactly one solution, and you may not use the same element twice.
 * 
 * Input: nums = [2, 7, 11, 15], target = 9
 * Output: [0,1]
 * 
 * Input: nums = [6, 6, 3, 5], target = 8
 * Output: [2,3]
 * 
 **************************************************************************************************************/

using System.Collections; // Hashtable NameSpace
using System.Collections.Generic; //Dictionary NameSpace

public class Solution
{
    // --------------- Brute Force --------------- O(n^2) 420ms --------------- 29MB ---------------
    /*
     * If i,j declaration at beginning, asymptotic time complexity will less (28.9MB)
     */
    public int[] TwoSum_1(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }
        return null;
    }  

    /* We can use a hashmap to reduce the searching time complexity from O(n) to O(1) */

    // --------------- HashTable(Hashtable) --------------- O(n) ---------------
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     * This implementation works in java Map, because if there is the same key,
     * the value corresponding to the last key will overwrite the previous same value.
     * 
     * But in C# Hashtable, when it add the same key, it will present error
     */
    public int[] TwoSum_2(int[] nums, int target)
    {
        Hashtable hashtable = new Hashtable();
        for (int i = 0; i < nums.Length; i++)
        {
            int aim = target - nums[i];
            if (hashtable.ContainsKey(aim))
            {
                return new int[] { (int)hashtable[aim], i };
            }
            hashtable.Add(nums[i], i);
        }
        return null;
    }
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++

    // --------------- HashTable(Hashtable) --------------- O(n) 264ms --------------- 30.4MB ---------------
    /*
     * We can add an if statement to decide to overwrite the previous same value
     */
    public int[] TwoSum_3(int[] nums, int target)
    {
        Hashtable hashtable = new Hashtable();
        for (int i = 0; i < nums.Length; i++)
        {
            int aim = target - nums[i];
            if (hashtable.ContainsKey(aim))
            {
                return new int[] { (int)hashtable[aim], i };
            }
            else
            {
                if (hashtable.ContainsKey(nums[i]))
                {
                    hashtable[nums[i]] = i;
                }
                else
                {
                    hashtable.Add(nums[i],i);
                }
            }
        }
        return null;
    }

    // --------------- HashTable(Hashtable) --------------- O(n) 256ms --------------- 30.4MB ---------------
    /*
     * Direct use "="
     */
    public int[] TwoSum_4(int[] nums, int target)
    {
        Hashtable hashtable = new Hashtable();
        for (int i = 0; i < nums.Length; i++)
        {
            int aim = target - nums[i];
            if (!hashtable.ContainsKey(aim))
            {
                hashtable[nums[i]] = i;
            }
            else
            {
                return new int[] { (int)hashtable[aim], i };
            }
        }
        return null;
    }

    // --------------- HashTable(Hashtable) --------------- O(n) 260ms --------------- 30.3MB ---------------
    /*
     * other solution idea: Add hashtable [aim,i]
     */
    public int[] TwoSum_5(int[] nums, int target)
    {
        Hashtable hashtable = new Hashtable();
        for (int i = 0; i < nums.Length; i++)
        {
            int aim = target - nums[i];
            if (!hashtable.ContainsKey(nums[i]))
            {
                hashtable[aim] = i;
            }
            else
            {
                return new int[] { (int)hashtable[nums[i]], i };
            }
        }
        return null;
    }
   
    // --------------- HashTable(Dictionary) --------------- O(n) 260ms --------------- 29.3MB ---------------
    /*
     * Change Hashtable to Dictionary from TwoSum_4
     */
    public int[] TwoSum_6(int[] nums, int target)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int aim = target - nums[i];
            if (!dictionary.ContainsKey(aim))
            {
                dictionary[nums[i]] = i;
            }
            else
            {
                return new int[] { (int)dictionary[aim], i };
            }
        }
        return null;
    }
   
    // --------------- HashTable(Dictionary) --------------- O(n) 260ms --------------- 29.4MB ---------------
    /*
     * Other solution idea: Add dictionary [aim,i]
     */
    public int[] TwoSum_7(int[] nums, int target)
    {
        Dictionary<int,int> dictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int aim = target - nums[i];
            if (!dictionary.ContainsKey(nums[i]))
            {
                dictionary[aim] = i;
            }
            else
            {
                return new int[] { (int)dictionary[nums[i]], i };
            }
        }
        return null;
    }

    // --------------- HashTable(Dictionary) --------------- O(n) 256ms --------------- 29.3MB ---------------
    /*
     * Other solution idea: Add hashtable [aim,i]
     * Direct use aim value
     * Initialize array at beginning
     */
    public int[] TwoSum_8(int[] nums, int target)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        int[] array = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            if (!dictionary.ContainsKey(nums[i]))
            {
                dictionary[target - nums[i]] = i;
            }
            else
            {
                array[0] = (int)dictionary[nums[i]];
                array[1] = i;
                break;
            }
        }
        return array;
    }
}
    /**************************************************************************************************************
     * TwoSum_4 TwoSum_5                                                                                          *
     **************************************************************************************************************/