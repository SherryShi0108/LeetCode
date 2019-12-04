//Source  : https://leetcode.com/problems/goat-latin/
//Author  : Xinruo Shi
//Date    : 2019-10-28
//Language: C#

/*******************************************************************************************************************************
 * 
 * A sentence S is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.
 * We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)
 *
 * The rules of Goat Latin are as follows:
 *      1. If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
 *         For example, the word 'apple' becomes 'applema'.
 *      2. If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
 *         For example, the word "goat" becomes "oatgma".
 *      3. Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
 *         For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
 * Return the final sentence representing the conversion from S to Goat Latin. 
 *
 * Input: "I speak Goat Latin"
 * Output: "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"
 *
 * Input: "The quick brown fox jumped over the lazy dog"
 * Output: "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"
 *
 * Notes:
 *      S contains only uppercase, lowercase and spaces. Exactly one space between each word.
 *      1 <= S.length <= 150.
 * 
 *******************************************************************************************************************************/


using System.Collections.Generic;

public class Solution824
{
    // --------------- O(n^2) 84ms --------------- 25.9MB --------------- (83% 33%)
    public string ToGoatLatin_1(string S)
    {
        HashSet<char> H = new HashSet<char>("AEIOUaeiou");
        string result = "";
        int count = 1;
        foreach (string str in S.Split(' '))
        {
            if (H.Contains(str[0]))
            {
                result = result + " " + str + "ma";
            }
            else
            {
                result = result + " " + str.Substring(1) + str[0] + "ma";
            }

            for (int i = 0; i < count; i++)
            {
                result += "a";
            }
            count++;
        }

        return result.Substring(1);
    }

    // --------------- O(n)? 84ms --------------- 23MB --------------- (83% 33%) ※
    public string ToGoatLatin_2(string S)
    {
        HashSet<char> H = new HashSet<char>("AEIOUaeiou");
        string result = "";
        string a = "a";
        foreach (string str in S.Split(' '))
        {
            string temp = str;
            if (!H.Contains(str[0]))
            {
                temp = str.Substring(1) + str[0];
            }

            result += " " + temp + "ma" + a;
            a += "a";
        }

        return result.Substring(1);
    }
}
/**************************************************************************************************************
 * ToGoatLatin_1 ToGoatLatin_2                                                                                *
 **************************************************************************************************************/