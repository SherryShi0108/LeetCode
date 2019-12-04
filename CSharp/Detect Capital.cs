//Source  : https://leetcode.com/problems/detect-capital/
//Author  : Xinruo Shi
//Date    : 2019-10-19
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a word, you need to judge whether the usage of capitals in it is right or not.
 * We define the usage of capitals in a word to be right when one of the following cases holds:
 *      1. All letters in this word are capitals, like "USA".
 *      2. All letters in this word are not capitals, like "leetcode".
 *      3. Only the first letter in this word is capital, like "Google".
 * Otherwise, we define that this word doesn't use capitals in a right way.
 *
 * Input: "USA"
 * Output: True
 *
 * Input: "FlaG"
 * Output: False
 *
 * Note: The input will be a non-empty word consisting of uppercase and lowercase latin letters.
 * 
 *******************************************************************************************************************************/

public class Solution520
{
    // --------------- O(n) 76ms --------------- O(1) 22.8MB --------------- (76% 100%)
    public bool DetectCapitalUse_1(string word)
    {
        bool isCapital = word[0] < 97;
        if (!isCapital)
        {
            foreach (char c in word)
            {
                if (c < 97)
                {
                    return false;
                }
            }
        }
        else
        {
            if (word.Length < 2)
            {
                return true;
            }
            else if (word[1] < 97)
            {
                foreach (char c in word)
                {
                    if (c >= 97)
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (word[i] < 97)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    // --------------- O(n) 64ms --------------- O(1) 22.4MB --------------- (100% 100%) ※
    public bool DetectCapitalUse_2(string word)
    {
        int count = 0;
        foreach (char c in word)
        {
            if (c < 97) count++;
        }

        return (count == 0 || count == word.Length || count == 1 && word[0] < 97);
    }

    // --------------- O(n) 76ms --------------- O(1) 22.8MB --------------- (76% 100%)
    public bool DetectCapitalUse_3(string word)
    {
        if (word.Length < 2) return true;
        if (word.ToUpper().Equals(word)) return true;
        if (word.Substring(1).ToLower().Equals(word.Substring(1))) return true;
        return false;
    }
}
/**************************************************************************************************************
 * DetectCapitalUse_2 DetectCapitalUse_3                                                                      *
 **************************************************************************************************************/