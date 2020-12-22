//Source  : https://leetcode.com/problems/positions-of-large-groups/
//Author  : Xinruo Shi
//Date    : 2019-07-02
//Language: C#

/*******************************************************************************************************************************
 * 
 * In a string S of lowercase letters, these letters form consecutive groups of the same character.
 * For example, a string like S = "abbxxxxzyy" has the groups "a", "bb", "xxxx", "z" and "yy".
 * Call a group large if it has 3 or more characters.  We would like the starting and ending positions of every large group.
 * The final answer should be in lexicographic order.
 * 
 * Note:
 * 1 <= S.length <= 1000
 * 
 * Input: "abbxxxxzzy"
 * Output: [[3,6]]
 * Explanation: "xxxx" is the single large group with starting  3 and ending positions 6.
 * 
 * Input: "abc"
 * Output: []
 * Explanation: We have "a","b" and "c" but no large group.
 * 
 * Input: "abcdddeeeeaabbbcd"
 * Output: [[3,5],[6,9],[12,14]]
 * 
 *******************************************************************************************************************************/
using System.Collections.Generic;

public class Solution830
{    
    // --------------- O(n) 252ms --------------- 30.5MB --------------- (88% 34%)
    /*
     *  Determine in the final ; use count
     */
    public IList<IList<int>> LargeGroupPositions_1(string S)
    {
        IList<IList<int>> L = new List<IList<int>>();
        int count = 1;
        for (int i = 1; i < S.Length; i++)
        {
            if (S[i] == S[i - 1])
            {
                count++;
            }
            else
            {
                if (count > 2)
                {
                    L.Add(new int[] {i - count, i - 1});
                }

                count = 1;
            }
        }

        if (count > 2)
        {
            L.Add(new int[] {S.Length - count, S.Length - 1});
        }

        return L;
    }

    // --------------- O(n) 236ms --------------- 33MB --------------- (60% 12%)
    /*
     * add non-letter "#" to avoid determine final ; use start
     */
    public IList<IList<int>> LargeGroupPositions_1_2(string S)
    {
        S = S + "#";
        List<IList<int>> L = new List<IList<int>>();

        int start = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] != S[start])
            {
                if (i - start >= 3)
                {
                    L.Add(new List<int>() { start, i - 1 });
                }
                start = i;
            }
        }

        return L;
    }
    
    // --------------- O(n) 260ms --------------- 30.7MB --------------- (29% 8%) ※
    /*
     * donnot need final determine ; use start
     */
    public IList<IList<int>> LargeGroupPositions_2(string S)
    {
        List<IList<int>> L = new List<IList<int>>();

        int start = 0;

        for (int i = 0; i < S.Length; i++)
        {
            if (i == S.Length - 1 || S[i] != S[i + 1])
            {
                if (i - start + 1 >= 3)
                {
                    L.Add(new int[] { start, i });
                }
                start = i + 1;
            }
        }

        return L;
    }
    
     // --------------- O(n) 232ms --------------- 32MB --------------- (83% 33%)  
    /*
     * donnot need final determine ; use count
     */
    public IList<IList<int>> LargeGroupPositions_2_2(string S)
    {
        List<IList<int>> L = new List<IList<int>>();
        int count = 1;

        for (int i = 0; i < S.Length; i++)
        {
            if (i == S.Length - 1 || S[i] != S[i + 1])
            {
                if (count >= 3)
                {
                    L.Add(new List<int>() { i - count + 1, i });
                }

                count = 1;
            }
            else
            {
                count++;
            }
        }

        return L;
    }
}
/**************************************************************************************************************
 * LargeGroupPositions_1 LargeGroupPositions_2                                                                *
 **************************************************************************************************************/
