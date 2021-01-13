//Source  : https://leetcode.com/problems/binary-watch/
//Author  : Xinruo Shi
//Date    : 2020-11-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * A binary watch has 4 LEDs on the top which represent the hours (0-11), and the 6 LEDs on the bottom represent the minutes (0-59).
 * Each LED represents a zero or one, with the least significant bit on the right.
 *
 * For example, the above binary watch reads "3:25". (0011 011001)
 * Given a non-negative integer n which represents the number of LEDs that are currently on, return all possible times the watch could represent.
 *
 * Input: n = 1
 * Return: ["1:00", "2:00", "4:00", "8:00", "0:01", "0:02", "0:04", "0:08", "0:16", "0:32"]
 *
 * Note:
 *      The order of output does not matter.
 *      The hour must not contain a leading zero, for example "01:00" is not valid, it should be "1:00".
 *      The minute must be consist of two digits and may contain a leading zero, for example "10:2" is not valid, it should be "10:02".
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution401
{
    // --------------- O(1) 244ms --------------- 32MB --------------- (20% 82%) 
    public IList<string> ReadBinaryWatch_1(int num)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                int count1 = 0;
                int temp = (i << 6) + j;
                for (int k = 0; k < 10; k++)
                {
                    count1 += temp >> k & 1;
                }

                if (count1 == num)
                {
                    result.Add($"{i}:{j:D2}");
                }
            }
        }

        return result;
    }

    // --------------- O(1) 217ms --------------- 32MB --------------- (100% 82%) ※
    /*
     *  Improve 1 : / is faster than >>
     */
    public IList<string> ReadBinaryWatch_1_2(int num)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                int count1 = 0;
                int temp = (i << 6) + j;
                for (int k = 0; k < 10; k++)
                {
                    count1 += temp % 2;
                    temp /= 2;
                }

                if (count1 == num)
                {
                    result.Add($"{i}:{j:D2}");
                }
            }
        }

        return result;
    }

    // --------------- O(1) 240ms --------------- 31MB --------------- (32% 100%)
    public IList<string> ReadBinaryWatch_2(int num)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                if (GetOneCount(i) + GetOneCount(j) == num)
                {
                    result.Add($"{i}:{j:00}");
                }
            }
        }

        return result;
    }

    private int GetOneCount(int num)
    {
        int count = 0;
        while (num>0)
        {
            count += num & 1;
            num /= 2;
        }

        return count;
    }

    // --------------- O(1) 224ms --------------- 32MB --------------- (98% 40%)
    public IList<string> ReadBinaryWatch_3(int num)
    {
        List<string> result = new List<string>();
        foreach (var item1 in D1)
        {
            foreach (var item2 in D2)
            {
                if (item1.Key + item2.Key == num)
                {
                    foreach (string s1 in item1.Value)
                    {
                        foreach (string s2 in item2.Value)
                        {
                            result.Add($"{s1}:{s2}");
                        }
                    }
                }
            }
        }

        return result;
    }

    private Dictionary<int, List<string>> D1 = new Dictionary<int, List<string>>()
    {
        {0, new List<string>() {"0"}},
        {1, new List<string>() {"1", "2", "4", "8"}},
        {2, new List<string>() {"3", "5", "6", "9", "10"}},
        {3, new List<string>() {"7", "11"}}
    };

    private Dictionary<int, List<string>> D2 = new Dictionary<int, List<string>>()
    {
        {0, new List<string>() {"00"}},
        {1, new List<string>() {"01", "02", "04", "08", "16", "32"}},
        {2, new List<string>() {"03", "05", "06", "09", "10", "12", "17", "18", "20", "24", "33", "34", "36", "40", "48"}},
        {3, new List<string>() {"07", "11", "13", "14", "19", "21", "22", "25", "26", "28", "35", "37", "38", "41", "42", "44", "49", "50", "52", "56"}},
        {4, new List<string>() {"15", "23", "27", "29", "30", "39", "43", "45", "46", "51", "53", "54", "57", "58"}},
        {5, new List<string>() {"31", "47", "55", "59"}}
    };
}
/**************************************************************************************************************
 * ReadBinaryWatch_1    ReadBinaryWatch_2    ReadBinaryWatch_3                                                *
 **************************************************************************************************************/