//Source  : https://leetcode.com/problems/student-attendance-record-i/
//Author  : Xinruo Shi
//Date    : 2019-10-20
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are given a string representing an attendance record for a student. The record only contains the following three characters:
 *      1. 'A' : Absent.
 *      2. 'L' : Late.
 *      3. 'P' : Present.
 * A student could be rewarded if his attendance record doesn't contain more than one 'A' (absent) or more than two continuous 'L' (late).
 * You need to return whether the student could be rewarded according to his attendance record.
 *
 * Input: "PPALLP"
 * Output: True
 *
 * Input: "PPALLL"
 * Output: False
 * 
 *******************************************************************************************************************************/

public class Solution551
{
    // --------------- O(n) 76ms --------------- 22MB --------------- (54% 100%)
    public bool CheckRecord_1(string S)
    {
        int countA = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == 'A')
            {
                countA++;
                if (countA > 1) return false;
            }
            else if (S[i] == 'L')
            {
                if (i > 1 && S[i - 1] == 'L' && S[i - 2] == 'L') return false;
            }
        }

        return true;
    }

    // --------------- O(n) 72ms --------------- 21.5MB --------------- (86% 100%) ※
    public bool CheckRecord_2(string s)
    {
        int absent = 0;
        int late = 0;
        foreach (char c in s)
        {
            if (c == 'A')
            {
                absent++;
            }

            if (c=='L')
            {
                late++;
            }
            else
            {
                late = 0;
            }

            if (absent > 1 || late > 2) return false;
        }

        return true;
    }

    // --------------- O(n) 84ms --------------- 22.3MB --------------- (24% 100%)
    public bool CheckRecord_3(string s)
    {
        return !(s.IndexOf("A") != s.LastIndexOf("A") || s.Contains("LLL"));
    }
}
/**************************************************************************************************************
 * CheckRecord_1 CheckRecord_2                                                                                *
 **************************************************************************************************************/
