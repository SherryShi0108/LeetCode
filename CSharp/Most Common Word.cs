//Source  : https://leetcode.com/problems/most-common-word/
//Author  : Xinruo Shi
//Date    : 2019-10-27
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words. 
 * It is guaranteed there is at least one word that isn't banned, and that the answer is unique.
 *
 * Words in the list of banned words are given in lowercase, and free of punctuation. 
 * Words in the paragraph are not case sensitive.  The answer is in lowercase.
 *
 * Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit." banned = ["hit"]
 * Output: "ball"
 * Explanation: "hit" occurs 3 times, but it is a banned word.
 *              "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph.
 *              Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"),
 *              and that "hit" isn't the answer even though it occurs more because it is banned.
 *
 * Note:
 *      1 <= paragraph.length <= 1000.
 *      0 <= banned.length <= 100.
 *      1 <= banned[i].length <= 10.
 *      The answer is unique, and written in lowercase (even if its occurrences in paragraph may have uppercase symbols, and even if it is a proper noun.)
 *      paragraph only consists of letters, spaces, or the punctuation symbols !?',;.
 *      There are no hyphens or hyphenated words.
 *      Words only consist of letters, never apostrophes or other punctuation symbols.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;
using System.Linq;

public class Solution819
{
    // --------------- O(n) 112ms --------------- 26MB --------------- (77% 88%) ※
    public string MostCommonWord_1(string paragraph, string[] banned)
    {
        string[] words = paragraph.ToLower().Split(new char[] { ' ', ',', '.', '?', '!', '\'', ';' });
        List<string> banList = new List<string>(banned);
        Dictionary<string, int> d = new Dictionary<string, int>();

        string result = "";
        int max = int.MinValue;

        foreach (string word in words)
        {
            if (banList.Contains(word) || string.IsNullOrEmpty(word)) continue;

            if (d.ContainsKey(word))
            {
                d[word]++;
            }
            else
            {
                d[word] = 1;
            }

            if (d[word] > max)
            {
                result = word;
                max = d[word];
            }
        }

        return result;
    }
    
    // --------------- O(n) 116ms --------------- 25MB --------------- (65% 9%)
    /*
     * use many API : split(char[]),Linq
     */
    public string MostCommonWord_2(string paragraph, string[] banned)
    {
        List<string> result = paragraph.Split('\'', ' ', ',', '?', '.', '!', ';').ToList();

        Dictionary<string,int> d=new Dictionary<string, int>();
        foreach (string s in result)
        {
            if (s != "")
            {
                d[s] = d.ContainsKey(s) ? d[s] + 1 : 1;
            }
        }

        foreach (string s in banned)
        {
            if (d.ContainsKey(s)) d.Remove(s);
        }

        return d.OrderByDescending(x => x.Value).First().Key;
    }
}
/**************************************************************************************************************
 * MostCommonWord_1 MostCommonWord_2                                                                          *
 **************************************************************************************************************/
