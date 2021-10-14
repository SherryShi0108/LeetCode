//Source  : https://leetcode.com/problems/remove-nth-node-from-end-of-list/
//Author  : Xinruo Shi
//Date    : 2021-06-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given the head of a linked list, remove the nth node from the end of the list and return its head.
 * Follow up: Could you do this in one pass?
 *
 * Input: head = [1,2,3,4,5], n = 2
 * Output: [1,2,3,5]
 *
 * Input: head = [1], n = 1
 * Output: []
 *
 * Input: head = [1,2], n = 1
 * Output: [1]
 *
 * Constraints:
 *      The number of nodes in the list is sz.
 *      1 <= sz <= 30
 *      0 <= Node.val <= 100
 *      1 <= n <= sz
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

public class Solution19
{
    // --------------- O(n) 124ms --------------- O(1) 26MB --------------- (8% 6%) ※
    /*
     * Two Pass
     */
    public ListNode RemoveNthFromEnd_1(ListNode head, int n)
    {
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        int length = 0;
        ListNode first = head;
        while (first != null)
        {
            length++;
            first = first.next;
        }

        length -= n;

        first = dummy;
        while (length > 0)
        {
            length--;
            first = first.next;
        }

        first.next = first.next.next;
        return dummy.next;
    }

    // --------------- O(n) 128ms --------------- O(1) 26MB --------------- (7% 5%) ※
    /*
     * One Pass
     */
    public ListNode RemoveNthFromEnd_2(ListNode head, int n)
    {
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode first = dummy;
        ListNode second = dummy;

        for (int i = 1; i <= n + 1; i++)
        {
            first = first.next;
        }

        while (first != null)
        {
            first = first.next;
            second = second.next;
        }

        second.next = second.next.next;
        return dummy.next;
    }
}


/**************************************************************************************************************
 *  RemoveNthFromEnd_1  RemoveNthFromEnd_2                                                                    *
 **************************************************************************************************************/
