//Source  : https://leetcode.com/problems/uncommon-words-from-two-sentences/
//Author  : Xinruo Shi
//Date    : 2019-08-20
//Language: C#

/*******************************************************************************************************************************
 * 
 * We are given two sentences A and B.  (A sentence is a string of space separated words.  Each word consists only of lowercase letters.)
 * A word is uncommon if it appears exactly once in one of the sentences, and does not appear in the other sentence.
 * Return a list of all uncommon words. You may return the list in any order.
 * 
 * Input: A = "this apple is sweet", B = "this apple is sour"
 * Output: ["sweet","sour"]
 * 
 * Input: A = "apple apple", B = "banana"
 * Output: ["banana"]
 * 
 * Note:
 *      0 <= A.length <= 200
 *      0 <= B.length <= 200
 *      A and B both contain only spaces and lowercase letters.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;
using System.Linq;

public class Solution884
{
    // --------------- O(n) 264ms --------------- 30MB ---------------(51% 100%) ※
    public string[] UncommonFromSentences_1(string A, string B)
    {
        string C = A + ' ' + B;
        string[] c = C.Split(' ');
        Dictionary<string, int> d = new Dictionary<string, int>();

        for (int i = 0; i < c.Length; i++)
        {
            if (d.ContainsKey(c[i]))
            {
                d[c[i]]++;
            }
            else
            {
                d[c[i]] = 1;
            }
        }

        int n = 0;
        for (int i = 0; i < c.Length; i++)
        {
            if (d[c[i]] == 1)
            {
                n++;
            }
        }

        string[] result = new string[n];
        int k = 0;
        for (int i = 0; i < c.Length; i++)
        {
            if (d[c[i]] == 1)
            {
                result[k++] = c[i];
            }
        }
        return result;
    }

    // --------------- O(n) 244ms --------------- 32MB ---------------(55% 100%)
    /*
     * similar to 1, but reduce a for()
     */
    public string[] UncommonFromSentences_1_2(string A, string B)
    {
        Dictionary<string, int> d = new Dictionary<string, int>();
        foreach (string s in (A + ' ' + B).Split(' '))
        {
            d[s] = d.ContainsKey(s) ? d[s] + 1 : 1;
        }

        List<string> L = new List<string>();
        foreach (var i in d)
        {
            if (i.Value == 1) L.Add(i.Key);
        }

        return L.ToArray();
    }

    // --------------- O(n) 252ms --------------- 30.3MB ---------------(93% 100%)
    /*
     * use Linq
     */
    public string[] UncommonFromSentences_2(string A, string B)
    {
        string[] x = (A + ' ' + B).Split(' ').GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key).ToArray();
        return x;
    }
}
/**************************************************************************************************************
 * UncommonFromSentences_1 UncommonFromSentences_2                                                            *
 **************************************************************************************************************/
