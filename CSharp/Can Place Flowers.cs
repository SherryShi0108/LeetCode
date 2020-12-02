//Source  : https://leetcode.com/problems/can-place-flowers/
//Author  : Xinruo Shi
//Date    : 2019-06-19
//Language: C#

/*******************************************************************************************************************************
 * 
 * Suppose you have a long flowerbed in which some of the plots are planted and some are not. 
 * However, flowers cannot be planted in adjacent plots - they would compete for water and both would die.
 * Given a flowerbed (represented as an array containing 0 and 1, where 0 means empty and 1 means not empty), 
 * and a number n, return if n new flowers can be planted in it without violating the no-adjacent-flowers rule.
 * 
 * Note:
 * The input array won't violate no-adjacent-flowers rule.
 * The input array size is in the range of [1, 20000].
 * n is a non-negative integer which won't exceed the input array size.
 * 
 * Input: nums = [1,0,0,0,1], n = 1
 * Output: True
 *  
 * Input: nums = [1,0,0,0,1], n = 2
 * Output: False
 * 
 *******************************************************************************************************************************/

public class Solution605
{
    // --------------- O(n) 104ms --------------- 28MB --------------- (99.2% 6%)
    public bool CanPlaceFlowers_1(int[] flowerbed, int n)
    {
        int i = 0;
        int count = 0;
        while (i < flowerbed.Length)
        {
            if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
            {
                count++;
                flowerbed[i] = 1;
            }
            i++;
        }

        return count >= n;
    }
    
    // --------------- O(n) 104ms --------------- 28MB --------------- (99.2% 6%) ※
    public bool CanPlaceFlowers_1_2(int[] flowerbed, int n)
    {
        int count = 0;
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0)
            {
                if ((i == 0 || flowerbed[i - 1] == 0)
                    && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    count++;
                    flowerbed[i] = 1;
                    
                    // i++; // less time
                }
            }
            
            // if(count>=n) return true;
        }

        return count >= n;
    }

    // --------------- O(n) 100ms --------------- 28MB --------------- (100%)
    public bool CanPlaceFlowers_1_3(int[] flowerbed, int n)
    {
        int i = 0;
        int count = 0;
        while (i < flowerbed.Length)
        {
            if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
            {
                count++;
                flowerbed[i] = 1;

                i += 2;
            }
            else
            {
                i++;
            }
            if (count >= n)
            {
                return true;
            }
        }

        return count >= n;
    }

    // --------------- O(n) 120ms --------------- 27.8MB --------------- (34% 13%)
    /*
     * easy-understanding
     */
    public bool CanPlaceFlowers_2(int[] flowerbed, int n)
    {
        int count = 1;
        int result = 0;
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0)
            {
                count++;
            }
            else
            {
                result += (count - 1) / 2;
                count = 0;
            }
        }
        if (count != 0)
        {
            result += count / 2;
        }

        return result >= n;
    }

    // --------------- O(n) 120ms --------------- 28MB --------------- (34% 6%)
    /*
     *  !!! The input array won't violate no-adjacent-flowers rule. !!!
     *  means 1 will not near 1 !!!
     */
    public bool CanPlaceFlowers_3(int[] flowerbed, int n)
    {
        int capacity = 0;

        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 1)
            {
                ++i;
                continue;
            }
            else
            {
                if (i == flowerbed.Length - 1)
                {
                    capacity++;
                    break;
                }
                if (flowerbed[i + 1] == 0)
                {
                    capacity++;
                    ++i;
                    continue;
                }
            }

        }
        return capacity >= n;
    }
}
/**************************************************************************************************************
 * CanPlaceFlowers_1 CanPlaceFlowers_2 CanPlaceFlowers_3                                                      *
 **************************************************************************************************************/
