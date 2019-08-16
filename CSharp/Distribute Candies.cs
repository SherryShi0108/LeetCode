//Source  : https://leetcode.com/problems/distribute-candies/
//Author  : Xinruo Shi
//Date    : 2019-08-15
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an integer array with even length, where different numbers in this array represent different kinds of candies.
 * Each number means one candy of the corresponding kind. You need to distribute these candies equally in number to brother 
 * and sister. Return the maximum number of kinds of candies the sister could gain.
 * 
 * Input: candies = [1,1,2,2,3,3]
 * Output: 3
 * Explanation: There are three different kinds of candies (1, 2 and 3), and two candies for each kind.
 *              Optimal distribution: The sister has candies [1,2,3] and the brother has candies [1,2,3], too. 
 *              The sister has three different kinds of candies. 
 *      
 * Input: candies = [1,1,2,3]
 * Output: 2
 * Explanation: For example, the sister has candies [2,3] and the brother has candies [1,1]. 
 *              The sister has two different kinds of candies, the brother has only one kind of candies. 
 *              
 * Note:
 *      The length of the given array is in range [2, 10,000], and will be even.
 *      The number in given array is in range [-100,000, 100,000].
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution575
{
    // --------------- O(n) 308ms --------------- 43MB --------------- (29% 100%) 
    public int DistributeCandies_1(int[] candies)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < candies.Length; i++)
        {
            if (d.ContainsKey(candies[i]))
            {
                d[candies[i]]++;
            }
            else
            {
                d[candies[i]] = 1;
            }
        }

        return d.Count < candies.Length / 2 ? d.Count : candies.Length / 2;
    }

    // --------------- O(n) 292ms --------------- 43MB --------------- (70% 100%) ※
    /*
     * use HashSet
     */
    public int DistributeCandies_2(int[] candies)
    {
        HashSet<int> hs = new HashSet<int>(candies);
        return hs.Count < candies.Length / 2 ? hs.Count : candies.Length / 2;
    }
}
/**************************************************************************************************************
 * DistributeCandies_1 DistributeCandies_2                                                                    *
 **************************************************************************************************************/