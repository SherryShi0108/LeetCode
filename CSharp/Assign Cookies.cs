//Source  : https://leetcode.com/problems/assign-cookies/
//Author  : Xinruo Shi
//Date    : 2020-11-06
//Language: C#

/*******************************************************************************************************************************
 * 
 * Assume you are an awesome parent and want to give your children some cookies. But, you should give each child at most one cookie.
 *
 * Each child i has a greed factor g[i], which is the minimum size of a cookie that the child will be content with;
 * and each cookie j has a size s[j]. If s[j] >= g[i], we can assign the cookie j to the child i,
 * and the child i will be content. Your goal is to maximize the number of your content children and output the maximum number.
 *
 * Input: g = [1,2,3], s = [1,1]
 * Output: 1
 * Explanation:
 *      You have 3 children and 2 cookies. The greed factors of 3 children are 1, 2, 3.
 *      And even though you have 2 cookies, since their size is both 1, you could only make the child whose greed factor is 1 content.
 * You need to output 1.
 *
 * Input: g = [1,2], s = [1,2,3]
 * Output: 2
 * Explanation:
 *      You have 2 children and 3 cookies. The greed factors of 2 children are 1, 2.
 *      You have 3 cookies and their sizes are big enough to gratify all of the children,
 *      You need to output 2.
 *
 * Constraints:
 *      1 <= g.length <= 3 * 10^4
 *      0 <= s.length <= 3 * 10^4
 *      1 <= g[i], s[j] <= 2^31 - 1
 * 
 *******************************************************************************************************************************/

using System;

public class Solution455
{
    // --------------- O(nlogn) 132ms --------------- 31MB --------------- (56% 97%) ※
    /*
     *  Greedy Solution
     */
    public int FindContentChildren_1(int[] g, int[] s)
    {
        if (s.Length == 0) return 0;

        Array.Sort(g);
        Array.Sort(s);

        int count = 0;
        int i = 0;
        int j = 0;
        while (i < g.Length && j < s.Length)
        {
            if (g[i] <= s[j])
            {
                count++;
                i++;
                
            }
            j++;
        }

        return count;
    }

    // --------------- O(nlogn) 136ms --------------- 31MB --------------- (43% 97%) 
    /*
     *  improve : use i to instead of count
     */
    public int FindContentChildren_1_2(int[] g, int[] s)
    {
        if (s.Length == 0) return 0;

        Array.Sort(g);
        Array.Sort(s);

        int i = 0;
        int j = 0;
        while (i < g.Length && j < s.Length)
        {
            if (g[i] <= s[j])
            {
                i++;
            }
            j++;
        }

        return i;
    }
}
/**************************************************************************************************************
 * FindContentChildren_1                                                                                      *
 **************************************************************************************************************/