//Source  : https://leetcode.com/problems/reorder-data-in-log-files/
//Author  : Xinruo Shi
//Date    : 2019-10-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * You have an array of logs.  Each log is a space delimited string of words.
 * For each log, the first word in each log is an alphanumeric identifier.  Then, either:
 *      Each word after the identifier will consist only of lowercase letters, or;
 *      Each word after the identifier will consist only of digits.
 *
 * We will call these two varieties of logs letter-logs and digit-logs.  It is guaranteed that each log has at least one word after its identifier.
 * Reorder the logs so that all of the letter-logs come before any digit-log.  The letter-logs are ordered lexicographically ignoring identifier,
 * with the identifier used in case of ties.  The digit-logs should be put in their original order.
 * Return the final order of the logs.
 *
 * Input: logs = ["dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero"]
 * Output: ["let1 art can","let3 art zero","let2 own kit dig","dig1 8 1 5 1","dig2 3 6"]
 *
 * Constraints:
 *             1. 0 <= logs.length <= 100
 *             2. 3 <= logs[i].length <= 100
 *             3. logs[i] is guaranteed to have an identifier, and a word after the identifier.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;
using System.Linq;

public class Solution937
{
    // --------------- O(mnlogn) 345ms --------------- 35MB --------------- (11% 48%) ※
    /*
     * Using SortedDictionary
     */
    public string[] ReorderLogFiles_1(string[] logs)
    {
        List<string> diStrs = new List<string>();
        SortedDictionary<string, string> leStrs = new SortedDictionary<string, string>();

        foreach (string log in logs)
        {
            string[] words = log.Split(' ');
            if (char.IsDigit(words[1][0]))
            {
                diStrs.Add(log);
            }
            else
            {
                int index = log.IndexOf(' ');
                string remain = log.Substring(index + 1);

                if (leStrs.ContainsKey(remain))
                {
                    leStrs[log] = log;
                }
                else
                {
                    leStrs[remain] = log;
                }
            }
        }

        string[] reslt = new string[logs.Length];
        int k = 0;
        foreach (var str in leStrs)
        {
            reslt[k++] = str.Value;
        }

        foreach (string str in diStrs)
        {
            reslt[k++] = str;
        }

        return reslt;
    }

    // --------------- O(mnlogn) 572ms --------------- 35MB --------------- (5% 98%) 
    /*
     * Using IComparer
     */
    public string[] ReorderLogFiles_2(string[] logs)
    {
        List<string> diStrs = new List<string>();
        List<string> leStrs = new List<string>();

        foreach (string log in logs)
        {
            if (char.IsDigit(log.Split(' ')[1][0]))
            {
                diStrs.Add(log);
            }
            else
            {
                leStrs.Add(log);
            }
        }

        leStrs.Sort(new LogCompareTemp());
        leStrs.AddRange(diStrs);
        return leStrs.ToArray();
    }

    public class LogCompareTemp : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string[] log1 = x.Split(new char[] {' '}, 2);
            string[] log2 = y.Split(new char[] {' '}, 2);

            int temp = log1[1].CompareTo(log2[1]);

            if (temp == 0)
            {
                return log1[0].CompareTo(log2[0]);
            }
            return temp;
        }
    }

    // --------------- O(mnlogn) 436ms --------------- 35MB --------------- (5% 35%) 
    public string[] ReorderLogFiles_2_2(string[] logs)
    {
        SortedSet<string> letterLogs = new SortedSet<string>(new LogComparator());
        List<string> numberLogs = new List<string>();
        List<string> result = new List<string>();

        foreach (string str in logs)
        {
            if (str[str.IndexOf(' ') + 1] >= 'a' && str[str.IndexOf(' ') + 1] <= 'z')
            {
                letterLogs.Add(str);
            }
            else
            {
                numberLogs.Add(str);
            }

        }

        foreach (string str in letterLogs)
        {
            result.Add(str);
        }

        foreach (string str in numberLogs)
        {
            result.Add(str);
        }

        return result.ToArray();
    }

    public class LogComparator : IComparer<string>
    {
        public int Compare(string str1, string str2)
        {
            string word1 = str1.Substring(str1.IndexOf(' ') + 1);
            string word2 = str2.Substring(str2.IndexOf(' ') + 1);

            string identifier1 = str1.Substring(0, str1.IndexOf(' '));
            string identifier2 = str2.Substring(0, str2.IndexOf(' '));

            if (word1.Equals(word2))
            {
                return string.Compare(identifier1, identifier2);
            }

            return string.Compare(word1, word2);
        }
    }
}
/**************************************************************************************************************
 * ReorderLogFiles_1 ReorderLogFiles_2                                                                        *
 **************************************************************************************************************/