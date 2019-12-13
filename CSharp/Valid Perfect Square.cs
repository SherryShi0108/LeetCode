//Source  : https://leetcode.com/problems/valid-perfect-square/
//Author  : Xinruo Shi
//Date    : 2019-09-09
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a positive integer num, write a function which returns True if num is a perfect square else False.
 * 
 * Note: Do not use any built-in library function such as sqrt.
 * 
 * Input: 16
 * Output: true
 * 
 * Input: 14
 * Output: false
 * 
 *******************************************************************************************************************************/

public class Solution367
{
    // --------------- O(n^0.5) 40ms --------------- 12.7MB --------------- (81% 100%)
    /*
     * Math : 1=1 , 4=1+3 , 9=1+3+5 , 16=1+3+5+7 , 25=1+3+5+7+9 ... 
     */
    public bool IsPerfectSquare_1(int num)
    {
        int i = 1;
        while (num > 0)
        {
            num -= i;
            i += 2;
        }

        return num == 0;
    }

   // --------------- O(logn) 40ms --------------- 14MB --------------- (74% 25%) ※
    /*
     * attention: num/mid , so mid != 0 , so i && j !=0
     */
    public bool IsPerfectSquare_2(int num)
    {
        int i = 1;
        int j = num;
        while (i<=j)
        {
            int mid = i + (j - i) / 2;
            if (mid == num / mid )
            {
                if (num % mid == 0){return true;}
                else
                {
                    j = mid - 1;
                }
            }
            else if (mid > num / mid)
            {
                j = mid - 1;
            }
            else if (mid < num / mid)
            {
                i = mid + 1;
            }
        }

        return false;
    }

    // use Newton Method
    public bool IsPerfectSquare_3(int num)
    {

        return false;
    }
}
/**************************************************************************************************************
 * IsPerfectSquare_1 IsPerfectSquare_2 IsPerfectSquare_3                                                      *
 **************************************************************************************************************/
