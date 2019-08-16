//Source  : https://leetcode.com/problems/jewels-and-stones/
//Author  : Xinruo Shi
//Date    : 2019-08-19
//Language: C#

/*******************************************************************************************************************************
 * 
 * You're given strings J representing the types of stones that are jewels, and S representing the stones you have.  
 * Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.
 * The letters in J are guaranteed distinct, and all characters in J and S are letters. Letters are case sensitive, 
 * so "a" is considered a different type of stone from "A".
 * 
 * Input: J = "aA", S = "aAAbbbb"
 * Output: 3
 * 
 * Input: J = "z", S = "ZZ"
 * Output: 0
 * 
 * Note:
 *      S and J will consist of letters and have length at most 50.
 *      The characters in J are distinct.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;
using System.Linq; // S.Count

public class Solution771
{
    // --------------- O(n) 80ms --------------- 21.3MB --------------- (58% 19%) 
    public int NumJewelsInStones_1(string J, string S)
    {
        Dictionary<char, int> d = new Dictionary<char, int>();
        foreach (char item in J)
        {
            d[item] = 1;
        }

        int count = 0;
        foreach (char item in S)
        {
            if (d.ContainsKey(item))
            {
                count++;
            }
        }
        return count;
    }

    // --------------- O(n) 68ms --------------- 21.2MB --------------- (99% 36%) 
    /*
     * use Linq
     */
    public int NumJewelsInStones_2(string J, string S)
    {
        return S.Count(i => J.Contains(i));
    }


    // --------------- O(n) 80ms --------------- 21.2MB --------------- (58% 57%) ※
    /*
     * a talented solution !!!
     */
    public int NumJewelsInStones_3(string J, string S)
    {
        int[] array = new int[58];
        foreach (char item in J)
        {
            array[item - 65]++;
        }
        int sum = 0;
        foreach (char item in S)
        {
            sum += array[item-65];
        }
        return sum;
    }
}
/**************************************************************************************************************
 * NumJewelsInStones_1 NumJewelsInStones_3                                                                    *
 **************************************************************************************************************/