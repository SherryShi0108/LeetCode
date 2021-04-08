//Source  : https://leetcode.com/problems/palindrome-number/
//Author  : Xinruo Shi
//Date    : 2019-09-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
 * 
 * Input: 121
 * Output: true
 * 
 * Input: -121
 * Output: false
 * Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
 * 
 * Input: 10
 * Output: false
 * Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 * 
 * Follow up: Coud you solve it without converting the integer to a string?
 * 
 *******************************************************************************************************************************/

public class Solution9
{
    // --------------- 72ms --------------- O(1) 17MB --------------- (46% 65%) 
    public bool IsPalindrome_1(int x)
    {
        if (x < 0) return false; 
      
        int result = 0;
        int temp = x;
        while (x != 0)
        {
            result = result * 10 + x % 10;
            x /= 10;
        }

        return temp == result;
    }
    
    // --------------- O(logn) 56ms --------------- O(1) 17MB --------------- (94% 65%) ※
    public bool IsPalindrome_2(int x)
    {
        if (x < 0 || x % 10 == 0 && x != 0) return false;

        int result = 0;
        while (x > result)
        {
            result = result * 10 + x % 10;
            x /= 10;
        }

        return result == x || result / 10 == x;
    }
        
    // --------------- 64ms --------------- O(n)19MB --------------- (70% 13%) 
    public bool IsPalindrome_3(int x)
    {
        if (x < 0) return false;
        
        List<int> L = new List<int>();
        while (x > 0)
        {
            L.Add(x % 10);
            x /= 10;
        }

        int[] arrays = new int[L.Count];
        arrays = L.ToArray();
        for (int i = 0; i < arrays.Length / 2; i++)
        {
            if (arrays[i] != arrays[arrays.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
    
    // --------------- 68ms --------------- 15.7MB --------------- (57% 15%)
    public bool IsPalindrome_4(int x)
    {
        if (x < 0) return false;

        int div = 1;
        while (x / div >= 10)
        {
             div *= 10;
        }

        while (div >= 10)
        {
             if (x / div != x % 10) return false;
              x = x % div / 10;
             div /= 100;
        }

        return true;
}
/**************************************************************************************************************
 * IsPalindrome_2                                                                                             *
 **************************************************************************************************************/
