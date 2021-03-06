﻿//Source  : https://leetcode.com/problems/first-bad-version/
//Author  : Xinruo Shi
//Date    : 2019-12-05
//Language: C#

/*******************************************************************************************************************************
 * 
 * You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your
 * product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.
 *
 * Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
 *
 * You are given an API bool isBadVersion(version) which will return whether version is bad. Implement a function to
 * find the first bad version. You should minimize the number of calls to the API.
 *
 * Given n = 5, and version = 4 is the first bad version.
 * call isBadVersion(3) -> false
 * call isBadVersion(5) -> true
 * call isBadVersion(4) -> true
 * Then 4 is the first bad version. 
 * 
 *******************************************************************************************************************************/

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class VersionControl
{
    public bool IsBadVersion(int version)
    {
        return false;
    }
}

public class Solution278 : VersionControl
{
    // --------------- O(logn) 36ms --------------- 14MB --------------- (93% 9%) 
    public int FirstBadVersion_1(int n)
    {
        int i = 1;
        int j = n;
        while (i<=j)
        {
            // int mid = i + (j - i) / 2;  
            int mid = i + ((j - i) >> 1);
            if (IsBadVersion(mid))
            {
                j = mid - 1;
            }
            else
            {
                i = mid + 1;
            }
        }

        return i;
    }

    // --------------- O(logn) 40ms --------------- 14MB --------------- (68% 9%) ※
    public int FirstBadVersion_1_2(int n)
    {
        int i = 1;
        int j = n;
        while (i < j)
        {
            // int mid = i + (j - i) / 2;
            int mid = i + ((j - i) >> 1);
            if (IsBadVersion(mid))
            {
                j = mid ;
            }
            else
            {
                i = mid + 1;
            }
        }

        return i;
    }
}
/**************************************************************************************************************
 * FirstBadVersion_1                                                                                          *
 **************************************************************************************************************/
