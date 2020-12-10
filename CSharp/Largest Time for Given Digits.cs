//Source  : https://leetcode.com/problems/largest-time-for-given-digits/
//Author  : Xinruo Shi
//Date    : 2019-09-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array of 4 digits, return the largest 24 hour time that can be made.
 * The smallest 24 hour time is 00:00, and the largest is 23:59.  Starting from 00:00, a time is larger if more time has elapsed since midnight.
 * Return the answer as a string of length 5.  If no valid time can be made, return an empty string.
 * 
 * Input: [1,2,3,4]
 * Output: "23:41"
 * 
 * Input: [5,5,5,5]
 * Output: ""
 * 
 * Note: A.length == 4
 *       0 <= A[i] <= 9
 * ※
 *******************************************************************************************************************************/

using System.Linq;

public class Solution949
{
    // --------------- 140ms --------------- 25.3MB --------------- (8% 100%)
    public string LargestTimeFromDigits_1(int[] A)
    {
        string result = "";
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (i == j || j == k || i == k)
                    {
                        continue;
                    }

                    string h = "" + A[i] + A[j];
                    string m = "" + A[k] + A[6 - i - j - k];
                    string t = h + ":" + m;

                    if (h.CompareTo("24") < 0 && m.CompareTo("60") < 0 && result.CompareTo(t) < 0)
                    {
                        result = t;
                    }
                }
            }
        }

        return result;
    }
    
    // --------------- 108ms --------------- 23.9MB --------------- (60% 100%) ※
    public string LargestTimeFromDigits_2(int[] A)
    {
        int max = -1;
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < A.Length; j++)
            {
                for (int k = 0; k < A.Length; k++)
                {
                    if (i != k && j != k && i != j)
                    {
                        int l = 6 - i - j - k;

                        int hour = 10 * A[i] + A[j];
                        int minute = 10 * A[k] + A[l];
                        if (hour < 24 && minute < 60)
                        {
                            int temp = hour * 60 + minute;
                            max = max > temp ? max : temp;
                        }
                    }
                }
            }
        }
        
        return max == -1 ? string.Empty : $"{max / 60:2D}:{max % 60:2D}";
    }
}
/**************************************************************************************************************
 * LargestTimeFromDigits_2                                                                                    *
 **************************************************************************************************************/
