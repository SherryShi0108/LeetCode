//Source  : https://leetcode.com/problems/guess-number-higher-or-lower/
//Author  : Xinruo Shi
//Date    : 2019-12-08
//Language: C#

/*******************************************************************************************************************************
 * 
 * We are playing the Guess Game. The game is as follows:
 * I pick a number from 1 to n. You have to guess which number I picked.
 * Every time you guess wrong, I'll tell you whether the number is higher or lower.
 *
 * You call a pre-defined API guess(int num) which returns 3 possible results (-1, 1, or 0):
 *      -1 : My number is lower
 *      1 : My number is higher
 *      0 : Congrats! You got it!
 *
 * Example : Input: n = 10, pick = 6 ; Output: 6
 * 
 *******************************************************************************************************************************/

/* The guess API is defined in the parent class GuessGame.
   @param num, your guess
   @return -1 if my number is lower, 1 if my number is higher, otherwise return 0
   int guess(int num); */

public class Temp
{
    public int guess(int n)
    {
        return 0; // 0 -1 1
    }
}

public class Solution374 : Temp
{
    // --------------- O(logn) 0ms --------------- 33.2MB --------------- (100% 100%) 
    public int guessNumber_1(int n)
    {
        int i = 1;
        int j = n;
        while (i <= j)
        {
            int mid = i + (j - i) / 2;
            if (guess(mid) == 0) return mid;
            else if (guess(mid) == 1)
            {
                i = mid + 1;
            }
            else
            {
                j = mid - 1;
            }
        }

        return -1;
    }
    
    // --------------- O(logn) 0ms --------------- 33.2MB --------------- (100% 100%) ※
    public int GuessNumber_1_2(int n)
    {
        int i = 1;
        int j = n;
        while (i < j)
        {
            int mid = i + ((j - i) >> 1);
            if (guess(mid) == 0) return mid;
            else if (guess(mid) == 1)
            {
                i = mid + 1;
            }
            else
            {
                j = mid;
            }
        }

        return i;
    }
}
/**************************************************************************************************************
 * guessNumber_1                                                                                              *
 **************************************************************************************************************/
