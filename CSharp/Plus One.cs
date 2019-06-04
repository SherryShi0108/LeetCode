//Source  : https://leetcode.com/problems/plus-one/
//Author  : Xinruo Shi
//Date    : 2019-05-30
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
 * The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.
 * 
 * You may assume the integer does not contain any leading zero, except the number 0 itself.
 * 
 * Input: nums = [1,2,3]
 * Output: [1,2,4]
 * 
 * Input: nums = [4,3,2,1]
 * Output: [4,3,2,2]
 * 
 *******************************************************************************************************************************/

using System; //Math名称空间

public class Solution66
{
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++
    /*
     *  if nums.length>10,int k overflow
     *  int:-2*10^9~2*10^9  uint:0-4*10^9
     */
    public int[] PlusOne_1(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int k = (int)Math.Pow(10, nums.Length-1-i);
            sum = sum+ nums[i] * k;
        }
        sum++;
        int z = sum;

        int temp = 0;
        while (sum!=0)
        {
            sum = sum / 10;
            temp++;
        }

        int[] a = new int[temp];
        for (int i = 0; i < temp; i++)
        {
            a[temp-1-i]= z % 10;
            z = z / 10;
        }
        return a;
    }
    ///+++++++++++++++++++++++++ Error +++++++++++++++++++++++++


    // --------------- O(n) 248ms --------------- 28.1MB ---------------
    public int[] PlusOne_2(int[] nums)
    {
        nums[nums.Length - 1]++;
        for (int i = nums.Length-1 ; i > 0; i--)
        {
            if (nums[i] > 9)
            {
                nums[i] = 0;
                nums[i - 1] = nums[i - 1] + 1;
            }
        }

        if (nums[0]>9)
        {
            int[] b = new int[nums.Length + 1];
            b[0] = 1;b[1] = 0;
            for (int i = 2 ; i < b.Length; i++)
            {
                b[i] = nums[i - 1];
            }
            return b;
        }

        return nums;
    }

    // --------------- O(n) 244ms --------------- 28.0MB ---------------
    public int[] PlusOne_3(int[] nums)
    {
        int len = nums.Length;
        for (int i = len - 1; i >= 0; i--)
        {
            if (nums[i] < 9)
            {
                nums[i]++;
                return nums;
            }
            nums[i] = 0;
        }

        if (nums[0] == 0)
        {
            int[] ret = new int[len + 1];
            ret[0] = 1;
            return ret;
        }

        return nums;
    }

    //--------------- O(n) 244ms --------------- 28.5MB ---------------
    public int[] PlusOne_4(int[] nums)
    {
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[i] < 9)
            {
                nums[i]++;
                break;
            }
            else
            {
                nums[i] = 0;
            }
        }
        if (nums[0] == 0)
        {
            int[] b = new int[nums.Length + 1];
            b[0] = 1;
            return b;
        }

        return nums;
    }
}
/**************************************************************************************************************
 * (PlusOne_2) PlusOne_3/4                                                                                    *
 **************************************************************************************************************/
 