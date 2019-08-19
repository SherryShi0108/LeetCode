//Source  : https://leetcode.com/problems/bulls-and-cows/
//Author  : Xinruo Shi
//Date    : 2019-08-08
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are playing the following Bulls and Cows game with your friend: You write down a number and ask your friend 
 * to guess what the number is. Each time your friend makes a guess, you provide a hint that indicates how many digits in 
 * said guess match your secret number exactly in both digit and position (called "bulls") and how many digits match the
 * secret number but locate in the wrong position (called "cows"). 
 * Your friend will use successive guesses and hints to eventually derive the secret number.
 * Write a function to return a hint according to the secret number and friend's guess, 
 * use A to indicate the bulls and B to indicate the cows. 
 * Please note that both secret number and friend's guess may contain duplicate digits.
 * 
 * Input: secret = "1807", guess = "7810"
 * Output: "1A3B"
 * Explanation: 1 bull and 3 cows. The bull is 8, the cows are 0, 1 and 7.
 * 
 * Input: secret = "1123", guess = "0111"
 * Output: "1A1B"
 * Explanation: The 1st 1 in friend's guess is a bull, the 2nd or 3rd 1 is a cow.
 * 
 * Note: You may assume that the secret number and your friend's guess only contain digits, and their lengths are always equal.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution299
{
    // --------------- O(n) 92ms --------------- 22.4MB --------------- (72% 100%)
    public string GetHint_1(string secret, string guess)
    {
        char[] a = secret.ToCharArray();
        char[] b = guess.ToCharArray();

        int count0 = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == b[i])
            {
                count0++;
            }
        }

        Dictionary<char, int> d = new Dictionary<char, int>();
        for (int i = 0; i < a.Length; i++)
        {
            if (d.ContainsKey(a[i]))
            {
                d[a[i]]++;
            }
            else
            {
                d[a[i]] = 1;
            }
        }
        int count1 = 0;
        for (int i = 0; i < b.Length; i++)
        {
            if (d.ContainsKey(b[i]) && d[b[i]] > 0)
            {
                count1++;
                d[b[i]]--;
            }
        }

        return count0 + "A" + (count1 - count0) + "B";
    }

    // --------------- O(n) 88ms --------------- 21.9MB --------------- (90% 100%) 
    /*
     * ASCII: 0 -> 48
     */
    public string GetHint_2(string secret, string guess)
    {
        int count0 = 0;
        int count1 = 0;
        int[] array = new int[10];
        for (int i = 0; i < secret.Length; i++)
        {
            array[secret[i] - 48] += 1;  //array[secret[i] - '0'] += 1;
        }
        for (int i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i])
            {
                count0++;
            }
            if (array[guess[i] - 48] > 0)
            {
                count1++;
                array[guess[i] - 48]--;
            }
        }

        return count0 + "A" + (count1 - count0) + "B";
    }

    // --------------- O(n) 88ms --------------- 22MB --------------- (90% 100%) 
    /*
     * amazing solution !!!
     */
    public string GetHint_3(string secret, string guess)
    {
        int count0 = 0;
        int count1 = 0;
        int[] array = new int[10];
        for (int i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i])
            {
                count0++;
            }
            else
            {
                if (array[guess[i] - '0'] > 0)
                {
                    count1++;
                }
                if (array[secret[i] - '0'] < 0)
                {
                    count1++;
                }
                array[guess[i] - '0']--;
                array[secret[i] - '0']++;
            }
        }
        return count0 + "A" + count1 + "B";
    }

    // --------------- O(n) 84ms --------------- 21.8MB --------------- (98% 100%) ※
    /*
     * amazing solution !!!
     */
    public string GetHint_4(string secret, string guess)
    {
        int count0 = 0;
        int count1 = 0;
        int[] a = new int[10];
        int[] b = new int[10];
        for (int i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i])
            {
                count0++;
            }
            else
            {
                a[secret[i] - '0']++;
                b[guess[i] - '0']++;
            }            
        }
        for (int i = 0; i < 10; i++)
        {
            count1 += a[i] < b[i] ? a[i] : b[i];
        }
        return count0 + "A" + count1 + "B";
    }
}
/**************************************************************************************************************
 * GetHint_2 GetHint_3 GetHint_4                                                                              *
 **************************************************************************************************************/