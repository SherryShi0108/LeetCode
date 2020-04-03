//Source  : https://leetcode.com/problems/binary-gap/
//Author  : Xinruo Shi
//Date    : 2019-09-18
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a positive integer N, find and return the longest distance between two consecutive 1's in the binary representation of N.
 * If there aren't two consecutive 1's, return 0.
 * 
 * Input: 22
 * Output: 2
 * Explanation: 
 *              22 in binary is 0b10110.
 *              In the binary representation of 22, there are three ones, and two consecutive pairs of 1's.
 *              The first consecutive pair of 1's have distance 2.
 *              The second consecutive pair of 1's have distance 1.
 *              The answer is the largest of these two distances, which is 2.
 *              
 * Input: 5
 * Output: 2
 * Explanation: 5 in binary is 0b101.
 * 
 * Input: 6
 * Output: 1
 * Explanation: 6 in binary is 0b110.
 * 
 * Input: 8
 * Output: 0
 * Explanation: 8 in binary is 0b1000. There aren't any consecutive pairs of 1's in the binary representation of 8, so we return 0.
 * 
 * Note: 1 <= N <= 10^9
 * 
 *******************************************************************************************************************************/

public class Solution868
{    
    // --------------- O(logn) 40ms --------------- 12.7MB --------------- (62% 100%) 
    /*
     * easy-understanding 
     * use count
     */
    public int BinaryGap_1(int n)
    {
        int maxCount = 0;
        int count = 0;
        bool flag = true;
        while (n>0)
        {
            if (n % 2 == 1)
            {
                if (flag)
                {
                    flag = false;
                    count = 1;
                }
                else
                {
                    maxCount = maxCount > count ? maxCount : count;
                    count = 1;
                }
            }
            else
            {
                count++;
            }

            n /= 2;
        }

        return maxCount;
    }
    
     // --------------- O(logn) 36ms --------------- 15MB --------------- (93% 100%) ※
    /*
     * should remember : use bit operator , and last
     */
    public int BinaryGap_2(int N)
    {
        int last = -1;
        int max = 0;
        for (int i = 0; i < 32; i++)
        {
            if (((N >> i) & 1) != 0)
            {
                if (last >= 0)
                {
                    max = max > i - last ? max : i - last;
                }
                last = i;
            }
        }

        return max;
    }

    // --------------- O(logn) 40ms --------------- 12.7MB --------------- (80% 100%)
    /*
     * int 32bits , use int[32] 
     */
    public int BinaryGap_3(int N)
    {
        int[] array = new int[32];
        int t = 0;
        for (int i = 0; i < 32 ; i++)
        {
            if (((N >> i) & 1) == 1)
            {
                array[t++] = i;
            }
        }

        int max = 0;
        for (int i = 1; i < t; i++)
        {
            max = max > array[i] - array[i - 1] ? max : array[i] - array[i - 1];
        }
        return max;
    }
    
    // --------------- O(logn) 40ms --------------- 13.7MB --------------- (80% 100%) ※
    public int BinaryGap_4(int N)
    {
        int max = 0;
        int i = -32;

        while (N>0)
        {
            if (N % 2 == 1)
            {
                max = max > i ? max : i;
                i = 0;
            }

            N /= 2;
            i++;
        }

        return max;
    }
}
/**************************************************************************************************************
 * BinaryGap_2                                                                                                *
 **************************************************************************************************************/
