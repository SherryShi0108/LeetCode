//Source  : https://leetcode.com/problems/remove-duplicates-from-sorted-list/
//Author  : Xinruo Shi
//Date    : 2019-10-02
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a sorted linked list, delete all duplicates such that each element appear only once.
 *
 * Input: 1->1->2
 * Output: 1->2
 *
 * Input: 1->1->2->3->3
 * Output: 1->2->3
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
public class Solution83
{
    // --------------- O(n) 92ms --------------- O(1) 25.1MB --------------- (93% 17%) ※
    public ListNode DeleteDuplicates_1(ListNode head)
    {
        if (head == null)
        {
            return head;
        }

        ListNode temp = head;
        while (temp.next!=null)
        {
            if (temp.val == temp.next.val)
            {
                temp.next = temp.next.next;
            }
            else
            {
                temp = temp.next;
            }
        }

        return head;
    }

    // --------------- O(n) 96ms --------------- O(1) 25.2MB --------------- (78% 17%)
    /*
     * hard to understand
     */
    public ListNode DeleteDuplicates_2(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        head.next = DeleteDuplicates_2(head.next);
        return head.val == head.next.val ? head.next : head;
    }
}
/**************************************************************************************************************
 * DeleteDuplicates_1  DeleteDuplicates_2                                                                     *
 **************************************************************************************************************/