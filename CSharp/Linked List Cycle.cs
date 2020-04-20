//Source  : https://leetcode.com/problems/linked-list-cycle/
//Author  : Xinruo Shi
//Date    : 2019-09-22
//Language: C#

/*******************************************************************************************************************************
 *
 * Given a linked list, determine if it has a cycle in it.
 * To represent a cycle in the given linked list, we use an integer pos which represents the position (0-indexed) in the
 * linked list where tail connects to. If pos is -1, then there is no cycle in the linked list.
 *
 * Input: head = [3,2,0,-4], pos = 1
 * Output: true
 * Explanation: There is a cycle in the linked list, where tail connects to the second node.
 *
 * Input: head = [1,2], pos = 0
 * Output: true
 * Explanation: There is a cycle in the linked list, where tail connects to the first node.
 *
 * Input: head = [1], pos = -1
 * Output: false
 * Explanation: There is no cycle in the linked list.
 *
 * Follow up : Can you solve it using O(1) (i.e. constant) memory?
 * 
 *******************************************************************************************************************************/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */

using System.Collections.Generic;

public class Solution141
{
    // --------------- O(n) 104ms --------------- O(n) 26.1MB --------------- (34% 7%) 
    /*
     * use HashSet : ListNode must has the same next and val !!!
     */
    public bool HasCycle_1(ListNode head)
    {
        HashSet<ListNode> h = new HashSet<ListNode>();
        ListNode temp = head;
        while (temp != null)
        {
            if (!h.Add(temp))
            {
                return true;
            }

            temp = temp.next;
        }

        return false;
    }

    // --------------- O(n) 104ms --------------- O(1) 25.1MB --------------- (34% 7%) 
    /*
     * use two points
     */
    public bool HasCycle_2(ListNode head)
    {
        if (head == null || head.next == null) return false;
        ListNode slow = head;
        ListNode fast = head.next;
        while (slow!=fast)
        {
            if (fast == null || fast.next == null)
            {
                return false;
            }

            slow = slow.next;
            fast = fast.next.next;
        }

        return true;
    }

    // --------------- O(n) 100ms --------------- O(1) 25.1MB --------------- (65% 7%) ※ 
    /*
     * improve 2
     */
    public bool HasCycle_2_2(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }
}

/**************************************************************************************************************
 * HasCycle_2 HasCycle_3                                                                                      *
 **************************************************************************************************************/
