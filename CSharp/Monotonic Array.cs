//Source  : https://leetcode.com/problems/monotonic-array/
//Author  : Xinruo Shi
//Date    : 2019-07-08
//Language: C#

/*******************************************************************************************************************************
 * 
 * An array is monotonic if it is either monotone increasing or monotone decreasing.
 * An array A is monotone increasing if for all i <= j, A[i] <= A[j].  An array A is monotone decreasing if for all i <= j, A[i] >= A[j].
 * Return true if and only if the given array A is monotonic.
 * 
 * Note:
 * 1 <= A.length <= 50000
 * -100000 <= A[i] <= 100000
 * 
 * Input: [1,2,2,3]
 * Output: true
 * 
 * Input: [6,5,4,4]
 * Output: true
 * 
 * Input: [1,3,2]
 * Output: false
 * 
 * Input: [1,2,4,5]
 * Output: true
 * 
 * Input: [1,1,1]
 * Output: true
 * 
 *******************************************************************************************************************************/

public class Solution896
{
    // --------------- O(n) 184ms --------------- 38MB --------------- (40% 11%)
    public bool IsMonotonic_1(int[] A)
    {
        int flag = 0;
        int flag1 = 0;
        int flag2 = 0;

        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] == A[i - 1])
            {
                flag++;
            }
            else if (A[i] > A[i - 1])
            {
                flag1++;
            }
            else if (A[i] < A[i - 1])
            {
                flag2++;
            }
        }

        if (flag + flag1 == A.Length - 1 || flag + flag2 == A.Length - 1)
        {
            return true;
        }
        return false;
    }

    // --------------- O(n) 172ms --------------- 37.9MB --------------- (70% 13%) 
    public bool IsMonotonic_2(int[] A)
    {
        return Increasing(A) || Decreasing(A);
    }
    public bool Increasing(int[] A)
    {
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] < A[i - 1])
            {
                return false;
            }
        }
        return true;
    }
    public bool Decreasing(int[] A)
    {
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > A[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    // --------------- O(n) 176ms --------------- 37.8MB --------------- (61% 29%) ※
    public bool IsMonotonic_3(int[] A)
    {
        bool increasing = true;
        bool decreasing = true;
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > A[i - 1])
            {
                decreasing = false;
            }
            if (A[i] < A[i - 1])
            {
                increasing = false;
            }
        }
        return decreasing || increasing;
    }

    // --------------- O(n) 196ms --------------- 37.7MB --------------- (11% 41%)
    public bool IsMonotonic_4(int[] A)
    {
        bool increasing = true;
        bool decreasing = true;
        for (int i = 1; i < A.Length; i++)
        {
            if (increasing)
            {
                increasing = increasing && (A[i] >= A[i - 1]);
            }
            if (decreasing)
            {
                decreasing = decreasing && (A[i] <= A[i - 1]);
            }
        }
        return increasing || decreasing;
    }
}
/**************************************************************************************************************
 * IsMonotonic_1 IsMonotonic_2 IsMonotonic_3 IsMonotonic_4                                                    *
 **************************************************************************************************************/
