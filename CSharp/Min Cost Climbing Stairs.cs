//Source  : https://leetcode.com/problems/min-cost-climbing-stairs/
//Author  : Xinruo Shi
//Date    : 2019-06-29
//Language: C#

/*******************************************************************************************************************************
 * 
 * On a staircase, the i-th step has some non-negative cost cost[i] assigned (0 indexed).
 * Once you pay the cost, you can either climb one or two steps. You need to find minimum cost to reach the top of the floor, 
 * and you can either start from the step with index 0, or the step with index 1.
 * 
 * Note:
 * cost will have a length in the range [2, 1000].
 * Every cost[i] will be an integer in the range [0, 999].
 * 
 * Input: cost = [10, 15, 20]
 * Output: 15
 * Explanation: Cheapest is start on cost[1], pay that cost and go to the top.
 * 
 * Input: cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
 * Output: 6
 * Explanation: Cheapest is start on cost[0], and only step on 1s, skipping cost[3].
 * 
 *******************************************************************************************************************************/

//动态规划
public class Solution746
{
    // --------------- O(n) 96ms --------------- 23.6MB --------------- (80% 41%) 
    public int MinCostClimbingStairs_1(int[] cost)
    {
        int[] C = new int[cost.Length+1];
        C[0] = 0;
        C[1] = 0;

        for (int i = 2; i < cost.Length+1; i++)
        {
            C[i] = (C[i - 2] + cost[i - 2]) < (C[i - 1] + cost[i - 1]) ? (C[i - 2] + cost[i - 2]) : (C[i - 1] + cost[i - 1]);
        }

        return C[C.Length-1];
    }
    
    // --------------- O(n) 96ms --------------- 24.3MB --------------- (83% 13%)  ※
    public int MinCostClimbingStairs_2(int[] cost)
    {
        for (int i = 2; i < cost.Length; i++)
        {
            cost[i] += (cost[i - 2] < cost[i - 1] ? cost[i - 2] : cost[i - 1]);
        }

        return cost[cost.Length - 1] < cost[cost.Length - 2] ? cost[cost.Length - 1] : cost[cost.Length - 2];
    }
}
/**************************************************************************************************************
 * MinCostClimbingStairs_1                                                                                            *
 **************************************************************************************************************/
