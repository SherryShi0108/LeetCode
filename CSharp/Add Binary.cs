//Source  : https://leetcode.com/problems/add-binary/
//Author  : Xinruo Shi
//Date    : 2019-09-02
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two binary strings, return their sum (also a binary string).
 * The input strings are both non-empty and contains only characters 1 or 0.
 * 
 * Input: a = "11", b = "1"
 * Output: "100"
 * 
 * Input: a = "1010", b = "1011"
 * Output: "10101"
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

public class Solution67
{
    // --------------- O(n) 88ms --------------- 24.4MB --------------- (90% 8%) ※
    public string AddBinary_1(string a, string b)
    {
        string result = "";
        int k = 0;
        int i = a.Length - 1;
        int j = b.Length - 1;

        while (i >= 0 || j >= 0 || k == 1)
        {
            k = k + (i >= 0 ? a[i--] - '0' : 0);
            k = k + (j >= 0 ? b[j--] - '0' : 0);

            result = (k % 2).ToString() + result;
            k /= 2;
        }

        return result;
    }

    // --------------- O(n) 88ms --------------- 25.2MB --------------- (90% 8%) 
    /*
     * similar to 1
     */
    public string AddBinary_1_2(string a, string b)
    {
        string result = "";
        int k = 0;
        int i = a.Length - 1;
        int j = b.Length - 1;

        while (i>=0||j>=0||k==1)
        {
            int sum = k;
            if (i >= 0)
            {
                sum += (a[i--] - '0');
            }

            if (j >= 0)
            {
                sum += (b[j--] - '0');
            }

            result = sum % 2 + result;
            k = sum/2;
        }

        return result;
    }
}
/**************************************************************************************************************
 * AddBinary_1                                                                                                *
 **************************************************************************************************************/
