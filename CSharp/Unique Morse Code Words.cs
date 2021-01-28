//Source  : https://leetcode.com/problems/unique-morse-code-words/
//Author  : Xinruo Shi
//Date    : 2019-10-20
//Language: C#

/*******************************************************************************************************************************
 * 
 * International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes,
 * as follows: "a" maps to ".-", "b" maps to "-...", "c" maps to "-.-.", and so on.
 *
 * For convenience, the full table for the 26 letters of the English alphabet is given below:
 *      [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...",
 *       "-","..-","...-",".--","-..-","-.--","--.."]
 *
 * Now, given a list of words, each word can be written as a concatenation of the Morse code of each letter.
 * For example, "cab" can be written as "-.-..--...", (which is the concatenation "-.-." + "-..." + ".-").
 * We'll call such a concatenation, the transformation of a word.
 * Return the number of different transformations among all words we have.
 *
 * Input: words = ["gin", "zen", "gig", "msg"]
 * Output: 2
 * Explanation:
 *              The transformation of each word is:
 *              "gin" -> "--...-."
 *              "zen" -> "--...-."
 *              "gig" -> "--...--."
 *              "msg" -> "--...--."
 *              There are 2 different transformations, "--...-." and "--...--.".
 *
 * Note:
 *      The length of words will be at most 100.
 *      Each words[i] will have length in range [1, 12].
 *      words[i] will only consist of lowercase letters.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution804
{
    // --------------- O(n) 132ms --------------- 26MB --------------- (6% 32%) ※
    public int UniqueMorseRepresentations_1(string[] words)
    {
        string[] strs = new string[]
        {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---",
            ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
        };

        HashSet<string> H = new HashSet<string>();
        foreach (string word in words)
        {
            string temp = "";
            foreach (char c in word)
            {
                temp += strs[c - 'a'];
            }

            H.Add(temp);
        }

        return H.Count;
    }
}

/**************************************************************************************************************
 * UniqueMorseRepresentations_1                                                                               *
 **************************************************************************************************************/