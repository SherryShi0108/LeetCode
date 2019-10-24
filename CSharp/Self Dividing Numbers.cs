//Source  : https://leetcode.com/problems/self-dividing-numbers/
//Author  : Xinruo Shi
//Date    : 2019-09-14
//Language: C#

/*******************************************************************************************************************************
 * 
 * A self-dividing number is a number that is divisible by every digit it contains.
 * For example, 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0, and 128 % 8 == 0.
 * Also, a self-dividing number is not allowed to contain the digit zero.
 * Given a lower and upper number bound, output a list of every possible self dividing number, including the bounds if possible.
 * 
 * Input: left = 1, right = 22
 * Output: [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22]
 * 
 * Note: The boundaries of each input argument are 1 <= left <= right <= 10000.
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic; //IList命名空间

public class Solution728
{
    // --------------- 224ms --------------- 24.5MB --------------- (73% 50%)
    public IList<int> SelfDividingNumbers_1(int left, int right)
    {
        List<int> L = new List<int>();
        for (int i = left; i <= right; i++)
        {
            bool isSelfDividingNum = true;
            if (i > 9)
            {
                int temp = i;
                while (temp > 0)
                {
                    int k = temp % 10;
                    temp /= 10;

                    if (k == 0||i % k != 0 )
                    {
                        isSelfDividingNum = false;
                        break;
                    }
                }
            }

            if (isSelfDividingNum)
            {
                L.Add(i);
            }
        }

        return L;
    }

    // --------------- 224ms --------------- 27.4MB --------------- (73% 50%)
    public IList<int> SelfDividingNumbers_2(int left, int right)
    {
        List<int> L = new List<int>();
        for (int i = left; i <= right; i++)
        {
            bool isSelfDividingNum = true;
            foreach (char c in i.ToString().ToCharArray())
            {
                if (c == '0' || i % (c - '0') != 0)
                {
                    isSelfDividingNum = false;
                    break;
                }
            }

            if (isSelfDividingNum)
            {
                L.Add(i);
            }
        }

        return L;
    }

    // --------------- 208ms --------------- 24.6MB --------------- (97% 50%) ※
    /*
     * use 2 method
     */
    public IList<int> SelfDividingNumbers_3(int left, int right)
    {
        List<int> L = new List<int>();
        for (int i = left; i <= right; i++)
        {
            if (Helper(i))
            {
                L.Add(i);
            }
        }

        return L;
    }

    public bool Helper(int n)
    {
        for (int i = n; i >0; i/=10)
        {
            if (i % 10 == 0 || n % (i % 10) != 0)
            {
                return false;
            }
        }

        return true;
    }
}
/**************************************************************************************************************
 * SelfDividingNumbers_1 SelfDividingNumbers_2 SelfDividingNumbers_3                                          *
 **************************************************************************************************************/