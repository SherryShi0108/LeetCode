//Source  : https://leetcode.com/problems/peak-index-in-a-mountain-array/
//Author  : Xinruo Shi
//Date    : 2019-12-11
//Language: C#

/*******************************************************************************************************************************
 * 
 * Let's call an array A a mountain if the following properties hold:
 *      A.length >= 3
 *      There exists some 0 < i < A.length - 1 such that A[0] < A[1] < ... A[i-1] < A[i] > A[i+1] > ... > A[A.length - 1]
 *
 * Given an array that is definitely a mountain, return any i such that A[0] < A[1] < ... A[i-1] < A[i] > A[i+1] > ... > A[A.length - 1].
 *
 * Input: [0,1,0]
 * Output: 1
 *
 * Input: [0,2,1,0]
 * Output: 1
 *
 * Note:
 *      3 <= A.length <= 10000
 *      0 <= A[i] <= 10^6
 *      A is a mountain, as defined above.
 * 
 *******************************************************************************************************************************/

public class Solution852
{
    // --------------- O(n) 100ms --------------- O(1) 25.9MB --------------- (75% 100%)
    public int PeakIndexInMountainArray_1(int[] A)
    {
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] < A[i - 1])
            {
                return i-1;
            }
        }

        return -1;
    }

    // --------------- O(n) 104ms --------------- O(1) 25.8MB --------------- (49% 100%)
    /*
     * improve 1
     */
    public int PeakIndexInMountainArray_2(int[] A)
    {
        int i = 0;
        while (A[i]<A[i+1])
        {
            i++;
        }

        return i;
    }

    // --------------- O(logn) 104ms --------------- O(1) 25.9MB --------------- (49% 100%) 
    /*
     * use binary search , faster than 1/2 because O(time) = O(logn)
     */
    public int PeakIndexInMountainArray_3(int[] A)
    {
        int left = 0;
        int right = A.Length - 1;
        while (left<right)
        {
            int mid = left + (right - left) / 2;
            if (A[mid] < A[mid + 1])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
    
    // --------------- O(logn) 104ms --------------- O(1) 26MB --------------- (49% 100%) ※
    public int PeakIndexInMountainArray_4(int[] A)
    {
        int i = 0;
        int j = A.Length;
        while (i<j)
        {
            int mid = i + (j - i) / 2;
            if (mid== A.Length-1 || A[mid] < A[mid+1])
            {
                i = mid+1;
            }
            else
            {
                j = mid;
            }
        }

        return i;
    }

    // --------------- O(n) 96ms --------------- O(1) 25.7MB --------------- (90% 100%)
    /*
     * find the max's index
     */
    public int PeakIndexInMountainArray_5(int[] A)
    {
        int index = 0;
        int max = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] > max)
            {
                max = A[i];
                index = i;
            }
        }

        return index;
    }
}
/**************************************************************************************************************
 * PeakIndexInMountainArray_2 PeakIndexInMountainArray_3 PeakIndexInMountainArray_4                           *
 **************************************************************************************************************/
