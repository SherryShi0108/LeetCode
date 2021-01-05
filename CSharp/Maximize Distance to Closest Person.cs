//Source  : https://leetcode.com/problems/maximize-distance-to-closest-person/
//Author  : Xinruo Shi
//Date    : 2019-07-05
//Language: C#

/*******************************************************************************************************************************
 * 
 * In a row of seats, 1 represents a person sitting in that seat, and 0 represents that the seat is empty. 
 * There is at least one empty seat, and at least one person sitting.
 * Alex wants to sit in the seat such that the distance between him and the closest person to him is maximized. 
 * Return that maximum distance to closest person.
 * 
 * Note:
 * 1 <= seats.length <= 20000
 * seats contains only 0s or 1s, at least one 0, and at least one 1.
 * 
 * Input: [1,0,0,0,1,0,1]
 * Output: 2
 * Explanation: If Alex sits in the second open seat (seats[2]), then the closest person has distance 2.
 *              If Alex sits in any other open seat, the closest person has distance 1.
 *              Thus, the maximum distance to the closest person is 2.
 * 
 * Input: [1,0,0,0]
 * Output: 3
 * Explanation: If Alex sits in the last seat, the closest person is 3 seats away.This is the maximum distance possible, so the answer is 3.
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution849
{
    // --------------- O(n) 104ms --------------- O(1) 28MB --------------- (73% 87%) ※
    /*
     * before + nomal ; after
     */
    public int MaxDistToClosest_1(int[] seats)
    {
        int last1 = -1;
        int result = 0;

        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i] == 1)
            {
                if (last1 == -1)
                {
                    result = result > i ? result : i;
                }
                else
                {
                    result = result > (i - last1) / 2 ? result : (i - last1) / 2;
                }

                last1 = i;
            }
        }

        result = result > seats.Length - 1 - last1 ? result : seats.Length - 1 - last1;
        return result;
    }   

    // --------------- O(n) 104ms --------------- O(1) 29MB --------------- (73% 87%) 
    /*
     * similar to 1
     */
    public int MaxDistToClosest_1_2(int[] seats)
    {
        int last1 = -1;
        int result = 0;

        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i] == 0) continue;

            if (last1 == -1)
            {
                result = result > i ? result : i;
            }
            else
            {
                result = result > (i - last1) / 2 ? result : (i - last1) / 2;
            }

            last1 = i;
        }

        if (seats[seats.Length - 1] == 0)
        {
            result = result > seats.Length - 1 - last1 ? result : seats.Length - 1 - last1;
        }
        return result;
    }  
}
/**************************************************************************************************************
 * MaxDistToClosest_1 / MaxDistToClosest_2                                                                    *
 **************************************************************************************************************/
