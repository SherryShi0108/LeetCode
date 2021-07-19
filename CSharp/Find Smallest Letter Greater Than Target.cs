//Source  : https://leetcode.com/problems/find-smallest-letter-greater-than-target/
//Author  : Xinruo Shi
//Date    : 2019-12-10
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a list of sorted characters letters containing only lowercase letters, and given a target letter target,
 * find the smallest element in the list that is larger than the given target.
 *
 * Letters also wrap around. For example, if the target is target = 'z' and letters = ['a', 'b'], the answer is 'a'.
 *
 * Input: letters = ["c", "f", "j"] ; target = "a" ;
 * Output: "c"
 *
 * Input: letters = ["c", "f", "j"] ; target = "c"
 * Output: "f"
 *
 * Input: letters = ["c", "f", "j"] ; target = "d"
 * Output: "f"
 *
 * Input: letters = ["c", "f", "j"] ; target = "g"
 * Output: "j"
 *
 * Input: letters = ["c", "f", "j"] ; target = "j"
 * Output: "c"
 *
 * Input: letters = ["c", "f", "j"] ; target = "k"
 * Output: "c"
 *
 * Note:
 *      letters has a length in range [2, 10000].
 *      letters consists of lowercase letters, and contains at least 2 unique letters.
 *      target is a lowercase letter.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;
using System.Data;
using System.Linq;

public class Solution744
{ 
    // --------------- O(logn) 116ms --------------- 27.5MB ---------------(95% 25%) ※
    /*
     *  Binary Search
     */
    public char NextGreatestLette_1(char[] letters, char target)
    {
        int i = 0;
        int j = letters.Length;
        while (i<j)
        {
            int mid = i + (j - i) / 2;      // int mid = i + ((j - i) >> 1);
            if (letters[mid] <= target)
            {
                i = mid + 1;
            }
            else
            {
                j = mid;
            }
        }

        return i >= letters.Length ? letters[0] : letters[i]; // return letter[i%letter.length];
    }

    // --------------- O(n) 136ms --------------- 27.8MB ---------------(13% 25%)
    /*
     * Linear Scan
     */
    public char NextGreatestLette_2(char[] letters, char target)
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] > target)
            {
                return letters[i];
            }
        }

        return letters[0];
    }
}
/**************************************************************************************************************
 * NextGreatestLette_1                                                                                        *
 **************************************************************************************************************/
