//Source  : https://leetcode.com/problems/hamming-distance/
//Author  : Xinruo Shi
//Date    : 2020-11-14
//Language: C#

/*******************************************************************************************************************************
 * 
 * The Hamming distance between two integers is the number of positions at which the corresponding bits are different.
 * Given two integers x and y, calculate the Hamming distance.
 *
 * Note: 0 ≤ x, y < 2^31.
 *
 * Input: x = 1, y = 4
 * Output: 2
 * Explanation:
 *      1   (0 0 0 1)
 *      4   (0 1 0 0)
 *             ↑   ↑
 * The above arrows point to positions where the corresponding bits are different.
 * 
 *******************************************************************************************************************************/

public class Solution461
{
    // --------------- O(n) 32ms --------------- 15MB --------------- (98% 43%)
    /*
     * Compare EveryNum
     */
    public int HammingDistance_1(int x, int y)
    {
        int count = 0;
        while (x > 0 || y > 0)
        {
            if (((x & 1) ^ (y & 1)) > 0)
            {
                count++;
            }

            x = x == 0 ? 0 : x >> 1;
            y = y == 0 ? 0 : y >> 1;
        }

        return count;
    }

    // --------------- O(n) 40ms --------------- 15MB --------------- (64% 21%) ※
    /*
     * ALl^ ,get all different
     * then use & to reduce on 1 step
     */
    public int HammingDistance_2(int x, int y)
    {
        int count = 0;
        int n = x ^ y;

        while (n > 0)
        {
            count++;
            n = n & (n - 1);
        }

        return count;
    }

    // --------------- O(n) 44ms --------------- 15MB --------------- (15% 76%)
    /*
     * ALl^ ,get all different
     * then use int32 to determine
     */
    public int HammingDistance_2_2(int x, int y)
    {
        int count = 0;
        int n = x ^ y;

        for (int i = 0; i < 32; i++)
        {
            count += (n >> i) & 1;
        }

        return count;
    }
}

/**************************************************************************************************************
 * HammingDistance_2                                                                                          *
 **************************************************************************************************************/