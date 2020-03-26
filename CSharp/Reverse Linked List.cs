//Source  : https://leetcode.com/problems/reverse-linked-list/
//Author  : Xinruo Shi
//Date    : 2019-10-07
//Language: C#

/*******************************************************************************************************************************
 * 
 * Reverse a singly linked list.
 *
 * Input: 1->2->3->4->5->NULL
 * Output: 5->4->3->2->1->NULL
 *
 * Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?
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
public class Solution206
{
    // --------------- O(n) 96ms --------------- O(1) 23.7MB --------------- (60% 8%)
    /*
     * using Iterative
     */
    public ListNode ReverseList_1(ListNode head)
    {
        ListNode prew = null;
        ListNode curr = head;
        while (curr!=null)
        {
            ListNode temp = curr.next;
            curr.next = prew;
            prew = curr;
            curr = temp;
        }

        return prew;
    }

    // --------------- O(n) 96ms --------------- O(n) 23.9MB --------------- (60% 8%)
    /*
     *  using Recursive , hard to understand
     */
    public ListNode ReverseList_2(ListNode head)
    {
        return ReverseListInt(head, null);
    }

    private ListNode ReverseListInt(ListNode head, ListNode newHead)
    {
        if (head == null) return newHead;

        ListNode next = head.next;
        head.next = newHead;
        return ReverseListInt(next, head);
    }
    
    // --------------- 80ms --------------- 24.5MB --------------- (99% 8%) ※
    /*
     *  easy-understanding
     */
    public ListNode ReverseList_3(ListNode head)
    {
        if (head == null) return head;

        ListNode newHead = head;
        while (head.next!=null)
        {
            ListNode current = head.next;
            head.next = head.next.next;
            current.next = newHead;
            newHead = current;
        }

        return newHead;
    }
}
/**************************************************************************************************************
 * ReverseList_1 ReverseList_2 ReverseList_3                                                                  *
 **************************************************************************************************************/
