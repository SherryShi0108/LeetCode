//Source  : https://leetcode.com/problems/valid-mountain-array/
//Author  : Xinruo Shi
//Date    : 2019-07-16
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array A of integers, return true if and only if it is a valid mountain array.
 * Recall that A is a mountain array if and only if:
 *      A.length >= 3
 *      There exists some i with 0 < i < A.length - 1 such that: A[0] < A[1] < ... A[i-1] < A[i]
 *                                                               A[i] > A[i+1] > ... > A[A.length - 1]
 * Note:
 * 0 <= A.length <= 10000
 * 0 <= A[i] <= 10000 
 * 
 * Input: [2,1]
 * Output: false
 * 
 * Input: [3,5,5]
 * Output: false
 * 
 * Input: [0,3,2,1]
 * Output: true
 *  
 *******************************************************************************************************************************/

public class Solution941
{
    // --------------- O(n) 144ms --------------- 31MB --------------- (12% 5%) 
    public bool ValidMountainArray_1(int[] A)
    {
        if (A.Length < 3) { return false; }

        int temp = 0;
        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i] < A[i + 1])
            {
                temp++;
            }
            else
            {
                break;
            }
        }
        if (temp == 0 || temp == A.Length - 1)
        {
            return false;
        }
        for (int i = temp; i < A.Length - 1; i++)
        {
            if (A[i] > A[i + 1])
            {
                temp++;
            }
        }

        return temp == A.Length - 1;
    }

    // --------------- O(n) 140ms --------------- 31MB --------------- (22% 5%) 
    /*
     * similar to "1"
     */
    public bool ValidMountainArray_2(int[] A)
    {
        int temp = 0;
        while (temp < A.Length - 1 && A[temp] < A[temp + 1])
        {
            temp++;
        }
        if (temp == 0 || temp == A.Length - 1) return false;

        for (int i = temp; i < A.Length - 1; i++)
        {
            if (A[i] <= A[i + 1]) return false;
        }

        return true;
    }

    // --------------- O(n) 132ms --------------- 30.9MB --------------- (37% 30%) ※
    /*
     *  easy - understanding
     */
    public bool ValidMountainArray_3(int[] A)
    {
        int i = 0;
        int j = A.Length - 1;

        while (i < A.Length - 1 && A[i] < A[i + 1])
        {
            i++;
        }
        while (j > 0 && A[j - 1] > A[j])
        {
            j--;
        }

        return i > 0 && i == j && j < A.Length - 1;
    }

    // --------------- O(n) 144ms --------------- 31MB --------------- (12% 5%) 
    /*
     *  easy - understanding
     */
    public bool ValidMountainArray_4(int[] A)
    {
        if (A == null || A.Length < 3) return false;

        bool increaseFound = false;
        bool decreaseFound = false;
        bool flag = true;

        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i] == A[i + 1])
            {
                return false;
            }

            if (flag)
            {
                if (A[i] < A[i + 1])
                {
                    increaseFound = true;
                }
                else
                {
                    flag = false;
                    decreaseFound = true;
                }
            }
            else
            {
                if (A[i] < A[i + 1])
                {
                    return false;
                }
            }
        }
        return increaseFound && decreaseFound;
    }    
    
    // --------------- O(n) 192ms --------------- 31MB --------------- (5% 13%) 
    public bool ValidMountainArray_5(int[] A)
    {
        int flag1 = 0;
        int flag2 = 0;

        int i = 1;
        int j = A.Length - 1;
        for (i = 1; i < A.Length; i++)
        {
            if (A[i] > A[i - 1])
            {
                flag1 = 1;
            }
            else
            {
                break;
            }
        }

        for (j = A.Length - 1; j > 0; j--)
        {
            if (A[j] < A[j - 1])
            {
                flag2 = 1;
            }
            else
            {
                break;
            }
        }

        bool a = (flag1 == 1 && flag2 == 1 && j + 1 == i);
        return a;
    }
    
     // --------------- O(n) 188ms --------------- 31MB --------------- (6% 100%) 
     /*
      *  easy - understanding
      */
    public bool ValidMountainArray_6(int[] A)
    {
        int p = 0; int q = -1;
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > A[i - 1])
            {
                continue;
            }
            else
            {
                p = i-1;
                break;
            }
        }

        for (int i = A.Length-1; i > 0; i--)
        {
            if (A[i] < A[i - 1])
            {
                continue;
            }
            else
            {
                q = i;
                break;
            }
        }

        return p == q;
    }
}
/**************************************************************************************************************
 * ValidMountainArray_2   ValidMountainArray_3   ValidMountainArray_4/5 ValidMountainArray_6                  *
 **************************************************************************************************************/
