//Source  : https://leetcode.com/problems/valid-palindrome/
//Author  : Xinruo Shi
//Date    : 2019-09-21
//Language: C#

/*******************************************************************************************************************************
 *
 * Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
 *
 * Note: For the purpose of this problem, we define empty string as valid palindrome.
 *
 * Input: "A man, a plan, a canal: Panama"
 * Output: true
 *
 * Input: "race a car"
 * Output: false
 * 
 *******************************************************************************************************************************/

public class Solution125
{
    ///+++++++++++++++++++++++++ Time Limited +++++++++++++++++++++++++
    public bool IsPalindrome_1(string s)
    {
        string s1 = "";
        foreach (char c in s.ToLower())
        {
            if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
            {
                s1 += c;
            }
        }

        for (int i = 0; i < s1.Length / 2; i++)
        {
            if (s1[i] != s1[s1.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    // --------------- O(n) 80ms --------------- 23.7MB --------------- (84% 10%) ※
    public bool IsPalindrome_2(string s)
    {
        s = s.ToLower();
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            if (!IsLetterOrDigit(s[i]))
            {
                i++;
            }
            else if (!IsLetterOrDigit(s[j]))
            {
                j--;
            }
            else if (s[i] != s[j])
            {
                return false;
            }
            else if (s[i] == s[j])
            {
                i++;
                j--;
            }
        }

        return true;
    }

    public bool IsLetterOrDigit(char c)
    {
        if (c >= '0' && c <= '9' || c >= 'a' && c <= 'z')
        {
            return true;
        }

        return false;
    }
}
/**************************************************************************************************************
 * IsPalindrome_2                                                                                             *
 **************************************************************************************************************/