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
    // --------------- O(n) 268ms --------------- 30.5MB --------------- (20% 8%)
    public IList<IList<int>> LargeGroupPositions_1(string S)
    {
        List<IList<int>> L = new List<IList<int>>();
        if (S.Length < 1) return null;

        char c = S[0];
        int count = 1;
        for (int i = 1; i < S.Length; i++)
        {
            if (S[i] == c)
            {
                count++;

                if (i == S.Length - 1 && count > 2)
                {
                    L.Add(new int[] { i - count + 1, i });
                }
            }
            if (S[i] != c)
            {
                if (count > 2)
                {
                    L.Add(new int[] { i - count, i - 1 });
                }

                count = 1;
                c = S[i];
            }
        }

        return L;
    }
    
    // --------------- O(n) 252ms --------------- 30.5MB --------------- (88% 34%)
    /*
     * similar to 1
     */
    public IList<IList<int>> LargeGroupPositions_1_2(string S)
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

    // --------------- O(n) 260ms --------------- 30.7MB --------------- (29% 8%) ※
    public IList<IList<int>> LargeGroupPositions_2(string S)
    {
        List<IList<int>> L = new List<IList<int>>();

        int i = 0;
        int N = S.Length;

        for (int j = 0; j < S.Length; j++)
        {
            if (j == N - 1 || S[j] != S[j + 1])
            {
                if (j - i + 1 >= 3)
                {
                    L.Add(new int[] { i, j });
                }
                i = j + 1;
            }
        }

        return L;
    }

    // --------------- O(n) 284ms --------------- 30.6MB --------------- (5% 8%)
    public IList<IList<int>> LargeGroupPositions_3(string S)
    {
        List<IList<int>> L = new List<IList<int>>();
        for (int i = 0, j = 0; i < S.Length; i = j)
        {
            while (j < S.Length && S[j] == S[i])
            {
                j++;
            }
            if (j - i >= 3)
            {
                L.Add(new int[] { i, j - 1 });
            }
        }
        return L;
    }
}
/**************************************************************************************************************
 * LargeGroupPositions_1 LargeGroupPositions_2 LargeGroupPositions_3                                          *
 **************************************************************************************************************/
