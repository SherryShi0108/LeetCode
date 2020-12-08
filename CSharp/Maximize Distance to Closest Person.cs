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
    // --------------- O(n) 104ms --------------- O(n) 27.2MB --------------- (83% 100%) ※
    public int MaxDistToClosest_1(int[] seats)
    {
        int max = 0;
        int count = 0;
        bool flag = true;
        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i] == 0)
            {
                count++;
            }
            else
            {
                if (flag)
                {
                    max = max > count ? max : count;
                    flag = false;
                    count = 0;
                }
                else
                {
                    max = max > (count + 1) / 2 ? max : (count + 1) / 2;
                    count = 0;
                }
            }
        }

        max = max > count ? max : count;
        return max;
    }

    // --------------- O(n) 108ms --------------- O(n) 25.9MB --------------- (73% 44%)   
    /*
     * easy-understanding
     */
    public int MaxDistToClosest_1_2(int[] seats)
    {
        int count = 0;
        int max = 0;

        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i] == 0)
            {
                count++;
                max = max > (count + 1) / 2 ? max : (count + 1) / 2;
            }
            else
            {
                count = 0;
            }
        }
        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i] == 1)
            {
                max = max > i ? max : i;
                break;
            }
        }
        for (int i = seats.Length - 1; i >= 0; i--)
        {
            if (seats[i] == 1)
            {
                max = max > seats.Length - 1 - i ? max : seats.Length - 1 - i;
                break;
            }
        }
        return max;
    }

    // --------------- O(n) 128ms --------------- O(n) 25.9MB --------------- (11% 47%) 
    public int MaxDistToClosest_1_3(int[] seats)
    {
        int max = 0;
        int countMedium = 0;

        while (seats[max] == 0)
        {
            max++;
        }

        for (int i = max + 1; i < seats.Length; i++)
        {
            if (seats[i] == 0)
            {
                countMedium++;
            }
            else
            {
                max = max > (countMedium + 1) / 2 ? max : (countMedium + 1) / 2;
                countMedium = 0;
            }
        }
        max = max > countMedium ? max : countMedium;
        return max;
    }

    // --------------- O(n) 128ms --------------- O(n) 25.8MB --------------- (11% 58%) 
    public int MaxDistToClosest_2(int[] seats)
    {
        int left = -1;
        int max = 0;

        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i] == 0) continue;
            if (left == -1)
            {
                max = max > i ? max : i;
            }
            else
            {
                max = max > (i - left) / 2 ? max : (i - left) / 2;
            }
            left = i;
        }

        max = max > (seats.Length - 1 - left) ? max : (seats.Length - 1 - left);
        return max;
    }   
}
/**************************************************************************************************************
 * MaxDistToClosest_1 / MaxDistToClosest_2                                                                    *
 **************************************************************************************************************/
