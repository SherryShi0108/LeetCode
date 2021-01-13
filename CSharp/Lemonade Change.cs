//Source  : https://leetcode.com/problems/lemonade-change/
//Author  : Xinruo Shi
//Date    : 2020-11-08
//Language: C#

/*******************************************************************************************************************************
 * 
 * At a lemonade stand, each lemonade costs $5. 
 * Customers are standing in a queue to buy from you, and order one at a time (in the order specified by bills).
 * Each customer will only buy one lemonade and pay with either a $5, $10, or $20 bill.  You must provide the correct change to each customer, so that the net transaction is that the customer pays $5.
 * Note that you don't have any change in hand at first.
 * Return true if and only if you can provide every customer with correct change.
 *
 * Input: [5,5,5,10,20]
 * Output: true
 * Explanation:
 *      From the first 3 customers, we collect three $5 bills in order.
 *      From the fourth customer, we collect a $10 bill and give back a $5.
 *      From the fifth customer, we give a $10 bill and a $5 bill.
 *      Since all customers got correct change, we output true.
 *
 * Input: [5,5,10]
 * Output: true
 *
 * Input: [10,10]
 * Output: false
 *
 * Input: [5,5,10,10,20]
 * Output: false
 * Explanation:
 *      From the first two customers in order, we collect two $5 bills.
 *      For the next two customers in order, we collect a $10 bill and give back a $5 bill.
 *      For the last customer, we can't give change of $15 back because we only have two $10 bills.
 *      Since not every customer received correct change, the answer is false.
 *
 * Note:
 *      0 <= bills.length <= 10000
 *      bills[i] will be either 5, 10, or 20.
 * 
 *******************************************************************************************************************************/


using System.Collections.Generic;

public class Solution860
{
    // --------------- O(n) 104ms --------------- 29MB --------------- (89% 38%) 
    /*
     *  Straight Forward
     */
    public bool LemonadeChange_1(int[] bills)
    {
        int[] temp = new int[2];

        foreach (int bill in bills)
        {
            if (bill == 5)
            {
                temp[0]++;
            }
            else if (bill == 10)
            {
                temp[1]++;
                temp[0]--;
            }
            else if (bill == 20)
            {
                if (temp[1] > 0)
                {
                    temp[1]--;
                    temp[0]--;
                }
                else
                {
                    temp[0] = temp[0] - 3;
                }
            }

            if (temp[0] < 0 || temp[1] < 0) return false;
        }

        return true;
    }

    // --------------- O(n) 108ms --------------- 29MB --------------- (67% 57%) ※
    /*
     *  use int*2 instead int[]
     */
    public bool LemonadeChange_1_2(int[] bills)
    {
        int five = 0;
        int ten = 0;

        foreach (int bill in bills)
        {
            if (bill == 5)
            {
                five++;
            }
            else if (bill == 10)
            {
                five--;
                ten++;
            }
            else 
            {
                if (ten > 0)
                {
                    ten--;
                    five--;
                }
                else
                {
                    five -= 3;
                }
            }

            if (five < 0 || ten < 0) return false;
        }

        return true;
    }
}
/**************************************************************************************************************
 * LemonadeChange_1                                                                                           *
 **************************************************************************************************************/