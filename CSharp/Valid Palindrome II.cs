//Source  : https://leetcode.com/problems/valid-palindrome-ii/
//Author  : Xinruo Shi
//Date    : 2019-10-23
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.
 * Input: "aba"
 * Output: True
 *
 * Input: "abca"
 * Output: True
 * Explanation: You could delete the character 'c'.
 *
 * Note: The string will only contain lowercase characters a-z. The maximum length of the string is 50000.
 *
 *******************************************************************************************************************************/

public class Solution680
{
    // --------------- O(n) 100ms --------------- 43MB --------------- (53% 73%) 
    /*
     *  Greedy
     */
    public bool ValidPalindrome_1(string s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
            {
                return IsPalindrome(s, i, s.Length - 1 - i - 1) || IsPalindrome(s, i + 1, s.Length - 1 - i);
            }
        }

        return true;
    }

    public bool IsPalindrome(string s, int i, int j)
    {
        while (i < j)
        {
            if (s[i++] != s[j--])
            {
                return false;
            }
        }

        return true;
    }

    // --------------- O(n) 88ms --------------- 43MB --------------- (93% 52%) ※
    /*
     *  Improve 1_1: use while instead of for
     */
    public bool ValidPalindrome_1_2(string s)
    {
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            if (s[i] != s[j])
            {
                return IsPalindrome(s, i, j - 1) || IsPalindrome(s, i + 1, j);
            }

            i++;
            j--;
        }

        return true;
    }

    // --------------- O(n) 92ms --------------- 43MB --------------- (84% 52%) 
    /*
     *  Improve 1_2: use ++ --
     */
    public bool ValidPalindrome_1_3(string s)
    {
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            if (s[i++] != s[j--])
            {
                return IsPalindrome(s, i - 1, j) || IsPalindrome(s, i, j + 1);
            }
        }

        return true;
    }
}
/**************************************************************************************************************
 * ValidPalindrome_1                                                                                          *
 **************************************************************************************************************/