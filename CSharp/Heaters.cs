//Source  : https://leetcode.com/problems/heaters/
//Author  : Xinruo Shi
//Date    : 2019-12-06
//Language: C#

/*******************************************************************************************************************************
 * 
 * Winter is coming! Your first job during the contest is to design a standard heater with fixed warm radius to warm all the houses.
 *
 * Now, you are given positions of houses and heaters on a horizontal line, find out minimum radius of heaters
 * so that all houses could be covered by those heaters.
 *
 * So, your input will be the positions of houses and heaters seperately, and your expected output will be the minimum radius standard of heaters.
 *
 * Note:
 *      Numbers of houses and heaters you are given are non-negative and will not exceed 25000.
 *      Positions of houses and heaters you are given are non-negative and will not exceed 10^9.
 *      As long as a house is in the heaters' warm radius range, it can be warmed.
 *      All the heaters follow your radius standard and the warm radius will the same.
 *
 * Input: [1,2,3],[2]
 * Output: 1
 * Explanation: The only heater was placed in the position 2, and if we use the radius 1 standard, then all the houses can be warmed.
 *
 * Input: [1,2,3,4],[1,4]
 * Output: 1
 * Explanation: The two heater was placed in the position 1 and 4. We need to use radius 1 standard, then all the houses can be warmed.
 * ※
 *******************************************************************************************************************************/

using System;
using System.Linq;

public class Solution475
{
    // --------------- O(nlogn+n) 156ms --------------- 35MB --------------- (56% 100%) 
    /*
     * easy-understanding solution
     * O(time) = O(nlogn)
     */
    public int FindRadius_1(int[] houses, int[] heaters)
    {
        Array.Sort(houses);
        Array.Sort(heaters);

        int[] arrays=new int[houses.Length];

        // right
        for (int i = 0,j=0; i < houses.Length && j<heaters.Length;)
        {
            if (houses[i] <= heaters[j])
            {
                arrays[i] = heaters[j] - houses[i] + 1;
                i++;
            }
            else
            {
                j++;
            }
        }

        //left
        for (int i = houses.Length - 1 ,j=heaters.Length-1; i >= 0 && j>=0;)
        {
            if (houses[i] >= heaters[j])
            {
                if (arrays[i] == 0)
                {
                    arrays[i] = houses[i] - heaters[j] +1 ;
                }
                else
                {
                    arrays[i] = arrays[i] < houses[i] - heaters[j]+1 ? arrays[i] : houses[i] - heaters[j] +1 ;
                }

                i--;
            }
            else
            {
                j--;
            }
        }

        return arrays.Max()-1;
    }

    // --------------- O(nlogn+nlogn) 152ms --------------- 35MB --------------- (70% 100%) 
    /*
     * use binary-search
     * [1,4,5,7] if(2) => -(1+1)=-2 ; if(0) => -(0+1)=-1 ; if(4) => 1 ; if(10) => -(4+1)=-5
     */
    public int FindRadius_2(int[] houses, int[] heaters)
    {
        Array.Sort(heaters);
        int result = int.MinValue;

        foreach (int house in houses)
        {
            int index = Array.BinarySearch(heaters, house);
            if (index < 0)
            {
                index = -(index + 1);
            }

            int dist1 = index > 0 ? house - heaters[index - 1] : int.MaxValue;
            int dist2 = index < heaters.Length ? heaters[index] - house : int.MaxValue;

            int x = dist1 < dist2 ? dist1 : dist2;
            result = result > x ? result : x;
        }

        return result ;
    }

    // --------------- O(nlogn) 152ms --------------- 35MB --------------- (70% 100%) 
    /*
     * improve 2
     * use binary-search , use ~
     */
    public int FindRadius_2_2(int[] houses, int[] heaters)
    {
        Array.Sort(heaters);
        int result = 0;

        foreach (int house in houses)
        {
            int index = Array.BinarySearch(heaters, house);
            if (index < 0)
            {
                index = ~index;// index= - (index + 1)
                int dist1 = index > 0 ? house - heaters[index - 1] : int.MaxValue;
                int dist2 = index < heaters.Length ? heaters[index] - house : int.MaxValue;

                int x = dist1 < dist2 ? dist1 : dist2;
                result = result > x ? result : x;
            }
        }
        return  result;
    }

    // --------------- O(logn+n) 144ms --------------- 35MB --------------- (95% 100%) 
    /*
     * difficult to understand , remember it;
     * find the nearest heater for each house
     */
    public int FindRadius_3(int[] houses, int[] heaters)
    {
        Array.Sort(houses);
        Array.Sort(heaters);

        int i = 0;
        int result = 0;

        foreach (int house in houses)
        {
            while (i+1<heaters.Length && heaters[i]+heaters[i+1]<=house*2)
            {
                i++;
            }

            int x = heaters[i] - house > 0 ? heaters[i] - house : -(heaters[i] - house);
            result = result > x ? result : x;
        }

        return result;
    }
    
    // Difficult to understand
    public int FindRadius_3_2(int[] houses, int[] heaters)
    {
        Array.Sort(houses);
        Array.Sort(heaters);

        int Length = 0;
        int temp = 0;

        for (int i = 0; i < houses.Length; i++)
        {
            int current = houses[i];

            while (temp < heaters.Length - 1 &&
                   Math.Abs(heaters[temp + 1] - current) <= Math.Abs(heaters[temp] - current))
            {
                temp++;
            }

            Length = Length > Math.Abs(heaters[temp] - current) ? Length : Math.Abs(heaters[temp] - current);
        }

        return Length;
    }
}
/**************************************************************************************************************
 * FindRadius_1 FindRadius_2 FindRadius_3                                                                     *
 **************************************************************************************************************/
