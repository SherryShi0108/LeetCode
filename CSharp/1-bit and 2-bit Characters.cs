//Source  : https://leetcode.com/problems/1-bit-and-2-bit-characters/
//Author  : Xinruo Shi
//Date    : 2019-06-27
//Language: C#

/*******************************************************************************************************************************
 * 
 * We have two special characters. The first character can be represented by one bit 0. The second character can be 
 * represented by two bits (10 or 11).
 * Now given a string represented by several bits. Return whether the last character must be a one-bit character or not. 
 * The given string will always end with a zero.
 * 
 * Note:
 *  1 <= len(bits) <= 1000.
 *  bits[i] is always 0 or 1.
 * 
 * Input: bits = [1, 0, 0]
 * Output: True
 * Explanation: The only way to decode it is two-bit character and one-bit character. So the last character is one-bit character.
 * 
 *Input: bits = [1, 1, 1, 0]
 * Output: False
 * Explanation: The only way to decode it is two-bit character and two-bit character. So the last character is NOT one-bit character.
 * 
 *******************************************************************************************************************************/

public class Solution717
{
    // --------------- O(n) 129ms --------------- 39MB --------------- (75% 68%)
    public bool IsOneBitCharacter_1(int[] bits)
    {
        int i = bits.Length - 2;
        for (; i >= 0; i--)
        {
            if (bits[i] == 0)
            {
                break;
            }
        }

        return (bits.Length - i) % 2 == 0;        
    }  
    
    // --------------- O(n) 96ms --------------- 22.8MB --------------- (48% 7%)
    public bool IsOneBitCharacter_1_2(int[] bits)
    {
        int i = bits.Length - 2;
        while (i >= 0 && bits[i] > 0)
        {
            i--;
        }
        return (bits.Length - i) % 2 == 0;
    }
    
    // --------------- O(n) 125ms --------------- 39MB --------------- (75% 68%)
    public bool IsOneBitCharacter_2(int[] bits)
    {
        if (bits.Length == 0)
        {
            return true;
        }
        else if(bits[bits.Length-2]==0)
        {
            return true;
        }
        else
        {
            bool result = true;
            for (int i = 0; i < bits.Length; i++)
            {
                int current = bits[i];
                if (current == 1)
                {
                    i++;
                    result = false;
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }
    }
    
    // --------------- O(n) 96ms --------------- 22.7MB --------------- (48% 50%)
    public bool IsOneBitCharacter_2_2(int[] bits)
    {
        int count = 0;
        while (count < bits.Length - 1)
        {
            if (bits[count] == 1)
            {
                count = count + 2;
            }
            else
            {
                count++;
            }
        }
        return count == bits.Length - 1;
    }
}

/**************************************************************************************************************
 * IsOneBitCharacter_1                                                                                        *
 **************************************************************************************************************/
