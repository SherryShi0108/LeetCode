//Source  : https://leetcode.com/problems/add-two-numbers/
//Author  : Xinruo Shi
//Date    : 2021-12-01
//Language: C#

/*******************************************************************************************************************************
 * You are given two non-empty linked lists representing two non-negative integers. 
 * The digits are stored in reverse order, and each of their nodes contains a single digit. 
 * Add the two numbers and return the sum as a linked list.
 * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
 * 
 * Input: l1 = [2,4,3], l2 = [5,6,4]
 * Output: [7,0,8]
 * Explanation: 342 + 465 = 807.
 * 
 * Input: l1 = [0], l2 = [0]
 * Output: [0]
 * 
 * Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
 * Output: [8,9,9,9,0,0,0,1]
 * 
 * Constraints:
 *          The number of nodes in each linked list is in the range [1, 100].
 *          0 <= Node.val <= 9
 *          It is guaranteed that the list represents a number that does not have leading zeros.
 * 
 *******************************************************************************************************************************/


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}


public class Solution2
{
    // --------------- O(n) 96s --------------- O(n) 41MB --------------- (69% 31%) ※
    public ListNode AddTwoNumbers_1(ListNode l1, ListNode l2)
    {
        ListNode newHead = new ListNode();
        ListNode listNode1 = l1;
        ListNode listNode2 = l2;
        ListNode current = newHead;
        int temp = 0;
        while (listNode1 != null || listNode2 != null || temp != 0)
        {
            if (listNode1 != null)
            {
                temp += listNode1.val;
                listNode1 = listNode1.next;
            }
            if (listNode2 != null)
            {
                temp += listNode2.val;
                listNode2 = listNode2.next;
            }

            current.next = new ListNode(temp % 10);
            current = current.next;
            temp /= 10;
        }


        return newHead.next;
    }

    // --------------- O(n) 100s --------------- O(n) 41MB --------------- (53% 17%) 
    public ListNode AddTwoNumbers_1_2(ListNode l1, ListNode l2)
    {
        ListNode newHead = new ListNode();

        ListNode listNode1 = l1;
        ListNode listNode2 = l2;
        ListNode current = newHead;
        int temp = 0;
        while (listNode1 != null || listNode2 != null || temp > 0)
        {
            int x = listNode1 == null ? 0 : listNode1.val;
            int y = listNode2 == null ? 0 : listNode2.val;
            int sum = x + y + temp;
            temp = sum / 10;

            current.next = new ListNode(sum % 10);
            current = current.next;
            if (listNode1 != null) listNode1 = listNode1.next;
            if (listNode2 != null) listNode2 = listNode2.next;
        }

        return newHead.next;
    }
}

/**************************************************************************************************************
 *  AddTwoNumbers_1                                                                                           *
 *************************************************************************************************************/
