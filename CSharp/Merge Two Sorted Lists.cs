//Source  : https://leetcode.com/problems/merge-two-sorted-lists/
//Author  : Xinruo Shi
//Date    : 2019-10-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
 *
 * Input: 1->2->4, 1->3->4
 * Output: 1->1->2->3->4->4
 * 
 *******************************************************************************************************************************/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

public class Solution21
{
    // --------------- O(n) 84ms --------------- O(n) 25MB --------------- (99.7% 6%) ※
    /*
     * using recursion , donnot understand
     */
    public ListNode MergeTwoLists_1(ListNode l1, ListNode l2)
    {
        if (l1 == null) return l2;
        if (l2 == null) return l1;

        if (l1.val < l2.val)
        {
            l1.next = MergeTwoLists_1(l1.next, l2);
            return l1;
        }
        else
        {
            l2.next = MergeTwoLists_1(l1, l2.next);
            return l2;
        }
    }

    // --------------- O(n) 112ms --------------- O(n) 25MB --------------- (8% 6%) 
    public ListNode MergeTwoLists_2(ListNode l1, ListNode l2)
    {
        ListNode start = new ListNode(-1);
        ListNode cur = start;
        ListNode temp1 = l1;
        ListNode temp2 = l2;

        while (temp1 != null && temp2 != null)
        {
            if (temp1.val <= temp2.val)
            {
                cur.next = temp1;
                temp1 = temp1.next;
            }
            else
            {
                cur.next = temp2;
                temp2 = temp2.next;
            }

            cur = cur.next;
        }

        if (temp1 != null)
        {
            cur.next = temp1;
        }

        if (temp2 != null)
        {
            cur.next = temp2;
        }

        return start.next;
    }
}
/**************************************************************************************************************
 * MergeTwoLists_1 MergeTwoLists_2                                                                            *
 **************************************************************************************************************/
