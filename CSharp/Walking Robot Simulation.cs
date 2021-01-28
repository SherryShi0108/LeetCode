//Source  : https://leetcode.com/problems/walking-robot-simulation/
//Author  : Xinruo Shi
//Date    : 2020-11-09
//Language: C#

/*******************************************************************************************************************************
 * 
 * A robot on an infinite grid starts at point (0, 0) and faces north.  The robot can receive one of three possible types of commands:
 *      -2: turn left 90 degrees
 *      -1: turn right 90 degrees
 *      1 <= x <= 9: move forward x units
 *
 * Some of the grid squares are obstacles. 
 * The i-th obstacle is at grid point (obstacles[i][0], obstacles[i][1])
 * If the robot would try to move onto them, the robot stays on the previous grid square instead (but still continues following the rest of the route.)
 * Return the square of the maximum Euclidean distance that the robot will be from the origin.
 *
 * Note:
 *      North means +Y direction.
 *      East means +X direction.
 *      South means -Y direction.
 *      West means -X direction.
 *
 * Input: commands = [4,-1,3], obstacles = []
 * Output: 25
 * Explanation: The robot starts at (0, 0):
 *      1. Move north 4 units to (0, 4).
 *      2. Turn right.
 *      3. Move east 3 units to (3, 4).
 *      The furthest point away from the origin is (3, 4), which is 3^2 + 4^2 = 25 units away.
 *
 * Input: commands = [4,-1,4,-2,4], obstacles = [[2,4]]
 * Output: 65
 * Explanation: robot will be stuck at (1, 4) before turning left and going to (1, 8)
 *
 * Note:
 *      1 <= commands.length <= 10^4
 *      commands[i] is one of the values in the list [-2,-1,1,2,3,4,5,6,7,8,9].
 *      0 <= obstacles.length <= 104
 *      -3 * 10^4 <= xi, yi <= 3 * 10^4
 *      The answer is guaranteed to be less than 2^31.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class Solution874
{
    // --------------- O(n+K) 264ms --------------- 41MB --------------- (50% 57%) ※
    public int RobotSim_1(int[] commands, int[][] obstacles)
    {
        Dictionary<int, int[]> d = new Dictionary<int, int[]>()
        {
            {0, new int[2] {0, 1}},  // North
            {1, new int[2] {1, 0}},  // East
            {2, new int[2] {0, -1}}, // South
            {3, new int[2] {-1, 0}}  // West
        };

        HashSet<string> H = new HashSet<string>();
        foreach (int[] obstacle in obstacles)
        {
            H.Add($"{obstacle[0]} {obstacle[1]}");
        }

        int result = 0;     // max Length
        int direction = 0;  // start face to North
        int x = 0;
        int y = 0;   // start point
        for (int i = 0; i < commands.Length; i++)
        {
            if (commands[i] == -2)  // Turn Left
            {
                direction = (direction + 3) % 4;
            }
            else if (commands[i] == -1) // Turn Right
            {
                direction = (direction + 1) % 4;
            }
            else  // Move
            {
                int step = 0;
                while (step < commands[i])
                {
                    int dx = d[direction][0];
                    int dy = d[direction][1];

                    string temp = $"{x + dx} {y + dy}";
                    if (H.Contains(temp))
                    {
                        break;
                    }

                    x += dx;
                    y += dy;

                    step++;
                }
            }

            result = result > x * x + y * y ? result : x * x + y * y;
        }

        return result;
    }
}
/**************************************************************************************************************
 * RobotSim_1                                                                                                 *
 **************************************************************************************************************/