//Source  : https://leetcode.com/problems/keyboard-row/
//Author  : Xinruo Shi
//Date    : 2019-08-14
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a List of words, return the words that can be typed using letters of alphabet on only one row's of American keyboard 
 * like the image below.[https://assets.leetcode.com/uploads/2018/10/12/keyboard.png]
 * 
 * Input: ["Hello", "Alaska", "Dad", "Peace"]
 * Output: ["Alaska", "Dad"]
 * 
 * Note:
 *      You may use one character in the keyboard more than once.
 *      You may assume the input string will only contain letters of alphabet.
 * ※
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution500
{
    // --------------- O(n) 264ms --------------- 28.4MB --------------- (75% 100%) 
    #region 1
    Dictionary<char, int> d = new Dictionary<char, int>();
    public string[] FindWords_1(string[] words)
    {
        MKd();
        List<string> L = new List<string>();
        foreach (string item in words)
        {
            int current = d[item[0]];
            bool flag = true;
            for (int i = 1; i < item.Length; i++)
            {
                if (d[item[i]] != current)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                L.Add(item);
            }
        }

        return L.ToArray();
    }
    private void MKd()
    {
        d['q'] = 0; d['Q'] = 0;
        d['w'] = 0; d['W'] = 0;
        d['e'] = 0; d['E'] = 0;
        d['r'] = 0; d['R'] = 0;
        d['t'] = 0; d['T'] = 0;
        d['y'] = 0; d['Y'] = 0;
        d['u'] = 0; d['U'] = 0;
        d['i'] = 0; d['I'] = 0;
        d['o'] = 0; d['O'] = 0;
        d['p'] = 0; d['P'] = 0;

        d['a'] = 1; d['A'] = 1;
        d['s'] = 1; d['S'] = 1;
        d['d'] = 1; d['D'] = 1;
        d['f'] = 1; d['F'] = 1;
        d['g'] = 1; d['G'] = 1;
        d['h'] = 1; d['H'] = 1;
        d['j'] = 1; d['J'] = 1;
        d['k'] = 1; d['K'] = 1;
        d['l'] = 1; d['L'] = 1;

        d['z'] = 2; d['Z'] = 2;
        d['x'] = 2; d['X'] = 2;
        d['c'] = 2; d['C'] = 2;
        d['v'] = 2; d['V'] = 2;
        d['b'] = 2; d['B'] = 2;
        d['n'] = 2; d['N'] = 2;
        d['m'] = 2; d['M'] = 2;
    }
    #endregion

    // --------------- O(n) 280ms --------------- 28.5MB --------------- (22% 100%) 
    /* 
     * improve 1: use toLower()
     */
    public string[] FindWords_2(string[] words)
    {
        int[] arrayInt = new int[] { 2, 3, 3, 2, 1, 2, 2, 2, 1, 2, 2, 2, 3, 3, 1, 1, 1, 1, 2, 1, 1, 3, 1, 3, 1, 3 };

        List<string> result = new List<string>();
        foreach (string item in words)
        {
            string word = item.ToLower();
            int temp = arrayInt[ word[0]-'a'];
            bool flag = true;

            for (int i = 1; i < word.Length; i++)
            {
                if (arrayInt[word[i] - 'a'] != temp)
                {
                    flag = false;
                    break;
                }
            }
            if (flag) { result.Add(item); }
        }
        return result.ToArray();
    }
        
    // --------------- O(n) 280ms --------------- 28.5MB --------------- (22% 100%) 
    /*
     * amazing solution!
     * use 1 10 100,to | ,a mart solution !
     */
     /* use 2,3,5prime,determine which can %2==0 && %3!=0 && %5!=0 , but it will overfolw */
    public string[] FindWords_3(string[] words)
    {
        Dictionary<char, int> d = new Dictionary<char, int>();
        foreach (var c in "qwertyuiopQWERTYUIOP")
        {
            d.Add(c, 1);
        }
        foreach (var c in "asdfghjklASDFGHJKL")
        {
            d.Add(c, 2);
        }
        foreach (var c in "zxcvbnmZXCVBNM")
        {
            d.Add(c, 4);
        }

        List<string> result = new List<string>();
        foreach (string item in words)
        {
            int mark = 0;
            foreach (char c in item)
            {
                mark |= d[c];
            }
            if (mark == 1 || mark == 2 || mark == 4)
            {
                result.Add(item);
            }
        }
        return result.ToArray();
    }
}
/**************************************************************************************************************
 * FindWords_2 FindWords_3                                                                                    *
 **************************************************************************************************************/
