//Source  : https://leetcode.com/problems/x-of-a-kind-in-a-deck-of-cards/
//Author  : Xinruo Shi
//Date    : 2019-07-12
//Language: C#

/*******************************************************************************************************************************
 * 
 * In a deck of cards, each card has an integer written on it.
 * Return true if and only if you can choose X >= 2 such that it is possible to split the entire deck into 1 or more groups of cards, 
 * where: Each group has exactly X cards. All the cards in each group have the same integer.
 * 
 * Note:
 * 1 <= deck.length <= 10000
 * 0 <= deck[i] < 10000
 * 
 * Input: [1,2,3,4,4,3,2,1]
 * Output: true
 * Explanation: Possible partition [1,1],[2,2],[3,3],[4,4]
 * 
 * Input: [1,1,1,2,2,2,3,3]
 * Output: false
 * Explanation: No possible partition.
 * 
 * Input: [1]
 * Output: false
 * Explanation: No possible partition.
 * 
 * Input: [1,1]
 * Output: true
 * Explanation: Possible partition [1,1]
 * 
 * Input: [1,1,2,2,2,2]
 * Output: true
 * Explanation: Possible partition [1,1],[2,2],[2,2]
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic; //Dictionary名称空间

public class Solution914
{
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     *     // [0,0,0,1,1,1,2,2,2] should be true
     *     X >= 2 !!! not X = 2 !!!
     *     You need to read the topic carefully!
     */
    public bool HasGroupsSizeX_1(int[] deck)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < deck.Length; i++)
        {
            if (d.ContainsKey(deck[i]))
            {
                d.Remove(deck[i]);
            }
            else
            {
                d[deck[i]] = 1;
            }
        }

        if (d.Count > 0)
        {
            return false;
        }
        return true;
    }
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    
    // --------------- O(n) 124ms --------------- 26.6MB --------------- (42% 100%)
    public bool HasGroupsSizeX_2(int[] deck)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < deck.Length; i++)
        {
            if (d.ContainsKey(deck[i]))
            {
                d[deck[i]]++;
            }
            else
            {
                d[deck[i]] = 1;
            }
        }

        int min = int.MaxValue;
        foreach (var item in d)
        {
            min = min < item.Value ? min : item.Value;
        }

        for (int i = 2; i <= min; i++)
        {
            bool flag = true;
            foreach (var item in d)
            {
                if (item.Value % i != 0) { flag = false; }
            }
            if (flag)
            {
                return true;
            }
        }
        return false;
    }
    
    /* using gcd , cannot understand */
    public bool HasGroupsSizeX_3(int[] deck)
    {
    }
}
/**************************************************************************************************************
 * HasGroupsSizeX_2 / 3                                                                                       *
 **************************************************************************************************************/
