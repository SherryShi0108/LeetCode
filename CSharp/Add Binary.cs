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
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     * stack overflow , it's all "add"
     */
    public string AddBinary_1(string a, string b)
    {
        int x = ChangeStringToInt(a);
        int y = ChangeStringToInt(b);
        int sum = x + y;
        if (sum == 0)
        {
            return "0";

        }

        List<int> L = new List<int>();
        while (sum > 0)
        {
            L.Add(sum % 2);
            sum /= 2;
        }

        string result = string.Empty;

        foreach (int t in L)
        {
            result = t + result;
        }

        return result;
    }

    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++

    public int ChangeStringToInt(string s)
    {
        int result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            result = result * 2 + int.Parse(s[i].ToString());
        }

        return result;
    }

    // --------------- O(n) 96ms --------------- 25.3MB --------------- (45% 8%)
    /*
     * "0" "0" should be "0" not "00"
     */
    public string AddBinary_2(string a, string b)
    {
        List<int> L1 = new List<int>();
        for (int i = a.Length - 1; i >= 0; i--)
        {
            L1.Add(int.Parse(a[i].ToString()));
        }

        List<int> L2 = new List<int>();
        for (int i = b.Length - 1; i >= 0; i--)
        {
            L2.Add(int.Parse(b[i].ToString()));
        }

        List<int> L3 = new List<int>();

        int k = 0;
        for (int i = 0; i < L1.Count || i < L2.Count || k == 1; i++)
        {
            int x = i < L1.Count ? L1[i] : 0;
            int y = i < L2.Count ? L2[i] : 0;

            int t = x + y + k;
            L3.Add(t % 2);
            k = t / 2;
        }

        string result = "";
        foreach (int t in L3)
        {
            result = t + result;
        }

        return result;
    }

    // --------------- O(n) 88ms --------------- 24.4MB --------------- (90% 8%) ※
    public string AddBinary_3(string a, string b)
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
     * similar to 3
     */
    public string AddBinary_4(string a, string b)
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
 * AddBinary_3 / AddBinary_4                                                                                  *
 **************************************************************************************************************/