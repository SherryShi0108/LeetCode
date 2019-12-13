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
    ///+++++++++++++++++++++++++ Time Limited +++++++++++++++++++++++++
    /*
     * this idea is right , but it cost lots of time
     */
    public int MinMoves_1(int[] nums)
    {
        if (nums == null||nums.Length == 0 ) return 0;
        int count = 0;

        while (!IsAllEqu(nums))
        {
            int maxIndex = 0;
            int max = int.MinValue;
            int min = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    maxIndex = i;
                }

                if (nums[i] < min)
                {
                    min = nums[i];
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i == maxIndex ? nums[i] : nums[i] + (max - min);
            }

            int x = max - min;

            count += max - min;

        }

        return count;
    }

    private bool IsAllEqu(int[] nums)
    {
        if (nums == null || nums.Length == 0 ) return false;
        int temp = nums[0];
        foreach (int num in nums)
        {
            if (num != temp) return false;
        }

        return true;
    }

    // --------------- O(n) 148ms --------------- 34MB --------------- (35% 100%) ※
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


    /*
     * Math solution : Amazing Solution !
     * (n-1)element + 1 = one element - 1
     * so finally = sum - n * minValue
     */
    public int MinMoves_3(int[] nums)
    {
        // the same with 2
        return 0;
    }
}
/**************************************************************************************************************
 * MinMoves_2 MinMoves_3                                                                                      *
 **************************************************************************************************************/