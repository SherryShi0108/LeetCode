//Source  : https://leetcode.com/problems/long-pressed-name/
//Author  : Xinruo Shi
//Date    : 2019-09-26
//Language: C#

/*******************************************************************************************************************************
 * 
 * Your friend is typing his name into a keyboard.  Sometimes, when typing a character c, the key might get long pressed,
 * and the character will be typed 1 or more times. You examine the typed characters of the keyboard.
 * Return True if it is possible that it was your friends name, with some characters (possibly none) being long pressed.
 *
 * Input: name = "alex", typed = "aaleex"
 * Output: true
 * Explanation: 'a' and 'e' in 'alex' were long pressed.
 *
 * Input: name = "saeed", typed = "ssaaedd"
 * Output: false
 * Explanation: 'e' must have been pressed twice, but it wasn't in the typed output.
 *
 * Input: name = "leelee", typed = "lleeelee"
 * Output: true
 *
 * Input: name = "laiden", typed = "laiden"
 * Output: true
 * Explanation: It's not necessary to long press any character.
 *
 * Note:
 *      name.length <= 1000
 *      typed.length <= 1000
 *      The characters of name and typed are lowercase letters.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution925
{
    // --------------- O(n) 72ms --------------- 22.7MB --------------- (82% 100%) 
    public bool IsLongPressedName_1(string name, string typed)
    {
        Dictionary<int, int[]> d1 = new Dictionary<int, int[]>();
        Dictionary<int, int[]> d2 = new Dictionary<int, int[]>();

        int current1 = 0;
        for (int i = 0; i < name.Length; i++)
        {
            if (i == 0)
            {
                d1[current1] =new int[]{name[i]-'a',1};
            }
            else if (name[i] == name[i - 1])
            {
                d1[current1][1]++;
            }
            else
            {
                current1++;
                d1[current1] = new int[] {name[i] - 'a', 1};
            }
        }

        int current2 = 0;
        for (int i = 0; i < typed.Length; i++)
        {
            if (i == 0)
            {
                d2[current2] = new int[] { typed[i] - 'a', 1 };
            }
            else if (typed[i] == typed[i - 1])
            {
                d2[current2][1]++;
            }
            else
            {
                current2++;
                d2[current2] = new int[] { typed[i] - 'a', 1 };
            }
        }

        if (d1.Count != d2.Count)
        {
            return false;
        }

        foreach (var temp in d1)
        {
            if (d2[temp.Key][0] != temp.Value[0])
            {
                return false;
            }

            if (d2[temp.Key][1] < temp.Value[1])
            {
                return false;
            }
        }
        return true;
    }

    // --------------- O(n) 72ms --------------- 22.7MB --------------- (82% 100%) 
    /*
     * Amazing solution !!! donnot understand , remember it !!!
     */
    public bool IsLongPressedName_2(string name, string typed)
    {
        int i = 0;
        for (int j = 0; j < typed.Length; j++)
        {
            if (i < name.Length && name[i] == typed[j])
            {
                i++;
            }
            else if(j==0||typed[j]!=typed[j-1])
            {
                return false;
            }
        }

        return i == name.Length;
    }
    
     // --------------- O(n) 72ms --------------- 22MB --------------- (80% 100%) ※
    /*
     * improve 2 : easy-unstanding
     */
    public bool IsLongPressedName_2_2(string name, string typed)
    {
        int i = 0;
        int j = 0;

        while (j < typed.Length)
        {
            if (i < name.Length && name[i] == typed[j])
            {
                i++;
                j++;
            }
            else if (j == 0 || typed[j] != typed[j - 1])
            {
                return false;
            }
            else
            {
                j++;
            }
        }

        return i == name.Length;
    }
}
/**************************************************************************************************************
 * IsLongPressedName_2                                                                                        *
 **************************************************************************************************************/
