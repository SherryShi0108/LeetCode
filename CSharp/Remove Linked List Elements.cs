//Source  : https://leetcode.com/problems/remove-linked-list-elements/
//Author  : Xinruo Shi
//Date    : 2019-10-06
//Language: C#

/*******************************************************************************************************************************
 * 
 * Remove all elements from a linked list of integers that have value val.
 *
 * Input:  1->2->6->3->4->5->6, val = 6
 * Output: 1->2->3->4->5
 * ※
 *******************************************************************************************************************************/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution203
{
    // --------------- O(n) 108ms --------------- O(1) 27.4MB --------------- (50% 20%)
    public ListNode RemoveElements_1(ListNode head, int val)
    {
        while (head != null && head.val == val)
        {
            head = head.next;
        }

        if (head == null)
        {
            return head;
        }

        ListNode temp = head;
        while (temp.next != null)
        {
            if (temp.next.val == val)
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

    // --------------- O(n) 104ms --------------- O(1) 27.5MB --------------- (75% 20%)
    /*
     * improve 1
     */
    public ListNode RemoveElements_2(ListNode head, int val)
    {
        if (head == null) return head;

        ListNode temp = head;
        while (temp!=null && temp.next!=null)
        {
            if (temp.next.val == val)
            {
                temp.next = temp.next.next;
            }
            else
            {
                temp = temp.next;
            }
                
        }
        return head.val == val ? head.next : head;
    }

    // --------------- O(n) 96ms --------------- O(1) 28.1MB --------------- (97% 20%) ※
    /*
     * using recursive
     */
    public ListNode RemoveElements_3(ListNode head, int val)
    {
        if (head == null) return null;
        head.next = RemoveElements_3(head.next, val);
        return head.val == val ? head.next : head;
    }
}
/**************************************************************************************************************
 * RemoveElements_2 RemoveElements_3                                                                          *
 **************************************************************************************************************/
