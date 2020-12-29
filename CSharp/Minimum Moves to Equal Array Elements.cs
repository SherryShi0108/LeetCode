//Source  : https://leetcode.com/problems/minimum-moves-to-equal-array-elements/
//Author  : Xinruo Shi
//Date    : 2019-09-11
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty integer array of size n, find the minimum number of moves required to make all array elements equal,
 * where a move is incrementing n - 1 elements by 1.
 * 
 * Input: [1,2,3]
 * Output: 3
 * Explanation: Only three moves are needed (remember each move increments two elements):
 *              [1,2,3]  =>  [2,3,3]  =>  [3,4,3]  =>  [4,4,4] 
 * 
 *******************************************************************************************************************************/

using System.Runtime.Remoting.Channels;

public class Solution453
{    
    // --------------- O(n) 132ms --------------- 34MB --------------- (86% 100%) ※
    /*
     * use trick : (n-1)element + 1 = one element - 1
     */
    public int MinMoves_1(int[] nums)
    {
        int min = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            min = nums[i] < min ? nums[i] : min;
        }

        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            count += (nums[i] - min);
        }

        return count;
    }

    // --------------- O(n) 148ms --------------- 34MB --------------- (35% 100%) 
    /*
     * Math solution :
     * 1. sum + m*(n-1)*1 = x * n
     * 2. x = minValue + m
     * 3. sum - m = n * minValue 
     */
    public int MinMoves_2(int[] nums)
    {
        int sum = 0;
        int min = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            min = min < nums[i] ? min : nums[i];
        }

        return sum - nums.Length * min;
    }
}
/**************************************************************************************************************
 * MinMoves_1 MinMoves_2                                                                                      *
 **************************************************************************************************************/
