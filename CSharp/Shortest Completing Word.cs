//Source  : https://leetcode.com/problems/shortest-completing-word/
//Author  : Xinruo Shi
//Date    : 2019-08-19
//Language: C#

/*******************************************************************************************************************************
 * 
 * Find the minimum length word from a given dictionary words, which has all the letters from the string licensePlate. 
 * Such a word is said to complete the given string licensePlate
 * Here, for letters we ignore case. For example, "P" on the licensePlate still matches "p" on the word.
 * It is guaranteed an answer exists. If there are multiple answers, return the one that occurs first in the array.
 * The license plate might have the same letter occurring multiple times. For example, given a licensePlate of "PP",
 * the word "pair" does not complete the licensePlate, but the word "supper" does.
 * 
 * Input: licensePlate = "1s3 PSt", words = ["step", "steps", "stripe", "stepple"]
 * Output: "steps"
 * Explanation: The smallest length word that contains the letters "S", "P", "S", and "T".
 *              Note that the answer is not "step", because the letter "s" must occur in the word twice.
 *              Also note that we ignored case for the purposes of comparing whether a letter exists in the word.
 *              
 * Input: licensePlate = "1s3 456", words = ["looks", "pest", "stew", "show"]
 * Output: "pest"
 * Explanation: There are 3 smallest length words that contains the letters "s". We return the one that occurred first.
 * 
 * Note:
 *      licensePlate will be a string with length in range [1, 7].
 *      licensePlate will contain digits, spaces, or letters (uppercase or lowercase).
 *      words will have a length in the range [10, 1000].
 *      Every words[i] will consist of lowercase letters, and have length in range [1, 15].
 * 
 *******************************************************************************************************************************/
using System.Collections.Generic;

public class Solution748
{
    // --------------- O(m*n) 112ms --------------- 25.9MB --------------- (89% 60%) 
    public string ShortestCompletingWord_1(string licensePlate, string[] words)
    {
        int[] array = new int[26];
        foreach (char c in licensePlate.ToLower())
        {
            if (c >= 'a' && c <= 'z')
            {
                array[c - 'a']++;
            }
        }

        int count = int.MaxValue;
        string result = "";
        foreach (string item in words)
        {
            if (item.Length >= count) { continue; }
            int[] copy = (int[])array.Clone();
            bool flag = true;
            foreach (char c in item)
            {
                copy[c - 'a']--;
            }
            for (int i = 0; i < copy.Length; i++)
            {
                if (copy[i] > 0) { flag = false; }
            }

            if (flag)
            {
                if (item.Length < count)
                {
                    result = item;
                    count = item.Length;
                }
            }
        }

        return result;
    }

    // --------------- O(m*n) 112ms --------------- 24.4MB --------------- (89% 60%)  ※
    /*
     * assign each letter a prime number and compute the product for the licenseplate
     */
    static int[] a= { 2,  3,  5,  7, 11, 13, 17, 19, 23, 29, 31, 37,  41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 }; //26 primes
    public string ShortestCompletingWord_2(string licensePlate, string[] words)
    {
        long temp = GetChar(licensePlate.ToLower());
        string result = "";
        int count = int.MaxValue;
        foreach (var s in words)
        {
            if (s.Length < count&&GetChar(s)%temp==0)
            {
                result = s;
                count = s.Length;
            }
        }
        return result;
    }

    public long GetChar(string s)
    {
        long x = 1;
        foreach (char c in s)
        {
            int index = c - 'a';
            if (index >= 0 && index <= 25)
            {
                x *= a[index];
            }
        }
        return x;
    }
}
/**************************************************************************************************************
 * ShortestCompletingWord_1 ShortestCompletingWord_2                                                          *
 **************************************************************************************************************/
